
namespace RssReader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.btRssGet = new System.Windows.Forms.Button();
            this.cbRssUrl = new System.Windows.Forms.ComboBox();
            this.LsBox = new System.Windows.Forms.ListBox();
            this.wbBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btRssGet
            // 
            this.btRssGet.Location = new System.Drawing.Point(787, 12);
            this.btRssGet.Name = "btRssGet";
            this.btRssGet.Size = new System.Drawing.Size(75, 23);
            this.btRssGet.TabIndex = 0;
            this.btRssGet.Text = "取得";
            this.btRssGet.UseVisualStyleBackColor = true;
            this.btRssGet.Click += new System.EventHandler(this.btRssGet_Click);
            // 
            // cbRssUrl
            // 
            this.cbRssUrl.FormattingEnabled = true;
            this.cbRssUrl.Location = new System.Drawing.Point(12, 15);
            this.cbRssUrl.Name = "cbRssUrl";
            this.cbRssUrl.Size = new System.Drawing.Size(769, 20);
            this.cbRssUrl.TabIndex = 1;
            // 
            // LsBox
            // 
            this.LsBox.FormattingEnabled = true;
            this.LsBox.ItemHeight = 12;
            this.LsBox.Location = new System.Drawing.Point(12, 52);
            this.LsBox.Name = "LsBox";
            this.LsBox.Size = new System.Drawing.Size(225, 628);
            this.LsBox.TabIndex = 2;
            // 
            // wbBrowser
            // 
            this.wbBrowser.Location = new System.Drawing.Point(253, 52);
            this.wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBrowser.Name = "wbBrowser";
            this.wbBrowser.Size = new System.Drawing.Size(609, 628);
            this.wbBrowser.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 708);
            this.Controls.Add(this.wbBrowser);
            this.Controls.Add(this.LsBox);
            this.Controls.Add(this.cbRssUrl);
            this.Controls.Add(this.btRssGet);
            this.Name = "Form1";
            this.Text = "RSSReader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRssGet;
        private System.Windows.Forms.ComboBox cbRssUrl;
        private System.Windows.Forms.ListBox LsBox;
        private System.Windows.Forms.WebBrowser wbBrowser;
    }
}

