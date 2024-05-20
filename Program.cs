using Material_System.Business;
using Material_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Material_System.Business.SystemSettings;

namespace Material_System
{
    static class Program
    {
       // public static ERP_USER user = null;
        public static PvsService.ErpUserEntity userEntity = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var defaultScreen = Ultils.GetValueRegistryKey(SystemSettings.path, KeyName.DefaultScreen);
            Application.Run(Ultils.GetForm(defaultScreen));
        }
    }
}
