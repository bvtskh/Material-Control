using Material_System.Business;
using System;
using System.Linq;
using System.Windows.Forms;
using Material_System.DAL;
using System.IO;
using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
using System.Drawing;
using System.Drawing.Imaging;
using Material_System.FTP;
using Material_System.Entities;

namespace Material_System
{
    public partial class frmPart : Form
    {
        public void ShowData()
        {
            try
            {
                var data = ErpHelper.GetAllLotNo();
                var lstRule = ErpHelper.FindRule(Module.ERP_LOTNO);
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
                        importToolStripMenuItem.Enabled = true;
                        exportToolStripMenuItem.Enabled = true;
                    }));
                }

                this.BeginInvoke(new Action(() =>
                {
                    this.dataGridView1.DataSource = data;
                    this.dataGridView1.Columns["PATH_IMG"].Visible = false;
                    this.dataGridView1.Columns["FullPath"].Visible = false;
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    for (int i = 1; i <= dataGridView1.Columns.Count - 1; i++)
                    {
                        // Store Auto Sized Widths:
                        int colw = dataGridView1.Columns[i].Width;

                        // Remove AutoSizing:
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        // Set Width to calculated AutoSize value:
                        dataGridView1.Columns[i].Width = colw;
                    }
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

        public frmPart()
        {
            InitializeComponent();
            // this.dataGridView1.AutoGenerateColumns = false;
            // this.pictureBox1.MouseWheel += new MouseEventHandler(PictureBoxMouseWheel);
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
        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //new FormTokusaiSave().ShowDialog();
            //ShowData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofl = new OpenFileDialog()
            //{
            //    DefaultExt = "*.csv",
            //    Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            //};
            //if (ofl.ShowDialog() == DialogResult.OK)
            //{
            //    var dt = ExcelHelper.ExcelImport(ofl.FileName);
            //    List<WH_BCLBFLM> lst = UsapHelper.ConvertToList(dt);
            //    var save = UsapHelper.SaveListLotNo(lst);
            //    if (save)
            //    {
            //        MessageBox.Show("Save sucess", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Save error!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    }
            //    ShowData();
            //}
            this.btnImport_Click(null, null);
        }

        private void frmLotNoBlock_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(null, null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedCells.Count > 0)
            //{
            //    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            //    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            //    var emNo = selectedRow.Cells["EM_NO"].Value.ToString();
            //    new FormTokusaiSave(emNo).ShowDialog();
            //    ShowData();
            //}
            MessageBox.Show("Coming soon");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedCells.Count > 0)
            //{
            //    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            //    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            //    var emNo = selectedRow.Cells["EM_NO"].Value.ToString();
            //    if (MessageBox.Show($"Are you sure to delete E/M No [{emNo}] ??", "Confirm Delete!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        ErpHelper.RemoveTokusai(emNo);
            //        MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        ShowData();
            //    }
            //}
            MessageBox.Show("Coming soon");
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
            //var tmp = (List<WH_Tokusai>)(dataGridView1.DataSource);
            //ListtoDataTableConverter convert = new ListtoDataTableConverter();
            //var dt = convert.ToDataTable<WH_Tokusai>(tmp);
            //SaveFileDialog sfl = new SaveFileDialog()
            //{
            //    DefaultExt = "*.xls",
            //    FileName = "Export_Tokusai.xls",
            //    Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            //};
            //if (sfl.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        var excelConfig = new ExcelConfig();
            //        excelConfig.FileName = sfl.FileName;
            //        excelConfig.Title = "Tokusai Material";
            //        excelConfig.IsAllSizeColumn = true;
            //        excelConfig.ColumnEntity = new List<ColumnEntity>() {
            //        new ColumnEntity() { Column = "EM_NO", ExcelColumn = "E/M No", Width = 15 },
            //        new ColumnEntity() { Column = "PART_FM", ExcelColumn = "Parts From", Width = 20 },
            //        new ColumnEntity() { Column = "PART_TO", ExcelColumn = "Parts To" , Width = 20 },
            //        new ColumnEntity() { Column = "PRODUCT_ID", ExcelColumn = "Models", Width = 25 },
            //        new ColumnEntity() { Column = "OS_QTY", ExcelColumn = "Os Qty", Width = 15},
            //        new ColumnEntity() { Column = "UPD_DATE", ExcelColumn = "Time",Width = 25 },
            //        new ColumnEntity() { Column = "UPD_NAME", ExcelColumn = "Updater Name",Width = 15 },
            //    };
            //        ExcelHelper.ExcelExport(dt, excelConfig);
            //        MessageBox.Show("Export success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error {ex.Message}");
            //    }

            //}
            MessageBox.Show("Coming soon");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var remoteDir = @"\PART_PICTURE\";
            OpenFileDialog ofl = new OpenFileDialog()
            {
                DefaultExt = "*.xlsx",
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };
            if (ofl.ShowDialog() == DialogResult.OK)
            {

                using (var stream = File.Open(ofl.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    XLWorkbook workbook = new XLWorkbook(stream);
                    var worksheet = workbook.Worksheet(1);

                    foreach (IXLPicture pic in worksheet.Pictures)
                    {
                        var addressPicture = pic.TopLeftCell;
                        var image = Image.FromStream(pic.ImageStream);
                        var partNo = worksheet.Cell(addressPicture.Address.RowNumber, "A").Value;
                        if (partNo != null)
                        {
                            LotPicture entity = LotPicture.CreateInstance(partNo.ToString());
                            var localPath = Path.Combine(Common.AllUsersDataFolder, entity.PATH_IMG);
                            image.Save(localPath, ImageFormat.Jpeg);
                            var remotePath = Path.Combine(remoteDir, entity.PATH_IMG);
                            UploadFileExample.UploadFile(localPath, remotePath);
                            ErpHelper.SaveLotPicture(entity);
                        }
                    }
                }
                FileHelper.DeleteAllFile(Common.AllUsersDataFolder);
                //var localPaths = Directory.GetFiles(Common.AllUsersDataFolder, "*.png", SearchOption.TopDirectoryOnly);
                // UploadManyFiles.UploadFiles(localPaths, @"\PART_PICTURE\");
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
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var data = dataGridView1.SelectedCells[0].Value.ToString();
                Clipboard.SetText(data);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                try
                {
                    var entity = (LotPicture)selectedRow.DataBoundItem;
                    using (var conn = new FluentFTP.FtpClient(Constant.FTP_ADDRESS, Constant.FTP_USER, Constant.FTP_PASS))
                    {
                        conn.AutoConnect();

                        // open an read-only stream to the file
                        using (var istream = conn.OpenRead(entity.FullPath))
                        {
                            try
                            {
                                var bmp = new Bitmap(istream);
                                pictureBox1.Image = (Bitmap)bmp.Clone();
                            }
                            finally
                            {
                                Console.WriteLine();
                                istream.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    pictureBox1.Image = null;
                }
            }
        }
    }
}
