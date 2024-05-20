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
    public partial class fChangePass : Form
    {
        public fChangePass()
        {
            InitializeComponent();
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            if (Program.userEntity == null)
            {
                MessageBox.Show("You can login!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            string oldPass = txtOldPass.Text;
            string newPass = txtNewPass.Text;
            if (Program.userEntity.User.PASSWORD != oldPass)
            {
                MessageBox.Show("Old pasword not match!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("New pasword not empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (newPass == oldPass)
            {
                MessageBox.Show("New pasword same password!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            var res = ErpHelper.ChangePass(newPass);
            if (!res)
            {
                MessageBox.Show("Change pass errors!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            MessageBox.Show("Change pass success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Program.user.PASS = newPass;
            this.Dispose();
        }
    }
}
