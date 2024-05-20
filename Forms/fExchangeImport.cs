using Material_System.Business;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Material_System
{
    public partial class fExchangeImport : Form
    {
        public string filePath;
        public string materialType;
        public fExchangeImport()
        {
            InitializeComponent();
            filePath = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofl = new OpenFileDialog()
            {
                DefaultExt = "*.csv",
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };
            if (ofl.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = filePath = ofl.FileName;
                materialType = chkFG.Checked ? "FG" : chkSemi.Checked ? "SEMI" : "";
                var lst = ExcelHelper2.GetExchangeComponent(ofl.FileName);
                var duplicate = lst.GroupBy(r => r.Material).Any(t => t.Count() > 1);
                if (duplicate)
                {
                    MessageBox.Show("Duplicate material number!");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.btnCancel_Click(null, null);
        }
    }
}
