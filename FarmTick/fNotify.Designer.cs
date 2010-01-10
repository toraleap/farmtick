namespace FarmTick
{
    partial class fNotify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fNotify));
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tmrFade = new System.Windows.Forms.Timer(this.components);
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.tmrRadar = new System.Windows.Forms.Timer(this.components);
            this.tmrAutoMove = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // picProduct
            // 
            this.picProduct.Location = new System.Drawing.Point(12, 12);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(61, 61);
            this.picProduct.TabIndex = 0;
            this.picProduct.TabStop = false;
            this.picProduct.Click += new System.EventHandler(this.fNotify_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(73, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(56, 17);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "好友昵称";
            this.lblTitle.Click += new System.EventHandler(this.fNotify_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.White;
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.Location = new System.Drawing.Point(84, 34);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(39, 16);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "label2";
            this.lblInfo.Click += new System.EventHandler(this.fNotify_Click);
            // 
            // tmrFade
            // 
            this.tmrFade.Tick += new System.EventHandler(this.tmrFade_Tick);
            // 
            // picBackground
            // 
            this.picBackground.Image = ((System.Drawing.Image)(resources.GetObject("picBackground.Image")));
            this.picBackground.Location = new System.Drawing.Point(12, 16);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(276, 53);
            this.picBackground.TabIndex = 3;
            this.picBackground.TabStop = false;
            this.picBackground.Click += new System.EventHandler(this.fNotify_Click);
            // 
            // tmrRadar
            // 
            this.tmrRadar.Interval = 1000;
            this.tmrRadar.Tag = "0";
            this.tmrRadar.Tick += new System.EventHandler(this.tmrRadar_Tick);
            // 
            // tmrAutoMove
            // 
            this.tmrAutoMove.Tick += new System.EventHandler(this.tmrAutoMove_Tick);
            // 
            // fNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(300, 85);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picProduct);
            this.Controls.Add(this.picBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fNotify";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "fNotify";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Click += new System.EventHandler(this.fNotify_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Timer tmrFade;
        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.Timer tmrRadar;
        private System.Windows.Forms.Timer tmrAutoMove;
    }
}