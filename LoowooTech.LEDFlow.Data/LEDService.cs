using LoowooTech.LEDFlow.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace LoowooTech.LEDFlow.Data
{
    public class LEDService : MarshalByRefObject
    {
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

        public void SendProgram(int ledId, Program program, TextStyle style = null)
        {
            //客户端发送的节目
            if (program.ID == 0 && !string.IsNullOrEmpty(program.ClientID))
            {
                ProgramManager.Save(program);
            }
            //客户端发送的节目默认为无限次播放，没有截至时间
            var schedule = new Schedule
            {
                LEDIDs = new int[] { ledId },
                BeginTime = DateTime.Now,
                PlayMode = PlayMode.立即开始,
                ProgramID = program.ID,
            };
            ScheduleManager.Save(schedule);

            if (style != null)
            {
                var led = LEDManager.GetModel(ledId);
                led.CustomStyle = style;
                LEDManager.Save(led);
            }
        }

        public Program GetCurrentProgram(int ledId)
        {
            var led = LEDManager.GetModel(ledId);
            return led.CurrentProgram;
        }
    }
}
