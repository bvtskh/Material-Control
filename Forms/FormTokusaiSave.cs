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
    public partial class FormTokusaiSave : Form
    {

        // private string _id = "";
        public FormTokusaiSave()
        {
            InitializeComponent();
        }
        public FormTokusaiSave(string emNo)
        {
            InitializeComponent();
            // _id = id;
            this.txtPartFm.Enabled = false;
            this.txtPartTo.Enabled = false;
            this.txtEmNo.Enabled = false;
            var lst = ErpHelper.FindTokusaiByEmNo(emNo);
            if (lst != null)
            {
                var entity = lst.FirstOrDefault();
                txtEmNo.Text = entity.EM_NO;
                this.txtPartFm.Text = entity.PART_FM;
                this.txtPartTo.Text = entity.PART_TO;
                this.txtOsQty.Text = entity.OS_QTY.ToString();
                this.rModels.Lines = lst.Select(r => r.PRODUCT_ID).ToArray();
            }
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            object value;
            value = txtEmNo.Text;
            if (string.IsNullOrEmpty(value.ToString()))
            {
                MessageBox.Show("E/M No not empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            value = txtPartFm.Text;
            if (string.IsNullOrEmpty(value.ToString()))
            {
                MessageBox.Show("Part From not empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            value = txtPartTo.Text;
            if (string.IsNullOrEmpty(value.ToString()))
            {
                MessageBox.Show("Part To not empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            value = txtOsQty.Text;
            int qty = 0;
            if (!int.TryParse(value.ToString(), out qty))
            {
                MessageBox.Show("Qty not number!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            List<WH_Tokusai> lstEntity = new List<WH_Tokusai>();
            var lstModel = rModels.Lines.Where(x => !string.IsNullOrEmpty(x)).Select(r => r.Trim());
            foreach (var item in lstModel)
            {
                lstEntity.Add(new WH_Tokusai()
                {
                    EM_NO = txtEmNo.Text,
                    PART_FM = txtPartFm.Text,
                    PART_TO = txtPartTo.Text,
                    OS_QTY = qty,
                    PRODUCT_ID = item.ToUpper()
                });
            }
            ErpHelper.SaveTokusai(lstEntity);
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
    }
}
