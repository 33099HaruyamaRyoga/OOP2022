using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp {
    public partial class Form1 : Form {

        private Dictionary<string, string> dic = new Dictionary<string, string>();

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load_Load(object sender, EventArgs e) {
            StreamReader sr = new StreamReader(@"areacode.csv", Encoding.GetEncoding("Shift_JIS"));
            {
                while (!sr.EndOfStream) {                  
                    string Line = sr.ReadLine();
                    string[] Values = Line.Split(',');
                    dic.Add($"{Values[0]}", $"{Values[1]}");
                }
            }
        }

        private void tvArea_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                var value = dic.FirstOrDefault(x => x.Key.Equals(tvArea.SelectedNode.Text)).Value;
                if (value == null) return;

                var wc = new WebClient() { Encoding = Encoding.UTF8 };

                var wString = wc.DownloadString($"https://www.jma.go.jp/bosai/forecast/data/forecast/{value}.json");
                var wString_3days = wc.DownloadString($"https://www.jma.go.jp/bosai/forecast/data/overview_forecast/{value}.json");
            }
            catch (Exception) {

            }
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
