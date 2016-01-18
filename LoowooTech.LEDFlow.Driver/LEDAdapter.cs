﻿using EQ2008_DataStruct;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Text;

namespace LoowooTech.LEDFlow.Driver
{
    /// <summary>
    /// LED适配类，将Led的Api转换为更简单的接口
    /// </summary>
    public class LEDAdapter : ILEDAdapter
    {
        private LEDAdapter()
        { }

        public static readonly LEDAdapter Instance = new LEDAdapter();

        private readonly Dictionary<int, Window> windows = new Dictionary<int, Window>();

        private readonly object syncRoot = new object();

        /// <summary>
        /// 打开一块LED屏幕，做初始化操作
        /// 注意：非线程安全
        /// </summary>
        /// <param name="ledIndex">屏幕的序号，从1开始</param>
        /// <returns></returns>
        public bool Open(int ledIndex)
        {
            return LedAPI.User_OpenScreen(ledIndex);
        }

        /// <summary>
        /// 关闭LED屏
        /// 注意：非线程安全
        /// </summary>
        /// <param name="ledIndex">屏幕的序号，从1开始</param>
        public void Close(int ledIndex)
        {
            LedAPI.User_DelAllProgram(ledIndex);
            LedAPI.User_CloseScreen(ledIndex);
        }

        /// <summary>
        /// 在屏幕上创建一个虚拟窗口
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="ledIndex">屏幕的序号，从1开始</param>
        /// <returns>返回虚拟窗口id，小于0表示创建失败</returns>
        public int CreateWindow(int x, int y, int width, int height, int ledIndex)
        {
            lock (syncRoot)
            {
                var win = Window.CreateWindow(ledIndex, x, y, height, width);
                windows.Add(win.Id, win);
                return win.Id;
            }
        }

        private static bool Overlap(int x, int y, int width, int height, User_PartInfo partInfo)
        {
            var minx = Math.Max(x, partInfo.iX);
            var miny = Math.Max(y, partInfo.iY);
            var maxx = Math.Min(x + width - 1, partInfo.iX + partInfo.iWidth - 1);
            var maxy = Math.Min(y + height - 1, partInfo.iY + partInfo.iHeight - 1);
            return !(minx > maxx || miny > maxy);
        }

        /// <summary>
        /// 在屏幕上删除一个已经建立的虚拟窗口
        /// </summary>
        /// <param name="windowId">虚拟窗口id</param>
        public void RemoveWindow(int windowId)
        {
            lock (syncRoot)
            {
                if (windows.ContainsKey(windowId))
                {
                    windows.Remove(windowId);
                }
                else
                {
                    throw new KeyNotFoundException(string.Format("不存在窗口：{0}", windowId));
                }
            }

        }

        /// <summary>
        /// 删除屏幕上所有窗口
        /// </summary>
        public void RemoveAllWindows()
        {
            lock (syncRoot)
            {
                windows.Clear();
            }
        }

        /// <summary>
        /// 设置某个窗口的文字显示方式，包括字体，对齐等
        /// </summary>
        /// <param name="font">字体，包括字体名、大小、是否加粗，是否倾斜，是否下划线</param>
        /// <param name="alignment">对齐方式</param>
        /// <param name="rowSpace">行间距</param>
        /// <param name="windowId">虚拟窗口id</param>
        public void SetFont(Font font, ContentAlignment alignment, int rowSpace, int windowId)
        {
            lock (syncRoot)
            {
                if (windows.ContainsKey(windowId))
                {
                    var win = windows[windowId];
                    var f = win.Font;
                    f.strFontName = font.FontFamily.Name;
                    f.bFontBold = font.Bold;
                    f.bFontItaic = font.Italic;
                    f.bFontUnderline = font.Underline;
                    f.iFontSize = (int)font.SizeInPoints;
                    f.iRowSpace = rowSpace;
                    f.colorFont = 0xffffff;
                    switch (alignment)
                    {
                        case ContentAlignment.TopLeft:
                            f.iAlignStyle = 0;
                            f.iVAlignerStyle = 0;
                            break;
                        case ContentAlignment.TopCenter:
                            f.iAlignStyle = 1;
                            f.iVAlignerStyle = 0;
                            break;
                        case ContentAlignment.TopRight:
                            f.iAlignStyle = 2;
                            f.iVAlignerStyle = 0;
                            break;
                        case ContentAlignment.MiddleLeft:
                            f.iAlignStyle = 0;
                            f.iVAlignerStyle = 1;
                            break;
                        case ContentAlignment.MiddleCenter:
                            f.iAlignStyle = 1;
                            f.iVAlignerStyle = 1;
                            break;
                        case ContentAlignment.MiddleRight:
                            f.iAlignStyle = 2;
                            f.iVAlignerStyle = 1;
                            break;
                        case ContentAlignment.BottomLeft:
                            f.iAlignStyle = 0;
                            f.iVAlignerStyle = 2;
                            break;
                        case ContentAlignment.BottomCenter:
                            f.iAlignStyle = 1;
                            f.iVAlignerStyle = 2;
                            break;
                        case ContentAlignment.BottomRight:
                            f.iAlignStyle = 2;
                            f.iVAlignerStyle = 2;
                            break;
                    }
                    win.Font = f;
                }
                else
                {
                    throw new KeyNotFoundException(string.Format("不存在窗口：{0}", windowId));
                }
            }
        }

        /// <summary>
        /// 在虚拟窗口中显示文字
        /// </summary>
        /// <param name="content">文字内容</param>
        /// <param name="animationType">动画类型，0-50，常用值1（立即显示文字，没有动画）</param>
        /// <param name="holdTime">文字显示时间，时间到后被擦除，单位0.1秒</param>
        /// <param name="animationSpeed">动画速度，1(最快)-20（最慢)</param>
        /// <param name="frameTime">动画速度2, 20(最快)-200(最慢)</param>
        /// <param name="windowId">虚拟窗口id</param>
        public void SendContent(IEnumerable<string> contents, int animationType, int animationSpeed, int frameTime, int holdTime, int windowId)
        {
            lock (syncRoot)
            {
                if (windows.ContainsKey(windowId))
                {
                    var win = windows[windowId];
                    var m = win.Movement;
                    m.iActionType = animationType;
                    m.iActionSpeed = animationSpeed;
                    m.iHoldTime = holdTime;
                    m.iFrameTime = frameTime;
                    win.Movement = m;
                    win.Text = new List<string>(contents);
                    RefreshWholeScreen(windowId);
                }
                else
                {
                    throw new KeyNotFoundException(string.Format("不存在窗口：{0}", windowId));
                }
            }
        }

        /// <summary>
        /// 刷新整个Led屏幕
        /// 由于API不支持更新某个逻辑窗口，因此需要刷新整个屏幕：让未更新的窗口立即显示以前的内容，让其他窗口更新信息（动态效果）
        /// </summary>
        /// <param name="activeWindowId"></param>
        private void RefreshWholeScreen(int activeWindowId)
        {
            var win = windows[activeWindowId];
            List<Window> wins = new List<Window>();
            foreach (var w in windows.Values)
            {
                if (w.LedIndex == win.LedIndex)
                {
                    wins.Add(w);
                }
            }
            LedAPI.User_DelAllProgram(win.LedIndex);
            var programId = LedAPI.User_AddProgram(win.LedIndex, true, 0);
            foreach (var w in wins)
            {
                var text = new User_Text();
                text.chContent = string.Join("\r\n", w.Text.ToArray());
                text.FontInfo = w.Font;
                text.MoveSet = w.Movement;

                if (w.Id != activeWindowId)
                {
                    text.MoveSet.iActionType = 1; // 除了当前窗，其他窗的文字都马上出现
                }
                else
                {
                    if (text.MoveSet.iActionSpeed == 3)
                    {
                        var list = new List<string>();
                        var count = int.Parse(ConfigurationManager.AppSettings["SpaceCount"]);
                        for (var i = 0; i < count; i++)
                        {
                            list.Add("　");
                        }
                        text.chContent = string.Join(string.Join(string.Empty, list.ToArray()), w.Text.ToArray());
                    }
                }

                text.PartInfo = w.Frame;
                LedAPI.User_AddText(win.LedIndex, ref text, programId);
            }
            LedAPI.User_SendToScreen(win.LedIndex);
        }
    }
}
