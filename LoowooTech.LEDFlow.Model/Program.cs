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
                    sb.Append("[" + (i + 1) + "] ");
                    sb.Append(msg.Content);
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

        public DateTime? UpdateTime { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public DateTime? PlayTime { get; set; }


        /// <summary>
        /// 已播放次数
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public int HasPlayedTimes
        {
            get
            {
                if (PlayTime == null) return 0;
                return (int)((DateTime.Now - PlayTime.Value).TotalSeconds / Duration) + 1;
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        public int Duration
        {
            get
            {
                var result = 0;
                foreach (var msg in Messages)
                {
                    result += msg.Duration;
                }
                return result;
            }
        }

        public bool Deleted { get; set; }
    }
}
