using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Material_System.DAL;

namespace Material_System
{
    public partial class FormMainSubModel : Form
    {
        public void ShowData()
        {
            var lstRule = ErpHelper.FindRule(Module.ERP_TOKUSAI);
            this.BeginInvoke(new Action(() =>
            {
                if (lstRule != null && lstRule.Any(r => r == 1))
                {
                    btnAdd.Enabled = true;
                    btnImport.Enabled = true;
                    btnRemove.Enabled = true;
                }
                this.dataGridView1.DataSource = ECOHelper.GetListMainSub();
                lbrow.Text = dataGridView1.RowCount.ToString() + " rows";
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }));
        }

        public void SearchByPart(string part)
        {
            if (string.IsNullOrEmpty(part))
            { ShowData(); return; }
            var data = ECOHelper.FindMainSubByPart(part);

            this.BeginInvoke(new Action(() =>
            {
                this.dataGridView1.DataSource = data;
            }));
        }

        public FormMainSubModel()
        {
            InitializeComponent();
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
            SearchByPart(txtSearch.Text.ToUpper().Trim());
        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormMainSubModelAdd().ShowDialog();
            ShowData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                var partFrom = selectedRow.Cells[0].Value.ToString();
                var partTo = selectedRow.Cells[1].Value.ToString();

                var confirmResult = MessageBox.Show($"Bạn có muốn xóa PartForm {partFrom} & PartTo {partTo} không?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.No)
                {
                    return;
                }

                var res = ECOHelper.MainSubRemove(partFrom, partTo);
                if (!string.IsNullOrEmpty(res))
                {
                    MessageBox.Show(res, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (ExcelHelper2.ExportSubMainToExcel(ECOHelper.GetListMainSubAll())) // Main sub đã lưu
                {
                    MessageBox.Show("Export Success full!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Export error!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnImportMainsub_Click(object sender, EventArgs e)
        {
            if (Program.userEntity == null)
            {
                MessageBox.Show("You must log in!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
            }
            try
            {
                OpenFileDialog ofl = new OpenFileDialog()
                {
                    DefaultExt = "*.csv",
                    Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
                };
                if (ofl.ShowDialog() == DialogResult.OK)
                {
                    var dt = ExcelHelper2.ImportExcel(ofl.FileName);
                    if (dt != null)
                    {
                        if (MainSubHelper.ImportMainSub(dt))
                        {
                            MessageBox.Show("Import Success full!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowData();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Import error!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void checkboxMainsub_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxMainsub.Checked)
            {
                this.dataGridView1.DataSource = ECOHelper.GetListMainSub(1);
                lbrow.Text = dataGridView1.RowCount.ToString() + " rows";
            }
            else
            {
                ShowData();
            }
        }
    }
}
