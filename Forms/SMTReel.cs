using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Material_System.DAL;
using Zuby.ADGV;
using ClosedXML.Excel;
using Material_System.Entities;
using System.Data;

namespace Material_System
{
    public partial class fSMTReel : Form
    {
        public void ShowData()
        {
            var data = UsapHelper.GetSMTReel();

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

        public void SearchByPartNo()
        {
            var data = UsapHelper.GetSMTReel(txtSearch.Text.Trim());

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


        public fSMTReel()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
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
            //using (frmWaitForm frm = new frmWaitForm(SearchByPartNo))
            //{
            //    frm.ShowDialog(this);
            //}
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            //new fECOSave().ShowDialog();
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                //int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                //DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                //var TnNo = selectedRow.Cells["TN_NO"].Value.ToString();
                //if (MessageBox.Show($"Are you sure to delete ??", "Confirm Delete!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    DXHelper.RemoveTnECO(TnNo);
                //    MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    ShowData();
                //}
            }
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfl = new SaveFileDialog()
            {
                DefaultExt = "*.xls",
                FileName = "SMT_Reel.xlsx",
                Filter = "Excel Files|*.xlsx;*.xlsm"
            };
            if (sfl.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var source = (DataTable)(dataGridView1.DataSource);
                    //ListtoDataTableConverter convert = new ListtoDataTableConverter();
                   // var dt = convert.ToDataTable<TokusaiHis>(source);
                   // dt.Columns.RemoveAt(0);
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        //Add DataTable in worksheet  
                        var ws = wb.Worksheets.Add(source, "SMT Reel");
                        ws.Columns().AdjustToContents();
                        wb.SaveAs(sfl.FileName);
                    }
                    MessageBox.Show("Export success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(sfl.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error {ex.Message}");
                }

            }
        }
    }
}
