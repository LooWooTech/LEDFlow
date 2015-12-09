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
            LEDAdapter.Init(led.ID, led.Width, led.Height);
        }

        //public static void PlayAllLED()
        //{
        //    var list = DataManager.Instance.GetList<LEDScreen>();
        //    foreach (var led in list)
        //    {
        //        LEDService.PlayLED(led.ID);
        //    }
        //}

        //public static void PlayLED(int ledId, TextStyle style = null)
        //{
        //    var led = LEDManager.GetModel(ledId);
        //    if (led == null)
        //    {
        //        return;
        //    }
        //    if (style == null)
        //    {
        //        style = led.DefaultStyle;
        //    }
        //    var program = ScheduleManager.GetCurrentProgram(ledId);
        //    if (program != null)
        //    {
        //        foreach (var msg in program.Messages)
        //        {
        //            LEDAdapter.SendContent(msg.Content, (int)style.TextAnimation, msg.Duration / 10, ledId);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("没有找到可以播放的节目");
        //    }
        //}

        public static void PlaySchedule(Schedule schedule, TextStyle style = null)
        {
            var program = ProgramManager.GetModel(schedule.ProgramID);
            var ledList = LEDManager.GetList();
            foreach (var id in schedule.LedIds)
            {
                var ledId = int.Parse(id);
                if(style == null)
                {
                    var led = ledList.Find(delegate(LEDScreen e) { return e.ID == ledId; });
                    style = led.DefaultStyle;
                }
                foreach (var msg in program.Messages)
                {
                    LEDAdapter.SendContent(msg.Content, (int)style.TextAnimation, msg.Duration / 10, ledId);
                }
            }
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
            PlayLogManager.Add(new PlayLog
            {
                ClientId = clientId,
                Content = program.Content,
                PlayTime = schedule.BeginTime,
            });
        }

        public Program GetCurrentProgram(int ledId)
        {
            return ScheduleManager.GetCurrentProgram(ledId);
        }
    }
}
