using Material_System.Business;
using Material_System.DialogCustom;
using Material_System.Entities;
using System;
using System.Windows.Forms;

namespace Material_System
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            lblVersion.Text = Ultils.GetRunningVersion();
        }

        private void vendorBarcodeSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmVendorBarcode().ShowDialog();
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmConfig().ShowDialog();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLotNoBlock().ShowDialog();
        }

        private void historiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLotNoHis().ShowDialog();
        }

        private void barCodeOfSpecialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmTokusai().ShowDialog();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmLogin().ShowDialog();
            lblAccount.Text = Program.userEntity != null ? Program.userEntity.User.ID : "";
            if (Program.userEntity != null)
            {
                this.loginToolStripMenuItem.Visible = false;
                logOutToolStripMenuItem.Visible = true;
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.userEntity = null;
            this.loginToolStripMenuItem.Visible = true;
            lblAccount.Text = "";
            MessageBox.Show("Log out success!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void userFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmListUser().ShowDialog();
        }

        private void historiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmHisTokusai().ShowDialog();
        }

        private void alertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmTokusaiAlert().ShowDialog();
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmPart().ShowDialog();
        }

        private void changingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmTokusaiChange().ShowDialog();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new fTokusaiStock().ShowDialog();
        }

        private void changePaswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new fChangePass().ShowDialog();
        }

        private void tokusaiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new fTokusaiStock().ShowDialog();
        }

        private void stockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new fECOStock().ShowDialog();
        }

        private void quotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new fQuota().ShowDialog();
        }

        private void stockToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new fReturnStock().ShowDialog();
        }

        private void sMTRealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new fSMTReel().ShowDialog();
        }

        private void pullListPartWOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new fMaterialOrder().ShowDialog();
        }

        private void sMTLineAlarmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormTokusaiAlarm().ShowDialog();
        }

        private void listPartWOItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new fMaterialOrderItem().ShowDialog();
        }

        private void wOChangingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormECOPlan().ShowDialog();
        }

        private void sapBOMListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new fBomList().ShowDialog();
        }

        private void lineAlarmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormTokusaiAlarm().ShowDialog();
        }

        private void historiesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new FormTokusaiECOHistory().ShowDialog();
        }

        private void exchangeComponentToolStripMenuItem_Click(object sender, EventArgs e)

        {
            new fExchangeComponent().ShowDialog();
        }

        private void planToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormTokusaiPlan().ShowDialog();
        }

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormMainSubModel().ShowDialog();
        }

        private void moritoringUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormMonitoringUpdateJob().ShowDialog();
        }
    }
}
