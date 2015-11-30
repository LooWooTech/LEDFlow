using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    public class PlayLog
    {
        public PlayLog()
        {
            CreateTime = DateTime.Now;
        }

        public int ID { get; set; }

        public int LEDID { get; set; }

        public int ProgramID { get; set; }

        public string ClientID { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
