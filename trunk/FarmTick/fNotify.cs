using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FarmTick
{
    public partial class fNotify : Form
    {
        private static fNotify LastInstance;
        private static Image ImageOriginal;
        private static SolidBrush BrushRadar = new SolidBrush(Color.FromArgb(128, Color.Aqua));

        private fNotify()
        {
            InitializeComponent();
        }

        public static void ShowMessage(string title, string info, Image image, int fadetime)
        {
            if (LastInstance == null)
            {
                LastInstance = new fNotify();
                LastInstance.Left = Screen.PrimaryScreen.WorkingArea.Right - LastInstance.Width;
                LastInstance.Top = Screen.PrimaryScreen.WorkingArea.Bottom - LastInstance.Height;
                //LastInstance.Opacity = 0.2;
                //Api.Penetrate.Enable(LastInstance.Handle);
            }
            LastInstance.ShowMessageEx(title, info, image, fadetime);
        }

        public static void RadarShadow(int time)
        {
        }

        private void ShowMessageEx(string title, string info, Image image, int fadetime)
        {
            ImageOriginal = image;
            picProduct.Image = image;
            lblTitle.Text = title;
            lblInfo.Text = info;
            if (fadetime > 0)
            {
                tmrFade.Stop();
                tmrFade.Interval = fadetime * 1000;
                tmrFade.Start();
            }
            FadeIn();
        }

        private void FadeIn()
        {
            if (Visible == true) return;
            Opacity = 0;
            Visible = true;
            //BeginRadar();
            for (int i = 0; i <= 14; i++)
            {
                Opacity = i * 0.05;
                Application.DoEvents();
                Thread.Sleep(25);
            }
            Opacity = 1;
        }

        private void FadeOut()
        {
            if (Visible == false) return;
            for (int i = 14; i >= 0; i--)
            {
                Opacity = i * 0.05;
                Application.DoEvents();
                Thread.Sleep(25);
            }
            Visible = false;
        }

        private void BeginRadar()
        {
            tmrRadar.Tag = 0;
            tmrRadar.Start();
        }

        private void fNotify_Click(object sender, EventArgs e)
        {
            FadeOut();
        }

        private void tmrFade_Tick(object sender, EventArgs e)
        {
            FadeOut();
        }

        private void tmrRadar_Tick(object sender, EventArgs e)
        {
            Image image = (Image)ImageOriginal.Clone();
            Graphics g = Graphics.FromImage(image);
            g.FillPie(BrushRadar, 0, 0, 61, 61, 270, 270 + 36 * (int)tmrRadar.Tag);
            picProduct.Image = image;
            if ((int)tmrRadar.Tag >= 10)
                tmrRadar.Enabled = false;
            else
                tmrRadar.Tag = (int)tmrRadar.Tag + 1;
        }

        private void tmrAutoMove_Tick(object sender, EventArgs e)
        {
            if (this.RectangleToScreen(ClientRectangle).Contains(Control.MousePosition))
            {
                if (Left == 0)
                {
                    tmrAutoMove.Enabled = false;
                    FadeOut();
                    Left = Screen.PrimaryScreen.WorkingArea.Width - Width;
                    FadeIn();
                    tmrAutoMove.Enabled = true;
                }
                else
                {
                    tmrAutoMove.Enabled = false;
                    FadeOut();
                    Left = 0;
                    FadeIn();
                    tmrAutoMove.Enabled = true;
                }
            }
        }
        //#region LayeredWindow区域
        //#region API声明
        //protected class LayeredWindowApi
        //{
        //    [StructLayout(LayoutKind.Sequential)]
        //    public struct Size
        //    {
        //        public Int32 cx;
        //        public Int32 cy;

        //        public Size(Int32 x, Int32 y)
        //        {
        //            cx = x;
        //            cy = y;
        //        }
        //    }

        //    [StructLayout(LayoutKind.Sequential, Pack = 1)]
        //    public struct BLENDFUNCTION
        //    {
        //        public byte BlendOp;
        //        public byte BlendFlags;
        //        public byte SourceConstantAlpha;
        //        public byte AlphaFormat;
        //    }

        //    [StructLayout(LayoutKind.Sequential)]
        //    public struct Point
        //    {
        //        public Int32 x;
        //        public Int32 y;

        //        public Point(Int32 x, Int32 y)
        //        {
        //            this.x = x;
        //            this.y = y;
        //        }
        //    }

        //    public const byte AC_SRC_OVER = 0;
        //    public const Int32 ULW_ALPHA = 2;
        //    public const byte AC_SRC_ALPHA = 1;

        //    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        //    public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        //    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        //    public static extern IntPtr GetDC(IntPtr hWnd);

        //    [DllImport("gdi32.dll", ExactSpelling = true)]
        //    public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

        //    [DllImport("user32.dll", ExactSpelling = true)]
        //    public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        //    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        //    public static extern int DeleteDC(IntPtr hDC);

        //    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        //    public static extern int DeleteObject(IntPtr hObj);

        //    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        //    public static extern int UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        //    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        //    public static extern IntPtr ExtCreateRegion(IntPtr lpXform, uint nCount, IntPtr rgnData);
        //}
        //#endregion

        //bool haveHandle = false;

        //#region 重载

        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    e.Cancel = true;
        //    base.OnClosing(e);
        //    haveHandle = false;
        //}

        //protected override void OnHandleCreated(EventArgs e)
        //{
        //    InitializeStyles();
        //    base.OnHandleCreated(e);
        //    haveHandle = true;
        //}

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cParms = base.CreateParams;
        //        cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
        //        return cParms;
        //    }
        //}

        //#endregion    }

        //private void InitializeStyles()
        //{
        //    SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        //    SetStyle(ControlStyles.UserPaint, true);
        //    UpdateStyles();
        //}

        //public void SetBits(Bitmap bitmap)
        //{
        //    if (!haveHandle) return;

        //    if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
        //        throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");

        //    IntPtr oldBits = IntPtr.Zero;
        //    IntPtr screenDC = LayeredWindowApi.GetDC(IntPtr.Zero);
        //    IntPtr hBitmap = IntPtr.Zero;
        //    IntPtr memDc = LayeredWindowApi.CreateCompatibleDC(screenDC);

        //    try
        //    {
        //        LayeredWindowApi.Point topLoc = new LayeredWindowApi.Point(Left, Top);
        //        LayeredWindowApi.Size bitMapSize = new LayeredWindowApi.Size(bitmap.Width, bitmap.Height);
        //        LayeredWindowApi.BLENDFUNCTION blendFunc = new LayeredWindowApi.BLENDFUNCTION();
        //        LayeredWindowApi.Point srcLoc = new LayeredWindowApi.Point(0, 0);

        //        hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
        //        oldBits = LayeredWindowApi.SelectObject(memDc, hBitmap);

        //        blendFunc.BlendOp = LayeredWindowApi.AC_SRC_OVER;
        //        blendFunc.SourceConstantAlpha = 255;
        //        blendFunc.AlphaFormat = LayeredWindowApi.AC_SRC_ALPHA;
        //        blendFunc.BlendFlags = 0;

        //        LayeredWindowApi.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, LayeredWindowApi.ULW_ALPHA);
        //    }
        //    finally
        //    {
        //        if (hBitmap != IntPtr.Zero)
        //        {
        //            LayeredWindowApi.SelectObject(memDc, oldBits);
        //            LayeredWindowApi.DeleteObject(hBitmap);
        //        }
        //        LayeredWindowApi.ReleaseDC(IntPtr.Zero, screenDC);
        //        LayeredWindowApi.DeleteDC(memDc);
        //    }
        //}
        //#endregion
    }
}
