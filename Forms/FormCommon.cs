using Material_System.Business;
using Material_System.DialogCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Material_System.Business.SystemSettings;

namespace Material_System
{

    public class FormCommon : Form
    {
        public void ShowConfirmDefaultScreen()
        {
            new DConfirmDefaultScreen(this.GetType().Name).ShowDialog();
        }

        public void BackToMain()
        {
            new frmMain().ShowDialog();
            this.Close();
        }

    }
}
