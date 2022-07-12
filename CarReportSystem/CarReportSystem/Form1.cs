using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class Form1 : Form {

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
        private void btAddPerson_Click(object sender, EventArgs e) {

            //氏名が未入力なら登録しない
            if (String.IsNullOrWhiteSpace(cbName.Text)) {
                MessageBox.Show("記録者が入力されていません");
                return;
            }

            CarReport newCarReport = new CarReport {

                Date = dtpRegistDate.Value,
            };
            listCarReports.Add(newCarReport);
            dgvCarReports.Rows[dgvCarReports.RowCount - 1].Selected = true;



        }
    }
}
