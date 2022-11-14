using Newtonsoft.Json;
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

namespace WeatherApp {
    public partial class 天気予報アプリ : Form {
        public 天気予報アプリ() {
            InitializeComponent();
        }

        private void btWeatherGet_Click(object sender, EventArgs e) {

            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };

            var dString = wc.DownloadString("https://weather.tsukumijima.net/api/forecast/city/370000");

            var json = JsonConvert.DeserializeObject<Rootobject>(dString);

            //tbWeatherInfo.Text = json.description.bodyText;

        }

        private void button1_Click(object sender, EventArgs e) {

            Tohoku tohoku = new Tohoku();
            tohoku.Show();
        }

        private void 天気予報アプリ_Load(object sender, EventArgs e) {
            plMap.BackgroundImageLayout = ImageLayout.Zoom;
            plMap.BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\infosys\Pictures\map-japan-10006.png");
        }
    }
}
