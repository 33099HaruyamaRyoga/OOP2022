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
    public partial class Tohoku : Form {
        public Tohoku() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Tohoku_Load(object sender, EventArgs e) {
            plTohokuMap.BackgroundImageLayout = ImageLayout.Zoom;
            plTohokuMap.BackgroundImage = System.Drawing.Image.FromFile(@"C:\Users\infosys\Pictures\map-tohoku-188x400.png");
        }

        private void btAomori_Click(object sender, EventArgs e) {
            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };

            var dString = wc.DownloadString("https://weather.tsukumijima.net/api/forecast/city/020000");

            var json = JsonConvert.DeserializeObject<Rootobject>(dString);

            tbAomori.Text = json.text;
        }

        private void tbAomori_TextChanged(object sender, EventArgs e) {

        }
    }
}
