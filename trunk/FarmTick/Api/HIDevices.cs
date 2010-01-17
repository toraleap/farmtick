using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FarmTick.Api
{
    public static class HIDevices
    {
        /// <summary>
        /// 模拟鼠标事件
        /// </summary>
        /// <param name="dwFlags">事件类型</param>
        /// <param name="dx">事件x位置</param>
        /// <param name="dy">事件y位置</param>
        /// <param name="cButtons">事件按钮</param>
        /// <param name="dwExtraInfo">附加信息</param>
        [DllImport("user32.dll", EntryPoint = "mouse_event")]
        public static extern void mouse_event(
            int dwFlags,
            int dx,
            int dy,
            int cButtons,
            int dwExtraInfo
        );

        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(
            byte bVk,
            byte bScan,
            int dwFlags,
            int dwExtraInfo
        );

        public const int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标 
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下 
        public const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        public const int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;// 模拟鼠标中键抬起 
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标
    }
}
