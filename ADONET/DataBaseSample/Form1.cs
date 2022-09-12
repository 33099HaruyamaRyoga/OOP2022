using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseSample {
    public partial class btConnect : Form {
        public btConnect() {
            InitializeComponent();
        }

        private void 社員BindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.社員BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202210DataSet);

        }

        private void Form1_Load(object sender, EventArgs e) {
            

        }

        private void btConnection_Click(object sender, EventArgs e) {
            // TODO: このコード行はデータを 'infosys202210DataSet.社員' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.社員TableAdapter.Fill(this.infosys202210DataSet.社員);
        }

        private void btSave_click(object sender, EventArgs e) {
            this.Validate();
            this.社員BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202210DataSet);

            //this.社員TableAdapter.Fill(this.infosys202210DataSet.社員);
        }

        private void btExecute_Click(object sender, EventArgs e) {
            this.社員TableAdapter.FillBySalary(this.infosys202210DataSet.社員, int.Parse(tbValue.Text));
        }
    }
}
