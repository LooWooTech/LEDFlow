using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    public class Schedule
    {
        public Schedule()
        {
            CreateTime = DateTime.Now;
        }

        public int ID { get; set; }

        public int ProgramID { get; set; }
        /// <summary>
        /// 播放方式
        /// </summary>
        public PlayMode PlayMode { get; set; }

        private DateTime _beginTime;
        /// <summary>
        /// 播放时间（如果是定点轮播，则忽略日期部分，只关注小时和分钟）
        /// </summary>
        public DateTime BeginTime
        {
            get
            {
                return _beginTime;
            }
            set
            {
                if (PlayMode == Model.PlayMode.定点轮播)
                {
                    _beginTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, value.Hour, value.Minute, 0);
                }
                else
                {
                    _beginTime = value;
                }
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 播放次数，0为无限循环
        /// </summary>
        public int PlayTimes { get; set; }

        public int[] LEDIDs { get; set; }

        public DateTime CreateTime { get; set; }
    }



    public enum PlayMode
    {
        立即开始,
        定点轮播,
        定点开始,
    }

}
