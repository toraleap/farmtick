using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;
using FarmTick.Properties;

namespace FarmTick
{
    public partial class fMain : Form
    {
        #region 窗体及按钮事件
        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            // 尝试启用Vista风格
            if (Environment.OSVersion.Version.Major >= 6)
            {
                Api.VistaTheme.SetListViewTheme(lvwFarms);
                //tbsMain.Renderer = new VistaRenderer.WindowsVistaRenderer();
            }

            // 载入植物图像文件
            DirectoryInfo di = new DirectoryInfo(@".\res");
            foreach (FileInfo fi in di.GetFiles("*.gif"))
            {
                imgPlants.Images.Add(fi.Name.Substring(0, fi.Name.LastIndexOf('.')), Image.FromFile(fi.FullName));
            }
            
            // 载入历史好友及农场列表，载入设置
            Friends.Load();
            FarmTick.Load();
            if (File.Exists("./config.xml")) Deserialize();
            FarmTick.FarmsChanged += OnFarmsChanged;
            tsbView.SelectedIndex = 0;
            OnFarmsChanged();

            if (tsbAutoCapture.Checked)
            {
                tsbCapture.Checked = true;
                if (tsbDataFiddler.Checked)
                    DataFiddler.Capture();
                else
                    DataHttpAnalyzer.Capture();
            }

            Left = Screen.PrimaryScreen.WorkingArea.Right - Width - 16;
            Top = Screen.PrimaryScreen.WorkingArea.Bottom - Height - 16;
        }

        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 保存当前好友列表及设置
            Friends.Save();
            FarmTick.Save();
            Serialize();

            if (DataFiddler.IsCapturing) DataFiddler.Release();
        }

        private static bool iconnotified = false;
        private void fMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                if (!iconnotified)
                {
                    iconnotified = true;
                    nfyAlarm.ShowBalloonTip(3000, "FarmTick", "您已将主窗口最小化到通知区。\n双击这里可以再次显示主窗口。", ToolTipIcon.Info);
                }
            }
        }

        private static FormWindowState originwindowstate = FormWindowState.Normal;
        private void nfyAlarm_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = originwindowstate;
                ShowInTaskbar = true;
            }
            else
            {
                originwindowstate = WindowState;
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }
        }

        private void lvwFarms_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            ListViewHitTestInfo hti = lvwFarms.HitTest(e.Location);
            if (hti.Item != null)
            {
                hti.Item.Selected = true;
                cmsListView.Show(lvwFarms, e.Location);
            }
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

        private void tsbShowRiped_Click(object sender, EventArgs e)
        {
            Settings.Default.ShowRiped = !Settings.Default.ShowRiped;
            tsbShowRiped.Checked = Settings.Default.ShowRiped;
            UpdateListView();
        }

        private void tsbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tsbView.SelectedIndex > 1)
            {
                lvwFarms.Visible = false;
                chtFarms.Visible = true;
                UpdateChart();
            }
            else
            {
                lvwFarms.Visible = true;
                chtFarms.Visible = false;
                UpdateListView();
            }
        }

        private void tsbCapture_Click(object sender, EventArgs e)
        {
            tsbCapture.Checked = !tsbCapture.Checked;
            if (tsbCapture.Checked)
            {
                if (tsbDataFiddler.Checked)
                    DataFiddler.Capture();
                else
                    DataHttpAnalyzer.Capture();
            }
            else
            {
                if (tsbDataFiddler.Checked)
                    DataFiddler.Release();
                else
                    DataHttpAnalyzer.Release();
            }
        }

        private void tsbAutoCapture_Click(object sender, EventArgs e)
        {
            Settings.Default.AutoCapture = !Settings.Default.AutoCapture;
            tsbAutoCapture.Checked = Settings.Default.AutoCapture;
        }

        private void tsbDataFiddler_Click(object sender, EventArgs e)
        {
            if (tsbCapture.Checked) tsbCapture_Click(null, null);
            Settings.Default.CapturerEngine = "Fiddler";
            tsbDataFiddler.Checked = true;
            tsbDataHttpAnalyzer.Checked = false;
            MessageBox.Show("您选用了Fiddler代理数据捕获引擎。\n若您使用的是非IE浏览器，需要将浏览器代理设置为使用IE代理，或手工设置代理为127.0.0.1:8877，此模式方能正常工作。", "Fiddler代理数据捕获引擎", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (tsbCapture.Checked) tsbCapture_Click(null, null);
        }

        private void tsbDataHttpAnalyzer_Click(object sender, EventArgs e)
        {
            if (tsbCapture.Checked) tsbCapture_Click(null, null);
            Settings.Default.CapturerEngine = "HttpAnalyzer";
            tsbDataHttpAnalyzer.Checked = true;
            tsbDataFiddler.Checked = false;
            MessageBox.Show("您选用了HttpAnalyzer驱动数据捕获引擎。\n您需要正确安装HttpAnalyzer软件，此模式方能正常工作。", "HttpAnalyzer驱动数据捕获引擎", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (tsbCapture.Checked) tsbCapture_Click(null, null);
        }

        private void tsbTopMost_Click(object sender, EventArgs e)
        {
            Settings.Default.TopMost = !Settings.Default.TopMost;
            tsbTopMost.Checked = Settings.Default.TopMost;
            TopMost = Settings.Default.TopMost;
        }

        private void tsbListShowOne_Click(object sender, EventArgs e)
        {
            ListShowOneId = (lvwFarms.SelectedItems[0].Tag as ProductGroup).Parent.OwnerId;
            tsbView.SelectedIndex = 1;
        }

        private void tsbNotifyItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem[] nis = new ToolStripMenuItem[] { tsbNotifyAll, tsbNotifyValuable100, tsbNotifyValuable300, tsbNotifySelfonly, tsbNotifyNone };
            for (int i = 0; i < nis.Length; i++)
            {
                if (nis[i] == sender as ToolStripMenuItem)
                {
                    nis[i].Checked = true;
                    Settings.Default.MuteMode = i;
                }
                else
                    nis[i].Checked = false;
            }
            UpdateAlarm();
        }

        private void tsbNotifyWindow_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem[] nws = new ToolStripMenuItem[] { tsbNotifyWindowNone, tsbNotifyWindowIcon, tsbNotifyWindowFloat };
            for (int i = 0; i < nws.Length; i++)
            {
                if (nws[i] == sender as ToolStripMenuItem)
                {
                    nws[i].Checked = true;
                    Settings.Default.NotifyWindow = i;
                }
                else
                    nws[i].Checked = false;
            }
        }

        private void tsbNameMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem[] nns = new ToolStripMenuItem[] { tsbNameModeBoth, tsbNameModeXiaoyou, tsbNameModeQzone };
            for (int i = 0; i < nns.Length; i++)
            {
                if (nns[i] == sender as ToolStripMenuItem)
                {
                    nns[i].Checked = true;
                    Settings.Default.NameMode = i;
                }
                else
                    nns[i].Checked = false;
            }
            OnFarmsChanged();
        }

        private void tsbNotifySound_Click(object sender, EventArgs e)
        {
            Settings.Default.NotifySound = !Settings.Default.NotifySound;
            tsbNotifySound.Checked = Settings.Default.NotifySound;
        }

        private void tsbAutoClick_Click(object sender, EventArgs e)
        {
            MessageBox.Show("把此菜单项拖到目标位置，即可开始自动点击。需停止请移动鼠标10像素以上的距离。", "自动快速点击", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbAutoClick_MouseDown(object sender, MouseEventArgs e)
        {
            btnDrag.Capture = true;
            btnDrag.Cursor = Cursors.Cross;
        }

        private void btnDrag_MouseUp(object sender, MouseEventArgs e)
        {
            btnDrag.Capture = false;
            btnDrag.Cursor = Cursors.Default;
            if (!new Rectangle(Location, Size).Contains(Control.MousePosition)) new Thread(AutoClickProcedure).Start();
        }
        #endregion

        #region 更新列表及更新倒计时函数
        Dictionary<ProductGroup, ListViewItem> dgl = new Dictionary<ProductGroup, ListViewItem>();
        private void UpdateListView()
        {
            FarmTick.GroupEvaluator ge;
            if (tsbView.SelectedIndex == 0) ge = ListShowAll;
            else ge = ListShowOne;

            if (WindowState != FormWindowState.Minimized && lvwFarms.Visible)
            {
                List<ProductGroup> groups = FarmTick.GetSortedGroups();
                foreach (ProductGroup g in groups)
                {
                    if (ge(g))
                    {
                        ListViewItem lvi;
                        if (dgl.ContainsKey(g))
                        {
                            lvi = dgl[g];
                            if (lvi.SubItems[1].Text != g.RipingString) lvi.SubItems[1].Text = g.RipingString;
                            if (lvi.Group != GetItemGroup(g.RipeOffset)) lvi.Group = GetItemGroup(g.RipeOffset);
                        }
                        else
                        {
                            lvi = new ListViewItem(new string[] { 
                                g.Parent.OwnerName, 
                                g.RipingString, 
                                String.Format("预计{0}金币", g.ExpectValue.ToString()) },
                                g.RipeName, GetItemGroup(g.RipeOffset));
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
            }
        }

        // 更新图表显示
        private void UpdateChart()
        {
            if (WindowState != FormWindowState.Minimized && chtFarms.Visible)
            {
                switch (tsbView.SelectedIndex)
                {
                    case 2:
                        ChartShowSource();
                        break;
                    case 3:
                        ChartShowTimeBlock();
                        break;
                    default:
                        break;
                }
            }
        }

        private ListViewGroup GetItemGroup(int offset)
        {
            if (offset <= 0) return lvwFarms.Groups[0];
            else if (offset <= 600) return lvwFarms.Groups[1];
            else if (offset <= 3600) return lvwFarms.Groups[2];
            else if (offset <= 14400) return lvwFarms.Groups[3];
            else return lvwFarms.Groups[4];
        }

        private FarmTick.GroupEvaluator GetGroupEvaluator()
        {
            FarmTick.GroupEvaluator[] ges = new FarmTick.GroupEvaluator[]{NotifyAll, NotifyValuable100, NotifyValuable300, NotifySelfonly, NotifyNone};
            return ges[Settings.Default.MuteMode];
        }

        private void UpdateAlarm()
        {
            FarmTick.RipeInfoCollection ris;

            ris = FarmTick.GetFirstRipeCollection(GetGroupEvaluator());
            if (ris.Count > 0)
            {
                nfyAlarm.Text = string.Format("FarmTick v0.9\n{0} {1}\n{2}({3}金币)", ris.RipeTime.ToShortTimeString(), TruncateString(ris.OwnerName, 15), TruncateString(ris.ProductString, 15), ris.ExpectValue);
                tmrNotifyIcon.Interval = (ris[0].RipeOffset + 1) * 1000;
                tmrNotifyIcon.Tag = ris;
                tmrNotifyIcon.Enabled = true;
            }
            else
                tmrNotifyIcon.Enabled = false;

            ris = FarmTick.GetFirstRipeCollection(g => { return(GetGroupEvaluator()(g) && g.RipeOffset > 60); });
            if (tsbAlarm.Checked && ris.Count > 0 && ris[0].RipeOffset > 60)
            {
                tmrAlarm.Interval = (ris[0].RipeOffset - 60) * 1000;
                tmrAlarm.Tag = ris;
                tmrAlarm.Enabled = true;
            }
            else
                tmrAlarm.Enabled = false;

            ris = FarmTick.GetFirstRipeCollection(g => { return(GetGroupEvaluator()(g) && g.RipeOffset > 10); });
            if (tsbAlarm2.Checked && ris.Count > 0 && ris[0].RipeOffset > 10)
            {
                tmrAlarm2.Interval = (ris[0].RipeOffset - 10) * 1000;
                tmrAlarm2.Tag = ris;
                tmrAlarm2.Enabled = true;
            }
            else
                tmrAlarm2.Enabled = false;
        }
        #endregion

        #region 定时器事件
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void tmrAlarm_Tick(object sender, EventArgs e)
        {
            FarmTick.RipeInfoCollection ris = tmrAlarm.Tag as FarmTick.RipeInfoCollection;
            tmrAlarm.Enabled = false;
            ShowNotify(string.Format("{0}", ris.OwnerName), string.Format("{0}已进入60秒倒计时\n预期价值:{1}", ris.ProductString, ris.ExpectValue), imgPlants.Images[ris[0].RipeName]);
            UpdateAlarm();
        }

        private void tmrAlarm2_Tick(object sender, EventArgs e)
        {
            FarmTick.RipeInfoCollection ris = tmrAlarm2.Tag as FarmTick.RipeInfoCollection;
            tmrAlarm2.Enabled = false;
            ShowNotify(string.Format("{0}", ris.OwnerName), string.Format("{0}已进入10秒倒计时\n预期价值:{1}", ris.ProductString, ris.ExpectValue), imgPlants.Images[ris[0].RipeName]);
            UpdateAlarm();
        }

        private void tmrNotifyIcon_Tick(object sender, EventArgs e)
        {
            tmrNotifyIcon.Enabled = false;
            UpdateAlarm();
        }
        #endregion

        #region 工具函数
        public static string GetFSOFilename(string domain, string appname, string flashname, string solname)
        {
            string root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Macromedia\Flash Player\#SharedObjects");
            DirectoryInfo di = new DirectoryInfo(root);
            string basedir = di.GetDirectories()[0].FullName;
            return Path.Combine(basedir, domain + @"\" + appname + @"\" + flashname + @"\" + solname);
        }

        private static string TruncateString(string src, int length)
        {
            if (src.Length <= length) return src;
            else return src.Substring(0, length - 3) + "...";
        }

        protected void ShowNotify(string title, string text, Image image)
        {
            if (Settings.Default.NotifySound) new System.Media.SoundPlayer(@"res\alarm.wav").Play();
            if (Settings.Default.NotifyWindow == 1)
                nfyAlarm.ShowBalloonTip(10000, title, text, ToolTipIcon.Info);
            else if (Settings.Default.NotifyWindow == 2)
                fNotify.ShowMessage(title, text, image, 15);
        }

        protected void OnFarmsChanged()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { OnFarmsChanged(); }));
                return;
            }
            lblHint.Visible = false;
            dgl.Clear();
            lvwFarms.Items.Clear();
            UpdateListView();
            UpdateChart();
            UpdateAlarm();
        }

        public void Serialize()
        {
            try
            {
                Settings.Default.Save();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "保存设置错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Deserialize()
        {
            try
            {
                Settings.Default.Reload();
                tsbAlarm.Checked = Settings.Default.Timer60Sec;
                tsbAlarm2.Checked = Settings.Default.Timer10Sec;
                tsbShowRiped.Checked = Settings.Default.ShowRiped;
                tsbAutoCapture.Checked = Settings.Default.AutoCapture;
                ToolStripMenuItem[] nis = new ToolStripMenuItem[] { tsbNotifyAll, tsbNotifyValuable100, tsbNotifyValuable300, tsbNotifySelfonly, tsbNotifyNone };
                nis[Settings.Default.MuteMode].Checked = true;
                tsbDataHttpAnalyzer.Checked = Settings.Default.CapturerEngine.ToLower() == "httpanalyzer";
                tsbDataFiddler.Checked = !tsbDataHttpAnalyzer.Checked;
                ToolStripMenuItem[] nws = new ToolStripMenuItem[] { tsbNotifyWindowNone, tsbNotifyWindowIcon, tsbNotifyWindowFloat };
                nws[Settings.Default.NotifyWindow].Checked = true;
                ToolStripMenuItem[] nns = new ToolStripMenuItem[] { tsbNameModeBoth, tsbNameModeXiaoyou, tsbNameModeQzone };
                nns[Settings.Default.NameMode].Checked = true;
                tsbNotifySound.Checked = Settings.Default.NotifySound;
                tsbTopMost.Checked = Settings.Default.TopMost;
                TopMost = Settings.Default.TopMost;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "读取设置错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

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
        }
        #endregion
    }
}
