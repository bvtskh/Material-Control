using Material_System.Business;
using Material_System.DAL;
using System;
using System.Windows.Forms;

namespace Material_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtCode.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                lblMessage.Text = "Nhập username;";
                return;
            }
            if (string.IsNullOrEmpty(username))
            {
                lblMessage.Text = "Nhập Password";
                return;
            }
            // Program.user = ErpHelper.FindUser(username, password);
            Program.userEntity = SingletonHelper.PvsInstance.FindUser(username, password);
            if (Program.userEntity == null)
            {
                lblMessage.Text = "Tên đăng nhập hoặc mật khẩu k chính xác";
                return;
            }
            this.Dispose();
            //var user = USERS_BUS.Get(username, password);
            //if (user != null)
            //{
            //    Program.CurrentUser = user;
            //    this.Hide();
            //    new FormMain().ShowDialog();
            //}
            //else
            //{
            //    lblMessage.Text = "Code không tồn tại. Vui lòng kiểm tra lại;";
            //    txtCode.SelectAll();
            //    txtCode.Focus();
            //    txtPassword.ResetText();
            //}
        }


        private void txtPassword_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtCode.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    button1.PerformClick();
                }
            }
        }
    }
}
