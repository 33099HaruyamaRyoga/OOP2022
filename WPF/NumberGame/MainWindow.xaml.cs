using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NumberGame {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        Random rand = new Random();

        private int correctNumber; //正解ナンバー

        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button bt = (Button)sender;

            if(bt.Content.ToString() == correctNumber.ToString()) {
                infoDisp.Text = "正解！";
                bt.Background = Brushes.LightPink;
            } else {
                infoDisp.Text = int.Parse((string)bt.Content) < correctNumber
                                            ? "もっと大きいです！" : "もっと小さいです！";
                bt.Background = int.Parse((string)bt.Content) < correctNumber
                                            ? Brushes.MediumPurple : Brushes.MediumPurple;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            infoDisp.Text = "ゲームスタート";
            correctNumber = rand.Next(minValue: 1, maxValue: 25); //正解ナンバーを確定
        }
    }
}
