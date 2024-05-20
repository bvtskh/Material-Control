using Material_System.Business;
using System;
using System.Windows.Forms;

namespace Material_System
{
    public partial class FormTokusaiECOHistory : Form
    {
        public void ShowData()
        {
            this.BeginInvoke(new Action(() =>
            {
                this.dgrvViewLineComfirm.DataSource =
               ECOHelper.Tokusai_GetAllLineConfirmCompletedByDate
               (cbTokusai.Checked,
               cbECO.Checked,
               cbbLocation.Text,
               dpFrom.Value,
               dpTo.Value);
            }));
        }
        public FormTokusaiECOHistory()
        {
            Console.Write("");
            InitializeComponent();

            this.dgrvViewLineComfirm.AutoGenerateColumns = false;
            dgrvViewLineComfirm.SetDoubleBuffering(true);
        }

        private void cbb_CheckedChanged(object sender, EventArgs e)
        {
            ShowData();
        }
        private void BindingLocation()
        {
            this.cbbLocation.Items.Clear();
            this.cbbLocation.Items.Add("ALL");
            this.cbbLocation.Items.AddRange(ECOHelper.GetLocation());
            this.cbbLocation.SelectedIndex = 0;
            dpFrom.Value = DateTime.Now.AddDays(-30);
            dpTo.Value = DateTime.Now.AddDays(10);
        }
        private void FormTokusaiECOHistory_Load(object sender, EventArgs e)
        {
            ShowData();
            BindingLocation();
            this.cbbLocation.SelectedIndexChanged += new System.EventHandler(this.cbb_CheckedChanged);
            this.cbECO.CheckedChanged += new System.EventHandler(this.cbb_CheckedChanged);
            this.cbTokusai.CheckedChanged += new System.EventHandler(this.cbb_CheckedChanged);
        }

        private void btnFilterUpdateTime_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
