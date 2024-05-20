using Material_System.Business;
using Material_System.DAL;
using Material_System.Entities;
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
    public partial class fECOSave : Form
    {
        public fECOSave()
        {
            InitializeComponent();
        }
        public fECOSave(string partNo)
        {
            InitializeComponent();
            var entity = DXHelper.GetQuota(partNo);
            if (entity != null)
            {
                txtTnNo.Text = partNo;
            }
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTnNo.Text))
            {
                MessageBox.Show("Nhập thông tin TN!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            DXHelper.SaveTnECO(txtTnNo.Text);
            MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

    }
}
