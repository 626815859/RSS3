namespace RSS阅读器2
{
    partial class RssControlForm
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
            this.RssList = new System.Windows.Forms.ListBox();
            this.DelBt = new System.Windows.Forms.Button();
            this.UpdateBt = new System.Windows.Forms.Button();
            this.RssLinkTb = new System.Windows.Forms.TextBox();
            this.RssTitleTb = new System.Windows.Forms.TextBox();
            this.DownLoadToExcelBt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RssList
            // 
            this.RssList.FormattingEnabled = true;
            this.RssList.ItemHeight = 15;
            this.RssList.Location = new System.Drawing.Point(16, 15);
            this.RssList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RssList.Name = "RssList";
            this.RssList.Size = new System.Drawing.Size(677, 154);
            this.RssList.TabIndex = 0;
            this.RssList.SelectedIndexChanged += new System.EventHandler(this.RssList_SelectedIndexChanged);
            // 
            // DelBt
            // 
            this.DelBt.Location = new System.Drawing.Point(727, 106);
            this.DelBt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DelBt.Name = "DelBt";
            this.DelBt.Size = new System.Drawing.Size(107, 29);
            this.DelBt.TabIndex = 1;
            this.DelBt.Text = "删除";
            this.DelBt.UseVisualStyleBackColor = true;
            this.DelBt.Click += new System.EventHandler(this.DelBt_Click);
            // 
            // UpdateBt
            // 
            this.UpdateBt.Location = new System.Drawing.Point(727, 256);
            this.UpdateBt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdateBt.Name = "UpdateBt";
            this.UpdateBt.Size = new System.Drawing.Size(100, 29);
            this.UpdateBt.TabIndex = 2;
            this.UpdateBt.Text = "保存修改";
            this.UpdateBt.UseVisualStyleBackColor = true;
            this.UpdateBt.Click += new System.EventHandler(this.UpdateBt_Click);
            // 
            // RssLinkTb
            // 
            this.RssLinkTb.Location = new System.Drawing.Point(16, 259);
            this.RssLinkTb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RssLinkTb.Name = "RssLinkTb";
            this.RssLinkTb.Size = new System.Drawing.Size(677, 25);
            this.RssLinkTb.TabIndex = 3;
            // 
            // RssTitleTb
            // 
            this.RssTitleTb.Location = new System.Drawing.Point(16, 225);
            this.RssTitleTb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RssTitleTb.Name = "RssTitleTb";
            this.RssTitleTb.Size = new System.Drawing.Size(677, 25);
            this.RssTitleTb.TabIndex = 4;
            // 
            // DownLoadToExcelBt
            // 
            this.DownLoadToExcelBt.Location = new System.Drawing.Point(727, 142);
            this.DownLoadToExcelBt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DownLoadToExcelBt.Name = "DownLoadToExcelBt";
            this.DownLoadToExcelBt.Size = new System.Drawing.Size(100, 29);
            this.DownLoadToExcelBt.TabIndex = 6;
            this.DownLoadToExcelBt.Text = "导出Excel";
            this.DownLoadToExcelBt.UseVisualStyleBackColor = true;
            this.DownLoadToExcelBt.Click += new System.EventHandler(this.DownLoadToExcelBt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 206);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "修改标题备注";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(727, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "添加订阅";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(727, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 41);
            this.button2.TabIndex = 9;
            this.button2.Text = "查看订阅";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RssControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 300);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DownLoadToExcelBt);
            this.Controls.Add(this.RssTitleTb);
            this.Controls.Add(this.RssLinkTb);
            this.Controls.Add(this.UpdateBt);
            this.Controls.Add(this.DelBt);
            this.Controls.Add(this.RssList);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RssControlForm";
            this.Text = "RssControlForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RssControlForm_FormClosing);
            this.Load += new System.EventHandler(this.RssControlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox RssList;
        private System.Windows.Forms.Button DelBt;
        private System.Windows.Forms.Button UpdateBt;
        private System.Windows.Forms.TextBox RssLinkTb;
        private System.Windows.Forms.TextBox RssTitleTb;
        private System.Windows.Forms.Button DownLoadToExcelBt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}