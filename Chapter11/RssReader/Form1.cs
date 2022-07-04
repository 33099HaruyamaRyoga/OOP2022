using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        IEnumerable<string> xTitle,xLink;
        public Form1() {
            InitializeComponent();
        }

        private void btRssGet_Click(object sender, EventArgs e) {

            using (var wc = new WebClient()) {

                var stream = wc.OpenRead(cbRssUrl.Text);

                var xdoc = XDocument.Load(stream);
                xTitle = xdoc.Root.Descendants("item").Select(x => (string)x.Element("title"));
                xLink = xdoc.Root.Descendants("item").Select(x => (string)x.Element("link"));

                foreach (var data in xTitle) {

                    lbRssTitle.Items.Add(data);
                }
            }
        }

        private void btBack_Click(object sender, EventArgs e) {
            wbBrowser.GoBack();
        }

        private void btFoward_Click(object sender, EventArgs e) {
            wbBrowser.GoForward();
        }

        private void wvBrowser_NavigationCompleted(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationCompletedEventArgs e) {
            btBack.Enabled = wvBrowser.CanGoBack;
            btFoward.Enabled = wvBrowser.CanGoForward;
        }

        private void Form1_Load(object sender, EventArgs e) {
            //進む・戻るボタンのマスク設定
            btBack.Enabled = wvBrowser.CanGoBack;
            btFoward.Enabled = wvBrowser.CanGoForward;
        }

        private void lsRssTitle_Click(object sender, EventArgs e) {
            
            int index = lbRssTitle.SelectedIndex; //選択した箇所のインデックスを取得（０～）
            if (index == -1) return;
            
            var url = xLink.ElementAt(index);
            wvBrowser.Source = new Uri(url);
        }
    }
}
