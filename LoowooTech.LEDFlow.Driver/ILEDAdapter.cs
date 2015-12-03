﻿using System;
using System.Collections.Generic;
using System.Drawing;

using System.Text;

namespace LoowooTech.LEDFlow.Driver
{
    /// <summary>
    /// 显示屏控制接口类
    /// </summary>
    public interface ILEDAdapter
    {
        /// <summary>
        /// 打开一块LED屏幕，做初始化操作
        /// </summary>
        /// <param name="ledIndex">屏幕的序号，从1开始</param>
        /// <returns></returns>
        bool Open(int ledIndex, int width, int height);

        /// <summary>
        /// 关闭LED屏
        /// </summary>
        /// <param name="ledIndex">屏幕的序号，从1开始</param>
        void Close(int ledIndex);

        /// <summary>
        /// 设置某个窗口的文字显示方式，包括字体，对齐等
        /// </summary>
        /// <param name="font">字体，包括字体名、大小、是否加粗，是否倾斜，是否下划线</param>
        /// <param name="alignment">对齐方式</param>
        /// <param name="rowSpace">行间距</param>
        /// <param name="ledId">虚拟窗口id</param>
        void SetFont(Font font, ContentAlignment alignment, int rowSpace, int ledId);

        /// <summary>
        /// 在虚拟窗口中显示文字
        /// </summary>
        /// <param name="content">文字内容</param>
        /// <param name="animationType">动画类型，0-50，常用值1（立即显示文字，没有动画）</param>
        /// <param name="holdTime">文字显示时间，时间到后被擦除，单位0.1秒</param>
        /// <param name="ledId">虚拟窗口id</param>
        void SendContent(string content, int animationType, int holdTime, int ledId);

    }
}
