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

        public static void OpenLED(LEDScreen led)
        {
            LEDAdapter.Open(led.ID);
        }

        public static void PlaySchedule(Schedule schedule, TextStyle style = null)
        {
            var program = ProgramManager.GetModel(schedule.ProgramID);
            foreach (var id in schedule.LedIds)
            {
                var ledId = int.Parse(id);
                var led = LEDManager.GetModel(ledId);
                if (led.VirtualID == -1)
                {
                    led.VirtualID = LEDAdapter.CreateWindow(0, 0, led.Width, led.Height, led.ID);
                }

                if (style == null)
                {
                    style = led.DefaultStyle;
                }
                foreach (var msg in program.Messages)
                {
                    LEDAdapter.SendContent(msg.Content, (int)style.TextAnimation, msg.Duration / 10, led.VirtualID);
                }
            }

            PlayLogManager.Add(new PlayLog
            {
                Content = program.Content,
                PlayTime = schedule.BeginTime,
                EndTime = schedule.EndTime,
                LedIds = schedule.LedIds
            });
        }

        public void SendProgram(int ledId, string clientId, Program program, TextStyle style = null)
        {
            //客户端发送的节目
            if (program.ID == 0 && !string.IsNullOrEmpty(clientId))
            {
                ProgramManager.Save(program);
            }
            var schedule = new Schedule
            {
                LedIds = new string[] { ledId.ToString() },
                BeginTime = DateTime.Now,
                PlayTimes = 1,
                PlayMode = PlayMode.立即开始,
                ProgramID = program.ID,
            };
            ScheduleManager.Save(schedule);
            PlaySchedule(schedule, style);
        }

        public Program GetCurrentProgram(int ledId)
        {
            return ScheduleManager.GetCurrentProgram(ledId);
        }
    }
}
