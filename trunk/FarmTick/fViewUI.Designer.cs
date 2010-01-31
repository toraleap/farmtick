namespace FarmTick
{
    partial class fViewUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fViewUI));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("刚成熟", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("即将收获", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("一小时以内", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("四小时以内", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("四小时以后", System.Windows.Forms.HorizontalAlignment.Left);
            this.tbsView = new System.Windows.Forms.ToolStrip();
            this.tsbUITime = new System.Windows.Forms.ToolStripButton();
            this.tsbUIUser = new System.Windows.Forms.ToolStripButton();
            this.tsbUIValue = new System.Windows.Forms.ToolStripButton();
            this.tsbUIHistory = new System.Windows.Forms.ToolStripButton();
            this.tsbTopMost = new System.Windows.Forms.ToolStripButton();
            this.tbsOptions = new System.Windows.Forms.ToolStrip();
            this.tsbCapture = new System.Windows.Forms.ToolStripButton();
            this.tsbDisplay = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbTimeMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbTimeAuto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbTimeExactly = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbTimeCountdown = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNameMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNameModeBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNameModeXiaoyou = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNameModeQzone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbShowHungry = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotify = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbAlarm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAlarm2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMuteMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyValuable100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyValuable300 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifySelfonly = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyNone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNotifyWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyWindowNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyWindowIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyWindowTransparent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifySound = new System.Windows.Forms.ToolStripMenuItem();
            this.l = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbCaptureOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAutoCapture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAutoProxy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAutoClick = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbEnableDock = new System.Windows.Forms.ToolStripMenuItem();
            this.imgProduct = new System.Windows.Forms.ImageList(this.components);
            this.nfyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.tmrAlarm = new System.Windows.Forms.Timer(this.components);
            this.tmrAlarm2 = new System.Windows.Forms.Timer(this.components);
            this.tmrNotifyIcon = new System.Windows.Forms.Timer(this.components);
            this.tmrDock = new System.Windows.Forms.Timer(this.components);
            this.lvwFarms = new FarmTick.DoubleBufferedListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.tbsView.SuspendLayout();
            this.tbsOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbsView
            // 
            this.tbsView.AutoSize = false;
            this.tbsView.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbsView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUITime,
            this.tsbUIUser,
            this.tsbUIValue,
            this.tsbUIHistory,
            this.tsbTopMost});
            this.tbsView.Location = new System.Drawing.Point(0, 0);
            this.tbsView.Name = "tbsView";
            this.tbsView.Size = new System.Drawing.Size(236, 24);
            this.tbsView.TabIndex = 7;
            this.tbsView.Text = "toolStrip1";
            // 
            // tsbUITime
            // 
            this.tsbUITime.Image = ((System.Drawing.Image)(resources.GetObject("tsbUITime.Image")));
            this.tsbUITime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUITime.Name = "tsbUITime";
            this.tsbUITime.Size = new System.Drawing.Size(52, 21);
            this.tsbUITime.Text = "时间";
            this.tsbUITime.Click += new System.EventHandler(this.tsbViewStyle_Click);
            // 
            // tsbUIUser
            // 
            this.tsbUIUser.Image = ((System.Drawing.Image)(resources.GetObject("tsbUIUser.Image")));
            this.tsbUIUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUIUser.Name = "tsbUIUser";
            this.tsbUIUser.Size = new System.Drawing.Size(52, 21);
            this.tsbUIUser.Text = "用户";
            this.tsbUIUser.Click += new System.EventHandler(this.tsbViewStyle_Click);
            // 
            // tsbUIValue
            // 
            this.tsbUIValue.Image = ((System.Drawing.Image)(resources.GetObject("tsbUIValue.Image")));
            this.tsbUIValue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUIValue.Name = "tsbUIValue";
            this.tsbUIValue.Size = new System.Drawing.Size(52, 21);
            this.tsbUIValue.Text = "价值";
            this.tsbUIValue.Click += new System.EventHandler(this.tsbViewStyle_Click);
            // 
            // tsbUIHistory
            // 
            this.tsbUIHistory.Image = ((System.Drawing.Image)(resources.GetObject("tsbUIHistory.Image")));
            this.tsbUIHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUIHistory.Name = "tsbUIHistory";
            this.tsbUIHistory.Size = new System.Drawing.Size(52, 21);
            this.tsbUIHistory.Text = "可收";
            this.tsbUIHistory.Click += new System.EventHandler(this.tsbViewStyle_Click);
            // 
            // tsbTopMost
            // 
            this.tsbTopMost.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbTopMost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTopMost.Image = ((System.Drawing.Image)(resources.GetObject("tsbTopMost.Image")));
            this.tsbTopMost.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTopMost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTopMost.Name = "tsbTopMost";
            this.tsbTopMost.Size = new System.Drawing.Size(23, 21);
            this.tsbTopMost.Text = "置顶";
            this.tsbTopMost.Click += new System.EventHandler(this.tsbTopMost_Click);
            // 
            // tbsOptions
            // 
            this.tbsOptions.AutoSize = false;
            this.tbsOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbsOptions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCapture,
            this.tsbDisplay,
            this.tsbNotify,
            this.l});
            this.tbsOptions.Location = new System.Drawing.Point(0, 389);
            this.tbsOptions.Name = "tbsOptions";
            this.tbsOptions.Size = new System.Drawing.Size(236, 24);
            this.tbsOptions.TabIndex = 8;
            this.tbsOptions.Text = "toolStrip1";
            // 
            // tsbCapture
            // 
            this.tsbCapture.Image = ((System.Drawing.Image)(resources.GetObject("tsbCapture.Image")));
            this.tsbCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCapture.Name = "tsbCapture";
            this.tsbCapture.Size = new System.Drawing.Size(52, 21);
            this.tsbCapture.Text = "捕获";
            this.tsbCapture.ToolTipText = "进入捕获状态后才能自动更新农牧场数据";
            this.tsbCapture.Click += new System.EventHandler(this.tsbCapture_Click);
            // 
            // tsbDisplay
            // 
            this.tsbDisplay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbTimeMode,
            this.tsbNameMode,
            this.tsbShowHungry});
            this.tsbDisplay.Image = ((System.Drawing.Image)(resources.GetObject("tsbDisplay.Image")));
            this.tsbDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDisplay.Name = "tsbDisplay";
            this.tsbDisplay.Size = new System.Drawing.Size(61, 21);
            this.tsbDisplay.Text = "显示";
            // 
            // tsbTimeMode
            // 
            this.tsbTimeMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbTimeAuto,
            this.tsbTimeExactly,
            this.tsbTimeCountdown});
            this.tsbTimeMode.Image = ((System.Drawing.Image)(resources.GetObject("tsbTimeMode.Image")));
            this.tsbTimeMode.Name = "tsbTimeMode";
            this.tsbTimeMode.Size = new System.Drawing.Size(166, 22);
            this.tsbTimeMode.Text = "时间显示模式(&T)";
            // 
            // tsbTimeAuto
            // 
            this.tsbTimeAuto.Name = "tsbTimeAuto";
            this.tsbTimeAuto.Size = new System.Drawing.Size(140, 22);
            this.tsbTimeAuto.Text = "智能模式(&I)";
            this.tsbTimeAuto.Click += new System.EventHandler(this.tsbTimeMode_Click);
            // 
            // tsbTimeExactly
            // 
            this.tsbTimeExactly.Name = "tsbTimeExactly";
            this.tsbTimeExactly.Size = new System.Drawing.Size(140, 22);
            this.tsbTimeExactly.Text = "精确时间(&A)";
            this.tsbTimeExactly.Click += new System.EventHandler(this.tsbTimeMode_Click);
            // 
            // tsbTimeCountdown
            // 
            this.tsbTimeCountdown.Name = "tsbTimeCountdown";
            this.tsbTimeCountdown.Size = new System.Drawing.Size(140, 22);
            this.tsbTimeCountdown.Text = "倒计时(&C)";
            this.tsbTimeCountdown.Click += new System.EventHandler(this.tsbTimeMode_Click);
            // 
            // tsbNameMode
            // 
            this.tsbNameMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNameModeBoth,
            this.tsbNameModeXiaoyou,
            this.tsbNameModeQzone});
            this.tsbNameMode.Image = ((System.Drawing.Image)(resources.GetObject("tsbNameMode.Image")));
            this.tsbNameMode.Name = "tsbNameMode";
            this.tsbNameMode.Size = new System.Drawing.Size(166, 22);
            this.tsbNameMode.Text = "昵称显示模式(&N)";
            // 
            // tsbNameModeBoth
            // 
            this.tsbNameModeBoth.Name = "tsbNameModeBoth";
            this.tsbNameModeBoth.Size = new System.Drawing.Size(140, 22);
            this.tsbNameModeBoth.Text = "同时显示(&B)";
            this.tsbNameModeBoth.Click += new System.EventHandler(this.tsbNameMode_Click);
            // 
            // tsbNameModeXiaoyou
            // 
            this.tsbNameModeXiaoyou.Name = "tsbNameModeXiaoyou";
            this.tsbNameModeXiaoyou.Size = new System.Drawing.Size(140, 22);
            this.tsbNameModeXiaoyou.Text = "校友优先(&X)";
            this.tsbNameModeXiaoyou.Click += new System.EventHandler(this.tsbNameMode_Click);
            // 
            // tsbNameModeQzone
            // 
            this.tsbNameModeQzone.Name = "tsbNameModeQzone";
            this.tsbNameModeQzone.Size = new System.Drawing.Size(140, 22);
            this.tsbNameModeQzone.Text = "空间优先(&Z)";
            this.tsbNameModeQzone.Click += new System.EventHandler(this.tsbNameMode_Click);
            // 
            // tsbShowHungry
            // 
            this.tsbShowHungry.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowHungry.Image")));
            this.tsbShowHungry.Name = "tsbShowHungry";
            this.tsbShowHungry.Size = new System.Drawing.Size(166, 22);
            this.tsbShowHungry.Text = "显示饥饿动物(&H)";
            this.tsbShowHungry.Click += new System.EventHandler(this.tsbShowHungry_Click);
            // 
            // tsbNotify
            // 
            this.tsbNotify.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAlarm,
            this.tsbAlarm2,
            this.toolStripMenuItem2,
            this.tsbMuteMode,
            this.toolStripMenuItem1,
            this.tsbNotifyWindow,
            this.tsbNotifySound});
            this.tsbNotify.Image = ((System.Drawing.Image)(resources.GetObject("tsbNotify.Image")));
            this.tsbNotify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNotify.Name = "tsbNotify";
            this.tsbNotify.Size = new System.Drawing.Size(61, 21);
            this.tsbNotify.Text = "提醒";
            // 
            // tsbAlarm
            // 
            this.tsbAlarm.Image = ((System.Drawing.Image)(resources.GetObject("tsbAlarm.Image")));
            this.tsbAlarm.Name = "tsbAlarm";
            this.tsbAlarm.Size = new System.Drawing.Size(153, 22);
            this.tsbAlarm.Text = "60秒提醒(&M)";
            this.tsbAlarm.Click += new System.EventHandler(this.tsbAlarm_Click);
            // 
            // tsbAlarm2
            // 
            this.tsbAlarm2.Image = ((System.Drawing.Image)(resources.GetObject("tsbAlarm2.Image")));
            this.tsbAlarm2.Name = "tsbAlarm2";
            this.tsbAlarm2.Size = new System.Drawing.Size(153, 22);
            this.tsbAlarm2.Text = "10秒提醒(&T)";
            this.tsbAlarm2.Click += new System.EventHandler(this.tsbAlarm2_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(150, 6);
            // 
            // tsbMuteMode
            // 
            this.tsbMuteMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNotifyAll,
            this.tsbNotifyValuable100,
            this.tsbNotifyValuable300,
            this.tsbNotifySelfonly,
            this.tsbNotifyNone});
            this.tsbMuteMode.Image = ((System.Drawing.Image)(resources.GetObject("tsbMuteMode.Image")));
            this.tsbMuteMode.Name = "tsbMuteMode";
            this.tsbMuteMode.Size = new System.Drawing.Size(153, 22);
            this.tsbMuteMode.Text = "免打扰模式(&U)";
            // 
            // tsbNotifyAll
            // 
            this.tsbNotifyAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbNotifyAll.Image")));
            this.tsbNotifyAll.Name = "tsbNotifyAll";
            this.tsbNotifyAll.Size = new System.Drawing.Size(211, 22);
            this.tsbNotifyAll.Text = "全部提示(&A)";
            this.tsbNotifyAll.Click += new System.EventHandler(this.tsbNotifyItem_Click);
            // 
            // tsbNotifyValuable100
            // 
            this.tsbNotifyValuable100.Image = ((System.Drawing.Image)(resources.GetObject("tsbNotifyValuable100.Image")));
            this.tsbNotifyValuable100.Name = "tsbNotifyValuable100";
            this.tsbNotifyValuable100.Size = new System.Drawing.Size(211, 22);
            this.tsbNotifyValuable100.Text = "价值大于100金币提示(&O)";
            this.tsbNotifyValuable100.Click += new System.EventHandler(this.tsbNotifyItem_Click);
            // 
            // tsbNotifyValuable300
            // 
            this.tsbNotifyValuable300.Image = ((System.Drawing.Image)(resources.GetObject("tsbNotifyValuable300.Image")));
            this.tsbNotifyValuable300.Name = "tsbNotifyValuable300";
            this.tsbNotifyValuable300.Size = new System.Drawing.Size(211, 22);
            this.tsbNotifyValuable300.Text = "价值大于300金币提示(&T)";
            this.tsbNotifyValuable300.Click += new System.EventHandler(this.tsbNotifyItem_Click);
            // 
            // tsbNotifySelfonly
            // 
            this.tsbNotifySelfonly.Image = ((System.Drawing.Image)(resources.GetObject("tsbNotifySelfonly.Image")));
            this.tsbNotifySelfonly.Name = "tsbNotifySelfonly";
            this.tsbNotifySelfonly.Size = new System.Drawing.Size(211, 22);
            this.tsbNotifySelfonly.Text = "仅提示自己的农场牧场(&S)";
            this.tsbNotifySelfonly.Click += new System.EventHandler(this.tsbNotifyItem_Click);
            // 
            // tsbNotifyNone
            // 
            this.tsbNotifyNone.Image = ((System.Drawing.Image)(resources.GetObject("tsbNotifyNone.Image")));
            this.tsbNotifyNone.Name = "tsbNotifyNone";
            this.tsbNotifyNone.Size = new System.Drawing.Size(211, 22);
            this.tsbNotifyNone.Text = "全部不提示(&N)";
            this.tsbNotifyNone.Click += new System.EventHandler(this.tsbNotifyItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
            // 
            // tsbNotifyWindow
            // 
            this.tsbNotifyWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNotifyWindowNone,
            this.tsbNotifyWindowIcon,
            this.tsbNotifyWindowTransparent});
            this.tsbNotifyWindow.Image = ((System.Drawing.Image)(resources.GetObject("tsbNotifyWindow.Image")));
            this.tsbNotifyWindow.Name = "tsbNotifyWindow";
            this.tsbNotifyWindow.Size = new System.Drawing.Size(153, 22);
            this.tsbNotifyWindow.Text = "提醒窗口(&W)";
            // 
            // tsbNotifyWindowNone
            // 
            this.tsbNotifyWindowNone.Image = ((System.Drawing.Image)(resources.GetObject("tsbNotifyWindowNone.Image")));
            this.tsbNotifyWindowNone.Name = "tsbNotifyWindowNone";
            this.tsbNotifyWindowNone.Size = new System.Drawing.Size(175, 22);
            this.tsbNotifyWindowNone.Text = "无(&N)";
            this.tsbNotifyWindowNone.Click += new System.EventHandler(this.tsbNotifyWindow_Click);
            // 
            // tsbNotifyWindowIcon
            // 
            this.tsbNotifyWindowIcon.Image = ((System.Drawing.Image)(resources.GetObject("tsbNotifyWindowIcon.Image")));
            this.tsbNotifyWindowIcon.Name = "tsbNotifyWindowIcon";
            this.tsbNotifyWindowIcon.Size = new System.Drawing.Size(175, 22);
            this.tsbNotifyWindowIcon.Text = "系统通知区图标(&I)";
            this.tsbNotifyWindowIcon.Click += new System.EventHandler(this.tsbNotifyWindow_Click);
            // 
            // tsbNotifyWindowTransparent
            // 
            this.tsbNotifyWindowTransparent.Image = ((System.Drawing.Image)(resources.GetObject("tsbNotifyWindowTransparent.Image")));
            this.tsbNotifyWindowTransparent.Name = "tsbNotifyWindowTransparent";
            this.tsbNotifyWindowTransparent.Size = new System.Drawing.Size(175, 22);
            this.tsbNotifyWindowTransparent.Text = "浮动半透明提示(&T)";
            this.tsbNotifyWindowTransparent.Click += new System.EventHandler(this.tsbNotifyWindow_Click);
            // 
            // tsbNotifySound
            // 
            this.tsbNotifySound.Image = ((System.Drawing.Image)(resources.GetObject("tsbNotifySound.Image")));
            this.tsbNotifySound.Name = "tsbNotifySound";
            this.tsbNotifySound.Size = new System.Drawing.Size(153, 22);
            this.tsbNotifySound.Text = "声音通知(&S)";
            this.tsbNotifySound.Click += new System.EventHandler(this.tsbNotifySound_Click);
            // 
            // l
            // 
            this.l.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCaptureOptions,
            this.tsbAutoClick,
            this.tsbEnableDock});
            this.l.Image = ((System.Drawing.Image)(resources.GetObject("l.Image")));
            this.l.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(61, 21);
            this.l.Text = "设置";
            // 
            // tsbCaptureOptions
            // 
            this.tsbCaptureOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAutoCapture,
            this.tsbAutoProxy});
            this.tsbCaptureOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsbCaptureOptions.Image")));
            this.tsbCaptureOptions.Name = "tsbCaptureOptions";
            this.tsbCaptureOptions.Size = new System.Drawing.Size(165, 22);
            this.tsbCaptureOptions.Text = "捕获选项(&C)";
            // 
            // tsbAutoCapture
            // 
            this.tsbAutoCapture.Image = ((System.Drawing.Image)(resources.GetObject("tsbAutoCapture.Image")));
            this.tsbAutoCapture.Name = "tsbAutoCapture";
            this.tsbAutoCapture.Size = new System.Drawing.Size(235, 22);
            this.tsbAutoCapture.Text = "启动时自动开始捕获(&A)";
            this.tsbAutoCapture.Click += new System.EventHandler(this.tsbAutoCapture_Click);
            // 
            // tsbAutoProxy
            // 
            this.tsbAutoProxy.Image = ((System.Drawing.Image)(resources.GetObject("tsbAutoProxy.Image")));
            this.tsbAutoProxy.Name = "tsbAutoProxy";
            this.tsbAutoProxy.Size = new System.Drawing.Size(235, 22);
            this.tsbAutoProxy.Text = "捕获时自动设置代理服务器(P)";
            this.tsbAutoProxy.Click += new System.EventHandler(this.tsbAutoProxy_Click);
            // 
            // tsbAutoClick
            // 
            this.tsbAutoClick.Image = ((System.Drawing.Image)(resources.GetObject("tsbAutoClick.Image")));
            this.tsbAutoClick.Name = "tsbAutoClick";
            this.tsbAutoClick.Size = new System.Drawing.Size(165, 22);
            this.tsbAutoClick.Text = "启用连点热键(&K)";
            this.tsbAutoClick.Click += new System.EventHandler(this.tsbAutoClick_Click);
            // 
            // tsbEnableDock
            // 
            this.tsbEnableDock.Image = ((System.Drawing.Image)(resources.GetObject("tsbEnableDock.Image")));
            this.tsbEnableDock.Name = "tsbEnableDock";
            this.tsbEnableDock.Size = new System.Drawing.Size(165, 22);
            this.tsbEnableDock.Text = "允许边缘停靠(&D)";
            this.tsbEnableDock.Click += new System.EventHandler(this.tsbEnableDock_Click);
            // 
            // imgProduct
            // 
            this.imgProduct.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imgProduct.ImageSize = new System.Drawing.Size(61, 61);
            this.imgProduct.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // nfyIcon
            // 
            this.nfyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nfyIcon.Icon")));
            this.nfyIcon.Text = "FarmTick v1.0";
            this.nfyIcon.Visible = true;
            this.nfyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfyIcon_MouseDoubleClick);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            this.tmrUpdate.Interval = 1000;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // tmrAlarm
            // 
            this.tmrAlarm.Tick += new System.EventHandler(this.tmrAlarm_Tick);
            // 
            // tmrAlarm2
            // 
            this.tmrAlarm2.Tick += new System.EventHandler(this.tmrAlarm2_Tick);
            // 
            // tmrNotifyIcon
            // 
            this.tmrNotifyIcon.Tick += new System.EventHandler(this.tmrNotifyIcon_Tick);
            // 
            // tmrDock
            // 
            this.tmrDock.Enabled = true;
            this.tmrDock.Tick += new System.EventHandler(this.tmrDock_Tick);
            // 
            // lvwFarms
            // 
            this.lvwFarms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwFarms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwFarms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwFarms.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwFarms.FullRowSelect = true;
            listViewGroup1.Header = "刚成熟";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "即将收获";
            listViewGroup2.Name = "listViewGroup2";
            listViewGroup3.Header = "一小时以内";
            listViewGroup3.Name = "listViewGroup3";
            listViewGroup4.Header = "四小时以内";
            listViewGroup4.Name = "listViewGroup4";
            listViewGroup5.Header = "四小时以后";
            listViewGroup5.Name = "listViewGroup5";
            this.lvwFarms.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5});
            this.lvwFarms.LargeImageList = this.imgProduct;
            this.lvwFarms.Location = new System.Drawing.Point(0, 24);
            this.lvwFarms.MultiSelect = false;
            this.lvwFarms.Name = "lvwFarms";
            this.lvwFarms.Size = new System.Drawing.Size(236, 365);
            this.lvwFarms.SmallImageList = this.imgProduct;
            this.lvwFarms.TabIndex = 5;
            this.lvwFarms.TileSize = new System.Drawing.Size(218, 64);
            this.lvwFarms.UseCompatibleStateImageBehavior = false;
            this.lvwFarms.View = System.Windows.Forms.View.Tile;
            this.lvwFarms.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwFarms_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "好友昵称";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "产品成熟时间";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "预计收益";
            // 
            // fViewUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 413);
            this.Controls.Add(this.lvwFarms);
            this.Controls.Add(this.tbsOptions);
            this.Controls.Add(this.tbsView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(252, 172);
            this.Name = "fViewUI";
            this.Text = "FarmTick v1.0";
            this.Load += new System.EventHandler(this.fViewUI_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fViewUI_FormClosed);
            this.Resize += new System.EventHandler(this.fViewUI_Resize);
            this.LocationChanged += new System.EventHandler(this.fViewUI_LocationChanged);
            this.tbsView.ResumeLayout(false);
            this.tbsView.PerformLayout();
            this.tbsOptions.ResumeLayout(false);
            this.tbsOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferedListView lvwFarms;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStrip tbsView;
        private System.Windows.Forms.ToolStripButton tsbUITime;
        private System.Windows.Forms.ToolStripButton tsbUIUser;
        private System.Windows.Forms.ToolStripButton tsbUIHistory;
        private System.Windows.Forms.ToolStrip tbsOptions;
        private System.Windows.Forms.ImageList imgProduct;
        private System.Windows.Forms.ToolStripButton tsbTopMost;
        private System.Windows.Forms.ToolStripButton tsbCapture;
        private System.Windows.Forms.ToolStripDropDownButton tsbDisplay;
        private System.Windows.Forms.ToolStripDropDownButton tsbNotify;
        private System.Windows.Forms.ToolStripDropDownButton l;
        private System.Windows.Forms.ToolStripMenuItem tsbTimeMode;
        private System.Windows.Forms.ToolStripMenuItem tsbTimeExactly;
        private System.Windows.Forms.ToolStripMenuItem tsbTimeCountdown;
        private System.Windows.Forms.ToolStripMenuItem tsbTimeAuto;
        private System.Windows.Forms.ToolStripButton tsbUIValue;
        private System.Windows.Forms.ToolStripMenuItem tsbShowHungry;
        private System.Windows.Forms.NotifyIcon nfyIcon;
        private System.Windows.Forms.ToolStripMenuItem tsbNameMode;
        private System.Windows.Forms.ToolStripMenuItem tsbNameModeBoth;
        private System.Windows.Forms.ToolStripMenuItem tsbNameModeXiaoyou;
        private System.Windows.Forms.ToolStripMenuItem tsbNameModeQzone;
        private System.Windows.Forms.ToolStripMenuItem tsbCaptureOptions;
        private System.Windows.Forms.ToolStripMenuItem tsbAutoCapture;
        private System.Windows.Forms.ToolStripMenuItem tsbAutoProxy;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyWindow;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifySound;
        private System.Windows.Forms.ToolStripMenuItem tsbAutoClick;
        private System.Windows.Forms.Timer tmrAlarm;
        private System.Windows.Forms.Timer tmrAlarm2;
        private System.Windows.Forms.Timer tmrNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem tsbAlarm;
        private System.Windows.Forms.ToolStripMenuItem tsbAlarm2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsbMuteMode;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyAll;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyValuable100;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyValuable300;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifySelfonly;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyNone;
        private System.Windows.Forms.Timer tmrDock;
        private System.Windows.Forms.ToolStripMenuItem tsbEnableDock;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyWindowNone;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyWindowIcon;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyWindowTransparent;
    }
}