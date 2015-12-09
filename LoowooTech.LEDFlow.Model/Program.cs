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

        [Newtonsoft.Json.JsonIgnore]
        public string Content
        {
            get
            {
                var sb = new StringBuilder();
                for (var i = 0; i < Messages.Count; i++)
                {
                    var msg = Messages[i];
                    sb.Append("【" + (i + 1) + "】");
                    sb.Append(msg.Content);
                    sb.Append("  （" + msg.Duration + "s）");
                    if (i + 1 < Messages.Count)
                    {
                        sb.Append("\r\n");
                    }
                }
                return sb.ToString();
            }
        }

        public string ClientID { get; set; }

        public List<Message> Messages { get; set; }

        public DateTime CreateTime { get; set; }

        public bool Deleted { get; set; }

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

    [Serializable]
    public class Message
    {
        public string Content { get; set; }

        public int Duration { get; set; }
    }
}
