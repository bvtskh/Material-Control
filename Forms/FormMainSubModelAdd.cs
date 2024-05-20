using Material_System.Business;
using Material_System.DAL;
using Material_System.Entities;
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
    public partial class FormMainSubModelAdd : Form
    {
        public FormMainSubModelAdd()
        {
            InitializeComponent();
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            string PartFrom = txbPartFrom.Text.Trim();
            string PartTo = txbPartTo.Text.Trim();
            if (PartFrom.IsEmpty())
            {
                MessageBox.Show($"Model empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txbPartFrom.Focus();
                return;
            }
            if (PartTo.IsEmpty())
            {
                MessageBox.Show($"Part empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txbPartTo.Focus();
                return;
            }
            if (!rdoSpecial.Checked && !rdoNormal.Checked)
            {
                MessageBox.Show($"Choose Main-Sub Type!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }


            var result = ECOHelper.MainSubSave(new MainSubModel()
            {
                ID = Guid.NewGuid().ToString(),
                PART_FROM = PartFrom,
                UPD_TIME = DateTime.Now,
                PART_TO = PartTo,
                UPDATOR = Program.userEntity.User.ID,
                IS_SPECIAL = rdoSpecial.Checked,
            });
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result);
            }
            else
            {
                this.Dispose();
            }

        }

        private void FormMainSubModelAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
