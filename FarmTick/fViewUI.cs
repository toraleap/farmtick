﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FarmTick.Properties;

namespace FarmTick
{
    public partial class fViewUI : Form
    {
        /// <summary>
        /// 视图显示模式枚举
        /// </summary>
        public enum ViewStyles
        {
            Time,
            User,
            Value,
            History
        }

        /// <summary>
        /// 时间显示模式枚举
        /// </summary>
        public enum TimeModes
        {
            Auto,
            Exactly,
            Countdown
        }

        /// <summary>
        /// 昵称显示模式枚举
        /// </summary>
        public enum NameModes
        {
            Both,
            Xiaoyou,
            Qzone
        }

        /// <summary>
        /// 免打扰模式枚举
        /// </summary>
        public enum MuteModes
        {
            All,
            Above100,
            Above300,
            OnlyMe,
            None
        }

        public fViewUI()
        {
            InitializeComponent();
        }

        private void fViewUI_Load(object sender, EventArgs e)
        {
            LoadImages();

            // 尝试启用Vista风格
            if (Environment.OSVersion.Version.Major >= 6) Api.VistaTheme.SetListViewTheme(lvwFarms);
            // 窗口定位于右下角
            Left = Screen.PrimaryScreen.WorkingArea.Right - Width - 16;
            Top = Screen.PrimaryScreen.WorkingArea.Bottom - Height - 16;

            ApplySettings();
            if (Settings.Default.AutoCapture)
            {
                tsbCapture.Checked = true;
                DataFiddler.Capture();
            }
            if (Settings.Default.FastClickHotkey) Api.Hotkeys.RegisterHotKey(Handle, 100, FarmTick.Api.Hotkeys.KeyModifiers.WindowsKey | FarmTick.Api.Hotkeys.KeyModifiers.Shift, Keys.C);
            FarmTickManager.FarmsChanged += OnFarmsChanged;
            ClearView();
            UpdateAlarm();
        }

        private void fViewUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DataFiddler.IsCapturing) DataFiddler.Release();
            Program.Exit();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            if (Settings.Default.FastClickHotkey && m.Msg == WM_HOTKEY && !AutoClickProcessing && m.WParam.ToInt32() == 100)
            {
                AutoClickProcessing = true;
                new Thread(AutoClickProcedure).Start();
            }
            base.WndProc(ref m);
        }

        Dictionary<ProductGroup, ListViewItem> dgl = new Dictionary<ProductGroup, ListViewItem>();
        /// <summary>
        /// 清空并重建ListView显示项目
        /// </summary>
        protected void ClearView()
        {
            lvwFarms.Items.Clear();
            lvwFarms.Groups.Clear();
            dgl.Clear();
            UpdateView();
        }

        /// <summary>
        /// 刷新ListView显示项目
        /// </summary>
        protected void UpdateView()
        {
            if (WindowState == FormWindowState.Minimized || !lvwFarms.Visible) return;

            List<ProductGroup> gs = FarmTickManager.GetSortedGroups();
            DateTime now = DateTime.Now;
            ListViewItem lvi = null;
            lvwFarms.BeginUpdate();

            foreach (ProductGroup g in gs)
            {
                // 是否应该保留
                if (ViewFilter(g))
                {
                    // 是否已存在
                    if (dgl.ContainsKey(g))
                    {
                        string ripetime = FormatTime(g.RipeTime);
                        ListViewGroup lvg = GetItemGroup(g);
                        lvi = dgl[g];
                        if (lvi.Text != g.OwnerName) lvi.Text = g.OwnerName;
                        if (lvi.SubItems[2].Text != ripetime) lvi.SubItems[2].Text = ripetime;
                        if (lvi.Group != lvg) lvi.Group = lvg;
                    }
                    else
                    {
                        lvi = new ListViewItem(new string[] { 
                                    g.Parent.OwnerName, 
                                    String.Format("{0} {1}金币", g.ProductString, g.ExpectValue.ToString()),
                                    FormatTime(g.RipeTime) },
                            g.RipeName, GetItemGroup(g));
                        lvi.Tag = g;
                        dgl.Add(g, lvi);
                        lvwFarms.Items.Add(lvi);
                    }
                }
                else
                {
                    if (dgl.ContainsKey(g))
                    {
                        lvwFarms.Items.Remove(dgl[g]);
                        dgl.Remove(g);
                    }
                }
            }
            lvwFarms.EndUpdate();
        }

        /// <summary>
        /// 根据系统设置获取ListView分组
        /// </summary>
        /// <param name="g">欲分组的ProductGroup</param>
        /// <returns>分到的ListViewGroup</returns>
        private ListViewGroup GetItemGroup(ProductGroup g)
        {
            string grouptext = null;
            switch (Settings.Default.ViewStyle)
            {
                case ViewStyles.Time:
                    if ((g.RipeTime - DateTime.Now).TotalMinutes < 10)
                        grouptext = "即将成熟";
                    else if ((g.RipeTime - DateTime.Now).TotalHours < 1)
                        grouptext = "一小时以内";
                    else if ((g.RipeTime - DateTime.Now).TotalHours < 4)
                        grouptext = "四小时以内";
                    else
                        grouptext = "四小时以后";
                    break;
                case ViewStyles.User:
                    grouptext = g.OwnerName;
                    break;
                case ViewStyles.Value:
                    if (g.ExpectValue < 100)
                        grouptext = "鸡肋排骨";
                    else if (g.ExpectValue < 300)
                        grouptext = "小本生意";
                    else if (g.ExpectValue < 600)
                        grouptext = "有利可图";
                    else
                        grouptext = "满载而归";
                    break;
                case ViewStyles.History:
                    if ((DateTime.Now - g.RipeTime).TotalMinutes < 10)
                        grouptext = "刚刚成熟";
                    else if ((DateTime.Now - g.RipeTime).TotalHours < 1)
                        grouptext = "一小时以内";
                    else if ((DateTime.Now - g.RipeTime).TotalHours < 4)
                        grouptext = "四小时以内";
                    else
                        grouptext = "四小时以前";
                    break;
            }
            foreach (ListViewGroup lvg in lvwFarms.Groups)
                if (lvg.Header == grouptext) return lvg;
            ListViewGroup newlvg = new ListViewGroup(grouptext);
            lvwFarms.Groups.Add(newlvg);
            return newlvg;
        }

        private void UpdateAlarm()
        {
            DateTime now = DateTime.Now;
            FarmTickManager.RipeInfoCollection ris = FarmTickManager.GetFirstRipeCollection(AlarmFilter);

            if (ris.Count > 0)
            {
                nfyIcon.Text = string.Format("FarmTick v1.0\n{0} {1}\n{2}({3}金币)", ris.RipeTime.ToShortTimeString(), TruncateString(ris.OwnerName, 15), TruncateString(ris.ProductString, 15), ris.ExpectValue);
                tmrNotifyIcon.Interval = (int)(ris[0].RipeTime.AddSeconds(1) - now).TotalMilliseconds;
                tmrNotifyIcon.Tag = ris;
                tmrNotifyIcon.Enabled = true;
            }
            else
                tmrNotifyIcon.Enabled = false;

            ris = FarmTickManager.GetFirstRipeCollection(g => { return (AlarmFilter(g) && (g.RipeTime - DateTime.Now).TotalSeconds > 60); });
            if (tsbAlarm.Checked && ris.Count > 0)
            {
                tmrAlarm.Interval = (int)(ris[0].RipeTime.AddSeconds(-60) - now).TotalMilliseconds;
                tmrAlarm.Tag = ris;
                tmrAlarm.Enabled = true;
            }
            else
                tmrAlarm.Enabled = false;

            ris = FarmTickManager.GetFirstRipeCollection(g => { return (AlarmFilter(g) && (g.RipeTime - DateTime.Now).TotalSeconds > 10); });
            if (tsbAlarm2.Checked && ris.Count > 0)
            {
                tmrAlarm2.Interval = (int)(ris[0].RipeTime.AddSeconds(-10) - now).TotalMilliseconds;
                tmrAlarm2.Tag = ris;
                tmrAlarm2.Enabled = true;
            }
            else
                tmrAlarm2.Enabled = false;
        }

        #region 界面操作事件
        private static bool iconnotified = false;
        private void fViewUI_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = false;
                if (!iconnotified)
                {
                    iconnotified = true;
                    nfyIcon.ShowBalloonTip(3000, "FarmTick", "您已将主窗口最小化到通知区。\n双击这里可以再次显示主窗口。", ToolTipIcon.Info);
                }
            }
        }

        private void lvwFarms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tbsView.Visible = !tbsView.Visible;
                tbsOptions.Visible = !tbsOptions.Visible;
            }
        }

        private static FormWindowState originwindowstate = FormWindowState.Normal;
        private void nfyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = true;
                WindowState = originwindowstate;
            }
            else
            {
                originwindowstate = WindowState;
                WindowState = FormWindowState.Minimized;
                Visible = false;
            }
        }

        private void tsbTopMost_Click(object sender, EventArgs e)
        {
            Settings.Default.TopMost = !Settings.Default.TopMost;
            tsbTopMost.Checked = Settings.Default.TopMost;
            TopMost = Settings.Default.TopMost;
        }

        private void tsbViewStyle_Click(object sender, EventArgs e)
        {
            ToolStripButton[] tsbUIGroup = new ToolStripButton[] { tsbUITime, tsbUIUser, tsbUIValue, tsbUIHistory };
            for (int i = 0; i < tsbUIGroup.Length; i++)
            {
                if (tsbUIGroup[i] == sender)
                {
                    tsbUIGroup[i].Checked = true;
                    Settings.Default.ViewStyle = (ViewStyles)i;
                }
                else
                    tsbUIGroup[i].Checked = false;
            }
            ClearView();
        }

        private void tsbTimeMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem[] tsbTimeGroup = new ToolStripMenuItem[] { tsbTimeAuto, tsbTimeExactly, tsbTimeCountdown };
            for (int i = 0; i < tsbTimeGroup.Length; i++)
            {
                if (tsbTimeGroup[i] == sender)
                {
                    tsbTimeGroup[i].Checked = true;
                    Settings.Default.TimeMode = (TimeModes)i;
                }
                else
                    tsbTimeGroup[i].Checked = false;
            }
            UpdateView();
        }

        private void tsbNameMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem[] tsbNameGroup = new ToolStripMenuItem[] { tsbNameModeBoth, tsbNameModeXiaoyou, tsbNameModeQzone };
            for (int i = 0; i < tsbNameGroup.Length; i++)
            {
                if (tsbNameGroup[i] == sender)
                {
                    tsbNameGroup[i].Checked = true;
                    Settings.Default.NameMode = (NameModes)i;
                }
                else
                    tsbNameGroup[i].Checked = false;
            }
            UpdateView();
        }

        private void tsbNotifyItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem[] tsbNotifyGroup = new ToolStripMenuItem[] { tsbNotifyAll, tsbNotifyValuable100, tsbNotifyValuable300, tsbNotifySelfonly, tsbNotifyNone };
            for (int i = 0; i < tsbNotifyGroup.Length; i++)
            {
                if (tsbNotifyGroup[i] == sender as ToolStripMenuItem)
                {
                    tsbNotifyGroup[i].Checked = true;
                    Settings.Default.MuteMode = (MuteModes)i;
                }
                else
                    tsbNotifyGroup[i].Checked = false;
            }
            UpdateAlarm();
        }

        private void tsbCapture_Click(object sender, EventArgs e)
        {
            tsbCapture.Checked = !tsbCapture.Checked;
            if (tsbCapture.Checked) DataFiddler.Capture();
            else DataFiddler.Release();
        }

        private void tsbAutoCapture_Click(object sender, EventArgs e)
        {
            Settings.Default.AutoCapture = !Settings.Default.AutoCapture;
            tsbAutoCapture.Checked = Settings.Default.AutoCapture;
        }

        private void tsbAutoProxy_Click(object sender, EventArgs e)
        {
            Settings.Default.AutoProxy = !Settings.Default.AutoProxy;
            tsbAutoProxy.Checked = Settings.Default.AutoProxy;
        }

        private void tsbAutoClick_Click(object sender, EventArgs e)
        {
            Settings.Default.FastClickHotkey = !Settings.Default.FastClickHotkey;
            tsbAutoClick.Checked = Settings.Default.FastClickHotkey;
            if (Settings.Default.FastClickHotkey)
            {
                MessageBox.Show("鼠标连点热键已激活。\n先把鼠标移动到需要连续点击的位置，保持鼠标不动，按 Win+Shift+C 进入鼠标连续点击状态。要终止鼠标连点，请向任意方向移动鼠标10个像素以上距离。", "FarmTick 连点热键说明", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Api.Hotkeys.RegisterHotKey(Handle, 100, FarmTick.Api.Hotkeys.KeyModifiers.WindowsKey | FarmTick.Api.Hotkeys.KeyModifiers.Shift, Keys.C);
            }
            else
                Api.Hotkeys.UnregisterHotKey(Handle, 100);
        }

        private void tsbShowHungry_Click(object sender, EventArgs e)
        {
            Settings.Default.ShowHungry = !Settings.Default.ShowHungry;
            tsbAutoCapture.Checked = Settings.Default.ShowHungry;
            ClearView();
        }

        private void tsbNotifyWindow_Click(object sender, EventArgs e)
        {
            Settings.Default.NotifyWindow = 1 - Settings.Default.NotifyWindow;
            tsbNotifyWindow.Checked = Settings.Default.NotifyWindow > 0;
        }

        private void tsbNotifySound_Click(object sender, EventArgs e)
        {
            Settings.Default.NotifySound = !Settings.Default.NotifySound;
            tsbNotifySound.Checked = Settings.Default.NotifySound;
        }

        private void tsbAlarm_Click(object sender, EventArgs e)
        {
            Settings.Default.Timer60Sec = !Settings.Default.Timer60Sec;
            tsbAlarm.Checked = Settings.Default.Timer60Sec;
            UpdateAlarm();
        }

        private void tsbAlarm2_Click(object sender, EventArgs e)
        {
            Settings.Default.Timer10Sec = !Settings.Default.Timer10Sec;
            tsbAlarm2.Checked = Settings.Default.Timer10Sec;
            UpdateAlarm();
        }
        #endregion

        private void tmrAlarm_Tick(object sender, EventArgs e)
        {
            FarmTickManager.RipeInfoCollection ris = tmrAlarm.Tag as FarmTickManager.RipeInfoCollection;
            tmrAlarm.Enabled = false;
            ShowNotify(string.Format("{0}", ris.OwnerName), string.Format("{0}已进入60秒倒计时\n预期价值:{1}", ris.ProductString, ris.ExpectValue), imgProduct.Images[ris[0].RipeName]);
            UpdateAlarm();
        }

        private void tmrAlarm2_Tick(object sender, EventArgs e)
        {
            FarmTickManager.RipeInfoCollection ris = tmrAlarm2.Tag as FarmTickManager.RipeInfoCollection;
            tmrAlarm2.Enabled = false;
            ShowNotify(string.Format("{0}", ris.OwnerName), string.Format("{0}已进入10秒倒计时\n预期价值:{1}", ris.ProductString, ris.ExpectValue), imgProduct.Images[ris[0].RipeName]);
            UpdateAlarm();
        }

        private void tmrNotifyIcon_Tick(object sender, EventArgs e)
        {
            tmrNotifyIcon.Enabled = false;
            UpdateAlarm();
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            UpdateView();
        }

        /// <summary>
        /// 载入农牧场产品的图像文件
        /// </summary>
        private void LoadImages()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(@".\res");
                foreach (FileInfo fi in di.GetFiles("*.gif"))
                {
                    imgProduct.Images.Add(fi.Name.Substring(0, fi.Name.LastIndexOf('.')), Image.FromFile(fi.FullName));
                }
            }
            catch (DirectoryNotFoundException exception)
            {
                MessageBox.Show("图像文件夹res没有找到，无法显示图像！" + exception.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 载入设置后设置界面
        /// </summary>
        private void ApplySettings()
        {
            ToolStripButton[] tsbUIGroup = new ToolStripButton[] { tsbUITime, tsbUIUser, tsbUIValue, tsbUIHistory };
            tsbUIGroup[(int)Settings.Default.ViewStyle].Checked = true;

            ToolStripMenuItem[] tsbTimeGroup = new ToolStripMenuItem[] { tsbTimeAuto, tsbTimeExactly, tsbTimeCountdown };
            tsbTimeGroup[(int)Settings.Default.TimeMode].Checked = true;

            ToolStripMenuItem[] tsbNameGroup = new ToolStripMenuItem[] { tsbNameModeBoth, tsbNameModeXiaoyou, tsbNameModeQzone };
            tsbNameGroup[(int)Settings.Default.NameMode].Checked = true;
            
            ToolStripMenuItem[] tsbNotifyGroup = new ToolStripMenuItem[] { tsbNotifyAll, tsbNotifyValuable100, tsbNotifyValuable300, tsbNotifySelfonly, tsbNotifyNone };
            tsbNotifyGroup[(int)Settings.Default.MuteMode].Checked = true;

            tsbShowHungry.Checked = Settings.Default.ShowHungry;

            tsbNotifySound.Checked = Settings.Default.NotifySound;
            tsbNotifyWindow.Checked = Settings.Default.NotifyWindow > 0;
            tsbAlarm.Checked = Settings.Default.Timer60Sec;
            tsbAlarm2.Checked = Settings.Default.Timer10Sec;

            tsbAutoCapture.Checked = Settings.Default.AutoCapture;
            tsbAutoProxy.Checked = Settings.Default.AutoProxy;
            tsbAutoClick.Checked = Settings.Default.FastClickHotkey;
        }

        /// <summary>
        /// 农场数据改变后调用回调函数
        /// </summary>
        protected void OnFarmsChanged()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { OnFarmsChanged(); }));
                return;
            }
            ClearView();
            UpdateAlarm();
        }

        /// <summary>
        /// 查看样式过滤器
        /// </summary>
        /// <param name="g">要判断的产品组</param>
        /// <returns>是否保留</returns>
        protected bool ViewFilter(ProductGroup g)
        {
            DateTime now = DateTime.Now;
            switch (Settings.Default.ViewStyle)
            {
                case ViewStyles.Time:
                    if (g.RipeTime > now) return true;
                    break;
                case ViewStyles.User:
                    if (g.RipeTime > now) return true;
                    break;
                case ViewStyles.Value:
                    if (g.RipeTime > now) return true;
                    break;
                case ViewStyles.History:
                    if (g.RipeTime < now && (now - g.RipeTime).TotalDays < 1) return true;
                    break;
            }
            return false;
        }

        /// <summary>
        /// 提醒过滤器
        /// </summary>
        /// <param name="g">要判断的产品组</param>
        /// <returns>是否保留</returns>
        protected bool AlarmFilter(ProductGroup g)
        {
            DateTime now = DateTime.Now;
            switch (Settings.Default.MuteMode)
            {
                case MuteModes.All:
                    if (g.RipeTime > now) return true;
                    break;
                case MuteModes.Above100:
                    if (g.RipeTime > now && g.ExpectValue >= 100) return true;
                    break;
                case MuteModes.Above300:
                    if (g.RipeTime > now && g.ExpectValue >= 300) return true;
                    break;
                case MuteModes.OnlyMe:
                    if (g.RipeTime > now && g.OwnerId == Friends.MasterId) return true;
                    break;
                case MuteModes.None:
                    break;
            }
            return false;
        }

        protected void ShowNotify(string title, string text, Image image)
        {
            if (Settings.Default.NotifySound) new System.Media.SoundPlayer(@"res\alarm.wav").Play();
            if (Settings.Default.NotifyWindow > 0)
                nfyIcon.ShowBalloonTip(10000, title, text, ToolTipIcon.Info);
        }

        bool AutoClickProcessing = false;
        /// <summary>
        /// 鼠标自动点击线程
        /// </summary>
        private void AutoClickProcedure()
        {
            Point mp = Control.MousePosition;
            while (true)
            {
                Point cmp = Control.MousePosition;
                if (cmp.X - mp.X > 10 || cmp.Y - mp.Y > 10 || mp.X - cmp.X > 10 || mp.Y - cmp.Y > 10) break;
                Api.HIDevices.mouse_event(Api.HIDevices.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                Api.HIDevices.mouse_event(Api.HIDevices.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                Thread.Sleep(50);
            }
            AutoClickProcessing = false;
        }
        /// <summary>
        /// 字符串截断，超出部分用省略号代替
        /// </summary>
        /// <param name="src">源字符串</param>
        /// <param name="length">长度限制</param>
        /// <returns>处理后字符串</returns>
        private static string TruncateString(string src, int length)
        {
            if (src.Length <= length) return src;
            else return src.Substring(0, length - 3) + "...";
        }

        /// <summary>
        /// 根据系统设置将时间转换为适当的显示格式
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns>适当的字符串表示</returns>
        protected string FormatTime(DateTime dt)
        {
            TimeSpan ts = dt - DateTime.Now;
            switch (Settings.Default.TimeMode)
            {
                case TimeModes.Auto:
                    if (ts.TotalHours > 1)
                        return dt.ToString();
                    else if (ts.TotalMinutes > 3)
                        return String.Format("{0}分钟后 {1}", ts.Minutes, dt.ToLongTimeString());
                    else if (ts.TotalSeconds > 60)
                        return String.Format("{0}分{1}秒钟后 {2}", ts.Minutes, ts.Seconds, dt.ToLongTimeString());
                    else if (ts.TotalSeconds > 0)
                        return String.Format("{0}秒钟后 {1}", ts.Seconds, dt.ToLongTimeString());
                    else if (ts.TotalMinutes > -1)
                        return String.Format("{0}秒钟前 {1}", (-ts).Seconds, dt.ToLongTimeString());
                    else if (ts.TotalHours > -1)
                        return String.Format("{0}分钟前 {1}", (-ts).Minutes, dt.ToLongTimeString());
                    else
                        return dt.ToString();
                case TimeModes.Exactly:
                    return dt.ToString();
                case TimeModes.Countdown:
                    if (ts.TotalHours > 1)
                        return String.Format("{0}小时{1}分钟后", (int)ts.TotalHours, ts.Minutes);
                    else if (ts.TotalMinutes > 3)
                        return String.Format("{0}分钟后", ts.Minutes);
                    else if (ts.TotalSeconds > 60)
                        return String.Format("{0}分{1}秒钟后", ts.Minutes, ts.Seconds);
                    else if (ts.TotalSeconds > 0)
                        return String.Format("{0}秒钟后", ts.Seconds);
                    else if (ts.TotalMinutes > -1)
                        return String.Format("{0}秒钟前", (-ts).Seconds);
                    else if (ts.TotalHours > -1)
                        return String.Format("{0}分钟前 {1}", (-ts).Minutes, dt.ToLongTimeString());
                    else
                        return String.Format("{0}小时{1}分钟前 {2}", (int)(-ts).TotalHours, (-ts).Minutes, dt.ToLongTimeString());
            }
            return "时间格式化错误";
        }

        private void fViewUI_MouseEnter(object sender, EventArgs e)
        {
            MessageBox.Show("cc");
            Text = e.ToString();
        }
    }
}