namespace RSS阅读器2
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.RssUrlTb = new System.Windows.Forms.TextBox();
            this.RssUrlGO = new System.Windows.Forms.Button();
            this.RssListTb = new System.Windows.Forms.ListBox();
            this.RssNewsList = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RssWeb = new System.Windows.Forms.WebBrowser();
            this.newsUrl = new System.Windows.Forms.TextBox();
            this.ControlBt = new System.Windows.Forms.Button();
            this.newsListBox = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RssUrlTb
            // 
            this.RssUrlTb.Location = new System.Drawing.Point(12, 14);
            this.RssUrlTb.Name = "RssUrlTb";
            this.RssUrlTb.Size = new System.Drawing.Size(380, 21);
            this.RssUrlTb.TabIndex = 0;
            // 
            // RssUrlGO
            // 
            this.RssUrlGO.Location = new System.Drawing.Point(408, 14);
            this.RssUrlGO.Name = "RssUrlGO";
            this.RssUrlGO.Size = new System.Drawing.Size(51, 23);
            this.RssUrlGO.TabIndex = 1;
            this.RssUrlGO.Text = "GO";
            this.RssUrlGO.UseVisualStyleBackColor = true;
            this.RssUrlGO.Click += new System.EventHandler(this.RssUrlGO_Click);
            // 
            // RssListTb
            // 
            this.RssListTb.FormattingEnabled = true;
            this.RssListTb.ItemHeight = 12;
            this.RssListTb.Location = new System.Drawing.Point(12, 41);
            this.RssListTb.Name = "RssListTb";
            this.RssListTb.Size = new System.Drawing.Size(181, 376);
            this.RssListTb.TabIndex = 2;
            this.RssListTb.SelectedIndexChanged += new System.EventHandler(this.RssListTb_SelectedIndexChanged);
            // 
            // RssNewsList
            // 
            this.RssNewsList.Location = new System.Drawing.Point(199, 41);
            this.RssNewsList.Name = "RssNewsList";
            this.RssNewsList.Size = new System.Drawing.Size(10, 374);
            this.RssNewsList.TabIndex = 3;
            this.RssNewsList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RssNewsList_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RssWeb);
            this.panel1.Location = new System.Drawing.Point(493, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 376);
            this.panel1.TabIndex = 4;
            // 
            // RssWeb
            // 
            this.RssWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RssWeb.Location = new System.Drawing.Point(0, 0);
            this.RssWeb.MinimumSize = new System.Drawing.Size(20, 20);
            this.RssWeb.Name = "RssWeb";
            this.RssWeb.Size = new System.Drawing.Size(485, 376);
            this.RssWeb.TabIndex = 0;
            // 
            // newsUrl
            // 
            this.newsUrl.Location = new System.Drawing.Point(493, 12);
            this.newsUrl.Name = "newsUrl";
            this.newsUrl.Size = new System.Drawing.Size(469, 21);
            this.newsUrl.TabIndex = 5;
            // 
            // ControlBt
            // 
            this.ControlBt.Location = new System.Drawing.Point(118, 421);
            this.ControlBt.Name = "ControlBt";
            this.ControlBt.Size = new System.Drawing.Size(75, 23);
            this.ControlBt.TabIndex = 6;
            this.ControlBt.Text = "管理";
            this.ControlBt.UseVisualStyleBackColor = true;
            this.ControlBt.Click += new System.EventHandler(this.ControlBt_Click);
            // 
            // newsListBox
            // 
            this.newsListBox.FormattingEnabled = true;
            this.newsListBox.ItemHeight = 12;
            this.newsListBox.Location = new System.Drawing.Point(215, 43);
            this.newsListBox.Name = "newsListBox";
            this.newsListBox.Size = new System.Drawing.Size(272, 376);
            this.newsListBox.TabIndex = 7;
            this.newsListBox.SelectedIndexChanged += new System.EventHandler(this.newsListBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(990, 456);
            this.Controls.Add(this.newsListBox);
            this.Controls.Add(this.ControlBt);
            this.Controls.Add(this.newsUrl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RssNewsList);
            this.Controls.Add(this.RssListTb);
            this.Controls.Add(this.RssUrlGO);
            this.Controls.Add(this.RssUrlTb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RssUrlTb;
        private System.Windows.Forms.Button RssUrlGO;
        private System.Windows.Forms.ListBox RssListTb;
        private System.Windows.Forms.TreeView RssNewsList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser RssWeb;
        private System.Windows.Forms.TextBox newsUrl;
        private System.Windows.Forms.Button ControlBt;
        private System.Windows.Forms.ListBox newsListBox;
    }
}

