using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberGame {
    public partial class Form1 : Form {

        private Random rand = new Random();//乱数オブジェクト生成

        //乱数
        private int randomnumber;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            //乱数取得
            randomnumber = rand.Next(minValue: 1, maxValue: 50 );
        }

        private void Judge_Click(object sender, EventArgs e) {

            if(randomnumber == num1.Value) {
                tb1.Text = ("正解！");
            } else {
                tb1.Text = ("不正解！");
            }
        }
    }
}
