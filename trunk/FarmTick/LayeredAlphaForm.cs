using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FarmTick
{
    public class LayeredAlphaForm : Form
    {
        private enum TimerModes
        {
            None,
            FadeIn,
            SplashA,
            SplashB,
            FadeOutB
        }

        static Bitmap background = Properties.Resources.notify;
        static Bitmap b = null;
        static LayeredAlphaForm f = new LayeredAlphaForm();
        static Font fontTitle = new Font("Î¢ÈíÑÅºÚ", 16);
        static Font fontText = new Font("Î¢ÈíÑÅºÚ", 12);
        static byte opacity = 0;
        static byte splashcount = 0;
        static TimerModes timerMode = TimerModes.None;

        private System.ComponentModel.IContainer components;
        private Timer tmrControl;
        private const int WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;

        private LayeredAlphaForm()
        {
            InitializeComponent();
        }

        public static void ShowNotify(FarmTickManager.RipeInfoCollection ric, Image image, int offset)
        {
            if (f == null) f = new LayeredAlphaForm();
            f.ShowNotifyEx(ric, image, offset);
        }

        public void ShowNotifyEx(FarmTickManager.RipeInfoCollection ric, Image image, int offset)
        {
            b = (Bitmap)background.Clone();
            Graphics g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.DrawImageUnscaled(image, (262 - image.Width) / 2, 54);

            SizeF size = g.MeasureString(ric.OwnerName, fontTitle);
            g.DrawString(ric.OwnerName, fontTitle, Brushes.Black, (262 - size.Width) / 2, 118);

            size = g.MeasureString(ric.ProductString, fontText);
            g.DrawString(ric.ProductString, fontText, Brushes.Black, (262 - size.Width) / 2, 150);

            string s = String.Format("Ô¤¼Æ{1}½ð±Ò", ric.ProductString, ric.ExpectValue);
            size = g.MeasureString(s, fontText);
            g.DrawString(s, fontText, Brushes.Black, (262 - size.Width) / 2, 170);

            s = String.Format("{0}Ãëºó³ÉÊì", offset);
            size = g.MeasureString(s, fontText);
            g.DrawString(s, fontText, Brushes.Black, (262 - size.Width) / 2, 190);

            opacity = 0;
            splashcount = 0;
            f.SetBitmap(b, opacity);
            f.Left = (Screen.PrimaryScreen.WorkingArea.Width - 256) / 2;
            f.Top = (Screen.PrimaryScreen.WorkingArea.Height - 256 - 20);
            f.Show();
            tmrControl.Stop();
            tmrControl.Interval = 50;
            tmrControl.Start();
            timerMode = TimerModes.FadeIn;
        }

        private void tmrControl_Tick(object sender, EventArgs e)
        {
            switch (timerMode)
            {
                case TimerModes.None:
                    Hide();
                    break;
                case TimerModes.FadeIn:
                    opacity += 20;
                    SetBitmap(b, opacity);
                    if (opacity >= 200)
                    {
                        tmrControl.Stop();
                        tmrControl.Interval = 50;
                        timerMode = TimerModes.SplashA;
                        tmrControl.Start();
                    }
                    break;
                case TimerModes.SplashA:
                    opacity -= 10;
                    SetBitmap(b, opacity);
                    if (opacity <= 140)
                    {
                        tmrControl.Stop();
                        tmrControl.Interval = 50;
                        timerMode = TimerModes.SplashB;
                        tmrControl.Start();
                    }
                    break;
                case TimerModes.SplashB:
                    opacity += 10;
                    SetBitmap(b, opacity);
                    if (opacity >= 200)
                    {
                        if (splashcount < 8)
                        {
                            splashcount++;
                            tmrControl.Stop();
                            tmrControl.Interval = 50;
                            timerMode = TimerModes.SplashA;
                            tmrControl.Start();
                        }
                        else
                        {
                            tmrControl.Stop();
                            tmrControl.Interval = 50;
                            timerMode = TimerModes.FadeOutB;
                            tmrControl.Start();
                        }
                    }
                    break;
                case TimerModes.FadeOutB:
                    opacity -= 20;
                    SetBitmap(b, opacity);
                    if (opacity <= 0)
                    {
                        tmrControl.Stop();
                        timerMode = TimerModes.None;
                        Hide();
                    }
                    break;
            }
        }
        #region LayeredAlpha Section
        public void SetBitmap(Bitmap bitmap)
        {
            SetBitmap(bitmap, 255);
        }

        public void SetBitmap(Bitmap bitmap, byte opacity)
        {
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

            IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
            IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));  // grab a GDI handle from this GDI+ bitmap
                oldBitmap = Win32.SelectObject(memDc, hBitmap);

                Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.Point pointSource = new Win32.Point(0, 0);
                Win32.Point topPos = new Win32.Point(Left, Top);
                Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
                blend.BlendOp = Win32.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = opacity;
                blend.AlphaFormat = Win32.AC_SRC_ALPHA;

                Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
            }
            finally
            {
                Win32.ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBitmap);
                    //Windows.DeleteObject(hBitmap); // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from Win32 GDI and it's working fine without any resource leak.
                    Win32.DeleteObject(hBitmap);
                }
                Win32.DeleteDC(memDc);
            }
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_TRANSPARENT | WS_EX_LAYERED;
                return cp;
            }
        }

        // class that exposes needed win32 gdi functions.
        class Win32
        {
            public enum Bool
            {
                False = 0,
                True
            };


            [StructLayout(LayoutKind.Sequential)]
            public struct Point
            {
                public Int32 x;
                public Int32 y;

                public Point(Int32 x, Int32 y) { this.x = x; this.y = y; }
            }


            [StructLayout(LayoutKind.Sequential)]
            public struct Size
            {
                public Int32 cx;
                public Int32 cy;

                public Size(Int32 cx, Int32 cy) { this.cx = cx; this.cy = cy; }
            }


            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            struct ARGB
            {
                public byte Blue;
                public byte Green;
                public byte Red;
                public byte Alpha;
            }


            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct BLENDFUNCTION
            {
                public byte BlendOp;
                public byte BlendFlags;
                public byte SourceConstantAlpha;
                public byte AlphaFormat;
            }


            public const Int32 ULW_COLORKEY = 0x00000001;
            public const Int32 ULW_ALPHA = 0x00000002;
            public const Int32 ULW_OPAQUE = 0x00000004;

            public const byte AC_SRC_OVER = 0x00;
            public const byte AC_SRC_ALPHA = 0x01;


            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr GetDC(IntPtr hWnd);

            [DllImport("user32.dll", ExactSpelling = true)]
            public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern Bool DeleteDC(IntPtr hdc);

            [DllImport("gdi32.dll", ExactSpelling = true)]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern Bool DeleteObject(IntPtr hObject);
        }
        #endregion

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrControl = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrControl
            // 
            this.tmrControl.Interval = 5000;
            this.tmrControl.Tick += new System.EventHandler(this.tmrControl_Tick);
            // 
            // LayeredAlphaForm
            // 
            this.ClientSize = new System.Drawing.Size(256, 256);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LayeredAlphaForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);

        }
    }
}