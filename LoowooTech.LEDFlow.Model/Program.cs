using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    [Serializable]
    public class Program
    {
        public Program()
        {
            Messages = new List<Message>();
            CreateTime = DateTime.Now;
        }

        public int ID { get; set; }

        /// <summary>
        /// 客户端ID
        /// </summary>
        public string ClientID { get; set; }

        public List<Message> Messages { get; set; }

        public DateTime CreateTime { get; set; }

        public bool Deleted { get; set; }

        //public TextStyle Style { get; set; }

        public int GetPlayDuration(int playTimes)
        {
            var result = 0;
            foreach (var msg in Messages)
            {
                result += msg.Duration;
            }
            return result * playTimes;
        }
    }

    public class Message
    {
        public string Content { get; set; }

        public int Duration { get; set; }
    }
}
