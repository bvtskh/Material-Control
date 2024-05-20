using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Material_System.DAL;
using Material_System.Entities;
using ClosedXML.Excel;

namespace Material_System
{
    public partial class frmHisTokusai : Form
    {
        List<TokusaiHis> data = new List<TokusaiHis>();
        public void ShowData()
        {
            try
            {
                var fr = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                var to = new DateTime(dateTimePicker2.Value.AddDays(1).Year, dateTimePicker2.Value.AddDays(1).Month, dateTimePicker2.Value.AddDays(1).Day);
                data = ErpHelper.FindHisTokusai(fr, to);
                this.BeginInvoke(new Action(() =>
                {
                    this.dataGridView1.DataSource = data;
                    lblStatus.Text = $"{data.Count} rows.";
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public frmHisTokusai()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            using (frmWaitForm frm = new frmWaitForm(ShowData))
            {
                frm.ShowDialog(this);
            }

        }


        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog sfl = new SaveFileDialog()
            {
                DefaultExt = "*.xls",
                FileName = "TokusaiNG.xlsx",
                Filter = "Excel Files|*.xlsx;*.xlsm"
            };
            if (sfl.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var source = (List<TokusaiHis>)(dataGridView1.DataSource);
                    ListtoDataTableConverter convert = new ListtoDataTableConverter();
                    var dt = convert.ToDataTable<TokusaiHis>(source);
                    dt.Columns.RemoveAt(0);
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        //Add DataTable in worksheet  
                        var ws = wb.Worksheets.Add(dt, "History");
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


        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnExport_Click(null, null);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var data = dataGridView1.SelectedCells[0].Value.ToString();
                Clipboard.SetText(data);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {

                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string upn = Convert.ToString(selectedRow.Cells["UPN_ID"].Value);
                new frmTokusaiDetail(upn).ShowDialog();
            }
        }
    }
}
