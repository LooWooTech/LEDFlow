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

        //public static void OpenLED(LEDScreen led)
        //{
        //    LEDAdapter.Open(led.ID);
        //}

        //public static void AutoPlay()
        //{
        //    var leds = LEDManager.GetList();
        //    foreach (var led in leds)
        //    {
        //        if (led == null)
        //        {
        //            return;
        //        }
        //        if (led.VirtualID == -1)
        //        {
        //            led.VirtualID = LEDAdapter.CreateWindow(0, 0, led.Width, led.Height, led.ID);
        //            LEDAdapter.SetFont(new Font(led.Style.FontFamily.ToString(), led.Style.FontSize), (ContentAlignment)led.Style.TextAlignment, 0, led.VirtualID);
        //        }
        //        var program = ScheduleManager.GetCurrentProgram(led.ID);
        //        if (program != null)
        //        {
        //            foreach (var msg in program.Messages)
        //            {
        //                LEDAdapter.SendContent(msg.Content, (int)led.Style.TextAnimation, msg.Duration, led.VirtualID);
        //            }
        //        }
        //    }
        //}

        //public static void PlaySchedule(Schedule schedule, TextStyle style = null)
        //{
        //    var program = ProgramManager.GetModel(schedule.ProgramID);
        //    foreach (var LEDID in schedule.LEDIDs)
        //    {
        //        var led = LEDManager.GetModel(LEDID);
        //        if (led.VirtualID == -1)
        //        {
        //            led.VirtualID = LEDAdapter.CreateWindow(0, 0, led.Width, led.Height, led.ID);
        //        }

        //        if (style == null)
        //        {
        //            style = led.Style;
        //        }
        //        foreach (var msg in program.Messages)
        //        {
        //            LEDAdapter.SendContent(msg.Content, (int)style.TextAnimation, msg.Duration / 10, led.VirtualID);
        //        }
        //    }
        //}

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
                var led= LEDManager.GetModel(ledId);
                led.CustomStyle = style;
                LEDManager.Save(led);
            }
        }

        public Program GetCurrentProgram(int ledId)
        {
            var led = LEDManager.GetModel(ledId);
            return ScheduleManager.GetCurrentProgram(led);
        }
    }
}
