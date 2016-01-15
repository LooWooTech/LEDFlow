using LoowooTech.LEDFlow.Common;
using LoowooTech.LEDFlow.Data;
using LoowooTech.LEDFlow.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace LoowooTech.LEDFlow.Server
{
    public class AutoPlayService
    {
        private AutoPlayService()
        {
        }

        public static readonly AutoPlayService Instance = new AutoPlayService();

        private Driver.LEDAdapter LEDAdapter = Driver.LEDAdapter.Instance;

        private static readonly Dictionary<int, Thread> LEDThreadPool = new Dictionary<int, Thread>();

        private static object lockObj = new object();
        private int GetAnimationSpeed()
        {
            return StringHelper.ToInt(System.Configuration.ConfigurationManager.AppSettings["AnimationSpeed"], 5);
        }

        private int GetFrameTime()
        {
            return StringHelper.ToInt(System.Configuration.ConfigurationManager.AppSettings["FrameTime"], 20);
        }

        private int GetHoldTime()
        {
            return StringHelper.ToInt(System.Configuration.ConfigurationManager.AppSettings["HoldTime"], 5);
        }

        private int GetInterval()
        {
            return StringHelper.ToInt(System.Configuration.ConfigurationManager.AppSettings["Interval"], 10);
        }


        public void Start()
        {
            var list = LEDManager.GetList();
            foreach (var item in list)
            {
                AddLED(item);
            }
        }

        private void OpenLED(LEDScreen led)
        {
            LEDAdapter.Open(led.ID);
            if (led.VirtualID == -1)
            {
                led.VirtualID = LEDAdapter.CreateWindow(0, 0, led.Width, led.Height, led.ID);
                LEDAdapter.SetFont(new Font(led.Style.FontFamily.ToString(), led.Style.FontSize), (ContentAlignment)led.Style.TextAlignment, 1, led.VirtualID);
            }
        }

        /// <summary>
        /// 动态添加一个LED，增加其节目播放
        /// </summary>
        public void AddLED(LEDScreen led)
        {
            lock (lockObj)
            {
                RemoveLED(led);
                OpenLED(led);

                LEDThreadPool.Add(led.ID, new Thread(() =>
                {
                    while (true)
                    {
                        Play(led);
                        Thread.Sleep(1000 * GetInterval());
                    }
                }));
                LEDThreadPool[led.ID].Start();
            }
        }

        private void Play(LEDScreen led)
        {
            var program = ScheduleManager.GetCurrentProgram(led);

            if (program != null)
            {
                program.PlayTime = DateTime.Now;
                var holdTime = 0;
                switch (led.Style.TextAnimation)
                {
                    case TextAnimation.上移:
                    case TextAnimation.下移:
                    case TextAnimation.立即显示:
                    case TextAnimation.连续上移:
                        holdTime = GetHoldTime() * 10;
                        break;
                }
                var sendContents = new List<string>();
                foreach (var msg in program.Messages)
                {
                    sendContents.Add(msg.Content);
                }
                LEDAdapter.SendContent(sendContents, (int)led.Style.TextAnimation, GetAnimationSpeed(), GetFrameTime(), holdTime, led.VirtualID);
            }
        }

        /// <summary>
        /// 动态移除一个LED
        /// </summary>
        public void RemoveLED(LEDScreen led)
        {
            lock (lockObj)
            {
                if (LEDThreadPool.ContainsKey(led.ID))
                {
                    LEDThreadPool[led.ID].Abort();
                    LEDThreadPool[led.ID] = null;
                    LEDThreadPool.Remove(led.ID);
                }
            }
        }

        /// <summary>
        /// 动态更新一个LED
        /// </summary>
        public void UpdateLED(LEDScreen led)
        {
            AddLED(led);
        }

        public void Stop()
        {
            lock (lockObj)
            {
                foreach (var kv in LEDThreadPool)
                {
                    var thread = LEDThreadPool[kv.Key];
                    if (thread != null)
                    {
                        thread.Abort();
                        thread = null;
                    }
                }

                LEDThreadPool.Clear();
            }
        }
    }
}
