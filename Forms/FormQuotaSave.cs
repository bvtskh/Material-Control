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
    public partial class fQuotaSave : Form
    {

        // private string _id = "";
        public fQuotaSave()
        {
            InitializeComponent();
        }
        public fQuotaSave(string partNo)
        {
            InitializeComponent();
            var entity = DXHelper.GetQuota(partNo);
            if (entity != null)
            {
                txtPartNo.Text = partNo;
                this.txtPitch.Text = entity.Pitch;
                this.txtRmax.Text = entity.R_Max.ToString();
                this.txtRmin.Text = entity.R_Min.ToString();
            }
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            QuotaEntity entity = new QuotaEntity()
            {
                Part_No = txtPartNo.Text.Trim(),
                Pitch = txtPitch.Text.Trim(),
                R_Max = txtRmax.Text.Trim(),
                R_Min = txtRmin.Text.Trim()
            };
            foreach (var error in entity.Validate())
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DXHelper.SaveQuota(entity);
            MessageBox.Show("Success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void txtEmNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //string emNo = txtEmNo.Text;
            //var data = ErpHelper.FindTokusaiByEmNo(emNo);
            //if (data == null || data.Count == 0)
            //{
            //    MessageBox.Show("E/M No not exist!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    return;
            //}

            //var entity = data.FirstOrDefault();
            //txtPartFm.Text = entity.PART_FM;
            //txtPartTo.Text = entity.PART_TO;
            //rModels.Lines = data.Select(r => r.PRODUCT_ID).ToArray();
        }

        private void btnPart_Click(object sender, EventArgs e)
        {
            using (fPartUsap f = new fPartUsap())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtPartNo.Text = f.PartNo;
                }
            }
        }
    }
}
