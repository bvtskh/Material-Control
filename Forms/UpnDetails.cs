using Material_System.Business;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Material_System
{
    public partial class frmTokusaiDetail : Form
    {
        public frmTokusaiDetail()
        {
            InitializeComponent();
        }
        public frmTokusaiDetail(string upn)
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            var bcTokusai = SingletonHelper.UsapInstance.GetBcTokusai(upn);
            if (bcTokusai != null)
            {
                var source = SingletonHelper.ErpInstance.FindTokusai(bcTokusai.EM_NO, bcTokusai.PART_FM, bcTokusai.PART_TO);
                this.dataGridView1.DataSource = source.OrderBy(r => r.PRODUCT_ID).ToList();
                this.lblRows.Text = $"{source.Count()} rows";
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var data = dataGridView1.SelectedCells[0].Value.ToString();
                Clipboard.SetText(data);
            }
        }
    }
}
