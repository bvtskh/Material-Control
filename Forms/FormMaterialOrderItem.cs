using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Material_System.DAL;
using Zuby.ADGV;
using DocumentFormat.OpenXml.VariantTypes;

namespace Material_System
{
    public partial class fMaterialOrderItem : Form
    {
        public void ShowData()
        {
            var data = DXHelper.GetWokingOrderItem();
            var data86 = DXHelper.GetWokingOrderItem86();
            this.BeginInvoke(new Action(() =>
            {
                this.dgvReturn.DataSource = data;
                this.dgv86.DataSource = data86;
               // this.lblRecord.Text = $"{data.Rows.Count} Record";
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    dataGridView1.Rows[i].Cells["clNo"].Value = i + 1;
                //}
            }));
        }

        public void SearchByPartNo()
        {
            var data = UsapHelper.GetECOStock(txtSearch.Text.Trim());

            this.BeginInvoke(new Action(() =>
            {
                this.dgvReturn.DataSource = data;
                this.lblRecord.Text = $"{data.Rows.Count} Record";
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    dataGridView1.Rows[i].Cells["clNo"].Value = i + 1;
                //}
            }));
        }


        public fMaterialOrderItem()
        {
            InitializeComponent();
            this.dgvReturn.AutoGenerateColumns = false;
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

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            new fWO_Save().ShowDialog();
            ShowData();
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedCells.Count > 0)
            //{
            //    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            //    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            //    var TnNo = selectedRow.Cells["TN_NO"].Value.ToString();
            //    if (MessageBox.Show($"Are you sure to delete ??", "Confirm Delete!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        DXHelper.RemoveTnECO(TnNo);
            //        MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        ShowData();
            //    }
            //}
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click_1(null, null);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRemove_Click_1(null, null);
        }
    }
}
