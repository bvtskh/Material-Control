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
    public partial class FormStockByPart : Form
    {
        string partNo;
        
        public FormStockByPart(string partNo)
        {
            InitializeComponent();
            this.partNo = partNo;
        }

        private void FormStockByPart_Load(object sender, EventArgs e)
        {
            using (frmWaitForm frm = new frmWaitForm(ShowData))
            {
                frm.ShowDialog(this);
            }
        }

        private void ShowData()
        {
            DataTable data = UsapHelper.GetStockByPart(partNo);
           
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
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            this.dataGridView1.Refresh();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = UsapHelper.GetStockByPart(partNo);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable data = (DataTable) e.Result;
            if (data != null)
            {
                toolStripStatusLabel4.Text = data.Rows.Count.ToString() + " rows";
            }

            this.dataGridView1.DataSource = data;
        }
    }
   

}
