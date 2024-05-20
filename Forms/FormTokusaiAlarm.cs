using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Material_System.DAL;
using System.Drawing;
using Material_System.Entities;
using Material_System.DialogCustom;
using System.Data;
using Material_System.UCCustom;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.EMMA;

namespace Material_System
{
    public partial class FormTokusaiAlarm : FormCommon
    {
        public void ShowData()
        {
            try
            {
                if (cbDemo.Checked) return;
                var data = ECOHelper.Tokusai_GetCurrentLineConfirm(true, true, cbbLocation.Text);
                if (data == null || data.Rows.Count == 0)
                {
                    comm.Send(SystemSettings.Option.SignalOK);
                    toolStripSignal.Text = SystemSettings.Option.SignalOK;
                }
                else
                {
                    comm.Send(SystemSettings.Option.SignalNG);
                    toolStripSignal.Text = SystemSettings.Option.SignalNG;
                }
                this.BeginInvoke(new Action(() =>
                {
                    this.dgrvViewLineComfirm.DataSource = data;
                }));
                this.BeginInvoke((Action)(() =>
                {
                    AutoConfirmDMNotAccess(data);
                }));
            }
            catch (Exception)
            {

            }          
        }

        private void AutoConfirmDMNotAccess(System.Data.DataTable data)
        {
            // Tự động confirm những wo đã đi qua theo LINE và những wo này được DM confirm là NG
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    string DMconfirm = row.Field<object>("DM") == null ? "" : row.Field<object>("DM").ToString();
                    if (!string.IsNullOrEmpty(DMconfirm) && DMconfirm == "NG")
                    {
                        string woConfirmNG = row.Field<object>("WO") == null ? "" : row.Field<object>("WO").ToString();
                        string line = row.Field<object>("LINE_ID") == null ? "" : row.Field<object>("LINE_ID").ToString();
                        var currentWoRuntime = Material_System.Business.MaterialHelper.GetWORuntime(line);
                        if(currentWoRuntime != null)
                        {
                            if (currentWoRuntime != woConfirmNG)
                            {
                                ECOHelper.AutoConfirmNGwoByDM(woConfirmNG, line);
                            }
                            if (currentWoRuntime == woConfirmNG) // trường hợp đã bắn lại PDA thành công
                            {
                                string Part = row.Field<object>("PART_ID") == null ? "" : row.Field<object>("PART_ID").ToString();
                                if (!string.IsNullOrEmpty(Part))
                                {
                                    if (ECOHelper.IS_RetryPDASuccess(Part, woConfirmNG))
                                    {
                                        ECOHelper.AutoConfirmNGwoByDM(woConfirmNG, line);
                                    }
                                }
                            }
                        }
                        else
                        {
                            ECOHelper.AutoConfirmNGwoByDM(woConfirmNG, line); // khi không tìm thấy Line => Line dừng
                        }
                    }
                }
            }
        }

        private CommPort comm;
        public FormTokusaiAlarm()
        {
            InitializeComponent();
            lblVersion.Text = Ultils.GetRunningVersion();
            BindingLocation();
            this.dgrvViewLineComfirm.AutoGenerateColumns = false;
            dgrvViewLineComfirm.SetDoubleBuffering(true);
            SystemSettings.Read();
            comm = CommPort.Instance;
            comm.StatusChanged += OnStatusChanged;
            comm.Open();
        }

        private void OnStatusChanged(string param)
        {

        }

        private void FormTokusaiAlarm_Load(object sender, EventArgs e)
        {
            ShowData();
            this.cbbLocation.SelectedIndexChanged += new System.EventHandler(this.cbb_CheckedChanged);
        }

        private void dgrvViewLineComfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                string state = dgrvViewLineComfirm.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (state == TEXT.NG)
                {
                    MessageBox.Show("Bạn không thể thực hiện chức năng này." +
                        " Liên hệ DM để đăng ký model được phép sử dụng Tokusai", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (state.Contains(TEXT.CONFIRM))
                {

                    var dept = dgrvViewLineComfirm.Columns[e.ColumnIndex].HeaderText;
                    string ID_HISTORY = dgrvViewLineComfirm.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string LINE_ID = dgrvViewLineComfirm.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string WO = dgrvViewLineComfirm.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string CHANGE_NAME = dgrvViewLineComfirm.Rows[e.RowIndex].Cells[6].Value.ToString();

                    var confirmForm = new FormTokusaiConfirm(new Tokusai_GetCurrentLineConfirm()
                    {
                        ID = ID_HISTORY,
                        DEPT = dept,
                        LINE_ID = LINE_ID,
                        WO = WO,
                        CHANGE_NAME = CHANGE_NAME
                    });
                   
                    confirmForm.ConfirmCompleted = (msg) =>
                    {
                        ShowData();
                    };
                    confirmForm.ShowDialog();
                }
            }
        }
        private void dgrvViewLineComfirm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgrvViewLineComfirm.Rows)
            {
                ChangeColorButtonBaseState(DEPT.DM, row);
                ChangeColorButtonBaseState(DEPT.PD, row);
                ChangeColorButtonBaseState(DEPT.TE, row);
                ChangeColorButtonBaseState(DEPT.QA, row);
            }
        }

        private void ChangeColorButtonBaseState(string col, DataGridViewRow row)
        {
            try
            {
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)row.Cells[col];
                buttonCell.FlatStyle = FlatStyle.Popup;
                if (row.Cells[col].Value.ToString() == TEXT.OK)
                {
                    buttonCell.Style.BackColor = Color.LightGreen;
                }
                else if (row.Cells[col].Value.ToString() == TEXT.NG)
                {
                    buttonCell.Style.BackColor = Color.Red;
                }
                else if (row.Cells[col].Value.ToString().Contains(TEXT.CONFIRM))
                {
                    buttonCell.Style.BackColor = Color.LightYellow;

                }

                else
                {
                    buttonCell.Style.BackColor = Color.White;
                }
                if (!string.IsNullOrEmpty(row.Cells["WARM"].Value.ToString()))
                {
                    buttonCell.ToolTipText = row.Cells["WARM"].Value.ToString();
                }
                else
                {
                    buttonCell.ToolTipText = "";
                }
            }
            catch (Exception ex)
            {

            }


        }
        private void cbb_CheckedChanged(object sender, EventArgs e)
        {
            ShowData();
        }
        private void BindingLocation()
        {
            this.cbbLocation.Items.Clear();
            this.cbbLocation.Items.Add("ALL");
            this.cbbLocation.Items.AddRange(ECOHelper.GetLocation());
            this.cbbLocation.SelectedIndex = 0;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            BackToMain();
        }

        private void FormTokusaiAlarm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                ShowConfirmDefaultScreen();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowData();
        }

        private void copyCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var cellContent = dgrvViewLineComfirm.Rows[currentRowIndex].Cells[currentCellIndex].Value.ToString();
                Clipboard.SetText(cellContent);
            }
            catch (Exception ex)
            {

            }

        }

        int currentCellIndex = 0;
        int currentRowIndex = 0;
        private void dgrvViewLineComfirm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    currentCellIndex = dgrvViewLineComfirm.HitTest(e.X, e.Y).ColumnIndex;
                    currentRowIndex = dgrvViewLineComfirm.HitTest(e.X, e.Y).RowIndex;
                    contextMenuStrip.Show(dgrvViewLineComfirm, new Point(e.X, e.Y));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }

            }
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var partNo = dgrvViewLineComfirm.Rows[currentRowIndex].Cells["Part"].Value.ToString();
                new FormStockByPart(partNo).ShowDialog();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
            }

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            new FormTokusaiECOHistory().ShowDialog();
        }


        private void cbDemo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDemo.Checked)
            {
                var data = ECOHelper.Tokusai_GetAllLineConfirmCompletedByDate(true, true, cbbLocation.Text,
               DateTime.Parse("2023-09-16"), DateTime.Parse("2023-09-20"));
                if (data == null)
                {
                    comm.Send(SystemSettings.Option.SignalOK);
                    toolStripSignal.Text = SystemSettings.Option.SignalOK;
                }
                else
                {
                    comm.Send(SystemSettings.Option.SignalNG);
                    toolStripSignal.Text = SystemSettings.Option.SignalNG;
                }
                this.dgrvViewLineComfirm.DataSource = data;
            }
            else
            {
                ShowData();
            }

        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            new FormTokusaiECOPlan().ShowDialog();
        }

        private void FormTokusaiAlarm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer1.Enabled = false;
        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {
            new FormMainSubModel().ShowDialog();
        }
    }
}
