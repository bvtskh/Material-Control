using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Material_System.DAL;

namespace Material_System
{
    public partial class frmTokusaiChange : Form
    {

        public void ShowData()
        {
            var data = ErpHelper.GetTokusaiChange("");

            this.BeginInvoke(new Action(() =>
            {
                this.dataGridView1.DataSource = data;
            }));
        }
        public void ComboboxOptionInit()
        {
            this.cbbOption.BeginUpdate();
            cbbOption.Items.AddRange(new[] { "E/M No" });
            this.cbbOption.EndUpdate();
            cbbOption.SelectedIndex = 0;
        }
        public void SearchByEmNo(string emNo)
        {
            var data = ErpHelper.GetTokusaiChange(emNo);

            this.BeginInvoke(new Action(() =>
            {
                this.dataGridView1.DataSource = data;
            }));
        }

        public frmTokusaiChange()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            ComboboxOptionInit();
        }

        private void frmLotNoBlock_Load(object sender, EventArgs e)
        {
            using (frmWaitForm frm = new frmWaitForm(ShowData))
            {
                frm.ShowDialog(this);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string value = txtSearch.Text;
            var option = cbbOption.Text;
            switch (option)
            {
                case "PART NO":
                    break;
                case "LOT NO":
                    break;
                default:
                    SearchByEmNo(value);
                    break;
            }
        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var data = SingletonHelper.UsapInstance.LotNoLockedGetAll();
            ShowData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new frmAddLotNo().ShowDialog();
            ShowData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                var id = selectedRow.Cells["ID"].Value.ToString();
                var res = UsapHelper.LotNoUpdate(id);
                if (res != -1)
                {
                    MessageBox.Show($"LotNo Unlock!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Error. Contact (3143)!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                using (frmWaitForm frm = new frmWaitForm(ShowData))
                {
                    frm.ShowDialog(this);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofl = new OpenFileDialog()
            {
                DefaultExt = "*.csv",
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };
            if (ofl.ShowDialog() == DialogResult.OK)
            {
                var dt = ExcelHelper2.ExcelImport(ofl.FileName);
                List<WH_LOTNG> lst = UsapHelper.ConvertToList(dt);
                var save = UsapHelper.SaveListLotNo(lst);
                if (save)
                {
                    MessageBox.Show("Save sucess", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Save error!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                ShowData();
            }

        }

        private void frmLotNoBlock_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, null);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(null, null);
        }
    }
}
