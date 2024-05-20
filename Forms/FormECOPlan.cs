using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Material_System.DAL;

namespace Material_System
{
    public partial class FormECOPlan : Form
    {
        public void ShowData()
        {
            var lstRule = ErpHelper.FindRule(Module.ERP_LOTNO);
            this.BeginInvoke(new Action(() =>
            {
                if (lstRule != null && lstRule.Any(r => r == 1))
                {
                    btnAdd.Enabled = true;
                    btnImport.Enabled = true;
                    btnRemove.Enabled = true;
                }
                this.dataGridView1.DataSource = ECOHelper.GetListECOPlan();
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }));
        }
        public void ComboboxOptionInit()
        {
            this.cbbOption.BeginUpdate();
            cbbOption.Items.AddRange(new[] { "Model", "WO" });
            this.cbbOption.EndUpdate();
            cbbOption.SelectedIndex = 0;
        }
        public void SearchByWO(string WO)
        {
            if (string.IsNullOrEmpty(WO))
            { ShowData(); return; }
            var data = ECOHelper.FindECOPlanByWO(WO);

            this.BeginInvoke(new Action(() =>
            {
                this.dataGridView1.DataSource = data;
            }));
        }
        public void SearchByModel(string Model)
        {
            if (string.IsNullOrEmpty(Model))
            { ShowData(); return; }
            var data = ECOHelper.FindECOPlanByModel(Model);

            this.BeginInvoke(new Action(() =>
            {
                this.dataGridView1.DataSource = data;
            }));
        }


        public FormECOPlan()
        {
            InitializeComponent();
            ComboboxOptionInit();
        }

        private void frmLotNoBlock_Load(object sender, EventArgs e)
        {
            using (frmWaitForm frm = new frmWaitForm(ShowData))
            {
                frm.ShowDialog(this);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string value = txtSearch.Text;
            var option = cbbOption.Text;
            switch (option)
            {
                case "Model":
                    SearchByModel(value);
                    break;
                case "WO":
                    SearchByWO(value);
                    break;
                default:
                    MessageBox.Show("?????");
                    break;
            }
        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var data = SingletonHelper.UsapInstance.LotNoLockedGetAll();
            ShowData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormECOPlanAdd().ShowDialog();
            ShowData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                var id = selectedRow.Cells["WO"].Value.ToString();

                var confirmResult = MessageBox.Show($"Bạn có muốn xóa WO {id} không?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.No)
                {
                    return;
                }
                
                var res = ECOHelper.ECOPlanRemove(id);
                if (!string.IsNullOrEmpty(res))
                {
                    MessageBox.Show(res, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                using (frmWaitForm frm = new frmWaitForm(ShowData))
                {
                    frm.ShowDialog(this);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofl = new OpenFileDialog()
            {
                DefaultExt = "*.csv",
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };
            if (ofl.ShowDialog() == DialogResult.OK)
            {
                var dt = ExcelHelper2.ExcelImport(ofl.FileName);
                List<WH_LOTNG> lst = UsapHelper.ConvertToList(dt);
                var save = UsapHelper.SaveListLotNo(lst);
                if (save)
                {
                    MessageBox.Show("Save sucess", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Save error!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                ShowData();
            }

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, null);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(null, null);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
