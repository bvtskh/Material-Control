using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Material_System.DAL;
using Material_System.Entities;

namespace Material_System
{
    public partial class frmTokusaiAlert : Form
    {
        List<Tokusai_Item> data = new List<Tokusai_Item>();
        string type = "NY";
        public void ShowData()
        {
            try
            {
                data = ErpHelper.FindTokusaiAlert(type);
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

        public frmTokusaiAlert()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.cbbType.BeginUpdate();
            cbbType.Items.Add("NY");
            cbbType.Items.Add("ALL");
            cbbType.EndUpdate();
            cbbType.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            type = cbbType.Text;
            using (frmWaitForm frm = new frmWaitForm(ShowData))
            {
                frm.ShowDialog(this);
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
                btnSearch_Click(null, null);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var tmp = (List<TokusaiHis>)(dataGridView1.DataSource);
            ListtoDataTableConverter convert = new ListtoDataTableConverter();
            var dt = convert.ToDataTable<TokusaiHis>(tmp);
            SaveFileDialog sfl = new SaveFileDialog()
            {
                DefaultExt = "*.xls",
                FileName = "TokusaiNG.xls",
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };
            if (sfl.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //    var excelConfig = new ExcelConfig();
                    //    excelConfig.FileName = sfl.FileName;
                    //    excelConfig.Title = "History Tokusai NG";
                    //    excelConfig.IsAllSizeColumn = true;
                    //    excelConfig.ColumnEntity = new List<ColumnEntity>() {
                    //    new ColumnEntity() { Column = "UPN_ID", ExcelColumn = "Barocde", Width = 15 },
                    //    new ColumnEntity() { Column = "PART_ID", ExcelColumn = "Parts", Width = 20 },
                    //    new ColumnEntity() { Column = "MACHINE_SLOT", ExcelColumn = "Slot" , Width = 20 },
                    //    new ColumnEntity() { Column = "MACHINE_ID", ExcelColumn = "Machine", Width = 25 },
                    //    new ColumnEntity() { Column = "PRODUCT_ID", ExcelColumn = "Product", Width = 15},
                    //    new ColumnEntity() { Column = "MATERIAL_ORDER_ID", ExcelColumn = "Material Order",Width = 25 },
                    //    new ColumnEntity() { Column = "LINE_ID", ExcelColumn = "Line",Width = 15 },
                    //     new ColumnEntity() { Column = "ERROR_TIME", ExcelColumn = "Error Time",Width = 15 },
                    //};
                    // ExcelHelper.ExcelExport(dt, excelConfig);
                    MessageBox.Show("Export success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
