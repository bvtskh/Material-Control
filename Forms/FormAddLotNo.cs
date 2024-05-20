using Material_System.Business;
using Material_System.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_System
{
    public partial class frmAddLotNo : Form
    {
        public frmAddLotNo()
        {
            InitializeComponent();
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            string lotNo = txtLotNo.Text;
            string partNo = txtPartNo.Text;
            if (partNo.IsEmpty())
            {
                MessageBox.Show($"Part No empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtPartNo.Focus();
                return;
            }
            if (lotNo.IsEmpty())
            {
                MessageBox.Show($"Lot No empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtLotNo.Focus();
                return;
            }
           
            List<WH_LOTNG> lst = new List<WH_LOTNG>()
            {
                new WH_LOTNG()
                {
                    ID = Guid.NewGuid().ToString(),
                    LOT_NO = lotNo,
                    PART_NO = partNo,
                    UPDATER = Environment.MachineName,
                    UPD_TIME = DateTime.Now
                }
            };

            var res = UsapHelper.SaveListLotNo(lst);
            if (res)
            {
                MessageBox.Show($"Lot No [{lotNo}] Locked!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show($"Error. Contact (3143)!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

    }
}
