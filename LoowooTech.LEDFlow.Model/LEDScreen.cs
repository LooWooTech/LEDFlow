using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    [Serializable]
    public class LEDScreen
    {
        public LEDScreen()
        {
            Style = new TextStyle { FontSize = 12, FontFamily = FontFamily.宋体 };
            VirtualID = -1;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        private TextStyle _defaultStyle;
        public TextStyle Style
        {
            get
            {
                return CustomStyle == null ? _defaultStyle : CustomStyle;
            }
            set
            {
                _defaultStyle = value;
            }
        }

        public TextStyle CustomStyle { get; set; }

        public string[] Clients { get; set; }

        /// <summary>
        /// 虚拟窗口的ID
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public int VirtualID { get; set; }

        /// <summary>
        /// 当前正在播放的节目
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public Program CurrentProgram { get; set; }
    }
}
