namespace FarmTick
{
    partial class fMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("刚成熟", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("即将收获", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("一小时以内", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("四小时以内", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("四小时以后", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ofdXmlFile = new System.Windows.Forms.OpenFileDialog();
            this.lvwFarms = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.imgPlants = new System.Windows.Forms.ImageList(this.components);
            this.tbsMain = new System.Windows.Forms.ToolStrip();
            this.tsbCapture = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbView = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMuteMode = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbNotifyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyValuable100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyValuable300 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifySelfonly = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyNone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAlarm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAlarm2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyWindowNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyWindowIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifyWindowFloat = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNotifySound = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbShowRiped = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNameMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNameModeBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNameModeXiaoyou = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNameModeQzone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAutoCapture = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDataCapturer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDataFiddler = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDataHttpAnalyzer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAutoClick = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbTopMost = new System.Windows.Forms.ToolStripButton();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.tmrAlarm = new System.Windows.Forms.Timer(this.components);
            this.nfyAlarm = new System.Windows.Forms.NotifyIcon(this.components);
            this.tmrAlarm2 = new System.Windows.Forms.Timer(this.components);
            this.lblHint = new System.Windows.Forms.Label();
            this.chtFarms = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmsListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsbListShowOne = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDrag = new System.Windows.Forms.Button();
            this.tmrNotifyIcon = new System.Windows.Forms.Timer(this.components);
            this.tbsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtFarms)).BeginInit();
            this.cmsListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdXmlFile
            // 
            this.ofdXmlFile.DefaultExt = "xml";
            this.ofdXmlFile.Filter = "Httpanalyzer XML 导出文件|*.xml|所有文件|*.*";
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
            this.lvwFarms.LargeImageList = this.imgPlants;
            this.lvwFarms.Location = new System.Drawing.Point(0, 35);
            this.lvwFarms.MultiSelect = false;
            this.lvwFarms.Name = "lvwFarms";
            this.lvwFarms.Size = new System.Drawing.Size(261, 375);
            this.lvwFarms.TabIndex = 4;
            this.lvwFarms.TileSize = new System.Drawing.Size(240, 64);
            this.lvwFarms.UseCompatibleStateImageBehavior = false;
            this.lvwFarms.View = System.Windows.Forms.View.Tile;
            this.lvwFarms.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwFarms_MouseUp);
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
            // imgPlants
            // 
            this.imgPlants.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgPlants.ImageSize = new System.Drawing.Size(61, 61);
            this.imgPlants.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tbsMain
            // 
            this.tbsMain.AutoSize = false;
            this.tbsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCapture,
            this.toolStripSeparator2,
            this.tsbView,
            this.toolStripSeparator1,
            this.tsbMuteMode,
            this.tsbOptions,
            this.tsbTopMost});
            this.tbsMain.Location = new System.Drawing.Point(0, 0);
            this.tbsMain.Name = "tbsMain";
            this.tbsMain.Size = new System.Drawing.Size(261, 35);
            this.tbsMain.TabIndex = 6;
            this.tbsMain.Text = "toolStrip1";
            // 
            // tsbCapture
            // 
            this.tsbCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCapture.Image = ((System.Drawing.Image)(resources.GetObject("tsbCapture.Image")));
            this.tsbCapture.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCapture.Name = "tsbCapture";
            this.tsbCapture.Size = new System.Drawing.Size(28, 32);
            this.tsbCapture.Text = "捕获并分析农场操作";
            this.tsbCapture.Click += new System.EventHandler(this.tsbCapture_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // tsbView
            // 
            this.tsbView.AutoSize = false;
            this.tsbView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsbView.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tsbView.Items.AddRange(new object[] {
            "全部列表",
            "单人列表",
            "收益来源",
            "时间收益图"});
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(90, 25);
            this.tsbView.SelectedIndexChanged += new System.EventHandler(this.tsbView_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // tsbMuteMode
            // 
            this.tsbMuteMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMuteMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNotifyAll,
            this.tsbNotifyValuable100,
            this.tsbNotifyValuable300,
            this.tsbNotifySelfonly,
            this.tsbNotifyNone,
            this.toolStripMenuItem2,
            this.tsbAlarm,
            this.tsbAlarm2,
            this.tsbNotifyWindow,
            this.tsbNotifySound});
            this.tsbMuteMode.Image = ((System.Drawing.Image)(resources.GetObject("tsbMuteMode.Image")));
            this.tsbMuteMode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMuteMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMuteMode.Name = "tsbMuteMode";
            this.tsbMuteMode.Size = new System.Drawing.Size(37, 32);
            this.tsbMuteMode.Text = "提醒设置";
            // 
            // tsbNotifyAll
            // 
            this.tsbNotifyAll.Name = "tsbNotifyAll";
            this.tsbNotifyAll.Size = new System.Drawing.Size(211, 22);
            this.tsbNotifyAll.Text = "全部提示(&A)";
            this.tsbNotifyAll.Click += new System.EventHandler(this.tsbNotifyItem_Click);
            // 
            // tsbNotifyValuable100
            // 
            this.tsbNotifyValuable100.Name = "tsbNotifyValuable100";
            this.tsbNotifyValuable100.Size = new System.Drawing.Size(211, 22);
            this.tsbNotifyValuable100.Text = "价值大于100金币提示(&O)";
            this.tsbNotifyValuable100.Click += new System.EventHandler(this.tsbNotifyItem_Click);
            // 
            // tsbNotifyValuable300
            // 
            this.tsbNotifyValuable300.Name = "tsbNotifyValuable300";
            this.tsbNotifyValuable300.Size = new System.Drawing.Size(211, 22);
            this.tsbNotifyValuable300.Text = "价值大于300金币提示(&T)";
            this.tsbNotifyValuable300.Click += new System.EventHandler(this.tsbNotifyItem_Click);
            // 
            // tsbNotifySelfonly
            // 
            this.tsbNotifySelfonly.Name = "tsbNotifySelfonly";
            this.tsbNotifySelfonly.Size = new System.Drawing.Size(211, 22);
            this.tsbNotifySelfonly.Text = "仅提示自己的农场牧场(&S)";
            this.tsbNotifySelfonly.Click += new System.EventHandler(this.tsbNotifyItem_Click);
            // 
            // tsbNotifyNone
            // 
            this.tsbNotifyNone.Name = "tsbNotifyNone";
            this.tsbNotifyNone.Size = new System.Drawing.Size(211, 22);
            this.tsbNotifyNone.Text = "全部不提示(&N)";
            this.tsbNotifyNone.Click += new System.EventHandler(this.tsbNotifyItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(208, 6);
            // 
            // tsbAlarm
            // 
            this.tsbAlarm.Checked = true;
            this.tsbAlarm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbAlarm.Name = "tsbAlarm";
            this.tsbAlarm.Size = new System.Drawing.Size(211, 22);
            this.tsbAlarm.Text = "收取前1分钟通知(&M)";
            this.tsbAlarm.Click += new System.EventHandler(this.tsbAlarm_Click);
            // 
            // tsbAlarm2
            // 
            this.tsbAlarm2.Checked = true;
            this.tsbAlarm2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbAlarm2.Name = "tsbAlarm2";
            this.tsbAlarm2.Size = new System.Drawing.Size(211, 22);
            this.tsbAlarm2.Text = "收取前10秒钟通知(&E)";
            this.tsbAlarm2.Click += new System.EventHandler(this.tsbAlarm2_Click);
            // 
            // tsbNotifyWindow
            // 
            this.tsbNotifyWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNotifyWindowNone,
            this.tsbNotifyWindowIcon,
            this.tsbNotifyWindowFloat});
            this.tsbNotifyWindow.Name = "tsbNotifyWindow";
            this.tsbNotifyWindow.Size = new System.Drawing.Size(211, 22);
            this.tsbNotifyWindow.Text = "提醒窗口(&W)";
            // 
            // tsbNotifyWindowNone
            // 
            this.tsbNotifyWindowNone.Name = "tsbNotifyWindowNone";
            this.tsbNotifyWindowNone.Size = new System.Drawing.Size(175, 22);
            this.tsbNotifyWindowNone.Text = "无提醒窗口(&N)";
            this.tsbNotifyWindowNone.Click += new System.EventHandler(this.tsbNotifyWindow_Click);
            // 
            // tsbNotifyWindowIcon
            // 
            this.tsbNotifyWindowIcon.Name = "tsbNotifyWindowIcon";
            this.tsbNotifyWindowIcon.Size = new System.Drawing.Size(175, 22);
            this.tsbNotifyWindowIcon.Text = "系统通知区气泡(&P)";
            this.tsbNotifyWindowIcon.Click += new System.EventHandler(this.tsbNotifyWindow_Click);
            // 
            // tsbNotifyWindowFloat
            // 
            this.tsbNotifyWindowFloat.Name = "tsbNotifyWindowFloat";
            this.tsbNotifyWindowFloat.Size = new System.Drawing.Size(175, 22);
            this.tsbNotifyWindowFloat.Text = "右下浮起窗口(&F)";
            this.tsbNotifyWindowFloat.Click += new System.EventHandler(this.tsbNotifyWindow_Click);
            // 
            // tsbNotifySound
            // 
            this.tsbNotifySound.Name = "tsbNotifySound";
            this.tsbNotifySound.Size = new System.Drawing.Size(211, 22);
            this.tsbNotifySound.Text = "声音提醒(&U)";
            this.tsbNotifySound.Click += new System.EventHandler(this.tsbNotifySound_Click);
            // 
            // tsbOptions
            // 
            this.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbShowRiped,
            this.tsbNameMode,
            this.tsbAutoCapture,
            this.toolStripMenuItem1,
            this.tsbDataCapturer,
            this.tsbAutoClick});
            this.tsbOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsbOptions.Image")));
            this.tsbOptions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(37, 32);
            this.tsbOptions.Text = "选项";
            this.tsbOptions.ToolTipText = "选项列表";
            // 
            // tsbShowRiped
            // 
            this.tsbShowRiped.Name = "tsbShowRiped";
            this.tsbShowRiped.Size = new System.Drawing.Size(240, 22);
            this.tsbShowRiped.Text = "显示刚成熟/可生产(&R)";
            this.tsbShowRiped.Click += new System.EventHandler(this.tsbShowRiped_Click);
            // 
            // tsbNameMode
            // 
            this.tsbNameMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNameModeBoth,
            this.tsbNameModeXiaoyou,
            this.tsbNameModeQzone});
            this.tsbNameMode.Name = "tsbNameMode";
            this.tsbNameMode.Size = new System.Drawing.Size(240, 22);
            this.tsbNameMode.Text = "昵称显示方式(&N)";
            // 
            // tsbNameModeBoth
            // 
            this.tsbNameModeBoth.Name = "tsbNameModeBoth";
            this.tsbNameModeBoth.Size = new System.Drawing.Size(200, 22);
            this.tsbNameModeBoth.Text = "同时显示校友及空间(&B)";
            this.tsbNameModeBoth.Click += new System.EventHandler(this.tsbNameMode_Click);
            // 
            // tsbNameModeXiaoyou
            // 
            this.tsbNameModeXiaoyou.Name = "tsbNameModeXiaoyou";
            this.tsbNameModeXiaoyou.Size = new System.Drawing.Size(200, 22);
            this.tsbNameModeXiaoyou.Text = "校友昵称优先(&X)";
            this.tsbNameModeXiaoyou.Click += new System.EventHandler(this.tsbNameMode_Click);
            // 
            // tsbNameModeQzone
            // 
            this.tsbNameModeQzone.Name = "tsbNameModeQzone";
            this.tsbNameModeQzone.Size = new System.Drawing.Size(200, 22);
            this.tsbNameModeQzone.Text = "空间昵称优先(&Q)";
            this.tsbNameModeQzone.Click += new System.EventHandler(this.tsbNameMode_Click);
            // 
            // tsbAutoCapture
            // 
            this.tsbAutoCapture.Checked = true;
            this.tsbAutoCapture.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbAutoCapture.Name = "tsbAutoCapture";
            this.tsbAutoCapture.Size = new System.Drawing.Size(240, 22);
            this.tsbAutoCapture.Text = "启动时自动进入捕获状态(&A)";
            this.tsbAutoCapture.Click += new System.EventHandler(this.tsbAutoCapture_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(237, 6);
            // 
            // tsbDataCapturer
            // 
            this.tsbDataCapturer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDataFiddler,
            this.tsbDataHttpAnalyzer});
            this.tsbDataCapturer.Name = "tsbDataCapturer";
            this.tsbDataCapturer.Size = new System.Drawing.Size(240, 22);
            this.tsbDataCapturer.Text = "选择数据捕获引擎(&C)";
            // 
            // tsbDataFiddler
            // 
            this.tsbDataFiddler.Checked = true;
            this.tsbDataFiddler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbDataFiddler.Name = "tsbDataFiddler";
            this.tsbDataFiddler.Size = new System.Drawing.Size(152, 22);
            this.tsbDataFiddler.Text = "&Fiddler (推荐)";
            this.tsbDataFiddler.Click += new System.EventHandler(this.tsbDataFiddler_Click);
            // 
            // tsbDataHttpAnalyzer
            // 
            this.tsbDataHttpAnalyzer.Name = "tsbDataHttpAnalyzer";
            this.tsbDataHttpAnalyzer.Size = new System.Drawing.Size(152, 22);
            this.tsbDataHttpAnalyzer.Text = "&HttpAnalyzer";
            this.tsbDataHttpAnalyzer.Click += new System.EventHandler(this.tsbDataHttpAnalyzer_Click);
            // 
            // tsbAutoClick
            // 
            this.tsbAutoClick.Name = "tsbAutoClick";
            this.tsbAutoClick.Size = new System.Drawing.Size(240, 22);
            this.tsbAutoClick.Text = "自动连续点击(拖动到目标位置)";
            this.tsbAutoClick.ToolTipText = "把此菜单项拖到目标位置，即可开始自动连续点击。\r\n要停止请向任意方向移动鼠标10个像素以上距离。";
            this.tsbAutoClick.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsbAutoClick_MouseDown);
            this.tsbAutoClick.Click += new System.EventHandler(this.tsbAutoClick_Click);
            // 
            // tsbTopMost
            // 
            this.tsbTopMost.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbTopMost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTopMost.Image = ((System.Drawing.Image)(resources.GetObject("tsbTopMost.Image")));
            this.tsbTopMost.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTopMost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTopMost.Name = "tsbTopMost";
            this.tsbTopMost.Size = new System.Drawing.Size(28, 32);
            this.tsbTopMost.Text = "窗口置顶显示";
            this.tsbTopMost.Click += new System.EventHandler(this.tsbTopMost_Click);
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 1000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // tmrAlarm
            // 
            this.tmrAlarm.Tick += new System.EventHandler(this.tmrAlarm_Tick);
            // 
            // nfyAlarm
            // 
            this.nfyAlarm.Icon = ((System.Drawing.Icon)(resources.GetObject("nfyAlarm.Icon")));
            this.nfyAlarm.Text = "FarmTick v0.9 双击弹出主窗口";
            this.nfyAlarm.Visible = true;
            this.nfyAlarm.DoubleClick += new System.EventHandler(this.nfyAlarm_DoubleClick);
            // 
            // tmrAlarm2
            // 
            this.tmrAlarm2.Tick += new System.EventHandler(this.tmrAlarm2_Tick);
            // 
            // lblHint
            // 
            this.lblHint.BackColor = System.Drawing.SystemColors.Window;
            this.lblHint.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHint.Location = new System.Drawing.Point(12, 47);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(237, 286);
            this.lblHint.TabIndex = 7;
            this.lblHint.Text = "操作说明\r\n\r\n1. 首次使用请先点击“重载好友列表”\r\n2. 在浏览器中进入所关注好友的农场/牧场\r\n3. enjoy it!";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHint.Visible = false;
            // 
            // chtFarms
            // 
            this.chtFarms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.chtFarms.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chtFarms.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chtFarms.BorderlineWidth = 2;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.PointDepth = 60;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.Title = "时间";
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.Title = "收益";
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartSource";
            this.chtFarms.ChartAreas.Add(chartArea1);
            this.chtFarms.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            legend1.Title = "收益列表";
            legend1.TitleFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chtFarms.Legends.Add(legend1);
            this.chtFarms.Location = new System.Drawing.Point(0, 35);
            this.chtFarms.Name = "chtFarms";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "ChartSource";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.LabelToolTip = "#VAL";
            series1.Legend = "Default";
            series1.Name = "Series1";
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series2.ChartArea = "ChartSource";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            series2.LabelToolTip = "#VAL";
            series2.Legend = "Default";
            series2.Name = "Series2";
            series3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series3.ChartArea = "ChartSource";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            series3.LabelToolTip = "#VAL";
            series3.Legend = "Default";
            series3.Name = "Series3";
            series4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series4.ChartArea = "ChartSource";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(5)))), ((int)(((byte)(100)))), ((int)(((byte)(146)))));
            series4.LabelToolTip = "#VAL";
            series4.Legend = "Default";
            series4.Name = "Series4";
            this.chtFarms.Series.Add(series1);
            this.chtFarms.Series.Add(series2);
            this.chtFarms.Series.Add(series3);
            this.chtFarms.Series.Add(series4);
            this.chtFarms.Size = new System.Drawing.Size(261, 375);
            this.chtFarms.TabIndex = 9;
            // 
            // cmsListView
            // 
            this.cmsListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbListShowOne});
            this.cmsListView.Name = "cmsListView";
            this.cmsListView.Size = new System.Drawing.Size(173, 26);
            // 
            // tsbListShowOne
            // 
            this.tsbListShowOne.Name = "tsbListShowOne";
            this.tsbListShowOne.Size = new System.Drawing.Size(172, 22);
            this.tsbListShowOne.Text = "仅显示此人的产品";
            this.tsbListShowOne.Click += new System.EventHandler(this.tsbListShowOne_Click);
            // 
            // btnDrag
            // 
            this.btnDrag.Location = new System.Drawing.Point(203, 47);
            this.btnDrag.Name = "btnDrag";
            this.btnDrag.Size = new System.Drawing.Size(46, 45);
            this.btnDrag.TabIndex = 10;
            this.btnDrag.Text = "拖动";
            this.btnDrag.UseVisualStyleBackColor = true;
            this.btnDrag.Visible = false;
            this.btnDrag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDrag_MouseUp);
            // 
            // tmrNotifyIcon
            // 
            this.tmrNotifyIcon.Tick += new System.EventHandler(this.tmrNotifyIcon_Tick);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 410);
            this.Controls.Add(this.btnDrag);
            this.Controls.Add(this.chtFarms);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lvwFarms);
            this.Controls.Add(this.tbsMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FarmTick v0.9";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fMain_FormClosed);
            this.Resize += new System.EventHandler(this.fMain_Resize);
            this.tbsMain.ResumeLayout(false);
            this.tbsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtFarms)).EndInit();
            this.cmsListView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdXmlFile;
        private System.Windows.Forms.ListView lvwFarms;
        private System.Windows.Forms.ImageList imgPlants;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStrip tbsMain;
        private System.Windows.Forms.ToolStripDropDownButton tsbOptions;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsbAlarm;
        private System.Windows.Forms.Timer tmrAlarm;
        private System.Windows.Forms.NotifyIcon nfyAlarm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsbAlarm2;
        private System.Windows.Forms.Timer tmrAlarm2;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.ToolStripMenuItem tsbShowRiped;
        private System.Windows.Forms.ToolStripComboBox tsbView;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtFarms;
        private System.Windows.Forms.ToolStripButton tsbCapture;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsbAutoCapture;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsbDataCapturer;
        private System.Windows.Forms.ToolStripMenuItem tsbDataFiddler;
        private System.Windows.Forms.ToolStripMenuItem tsbDataHttpAnalyzer;
        private System.Windows.Forms.ToolStripButton tsbTopMost;
        private System.Windows.Forms.ContextMenuStrip cmsListView;
        private System.Windows.Forms.ToolStripMenuItem tsbListShowOne;
        private System.Windows.Forms.ToolStripDropDownButton tsbMuteMode;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyAll;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyValuable100;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyValuable300;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifySelfonly;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyNone;
        private System.Windows.Forms.ToolStripMenuItem tsbAutoClick;
        private System.Windows.Forms.Button btnDrag;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyWindow;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyWindowNone;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyWindowIcon;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifyWindowFloat;
        private System.Windows.Forms.ToolStripMenuItem tsbNotifySound;
        private System.Windows.Forms.Timer tmrNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem tsbNameMode;
        private System.Windows.Forms.ToolStripMenuItem tsbNameModeBoth;
        private System.Windows.Forms.ToolStripMenuItem tsbNameModeXiaoyou;
        private System.Windows.Forms.ToolStripMenuItem tsbNameModeQzone;
    }
}

