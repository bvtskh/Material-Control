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
    public partial class FormTokusaiPlanAdd : Form
    {
        public FormTokusaiPlanAdd()
        {
            InitializeComponent();
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            string WO = txbWO.Text.Trim();
            string Model = txbModel.Text.Trim();
            string Qty = txbQuantity.Text.Trim();
            string OrderType = txbQuantity.Text.Trim();
            if (WO.IsEmpty())
            {
                MessageBox.Show($"WO empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txbWO.Focus();
                return;
            }
            if (Model.IsEmpty())
            {
                MessageBox.Show($"Model empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txbModel.Focus();
                return;
            }
            if (Qty.IsEmpty())
            {
                MessageBox.Show($"Qty empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txbModel.Focus();
                return;
            }
            if (OrderType.IsEmpty())
            {
                MessageBox.Show($"Order Type empty!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txbModel.Focus();
                return;
            }

            var result =  ECOHelper.TokusaiPlanSave(new Tokusai_Plan()
            {
                ID = Guid.NewGuid().ToString(),
                ORDER_NO = WO,
                MODEL_NO = Model,
                DUE_DATE = dpDueDate.Value,
                QUANTITY = Qty,
                ORDER_TYPE = OrderType,
                UPD_DATE = DateTime.Now
            });
            if(!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result);
            }
            else
            {
                this.Dispose();
            }
           
        }

        private void OnlyNumberPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            //  (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}

        }


    }
}
