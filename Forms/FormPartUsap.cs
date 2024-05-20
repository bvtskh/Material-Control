using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Material_System.DAL;
using DocumentFormat.OpenXml.Office.Word;
using Zuby.ADGV;
using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace Material_System
{
    public partial class fPartUsap : Form
    {
        public string PartNo
        {
            get
            {
                if (this.dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    var partNo = selectedRow.Cells["Part_No"].Value.ToString();
                    return partNo;
                }
                return string.Empty;
            }
        }
        public void ShowData()
        {
            var data = DXHelper.GetNewPart();

            this.BeginInvoke(new Action(() =>
            {
                this.dataGridView1.DataSource = data;
                this.lblRecord.Text = $"{data.Count} Record";
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    dataGridView1.Rows[i].Cells["clNo"].Value = i + 1;
                //}
            }));
        }

        public void SearchByPartNo()
        {
            var data = DXHelper.GetListQuota(txtSearch.Text.Trim());

            this.BeginInvoke(new Action(() =>
            {
                this.dataGridView1.DataSource = data;
                this.lblRecord.Text = $"{data.Rows.Count} Record";
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    dataGridView1.Rows[i].Cells["clNo"].Value = i + 1;
                //}
            }));
        }


        public fPartUsap()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void frmLotNoBlock_Load(object sender, EventArgs e)
        {
            using (frmWaitForm frm = new frmWaitForm(ShowData))
            {
                frm.ShowDialog(this);
            }

        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var data = SingletonHelper.UsapInstance.LotNoLockedGetAll();
            // ShowData();
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


        private void fTokusaiStock_Load(object sender, EventArgs e)
        {
            using (frmWaitForm frm = new frmWaitForm(ShowData))
            {
                frm.ShowDialog(this);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frm = new frmWaitForm(SearchByPartNo))
            {
                frm.ShowDialog(this);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, null);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new fQuotaSave().ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                var partNo = selectedRow.Cells["Part_No"].Value.ToString();
                new fQuotaSave(partNo).ShowDialog();
                ShowData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
