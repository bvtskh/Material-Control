using Material_System.DAL;
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
    public partial class frmAddUser : Form
    {
        // bool modify = false;
        // ERP_USER userEntity = new ERP_USER();
        public frmAddUser()
        {
            InitializeComponent();
        }
        public frmAddUser(string userId)
        {
            InitializeComponent();
            //userEntity = ErpHelper.FindUser(userId);
            //if (userEntity != null)
            //{
            //    txtUserID.Text = userId;
            //    txtUserName.Text = userEntity.USER_NAME;
            //    txtPassword.Text = userEntity.PASS;
            //    txtUserID.Enabled = false;
            //}
            //modify = true;
        }
        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            //string userId = txtUserID.Text.Trim();
            //string userName = txtUserName.Text;
            //string password = txtPassword.Text;
            //if (string.IsNullOrEmpty(userId))
            //{
            //    MessageBox.Show("User Id not empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    return;
            //}
            //if (string.IsNullOrEmpty(password))
            //{
            //    MessageBox.Show("Password not empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    return;
            //}
            //if (modify)
            //{
            //    userEntity.USER_NAME = userName;
            //    userEntity.PASS = password;
            //}
            //var flag = ErpHelper.UserExist(userId);
            //if (flag)
            //{
            //    MessageBox.Show("User Id exist!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    return;
            //}
            //ERP_USER user = new ERP_USER()
            //{
            //    USER_ID = userId,
            //    USER_NAME = userName,
            //    PASS = password,
            //    CREATE_BY = Program.user.USER_ID,
            //    CREATE_DATE = DateTime.Now
            //};
            //flag = ErpHelper.SaveUser(user);
            //if (flag)
            //    MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else MessageBox.Show("Error! Contact 3143!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
