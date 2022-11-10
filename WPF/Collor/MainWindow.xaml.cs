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

        List<MyColor> colorList = new List<MyColor>();

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            setColor();
        }

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
            //正解
            MyColor stColor = new MyColor();
            var r = byte.Parse(rValue.Text);
            var g = byte.Parse(gValue.Text);
            var b = byte.Parse(bValue.Text);
            stColor.Color = Color.FromRgb(r, g, b);

            var colorName = ((IEnumerable<MyColor>)DataContext)
                                .Where(c => c.Color.R == stColor.Color.R &&
                                            c.Color.G == stColor.Color.G &&
                                            c.Color.B == stColor.Color.B ).FirstOrDefault();

            stockList.Items.Add(colorName?.Name ?? "R：" + rValue.Text + "　G：" + gValue.Text + "　B：" + bValue.Text);
            //stockList.Items.Add(rValue.Text);
            //stockList.Items.Add(gValue.Text);
            //stockList.Items.Add(bValue.Text);

            //rValue.Text = stockList.SelectedItem.ToString();
            //gValue.Text = stockList.SelectedItem.ToString();
            //bValue.Text = stockList.SelectedItem.ToString();

            //if (stockList.Items.Contains(rValue.Text) != true) {
            //    stockList.Items.Add(rValue.Text);
            //}
            //if (stockList.Items.Contains(gValue.Text) != true) {
            //    stockList.Items.Add(gValue.Text);
            //}
            //if (stockList.Items.Contains(bValue.Text) != true) {
            //    stockList.Items.Add(bValue.Text);
            //}
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            rSlider.Value = colorList[stockList.SelectedIndex].Color.R;
            gSlider.Value = colorList[stockList.SelectedIndex].Color.G;
            bSlider.Value = colorList[stockList.SelectedIndex].Color.B;
            setColor();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) {
            int sel = stockList.SelectedIndex;

            stockList.Items.RemoveAt(sel);
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


