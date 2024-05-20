using DocumentFormat.OpenXml.Office2010.Excel;
using Material_System.Business;
using Material_System.Entities;
using Material_System.UCCustom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_System
{
    public partial class FormTokusaiConfirm : Form
    {
        private List<Tuple<string, string>> PD = new List<Tuple<string, string>>()
        {
            new Tuple<string, string>("1. Bước Pitch của linh kiện","(Sai pitch sẽ gây tổn thất linh kiện hàng loạt, ảnh hưởng đến độ loss)"),
            new Tuple<string, string>("2. Swive Angle (Góc xoay của linh kiện)","(Sai góc xoay có thể gây ra gắn ngược cực linh kiện)"),
            new Tuple<string, string>("3. Đã thực sự hết linh kiện hay chưa",""),
        };
        private List<Tuple<string, string>> TE = new List<Tuple<string, string>>()
        {
            new Tuple<string, string>("1. Bước Pitch của linh kiện","(Sai pitch sẽ gây tổn thất linh kiện hàng loạt, ảnh hưởng đến độ loss)"),
            new Tuple<string, string>("2. Swive Angle (Góc xoay của linh kiện)","(Sai góc xoay có thể gây ra gắn ngược cực linh kiện)"),
            new Tuple<string, string>("3. Đã hoàn thành SAVE(Lưu giữ) chương trình gắn","")
        };
        private List<Tuple<string, string>> QA = new List<Tuple<string, string>>()
        {
            new Tuple<string, string>("1. Bước Pitch của linh kiện","(Sai pitch sẽ gây tổn thất linh kiện hàng loạt, ảnh hưởng đến độ loss)"),
            new Tuple<string, string>("2. Swive Angle (Góc xoay của linh kiện)","(Sai góc xoay có thể gây ra gắn ngược cực linh kiện)"),
        };
        private List<Tuple<string, string>> MainSub = new List<Tuple<string, string>>()
        {
            new Tuple<string, string>("1. Bước Pitch của linh kiện","(Sai pitch sẽ gây tổn thất linh kiện hàng loạt, ảnh hưởng đến độ loss)"),
            new Tuple<string, string>("2. Swive Angle (Góc xoay của linh kiện)","(Sai góc xoay có thể gây ra gắn ngược cực linh kiện)"),
        };
        private Tokusai_GetCurrentLineConfirm info;

        public Action<string> ConfirmCompleted;
        public FormTokusaiConfirm(Tokusai_GetCurrentLineConfirm info)
        {
            this.info = info;

            InitializeComponent();
            this.lblTitle.Text = info.DEPT + " Confirm";
            this.lblLine.Text = info.LINE_ID;
            this.lblWo.Text = info.WO;

            if(info.DEPT == "PD")
            {
                rdoHasDocument.Visible = true;
                rdoNoDocument.Visible = true;
                lb1.Visible = true;
                lb2.Visible = true;
                lb3.Visible = true;
            }
            else
            {
                rdoHasDocument.Visible = false;
                rdoNoDocument.Visible = false;
                lb1.Visible = false;
                lb2.Visible = false;
                lb3.Visible = false;
            }
            DrawConfirmInfo();
        }
        private void DrawConfirmInfo()
        {
            var listInfo = this.info.DEPT == DEPT.PD ? PD : this.info.DEPT == DEPT.TE ? TE : this.info.DEPT == DEPT.QA ? QA : null;
            if (this.info.CHANGE_NAME.Contains("MainSub")) listInfo = MainSub;
            if (listInfo == null) return;
            int y = 25;
            int height = 70;
            foreach(var info in listInfo)
            {
                var itemConfirm1 = new UConfirmInfo(info.Item1,info.Item2);
                itemConfirm1.Location = new System.Drawing.Point(5, y);
                itemConfirm1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
                itemConfirm1.MinimumSize = new System.Drawing.Size(1, 1);
                itemConfirm1.Size = new System.Drawing.Size(708, height);
                this.groupConfirm.Controls.Add(itemConfirm1);
                y += height + 2;
            }
           

        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var notCheckAll = this.groupConfirm.Controls.OfType<UConfirmInfo>().Any(t => t.Checked == false);
            if (notCheckAll)
            {
                MessageBox.Show("Hãy xác nhận đầy đủ các thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbUsername.Text) || string.IsNullOrEmpty(txbPassword.Text))
            {
                MessageBox.Show("Hãy nhập thông tin user!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var checkUser = ECOHelper.CheckUserConfirm(txbUsername.Text.Trim(), txbPassword.Text.Trim(), info.DEPT);
            if (checkUser != TEXT.OK)
            {
                MessageBox.Show(checkUser, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(info.DEPT == "PD" && rdoNoDocument.Checked)
            {

                DialogResult log = MessageBox.Show("KHÔNG có giấy, QA không cần xác nhận\nYES để tiếp tục", "PD xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (log == DialogResult.Yes)
                {
                    Tokusai_GetCurrentLineConfirm autoConfirm = new Tokusai_GetCurrentLineConfirm();                  
                    autoConfirm.USER_CONFIRM = "IT";
                    autoConfirm.DEPT = DEPT.QA;
                    autoConfirm.ID = info.ID;
                    autoConfirm.LINE_ID =info.LINE_ID;
                    autoConfirm.WO = info.WO;
                    autoConfirm.CHANGE_NAME = info.CHANGE_NAME;
                    string result = ECOHelper.Tokusai_LineConfirm(autoConfirm);                                     
                }
                else return;
            }


            var confirmResult = MessageBox.Show("Bạn có muốn xác nhận OK không?", "Xác nhận",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirmResult == DialogResult.Yes)
            {
                info.USER_CONFIRM = txbUsername.Text.Trim();
                string result = ECOHelper.Tokusai_LineConfirm(info);
                if (result == TEXT.OK)
                {
                    ConfirmCompleted(TEXT.OK);
                    this.Dispose();
                }
                else MessageBox.Show(result);
            }
        }

        private void FormTokusaiConfirm_Load(object sender, EventArgs e)
        {

        }
    }
}
