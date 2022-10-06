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
            dgvCarReports.DataSource = listCarReports;
        }

        private void btPictureOpen_Click(object sender, EventArgs e) {
            if (ofdFileOpenDialog.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdFileOpenDialog.FileName);
            }
        }
        private void btPictureClear_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btAddPerson_Click(object sender, EventArgs e) {

            //氏名が未入力なら登録しない
            if (String.IsNullOrWhiteSpace(cbAuther.Text)) {
                MessageBox.Show("記録者が入力されていません");
                return;
            }

            CarReport newCarReport = new CarReport {

                Date = dtpRegistDate.Value,
                Auther = cbAuther.Text,
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
                Maker = GetRadioButtonMakerGroup()
            };
            listCarReports.Add(newCarReport);
            dgvCarReports.Rows[dgvCarReports.RowCount - 1].Selected = true;

            EnabledCheck();

            setcbAuter(cbAuther.Text);
            setcbCarName(cbCarName.Text);

        }
        private void EnabledCheck() {
            if (listCarReports.Count() > 0) {
                btDelete.Enabled = true;
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

        private void dgvPersons_Click(object sender, EventArgs e) {

            if (dgvCarReports.CurrentRow == null) return;

            int index = dgvCarReports.CurrentRow.Index;

            cbAuther.Text = listCarReports[index].Auther;
            cbCarName.Text = listCarReports[index].CarName;
            tbReport.Text = listCarReports[index].Report;
            pbPicture.Image = listCarReports[index].Picture;

            dtpRegistDate.Value =
                listCarReports[index].Registration.Year > 1900 ? listCarReports[index].Registration : DateTime.Today;

            setMakerGroup(index);　//番号種別を設定
        }

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

            listCarReports[dgvCarReports.CurrentRow.Index].Auther = cbAuther.Text;
            listCarReports[dgvCarReports.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvCarReports.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvCarReports.CurrentRow.Index].Maker = GetRadioButtonMakerGroup();
            listCarReports[dgvCarReports.CurrentRow.Index].Picture = pbPicture.Image;
            listCarReports[dgvCarReports.CurrentRow.Index].Registration = dtpRegistDate.Value;
            dgvCarReports.Refresh();//データグリッドビュー更新
        }

        //削除ボタンが押された時の処理
        private void btDelete_Click(object sender, EventArgs e) {

            listCarReports.RemoveAt(dgvCarReports.CurrentRow.Index);
            EnabledCheck(); //マスク処理呼び出し
        }

        private void setcbAuter(String Auther) {

            if (!cbAuther.Items.Contains(Auther)) {

                cbAuther.Items.Add(Auther);
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
            EnabledCheck();
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
