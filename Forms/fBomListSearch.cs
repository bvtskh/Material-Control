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
    public partial class fBomListSearch : Form
    {
        public static List<string> lstCustomer;
        public static List<string> lstMaterial;
        public fBomListSearch()
        {
            InitializeComponent();
            lstMaterial = new List<string>();
            lstCustomer = new List<string>();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            using (fParam form = new fParam())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lstCustomer = form.values;
                    this.txtCustomer.Text = lstCustomer == null || lstCustomer.Count == 0 ? "" : lstCustomer[0];
                }
            }
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            using (fParam form = new fParam())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lstMaterial = form.values;
                    this.txtMaterial.Text = lstMaterial == null || lstMaterial.Count == 0 ? "" : lstMaterial[0];
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustomer.Text))
            {
                if (lstCustomer.Count > 0)
                {
                    lstCustomer[0] = txtCustomer.Text;
                }
                else
                {
                    lstCustomer.Add(txtCustomer.Text);
                }
            }

            if (!string.IsNullOrEmpty(txtMaterial.Text))
            {
                if (lstMaterial.Count > 0)
                {
                    lstMaterial[0] = txtMaterial.Text;
                }
                else
                {
                    lstMaterial.Add(txtMaterial.Text);
                }
            }

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fBomListSearch_Load(object sender, EventArgs e)
        {
            this.txtCustomer.Text = lstCustomer == null || lstCustomer.Count == 0 ? "" : lstCustomer[0];
            this.txtMaterial.Text = lstMaterial == null || lstMaterial.Count == 0 ? "" : lstMaterial[0];
        }
    }
}
