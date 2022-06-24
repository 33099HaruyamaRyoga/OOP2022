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

namespace AddressBook {
    public partial class Form1 : Form {
        //住所データ管理用リスト
        BindingList<Person> listPerson = new BindingList<Person>();
        
        public Form1() {
            InitializeComponent();
            dgvPersons.DataSource = listPerson;
        }

        private void btPictureOpen_Click(object sender, EventArgs e) {
            if(ofdFileOpenDialog.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdFileOpenDialog.FileName);
            }
        }
        
        private void btAddPerson_Click(object sender, EventArgs e) {

            //氏名が未入力なら登録しない
            if (String.IsNullOrWhiteSpace(tbName.Text)) {
                MessageBox.Show("氏名が入力されていません");
                return;
            }

            Person newPerson = new Person {

                Name = tbName.Text,
                MailAddress = tbMailAdress.Text,
                Address = tbAdress.Text,
                Company = cbCompany.Text,
                Picture = pbPicture.Image,
                listGroup = GetCheckBoxGroup(),
                KindNumber = GetRadioButtonKindNumber(),
                TelNumber = tbTelNumber.Text,
                Registration = dtpRegistDate.Value,
            };
            listPerson.Add(newPerson);
            dgvPersons.Rows[dgvPersons.RowCount - 1].Selected = true;

            EnabledCheck();

            setCbCompany(cbCompany.Text);

        }



        private void EnabledCheck() {
            if (listPerson.Count() > 0) {
                btDelete.Enabled = true;
                btUpdate.Enabled = true;
            }
        }

        //コンボボックスに会社名を登録する（重複なし）
        private void setCbCompany(String Company) {
            
            if (!cbCompany.Items.Contains(Company)) {

                //まだ登録されていなければ登録処理
                cbCompany.Items.Add(Company);
            }
        }

        private Person.KindNumberType GetRadioButtonKindNumber() {
            //デフォルトの戻りを設定
            var selectedKindNumber = Person.KindNumberType.その他;

            if (rbHome.Checked) //自宅にチェックがついている
            {
                selectedKindNumber = Person.KindNumberType.自宅;
            }
            if (rbMobile.Checked) //携帯にチェックがついている
            {
                selectedKindNumber = Person.KindNumberType.携帯;
            }
            return selectedKindNumber;
        }

        //チェックボックスにセットされている値をリストとして取り出す
        private List<Person.GroupType> GetCheckBoxGroup() {
            var listGroup = new List<Person.GroupType>();
            if (cbFamily.Checked) {
                listGroup.Add(Person.GroupType.家族);
            }
            if (cbFriend.Checked) {
                listGroup.Add(Person.GroupType.友人);
            }
            if (cbWork.Checked) {
                listGroup.Add(Person.GroupType.仕事);
            }
            if (cbOther.Checked) {
                listGroup.Add(Person.GroupType.その他);
            }

            return listGroup;
        }

        private void btPictureClear_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        //データグリッドビューをクリックした時のイベントハンドラ
        private void dgvPersons_Click(object sender, EventArgs e) {

            if (dgvPersons.CurrentRow == null) return;

            int index = dgvPersons.CurrentRow.Index;

            tbName.Text = listPerson[index].Name;
            tbMailAdress.Text = listPerson[index].MailAddress;
            tbAdress.Text = listPerson[index].Address;
            cbCompany.Text = listPerson[index].Company;
            pbPicture.Image = listPerson[index].Picture;

            dtpRegistDate.Value =
                listPerson[index].Registration.Year > 1900 ? listPerson[index].Registration : DateTime.Today;

            setGroupType(index);　//グループを設定
            setKindNumberType(index);　//番号種別を設定
        }

        private void setKindNumberType(int index) {
            //番号種別チェック処理
            switch (listPerson[index].KindNumber) {
                case Person.KindNumberType.自宅:
                    rbHome.Checked = true;
                    break;
                case Person.KindNumberType.携帯:
                    rbMobile.Checked = true;
                    break;
                case Person.KindNumberType.その他:
                    break;
                default:
                    break;
            }
        }

        private void setGroupType(int index) {
            groupCheckBoxAllClear();

            foreach (var group in listPerson[index].listGroup) {
                switch (group) {
                    case Person.GroupType.家族:
                        cbFamily.Checked = true;
                        break;
                    case Person.GroupType.友人:
                        cbFriend.Checked = true;
                        break;
                    case Person.GroupType.仕事:
                        cbWork.Checked = true;
                        break;
                    case Person.GroupType.その他:
                        cbOther.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }

        //グループのチェックボックスをオールクリア
        private void groupCheckBoxAllClear() {
            cbFamily.Checked = cbFriend.Checked = cbWork.Checked = cbOther.Checked = false;
        }

        //更新ボタンが押されたときの処理
        private void btUpdate_Click(object sender, EventArgs e) {

            listPerson[dgvPersons.CurrentRow.Index].Name = tbName.Text;
            listPerson[dgvPersons.CurrentRow.Index].MailAddress = tbMailAdress.Text;
            listPerson[dgvPersons.CurrentRow.Index].Address = tbAdress.Text;
            listPerson[dgvPersons.CurrentRow.Index].Company = cbCompany.Text;
            listPerson[dgvPersons.CurrentRow.Index].listGroup = GetCheckBoxGroup();
            listPerson[dgvPersons.CurrentRow.Index].Picture = pbPicture.Image;
            listPerson[dgvPersons.CurrentRow.Index].Registration = dtpRegistDate.Value;
            dgvPersons.Refresh();//データグリッドビュー更新
        }

        //削除ボタンが押された時の処理
        private void btDelete_Click(object sender, EventArgs e) {

            listPerson.RemoveAt(dgvPersons.CurrentRow.Index);
            EnabledCheck(); //マスク処理呼び出し
        }

        private void Form1_Load(object sender, EventArgs e) {
            //削除ボタンをマスク
            btDelete.Enabled = false;
            btUpdate.Enabled = true;
        }

        //保存のイベントハンドラ
        private void btSave_Click(object sender, EventArgs e) {
            if(sfdSaveDialog.ShowDialog() == DialogResult.OK) {

                try {
                    //バイナリ形式でシリアル化
                    var bf = new BinaryFormatter();

                    using (FileStream fs = File.Open(sfdSaveDialog.FileName,FileMode.Create)) {
                        bf.Serialize(fs, listPerson);
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
                        listPerson = (BindingList<Person>)bf.Deserialize(fs);
                        dgvPersons.DataSource = null;
                        dgvPersons.DataSource = listPerson;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }

                foreach(var item in listPerson) {
                    setCbCompany(item.Company);//存在する会社を登録
                }
            }
            EnabledCheck(); //マスク処理呼び出し
        }
    }
}
