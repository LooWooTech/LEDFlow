using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    [Serializable]
    public class Message
    {
        public Message()
        {
            CreateTime = DateTime.Now;
        }

        public int ID { get; set; }

        public string Content { get; set; }

        public int Duration { get; set; }

        public DateTime CreateTime { get; set; }

        public bool Deleted { get; set; }
    }
}
