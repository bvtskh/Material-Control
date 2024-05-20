using Material_System.Business;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Material_System.Business.SystemSettings;

namespace Material_System.DialogCustom
{
    public partial class DConfirmDefaultScreen : Form
    {
        private string formName;
        public DConfirmDefaultScreen(string formName)
        {
            InitializeComponent();
            this.formName = formName;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Ultils.WriteRegistry(SystemSettings.path,KeyName.DefaultScreen, formName);
            Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Ultils.WriteRegistry(SystemSettings.path, KeyName.DefaultScreen, "frmMain");
            Close();
        }
    }
}
