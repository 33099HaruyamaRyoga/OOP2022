using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ColorChecker {
    public partial class MainWindow : Window {

        //コンストラクタ
        public MainWindow() {
            InitializeComponent();

            DataContext = GetColorList();

        }



        /// <summary>
        /// すべての色を取得するメソッド
        /// </summary>
        /// <returns></returns>
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            setColor();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            setColor();
        }

        private void setColor() {
            var r = byte.Parse(rValue.Text.ToString());
            var g = byte.Parse(gValue.Text.ToString());
            var b = byte.Parse(bValue.Text.ToString());
            ColorLabel.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var mycolor = (MyColor)((ComboBox)sender).SelectedItem;

            rSlider.Value = mycolor.Color.R;
            gSlider.Value = mycolor.Color.G;
            bSlider.Value = mycolor.Color.B;
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {

        }
    }


    /// <summary>
    /// 色と色名を保持するクラス
    /// </summary>
    public class MyColor {
        public Color Color { get; set; }
        public string Name { get; set; }
    }
}


