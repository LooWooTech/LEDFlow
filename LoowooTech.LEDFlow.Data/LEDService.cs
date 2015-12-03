using LoowooTech.LEDFlow.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Data
{
    public class LEDService : MarshalByRefObject
    {
        private static readonly LEDFlow.Driver.LEDAdapter LEDAdapter = new Driver.LEDAdapter();

        public List<LEDScreen> GetLEDs(string client)
        {
            var result = new List<LEDScreen>();
            var list = LEDManager.GetList();
            foreach (var item in list)
            {
                if (item.Clients == null) continue;
                foreach (var c in item.Clients)
                {
                    if (c == client)
                    {
                        result.Add(item);
                        break;
                    }
                }
            }
            return result;
        }

        public void PlayProgram(int ledId, TextStyle style = null)
        {
            var led = LEDManager.GetModel(ledId);
            if (led == null)
            {
                return;
            }
            if (style == null)
            {
                style = led.DefaultStyle;
            }
            var program = ScheduleManager.GetCurrentProgram(ledId);
            if (program != null)
            {
                var windowId = LEDAdapter.CreateWindow(0, 0, led.Width, led.Height, led.ID);
                foreach (var msg in program.Messages)
                {
                    LEDAdapter.SendContent(msg.Content, (int)style.TextAnimation, msg.Duration, windowId);
                }
            }
        }

        public void SendProgram(int ledId, Program program, TextStyle style = null)
        {
            //客户端发送的节目
            if (program.ID == 0 && !string.IsNullOrEmpty(program.ClientID))
            {
                ProgramManager.Save(program);
            }
            var schedule = new Schedule
            {
                LedIds = new string[] { ledId.ToString() },
                BeginTime = DateTime.Now,
                PlayTimes = 1,
                EndTime = DateTime.Now.AddSeconds(program.GetPlayDuration(1)),
                PlayMode = PlayMode.立即开始,
                ProgramID = program.ID,
            };
            ScheduleManager.Save(schedule);
        }
    }
}
