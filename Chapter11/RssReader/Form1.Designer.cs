
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
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.wbBrowser = new System.Windows.Forms.WebBrowser();
            this.btBack = new System.Windows.Forms.Button();
            this.btFoward = new System.Windows.Forms.Button();
            this.wvBrowser = new Microsoft.Toolkit.Forms.UI.Controls.WebView();
            ((System.ComponentModel.ISupportInitialize)(this.wvBrowser)).BeginInit();
            this.SuspendLayout();
            // 
            // btRssGet
            // 
            this.btRssGet.Location = new System.Drawing.Point(644, 13);
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
            this.cbRssUrl.Size = new System.Drawing.Size(607, 20);
            this.cbRssUrl.TabIndex = 1;
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(12, 52);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(225, 628);
            this.lbRssTitle.TabIndex = 2;
            this.lbRssTitle.Click += new System.EventHandler(this.lsRssTitle_Click);
            // 
            // wbBrowser
            // 
            this.wbBrowser.Location = new System.Drawing.Point(253, 52);
            this.wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBrowser.Name = "wbBrowser";
            this.wbBrowser.ScriptErrorsSuppressed = true;
            this.wbBrowser.Size = new System.Drawing.Size(609, 628);
            this.wbBrowser.TabIndex = 3;
            // 
            // btBack
            // 
            this.btBack.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btBack.Location = new System.Drawing.Point(742, 5);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(30, 31);
            this.btBack.TabIndex = 4;
            this.btBack.Text = "◀";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btFoward
            // 
            this.btFoward.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btFoward.Location = new System.Drawing.Point(778, 5);
            this.btFoward.Name = "btFoward";
            this.btFoward.Size = new System.Drawing.Size(30, 31);
            this.btFoward.TabIndex = 4;
            this.btFoward.Text = "▶";
            this.btFoward.UseVisualStyleBackColor = true;
            this.btFoward.Click += new System.EventHandler(this.btFoward_Click);
            // 
            // wvBrowser
            // 
            this.wvBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wvBrowser.Location = new System.Drawing.Point(253, 52);
            this.wvBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wvBrowser.Name = "wvBrowser";
            this.wvBrowser.Size = new System.Drawing.Size(591, 628);
            this.wvBrowser.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 708);
            this.Controls.Add(this.wvBrowser);
            this.Controls.Add(this.btFoward);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.wbBrowser);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.cbRssUrl);
            this.Controls.Add(this.btRssGet);
            this.Name = "Form1";
            this.Text = "RSSReader";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wvBrowser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRssGet;
        private System.Windows.Forms.ComboBox cbRssUrl;
        private System.Windows.Forms.ListBox lbRssTitle;
        private System.Windows.Forms.WebBrowser wbBrowser;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btFoward;
        private Microsoft.Toolkit.Forms.UI.Controls.WebView wvBrowser;
    }
}

