using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FarmTick.Api
{
    public static class VistaTheme
    {
        #region LVS_EX
        public enum LVS_EX
        {
            LVS_EX_GRIDLINES = 0x00000001,
            LVS_EX_SUBITEMIMAGES = 0x00000002,
            LVS_EX_CHECKBOXES = 0x00000004,
            LVS_EX_TRACKSELECT = 0x00000008,
            LVS_EX_HEADERDRAGDROP = 0x00000010,
            LVS_EX_FULLROWSELECT = 0x00000020,
            LVS_EX_ONECLICKACTIVATE = 0x00000040,
            LVS_EX_TWOCLICKACTIVATE = 0x00000080,
            LVS_EX_FLATSB = 0x00000100,
            LVS_EX_REGIONAL = 0x00000200,
            LVS_EX_INFOTIP = 0x00000400,
            LVS_EX_UNDERLINEHOT = 0x00000800,
            LVS_EX_UNDERLINECOLD = 0x00001000,
            LVS_EX_MULTIWORKAREAS = 0x00002000,
            LVS_EX_LABELTIP = 0x00004000,
            LVS_EX_BORDERSELECT = 0x00008000,
            LVS_EX_DOUBLEBUFFER = 0x00010000,
            LVS_EX_HIDELABELS = 0x00020000,
            LVS_EX_SINGLEROW = 0x00040000,
            LVS_EX_SNAPTOGRID = 0x00080000,
            LVS_EX_SIMPLESELECT = 0x00100000
        }
        #endregion

        #region LVM
        public enum LVM
        {
            LVM_FIRST = 0x1000,
            LVM_SETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 54),
            LVM_GETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 55),
        }
        #endregion
        [DllImport("uxtheme", CharSet = CharSet.Unicode)]
        private extern static Int32 SetWindowTheme(IntPtr hWnd, String textSubAppName, String textSubIdList);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private extern static int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam); 

        /// <summary>
        /// 开启ListView的Vista风格
        /// </summary>
        /// <param name="lvw">欲应用Vista风格的ListView控件</param>
        public static void SetListViewTheme(ListView lvw)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetWindowTheme(lvw.Handle, "explorer", null);
                SendMessage(lvw.Handle, (int)LVM.LVM_SETEXTENDEDLISTVIEWSTYLE, (int)LVS_EX.LVS_EX_DOUBLEBUFFER, (int)LVS_EX.LVS_EX_DOUBLEBUFFER);  
                SendMessage(lvw.Handle, 0x1000 + 54, 0x00010000, 0x00010000);
            }
        }
    }
}
