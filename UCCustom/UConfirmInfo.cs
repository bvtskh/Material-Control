using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_System.UCCustom
{
    public partial class UConfirmInfo : UserControl
    {
        public bool Checked;
        public UConfirmInfo(string title, string sub)
        {
            InitializeComponent();
            cbTitle.Text = title;
            subTitle.Text = sub;
        }

        private void cbTitle_CheckedChanged(object sender, EventArgs e)
        {
            Checked = cbTitle.Checked;
        }
    }
}
