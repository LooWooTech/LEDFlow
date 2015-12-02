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
        左上 = 1,
        上 = 2,
        右上 = 4,

        左 = 16,
        中 = 32,
        右 = 64,

        左下 = 128,
        下 = 512,
        右下 = 1024
    }

    public enum TextAnimation
    {
        从右到左 = 1,
        从左到右,
        从上到下,
        从下到上
    }
}
