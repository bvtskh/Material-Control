using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Material_System.DAL;
using System.Data;
using System.Linq;
using System.ComponentModel;
using System.IO;
using Material_System.Entities;

namespace Material_System
{
    public partial class fExchangeComponent : Form
    {
        private DataTable dt;
        private string _filePath;
        fExchangeImport frmImport;
        public fExchangeComponent()
        {
            InitializeComponent();
            _filePath = string.Empty;
            dt = new DataTable();
            frmImport = new fExchangeImport();
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
            }

        }
        DataTable tblExchange;
        private void btnImport_Click(object sender, EventArgs e)
        {

            frmImport.ShowDialog();
            //OpenFileDialog ofl = new OpenFileDialog()
            //{
            //    DefaultExt = "*.csv",
            //    Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            //};
            //if (ofl.ShowDialog() == DialogResult.OK)
            //{
            //    _filePath = ofl.FileName;
            //    var lst = ExcelHelper2.GetExchangeComponent(ofl.FileName);
            //    var duplicate = lst.GroupBy(r => r.Material).Any(t => t.Count() > 1);
            //    if (duplicate)
            //    {
            //        MessageBox.Show("Duplicate material number!");
            //        return;
            //    }
            //    // ExchangeComponentHelper.SaveTotal(lst);
            //    ListtoDataTableConverter convert = new ListtoDataTableConverter();
            //    tblExchange = new DataTable();
            //    tblExchange.Columns.Add("MATERIAL_NUMBER");
            //    tblExchange.Columns.Add("TOTAL");
            //    foreach (var item in lst)
            //    {
            //        tblExchange.Rows.Add(new object[] { item.Material, item.Total });
            //    }
            //    MessageBox.Show("Import success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    btnExecution.Enabled = true;
            //}
        }

        private void btnExecution_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.DataSource = null;
            if (string.IsNullOrEmpty(frmImport.filePath))
            {
                MessageBox.Show("No data import!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            var lst = ExcelHelper2.GetExchangeComponent(frmImport.filePath);
            var duplicate = lst.GroupBy(r => r.Material).Any(t => t.Count() > 1);
            if (duplicate)
            {
                MessageBox.Show("Duplicate material number!");
                return;
            }
            tblExchange = new DataTable();
            tblExchange.Columns.Add("MATERIAL_NUMBER");
            tblExchange.Columns.Add("TOTAL");
            foreach (var item in lst)
            {
                tblExchange.Rows.Add(new object[] { item.Material, item.Total });
            }
            var notBomList = ExchangeComponentHelper.GetMaterialNotBomList(tblExchange);
            if (notBomList.Count > 0)
            {
                var arr = string.Join(",", notBomList.ToArray());
                MessageBox.Show($"{arr} Not Bomlist!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }


            dt = ExchangeComponentHelper.GetListExchange(tblExchange, frmImport.materialType);

            this.advancedDataGridView1.DataSource = dt;
            advancedDataGridView1.Columns["Qty"].DefaultCellStyle.Format = "N1";
            advancedDataGridView1.Columns["Qty Actual"].DefaultCellStyle.Format = "N1";
            advancedDataGridView1.Columns["Total Component Qty"].DefaultCellStyle.Format = "N1";
            this.lblRecord.Text = $"{dt.Rows.Count} Record";
        }

        private void ExchangeComponentFinish(object sender, RunWorkerCompletedEventArgs e)
        {
            btnExecution.Enabled = true;
            if (e.Cancelled)
            {
                MessageBox.Show("Save error!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Save error!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                var dtTop1000 = dt.Rows.Count > 0 ? dt.AsEnumerable().Take(100).CopyToDataTable() : null;
                this.BeginInvoke(new Action(() =>
                {
                    this.advancedDataGridView1.DataSource = dtTop1000;
                    this.lblRecord.Text = $"{dt.Rows.Count} Record";
                }));
                MessageBox.Show("Save sucess", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetExchangeComponent(object sender, DoWorkEventArgs e)
        {
            var lst = ExcelHelper2.GetExchangeComponent(_filePath);
            dt = ExchangeComponentHelper.GetListPart(lst);
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

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "Exchange.csv";
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
                        dt.ToCSV(sfd.FileName);
                        MessageBox.Show("Data Exported Successfully !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
        }
    }
}
