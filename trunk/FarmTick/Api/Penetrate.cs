using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace FarmTick.Api
{
    public static class Penetrate
    {
        private const int WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        private const int LWA_ALPHA = 0x2;

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong(
        IntPtr hwnd,
        int nIndex,
        int dwNewLong
        );

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern int GetWindowLong(
        IntPtr hwnd,
        int nIndex
        );

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern int SetLayeredWindowAttributes(
        IntPtr hwnd,
        int crKey,
        int bAlpha,
        int dwFlags
        );

        /// <summary>
        /// 使窗口有鼠标穿透功能
        /// </summary>
        public static void Enable(IntPtr handle)
        {
            int oriEx = GetWindowLong(handle, GWL_EXSTYLE);
            int newEx = oriEx | WS_EX_TRANSPARENT | WS_EX_LAYERED;
            SetWindowLong(handle, GWL_EXSTYLE, newEx);
            SetLayeredWindowAttributes(handle, 0, 160, LWA_ALPHA);
        }

        /// <summary>
        /// 禁用窗口有鼠标穿透功能
        /// </summary>
        public static void Disable(IntPtr handle)
        {
            int oriEx = GetWindowLong(handle, GWL_EXSTYLE);
            int newEx = oriEx & ~WS_EX_TRANSPARENT & ~WS_EX_LAYERED;
            SetWindowLong(handle, GWL_EXSTYLE, newEx);
            //SetLayeredWindowAttributes(handle, 0, 100, LWA_ALPHA);
        }
    }
}
