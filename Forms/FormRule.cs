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
    public partial class frmModule : Form
    {
        private string _userId = string.Empty;
        public void InitModule()
        {
            this.cbbModule.BeginUpdate();
            this.cbbModule.DataSource = ErpHelper.GetAllModule();
            this.cbbModule.EndUpdate();
            cbbModule.SelectedIndex = 0;
        }
        public frmModule()
        {
            InitializeComponent();
        }
        public frmModule(string userId)
        {
            InitializeComponent();
            InitModule();
            _userId = userId;
            this.KeyPreview = true;
            this.KeyDown += FrmModule_KeyDown;
        }

        private void FrmModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                // Do what you want here
                btnSaveChanged_Click(null, null);
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            }
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            int access = 0;

            if (!int.TryParse(txtAccess.Text, out access))
            {
                MessageBox.Show("Access not valid!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            ERP_RULES entity = new ERP_RULES()
            {
                //ID = Guid.NewGuid().ToString(),
                USER_ID = _userId,
                MODULE = cbbModule.Text,
                RULE_ID = access,
                DESCRIPTION = txbDescription.Text
            };
           var result =  ErpHelper.SaveModule(entity);
            if (result)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Đã thêm quyền cho module này rồi");
            }
            this.Dispose();
        }

        private void cbbModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbDescription.Text = ErpHelper.GetDescriptionFromModule(cbbModule.Text.Trim());
        }
    }
}
