using Material_System.Business;
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
    public partial class FormTokusaiECOPlan : Form
    {
        public FormTokusaiECOPlan()
        {
            InitializeComponent();
        }

        private void FormTokusaiECOPlan_Load(object sender, EventArgs e)
        {
            using (frmWaitForm frm = new frmWaitForm(ShowData))
            {
                frm.ShowDialog(this);
            }
        }

        private void ShowData()
        {
            DataTable data = ECOHelper.GetTokusaiECOPlan();

            this.BeginInvoke(new Action(() =>
            {
                if (data != null)
                {
                    toolStripStatusLabel4.Text = data.Rows.Count.ToString() + " rows";
                }
                this.dataGridView1.DataSource = data;
            }));

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            this.dataGridView1.Columns[dataGridView1.Columns.Count-1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Refresh();
        }
    }
}
