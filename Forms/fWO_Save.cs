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
    public partial class fWO_Save : Form
    {
        DataTable dt;
        public fWO_Save()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            var data = rtWO.Lines;
            var refNo = DXHelper.GetRefNo();
            dt = new DataTable();
            foreach (var item in rtWO.Lines.Where(x => !string.IsNullOrEmpty(x)))
            {
                var col = item.Split('\t');
                if ("Priority" == col[0])
                {
                    //for (int i = 0; i < col.Length - 1; i++)
                    //{
                    //    dt.Columns.Add(col[i]);
                    //}
                    dt.Columns.Add("Priority", typeof(string));
                    dt.Columns.Add("WO", typeof(string));
                    dt.Columns.Add("Model", typeof(string));
                    dt.Columns.Add("Qty", typeof(int));
                    dt.Columns.Add("Line", typeof(string));
                    dt.Columns.Add("Bom", typeof(string));
                    dt.Columns.Add("ECO old", typeof(string));
                    dt.Columns.Add("ECO new", typeof(string));
                    dt.Columns.Add("TOKUSAI old", typeof(string));
                    dt.Columns.Add("TOKUSAI new", typeof(string));
                    dt.Columns.Add("Ref No", typeof(int));
                }
                else
                {

                    DataRow row = dt.NewRow();
                    if (!string.IsNullOrWhiteSpace(col[0]))
                    {
                        for (int i = 0; i < col.Length - 1; i++)
                        {
                            row[i] = col[i].Replace(",", "").Trim();
                        }
                        row[10] = refNo;
                        dt.Rows.Add(row);
                    }
                }
            }
            this.dataGridView1.DataSource = dt;
            //DatagridViewPerformance();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var refNo = DXHelper.SaveWorkingOrder(dt);
            // UmesHelper.GetDocument("RM3-7575-00SS01AI", "A01");
            DXHelper.SavePart(refNo);
            MessageBox.Show("Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
