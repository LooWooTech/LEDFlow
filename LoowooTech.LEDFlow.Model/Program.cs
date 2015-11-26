using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    public class Program
    {
        public int ID { get; set; }

        /// <summary>
        /// 客户端ID
        /// </summary>
        public string ClientID { get; set; }

        public string Content { get; set; }
        /// <summary>
        /// 播放时间（轮播则只获取小时和分钟，定点则获取日期全部）
        /// </summary>
        public DateTime? PlayTime { get; set; }

        /// <summary>
        /// 播放次数
        /// </summary>
        public int PlayTimes { get; set; }

        public TextStyle Style { get; set; }

        /// <summary>
        /// 播放方式
        /// </summary>
        public PlayMode PlayMode { get; set; }
    }

    public enum PlayMode
    { 
        立即开始,
        定点轮播,
        定点开始,
    }
}
