using Material_System.Business;
using System;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Linq;
using System.ComponentModel;

namespace Material_System
{
    public partial class fBomList : Form
    {
        private DataTable data2 = new DataTable();
        public void ShowData()
        {
            var data = BomListHelper.GetTop1000();
            this.BeginInvoke(new Action(() =>
            {
                this.advancedDataGridView1.DataSource = data;
                this.lblRecord.Text = $"{data.Rows.Count} Record";
            }));
        }
        private void SearchWithParam()
        {
            data2 = BomListHelper.GetData();
            var dtTop1000 = data2.Rows.Count > 0 ? data2.AsEnumerable().Take(100).CopyToDataTable() : null;
            this.BeginInvoke(new Action(() =>
            {
                this.advancedDataGridView1.DataSource = dtTop1000;
                this.lblRecord.Text = $"{data2.Rows.Count} Record";
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    dataGridView1.Rows[i].Cells["clNo"].Value = i + 1;
                //}
            }));
        }

        public fBomList()
        {
            InitializeComponent();
            // this.dataGridView1.AutoGenerateColumns = false;
        }

        private void fTokusaiStock_Load(object sender, EventArgs e)
        {
            //using (frmWaitForm frm = new frmWaitForm(ShowData))
            //{
            //    frm.ShowDialog(this);
            //}
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofl = new OpenFileDialog()
            {
                DefaultExt = "*.csv",
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };
            if (ofl.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //BackgroundWorker bg = new BackgroundWorker();
                    //bg.DoWork += new DoWorkEventHandler(ImportData);
                    //bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(InsertData);
                    //bg.RunWorkerAsync(argument: ofl.FileName);
                    var dt = ExcelHelper2.ReadBomlist(ofl.FileName);
                    BomListHelper.Save(dt);
                    MessageBox.Show("Save sucess", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save error!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    throw;
                }
            }
        }

        private void InsertData(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // ShowMessage("FAIL", "NG", $"Group File Canceled");
                MessageBox.Show("Save error!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (e.Error != null)
            {
                // ShowMessage("FAIL", "NG", $"Group File Error");
                MessageBox.Show("Save error!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                DataTable dt = e.Result as DataTable;
                BomListHelper.Save(dt);
                MessageBox.Show("Save sucess", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ImportData(object sender, DoWorkEventArgs e)
        {
            var filePath = e.Argument as string;
            var dt = ExcelHelper2.ReadBomlist(filePath);
            e.Result = dt;
        }

        private void advancedDataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            advancedDataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            advancedDataGridView1.Columns[0].MinimumWidth = 150;
            for (int i = 1; i < advancedDataGridView1.Columns.Count; i++)
            {
                advancedDataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            this.advancedDataGridView1.Refresh();
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "Output.csv";
            bool fileError = false;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfd.FileName))
                {
                    try
                    {
                        File.Delete(sfd.FileName);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }
                }
                if (!fileError)
                {
                    try
                    {
                        data2.ToCSV(sfd.FileName);
                        MessageBox.Show("Data Exported Successfully !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
            //if (advancedDataGridView1.Rows.Count > 0)
            //{
            //    SaveFileDialog sfd = new SaveFileDialog();
            //    sfd.Filter = "CSV (*.csv)|*.csv";
            //    sfd.FileName = "Output.csv";
            //    bool fileError = false;
            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        if (File.Exists(sfd.FileName))
            //        {
            //            try
            //            {
            //                File.Delete(sfd.FileName);
            //            }
            //            catch (IOException ex)
            //            {
            //                fileError = true;
            //                MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
            //            }
            //        }
            //        if (!fileError)
            //        {
            //            try
            //            {
            //                int columnCount = advancedDataGridView1.Columns.Count;
            //                string columnNames = "";
            //                string[] outputCsv = new string[advancedDataGridView1.Rows.Count + 1];
            //                for (int i = 0; i < columnCount; i++)
            //                {
            //                    columnNames += advancedDataGridView1.Columns[i].HeaderText.ToString() + ",";
            //                }
            //                outputCsv[0] += columnNames;

            //                for (int i = 1; (i - 1) < advancedDataGridView1.Rows.Count; i++)
            //                {
            //                    for (int j = 0; j < columnCount; j++)
            //                    {
            //                        outputCsv[i] += advancedDataGridView1.Rows[i - 1].Cells[j].Value.ToString().Escape() + ",";
            //                    }
            //                }
            //                File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
            //                MessageBox.Show("Data Exported Successfully !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("Error :" + ex.Message);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No Record To Export !!!", "Info");
            //}
        }

        private void btnParam_Click(object sender, EventArgs e)
        {
            new fBomListSearch().ShowDialog();
        }

        private void btnExecution_Click(object sender, EventArgs e)
        {
            using (frmWaitForm frm = new frmWaitForm(SearchWithParam))
            {
                frm.ShowDialog(this);
            }
        }
    }
}
