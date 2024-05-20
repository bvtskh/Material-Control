using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Material_System.DAL;
using ClosedXML.Excel;
using System.Linq.Dynamic;
using System.Reflection;
using System.Data;

namespace Material_System
{
    public partial class frmTokusai : Form
    {
        List<WH_Tokusai> lstTokusai;
        List<WH_Tokusai> lstfiltered;
        public void ShowData()
        {
            try
            {
                lstfiltered = lstTokusai = ErpHelper.FindListTokusai();
                var lstRule = ErpHelper.FindRule(Business.Module.ERP_TOKUSAI);
                if (lstRule != null && lstRule.Any(r => r == 1))
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        btnAdd.Enabled = true;
                        btnImport.Enabled = true;
                        btnExport.Enabled = true;
                        btnRemove.Enabled = true;
                        btnEdit.Enabled = true;
                        addToolStripMenuItem.Enabled = true;
                        editoolStripMenuItem.Enabled = true;
                        removeToolStripMenuItem1.Enabled = true;
                        removeEmNoToolStripMenuItem.Enabled = true;
                        importToolStripMenuItem.Enabled = true;
                        exportToolStripMenuItem.Enabled = true;
                    }));
                }

                this.BeginInvoke(new Action(() =>
                {
                    this.advancedDataGridView1.DataSource = lstTokusai;
                    //this.lblRows.Text = $"{lstTokusai.Count} rows";
                    //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    //{
                    //    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    //}
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public frmTokusai()
        {
            InitializeComponent();
            this.advancedDataGridView1.AutoGenerateColumns = false;
            //this.cbbOption.SelectedIndex = 0;
            advancedDataGridView1.FilterStringChanged += advancedDataGridView1_FilterStringChanged;
            advancedDataGridView1.SortStringChanged += advancedDataGridView1_SortStringChanged;
        }
        private void advancedDataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(advancedDataGridView1.FilterString) == true)
                {
                    lstfiltered = lstTokusai;
                    advancedDataGridView1.DataSource = lstTokusai;

                }
                else
                {
                    var listfilter = FilterStringconverter(advancedDataGridView1.FilterString);

                    lstfiltered = lstfiltered.Where(listfilter).ToList();

                    advancedDataGridView1.DataSource = lstfiltered;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " - " + MethodBase.GetCurrentMethod().Name);
            }
        }

        private string FilterStringconverter(string filter)
        {
            string newColFilter = "";
            filter = filter.Replace("(", "").Replace(")", "");
            var colFilterList = filter.Split(new string[] { "AND" }, StringSplitOptions.None);
            string andOperator = "";
            foreach (var colFilter in colFilterList)
            {
                newColFilter += andOperator;
                var temp1 = colFilter.Trim().Split(new string[] { "IN" }, StringSplitOptions.None);
                var colName = temp1[0].Split('[', ']')[1].Trim();
                newColFilter += string.Format("({0} != null && (", colName);
                string orOperator = "";
                var filterValsList = temp1[1].Split(',');
                foreach (var filterVal in filterValsList)
                {
                    var cleanFilterVal = filterVal.Replace("'", "").Trim();

                    double tempNum = 0;
                    if (Double.TryParse(cleanFilterVal, out tempNum))
                        newColFilter += string.Format("{0} {1} = {2}", orOperator, colName, cleanFilterVal.Trim());
                    else
                        newColFilter += string.Format("{0} {1}.Contains('{2}')", orOperator, colName, cleanFilterVal.Trim());

                    orOperator = " OR ";
                }

                newColFilter += "))";

                andOperator = " AND ";
            }
            return newColFilter.Replace("'", "\"");
        }

        private void advancedDataGridView1_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(advancedDataGridView1.SortString) == true)
                    return;

                var sortStr = advancedDataGridView1.SortString.Replace("[", "").Replace("]", "");

                if (string.IsNullOrEmpty(advancedDataGridView1.FilterString) == true)
                {
                    // the grid is not filtered!
                    lstTokusai = lstTokusai.OrderBy(sortStr).ToList();
                    advancedDataGridView1.DataSource = lstTokusai;
                }
                else
                {
                    // the grid is filtered!
                    lstfiltered = lstfiltered.OrderBy(sortStr).ToList();
                    advancedDataGridView1.DataSource = lstfiltered;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " - " + MethodBase.GetCurrentMethod().Name);
            }
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
            //string value = txtSearch.Text;
            //if (string.Equals(cbbOption.Text, "E/M NO", StringComparison.OrdinalIgnoreCase))
            //{
            //    SearchByEmNo(value);
            //}
            //else if (cbbOption.Text.Equals("Part To", StringComparison.OrdinalIgnoreCase))
            //{
            //    SearchByPartNo(value);
            //}
            //else
            //{
            //    SearchByModel(value);
            //}
        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormTokusaiSave().ShowDialog();
            ShowData();
        }


        private void frmLotNoBlock_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(null, null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (advancedDataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = advancedDataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = advancedDataGridView1.Rows[selectedrowindex];
                var emNo = selectedRow.Cells["EM_NO"].Value.ToString();
                new FormTokusaiSave(emNo).ShowDialog();
                ShowData();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (advancedDataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = advancedDataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = advancedDataGridView1.Rows[selectedrowindex];
                var emNo = selectedRow.Cells["EM_NO"].Value.ToString();
                var productID = selectedRow.Cells["PRODUCT_ID"].Value.ToString();
                if (MessageBox.Show($"Are you sure to delete ??", "Confirm Delete!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var res = ErpHelper.RemoveTokusai(emNo, productID);
                    if (res)
                    {
                        MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowData();
                    }
                    else
                    {
                        MessageBox.Show("Error!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.btnRemove_Click(null, null);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //  var tmp = (List<WH_Tokusai>)(dataGridView1.DataSource);

            SaveFileDialog sfl = new SaveFileDialog()
            {
                DefaultExt = "*.xls",
                FileName = "Export_Tokusai.xlsx",
                Filter = "Excel Files|*.xlsx;*.xlsm"
            };
            if (sfl.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var allList = ErpHelper.GetAllTokusai();
                    ListtoDataTableConverter convert = new ListtoDataTableConverter();
                    var dt = convert.ToDataTable<WH_Tokusai>(allList);
                    dt.Columns.RemoveAt(0);
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        //Add DataTable in worksheet  
                        var ws = wb.Worksheets.Add(dt, "List tokusai");
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

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofl = new OpenFileDialog()
            {
                DefaultExt = "*.xlsx",
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };
            if (ofl.ShowDialog() == DialogResult.OK)
            {
                var lst = ExcelHelper2.GetListTokusai(ofl.FileName);
                //var data = ExcelHelper2.ExcelImport(ofl.FileName);
                ErpHelper.SaveTokusai(lst);
                MessageBox.Show("Save sucess", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnImport_Click(null, null);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnExport_Click(null, null);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (advancedDataGridView1.SelectedCells.Count > 0)
            {
                var data = advancedDataGridView1.SelectedCells[0].Value.ToString();
                Clipboard.SetText(data);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removeEmNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (advancedDataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = advancedDataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = advancedDataGridView1.Rows[selectedrowindex];
                var emNo = selectedRow.Cells["EM_NO"].Value.ToString();
                if (MessageBox.Show($"Are you sure to delete E/M No {emNo} ??", "Confirm Delete!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ErpHelper.RemoveTokusai(emNo);
                    MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
            }
        }

        private void advancedDataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            this.lblRows.Text = $"{lstTokusai.Count} rows";
        }
    }
}
