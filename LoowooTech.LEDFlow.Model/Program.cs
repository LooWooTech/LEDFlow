using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    public class Program
    {
        public int ID { get; set; }

        public string ClientID { get; set; }

        public string Content { get; set; }

        public DateTime? StartDay { get; set; }

        public TimeSpan? StartTime { get; set; }

        public int PlayTimes { get; set; }

        public TextStyle Style { get; set; }
    }
}
