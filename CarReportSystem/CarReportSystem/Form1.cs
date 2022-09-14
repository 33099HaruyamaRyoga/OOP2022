using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {
        Settings settings = Settings.getInstance();

        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            //dgvCarReports.DataSource = listCarReports;
        }

        private void btPictureOpen_Click(object sender, EventArgs e) {
            ofdFileOpenDialog.Filter = "画像ファイル(*.jpg; *.png; *.bmp) | *.jpg; *.png; *.bmp";
            if (ofdFileOpenDialog.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdFileOpenDialog.FileName);
            }
        }
        private void btPictureClear_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b) {
            ImageConverter imgconv = new ImageConverter();
            Image img = (Image)imgconv.ConvertFrom(b);
            return img;
        }

        // Imageオブジェクトをバイト配列に変換
        public static byte[] ImageToByteArray(Image img) {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }

        private void btAddPerson_Click(object sender, EventArgs e) {

            DataRow newRow = infosys202210DataSet.CarReportDB.NewRow();
            newRow[1] = dtpRegistDate.Value;
            newRow[2] = cbAuthor.Text;
            newRow[3] = GetRadioButtonMakerGroup();
            newRow[4] = cbCarName.Text;
            newRow[5] = tbReport.Text;
            newRow[6] = ImageToByteArray(pbPicture.Image);
            //データセットへ新しいコードを追加
            infosys202210DataSet.CarReportDB.Rows.Add(newRow);
            //データベース更新
            this.carReportDBTableAdapter.Update(this.infosys202210DataSet.CarReportDB);


            //氏名が未入力なら登録しない
            /*if (String.IsNullOrWhiteSpace(cbAuthor.Text)) {
                MessageBox.Show("記録者が入力されていません");
                return;
            }

            CarReport newCarReport = new CarReport {

                Date = dtpRegistDate.Value,
                Auther = cbAuthor.Text,
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
                Maker = GetRadioButtonMakerGroup()
            };
            listCarReports.Add(newCarReport);
            dgvCarReports.Rows[dgvCarReports.RowCount - 1].Selected = true;

            EnabledCheck();

            setcbAuter(cbAuthor.Text);
            setcbCarName(cbCarName.Text); */

        }
        private void EnabledCheck() {
            if (listCarReports.Count() > 0) {
                //btDelete.Enabled = true;
                btUpdate.Enabled = true;
            }
        }

        private CarReport.MakerGroup GetRadioButtonMakerGroup() {
            //デフォルトの戻りを設定
            var selectedKindNumber = CarReport.MakerGroup.その他;

            if (rbToyota.Checked) {
                selectedKindNumber = CarReport.MakerGroup.トヨタ;
            }
            if (rbNissan.Checked) {
                selectedKindNumber = CarReport.MakerGroup.日産;
            }
            if (rbHonda.Checked) {
                selectedKindNumber = CarReport.MakerGroup.ホンダ;
            }
            if (rbSubaru.Checked) {
                selectedKindNumber = CarReport.MakerGroup.スバル;
            }
            if (rbForeigncar.Checked) {
                selectedKindNumber = CarReport.MakerGroup.外国車;
            }

            return selectedKindNumber;
        }

        /*
        private void dgvPersons_Click(object sender, EventArgs e) {

            if (dgvCarReports.CurrentRow == null) return;

            int index = dgvCarReports.CurrentRow.Index;

            cbAuthor.Text = listCarReports[index].Auther;
            cbCarName.Text = listCarReports[index].CarName;
            tbReport.Text = listCarReports[index].Report;
            pbPicture.Image = listCarReports[index].Picture;

            dtpRegistDate.Value =
                listCarReports[index].Registration.Year > 1900 ? listCarReports[index].Registration : DateTime.Today;

            setMakerGroup(index);　//番号種別を設定
        }
        */

        private void setMakerGroup(int index) {
            //番号種別チェック処理
            switch (listCarReports[index].Maker) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.外国車:
                    rbForeigncar.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    break;
                default:
                    break;
            }
        }

        private void btUpdate_Click(object sender, EventArgs e) {

            carReportDBDataGridView.CurrentRow.Cells[1].Value = dtpRegistDate.Value;
            carReportDBDataGridView.CurrentRow.Cells[2].Value = cbAuthor.Text;
            carReportDBDataGridView.CurrentRow.Cells[3].Value = GetRadioButtonMakerGroup();
            carReportDBDataGridView.CurrentRow.Cells[4].Value = cbCarName.Text;
            carReportDBDataGridView.CurrentRow.Cells[5].Value = tbReport.Text;
            carReportDBDataGridView.CurrentRow.Cells[6].Value = pbPicture.Image;
            //listCarReports[dgvCarReports.CurrentRow.Index].Auther = cbAuthor.Text;
            //listCarReports[dgvCarReports.CurrentRow.Index].CarName = cbCarName.Text;
            //listCarReports[dgvCarReports.CurrentRow.Index].Report = tbReport.Text;
            //listCarReports[dgvCarReports.CurrentRow.Index].Maker = GetRadioButtonMakerGroup();
            //listCarReports[dgvCarReports.CurrentRow.Index].Picture = pbPicture.Image;
            //listCarReports[dgvCarReports.CurrentRow.Index].Registration = dtpRegistDate.Value;
            //dgvCarReports.Refresh();//データグリッドビュー更新

            //データセットの中をデータベースへ反映（保存）
            this.Validate();
            this.carReportDBBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202210DataSet);
        }

        /*
        //削除ボタンが押された時の処理
        private void btDelete_Click(object sender, EventArgs e) {

            listCarReports.RemoveAt(dgvCarReports.CurrentRow.Index);
            EnabledCheck(); //マスク処理呼び出し
        }
        */

        private void setcbAuter(String Auther) {

            if (!cbAuthor.Items.Contains(Auther)) {

                cbAuthor.Items.Add(Auther);
            }
        }
        private void setcbCarName(String CarName) {

            if (!cbCarName.Items.Contains(CarName)) {

                cbCarName.Items.Add(CarName);
            }
        }

        private void btClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        /*
        private void btSave_Click(object sender, EventArgs e) {
            if (sfdSaveDialog.ShowDialog() == DialogResult.OK) {

                try {
                    //バイナリ形式でシリアル化
                    var bf = new BinaryFormatter();

                    using (FileStream fs = File.Open(sfdSaveDialog.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        */

        /*
        private void btOpen_Click(object sender, EventArgs e) {
            if (ofdFileOpenDialog.ShowDialog() == DialogResult.OK) {

                try {
                    //バイナリ形式でシリアル化
                    var bf = new BinaryFormatter();

                    using (FileStream fs = File.Open(ofdFileOpenDialog.FileName, FileMode.Open, FileAccess.Read)) {
                        //逆シリアル化して読み込む
                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvCarReports.DataSource = null;
                        dgvCarReports.DataSource = listCarReports;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }

                foreach (var item in listCarReports) {
                    setcbAuter(item.Auther);
                }
            }
            EnabledCheck(); //マスク処理呼び出し
        }
        */
        

        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColorSelect.ShowDialog() == DialogResult.OK) {
                BackColor = cdColorSelect.Color;
                settings.MainFormColor = cdColorSelect.Color.ToArgb();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {

            //設定ファイルをシリアル化
            using (var writer = XmlWriter.Create("settings.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

            try {
                //設定ファイルを逆シリアル化して背景の色を設定
                using (var reader = XmlReader.Create("settings.xml")) {
                    var serializer = new XmlSerializer(typeof(Settings));
                    settings = serializer.Deserialize(reader) as Settings;
                    BackColor = Color.FromArgb(settings.MainFormColor);
                }
            }
            catch(Exception) {
            }
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void データベース接続ToolStripMenuItem_Click(object sender, EventArgs e) {
            this.carReportDBTableAdapter.Fill(this.infosys202210DataSet.CarReportDB);
        }

        private void carReportDBDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e) {

        }

        private void btAuthorSerch_Click(object sender, EventArgs e) {
            carReportDBTableAdapter.FillByAuthor(infosys202210DataSet.CarReportDB, tbAuthorSerch.Text);
        }


        private void バージョンToolStripMenuItem_Click(object sender, EventArgs e) {
            new Version().ShowDialog();
        }

        private void carReportDBDataGridView_Click(object sender, EventArgs e) {
            if (carReportDBDataGridView.CurrentRow == null)
                return;
            //データグリットビューの選択レコードを描くテキストボックスへ設定
            dtpRegistDate.Value = (DateTime)carReportDBDataGridView.CurrentRow.Cells[1].Value;
            cbAuthor.Text = carReportDBDataGridView.CurrentRow.Cells[2].Value.ToString();
            //GetRadioButtonMakerGroup() = carReportDBDataGridView.CurrentRow.Cells[3].Value.ToString;
            cbCarName.Text = carReportDBDataGridView.CurrentRow.Cells[4].Value.ToString();
            tbReport.Text = carReportDBDataGridView.CurrentRow.Cells[5].Value.ToString();
            if (!(carReportDBDataGridView.CurrentRow.Cells[6].Value is DBNull))
                pbPicture.Image = ByteArrayToImage((byte[])carReportDBDataGridView.CurrentRow.Cells[6].Value);
            else
                pbPicture.Image = null;
        }

        private void btClear_Click(object sender, EventArgs e) {
            
        }
    }
}
