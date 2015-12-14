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
            Interval = StringHelper.ToInt(System.Configuration.ConfigurationManager.AppSettings["Interval"], 15);
        }

        public static readonly AutoPlayService Instance = new AutoPlayService();

        private Driver.LEDAdapter LEDAdapter = Driver.LEDAdapter.Instance;

        private static Dictionary<int, Thread> _threadPool = new Dictionary<int, Thread>();

        private static int Interval = 30;

        private static object lockObj = new object();

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

                _threadPool.Add(led.ID, new Thread(() =>
                {
                    while (true)
                    {
                        Play(led);
                        Thread.Sleep(1000 * Interval);
                    }
                }));
                _threadPool[led.ID].Start();
            }
        }

        private void Play(LEDScreen led)
        {
            var program = ScheduleManager.GetCurrentProgram(led);

            if (program != null)
            {
                program.PlayTime = DateTime.Now;
                foreach (var msg in program.Messages)
                {
                    LEDAdapter.SendContent(msg.Content, (int)led.Style.TextAnimation, msg.Duration * 10, led.VirtualID);
                }
            }
        }

        /// <summary>
        /// 动态移除一个LED
        /// </summary>
        public void RemoveLED(LEDScreen led)
        {
            lock (lockObj)
            {
                if (_threadPool.ContainsKey(led.ID))
                {
                    _threadPool[led.ID].Abort();
                    _threadPool[led.ID] = null;
                    _threadPool.Remove(led.ID);
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
                foreach (var kv in _threadPool)
                {
                    var thread = _threadPool[kv.Key];
                    if (thread != null)
                    {
                        thread.Abort();
                        thread = null;
                    }
                }
                _threadPool.Clear();
            }
        }
    }
}
