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
    public partial class fParam : Form
    {
        public List<string> values;
        public fParam()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            values = richTextBox1.Lines.ToList();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
