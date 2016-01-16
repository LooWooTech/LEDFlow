using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Model
{
    [Serializable]
    public class TextStyle
    {
        public FontFamily FontFamily { get; set; }

        public int FontSize { get; set; }

        private bool _isHold;
        /// <summary>
        /// 是否暂停一会
        /// </summary>
        public bool IsHold
        {
            get
            {
                if (TextAnimation == Model.TextAnimation.连续左移)
                {
                    return false;
                }
                return _isHold;
            }
            set { _isHold = value; }
        }

        public TextAlignment TextAlignment { get; set; }

        public TextAnimation TextAnimation { get; set; }
    }

    public enum FontFamily
    {
        宋体 = 1,
        黑体,
        楷体
    }

    public enum TextAlignment
    {
        左 = 16,
        中 = 32,
        右 = 64
    }

    public enum TextAnimation
    {
        立即显示 = 1,
        左移 = 2,
        连续左移 = 3,
        右移 = 4,
        上移 = 5,
        下移 = 7
    }
}
