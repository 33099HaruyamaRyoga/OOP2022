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

        private void Form1_Load(object sender, EventArgs e) {
            StreamReader sr = new StreamReader(@"areacode.csv", Encoding.GetEncoding("Shift_JIS"));{
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

                var ws = wc.DownloadString($"https://www.jma.go.jp/bosai/forecast/data/forecast/{value}.json");
                var ws_3days = wc.DownloadString($"https://www.jma.go.jp/bosai/forecast/data/overview_forecast/{value}.json");

                var json_w = JsonConvert.DeserializeObject<Class1[]>(ws);
                var json_w_3days = JsonConvert.DeserializeObject<Rootobject_3days>(ws_3days);

                var weatherCodeToday = json_w[0].timeSeries[0].areas[0].weatherCodes[0];
                var weatherCodeTomorrow = json_w[0].timeSeries[0].areas[0].weatherCodes[1];
                var weatherCodeDayAfterTomorrow = json_w[0].timeSeries[0].areas[0].weatherCodes[2];

                pb1.ImageLocation = $"https://www.jma.go.jp/bosai/forecast/img/{weatherCodeToday}.png";
                pb2.ImageLocation = $"https://www.jma.go.jp/bosai/forecast/img/{weatherCodeTomorrow}.png";
                pb3.ImageLocation = $"https://www.jma.go.jp/bosai/forecast/img/{weatherCodeDayAfterTomorrow}.png";

                tbOverview.Text = json_w_3days.text;
                tb1.Text = json_w[0].timeSeries[0].areas[0].weathers[0];
                tb2.Text = json_w[0].timeSeries[0].areas[0].weathers[1];
                tb3.Text = json_w[0].timeSeries[0].areas[0].weathers[2];

                tbLowest1.Text = json_w[1].timeSeries[1].areas[0].tempsMin[1];
                tbMax1.Text = json_w[1].timeSeries[1].areas[0].tempsMax[1];
                tbLowest2.Text = json_w[1].timeSeries[1].areas[0].tempsMin[2];
                tbMax2.Text = json_w[1].timeSeries[1].areas[0].tempsMax[2];
                tbLowest3.Text = json_w[1].timeSeries[1].areas[0].tempsMin[3];
                tbMax3.Text = json_w[1].timeSeries[1].areas[0].tempsMax[3];
            }
            catch (Exception) {

            }
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
