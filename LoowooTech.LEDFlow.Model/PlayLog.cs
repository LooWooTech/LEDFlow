using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    public class PlayLog
    {
        public int ID { get; set; }

        public string Content { get; set; }

        public string ClientId { get; set; }

        public DateTime PlayTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
