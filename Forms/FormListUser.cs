using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Material_System.DAL;

namespace Material_System
{
    public partial class frmListUser : Form
    {

        private string _userId;
        private void LoadModule()
        {
            var lstRule = ErpHelper.FindRule(_userId);
            this.dgvAccess.DataSource = lstRule;
        }
        public void ShowData()
        {
            var data = SingletonHelper.PvsInstance.FindListUser();
            this.BeginInvoke(new Action(() =>
            {
                if (Program.userEntity != null && Program.userEntity.Rules.Any(r => r.MODULE == "ERP_ROOT" && r.RULE_ID == 1))
                {
                    addToolStripMenuItem.Enabled = true;
                    removeToolStripMenuItem.Enabled = true;
                }
                this.dgvUser.DataSource = data;
                for (int i = 0; i < dgvUser.Rows.Count; i++)
                {
                    dgvUser.Rows[i].Cells["clNo"].Value = i + 1;
                }
            }));
        }
        public void ComboboxOptionInit()
        {
            this.cbbOption.BeginUpdate();
            cbbOption.Items.AddRange(new[] { "USER_ID", "USER_NAME" });
            this.cbbOption.EndUpdate();
            cbbOption.SelectedIndex = 0;
        }
        public void SearchByUserId(string userId)
        {
            var data = SingletonHelper.PvsInstance.GetUserByID(userId);
            this.BeginInvoke(new Action(() =>
            {
                if (data == null)
                {
                    this.dgvUser.DataSource = null;
                    this.dgvAccess.DataSource = null;
                }
                else
                {
                    this.dgvUser.DataSource = new List<PvsService.USERSEntity>() { data };
                    for (int i = 0; i < dgvUser.Rows.Count; i++)
                    {
                        dgvUser.Rows[i].Cells["clNo"].Value = i + 1;
                    }
                }
            }));
        }

        public frmListUser()
        {
            InitializeComponent();
            this.dgvUser.AutoGenerateColumns = false;
            this.dgvAccess.AutoGenerateColumns = false;
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
                case "USER_ID":
                    SearchByUserId(value);
                    break;
                case "USER_NAME":
                    SearchByUserId(value);
                    break;
                default:
                    MessageBox.Show("?????");
                    break;
            }
        }


        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmModule(_userId).ShowDialog();
            LoadModule();
        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUser.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvUser.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvUser.Rows[selectedrowindex];
                _userId = selectedRow.Cells["USER_ID"].Value.ToString();
                var lstRule = ErpHelper.FindRule(_userId);
                this.dgvAccess.DataSource = lstRule;
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAccess.SelectedCells.Count > 0)
            {
                if (MessageBox.Show($"Are you sure to delete module ??", "Confirm Delete!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int selectedrowindex = dgvAccess.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgvAccess.Rows[selectedrowindex];
                    var module = selectedRow.Cells["MODULE"].Value.ToString();
                    var ruleId = (int)selectedRow.Cells["RULE_ID"].Value;
                    ErpHelper.RemoveRule(_userId, module, ruleId);
                    LoadModule();
                }
            }

        }
    }
}
