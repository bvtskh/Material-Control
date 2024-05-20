using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Material_System
{
    public enum Type
    {
        AUTO, MANUAL
    }
    public partial class frmVendorBarcode : Form
    {
        List<string> Paths = new List<string>();
        int pass = 0, ng = 0, total = 0;
        private List<VendorBarCode> info = new List<VendorBarCode>();
        private UsapService.BCLBFLMEntity upnEntity = new UsapService.BCLBFLMEntity();
        private string bcNo = String.Empty;
        private string vendorPartno = String.Empty;
        private bool exist = false;
        private Type type = Type.AUTO;

        // delegate used for Invoke
        internal delegate void StringDelegate(string data);
        public void OnStatusChanged(string status)
        {
            //Handle multi-threading
            if (InvokeRequired)
            {
                Invoke(new StringDelegate(OnStatusChanged), new object[] { status });
                return;
            }
            lblDeviceSate.Text = status;
        }

        // shutdown the worker thread when the form closes
        protected override void OnClosed(EventArgs e)
        {
            CommPort com = CommPort.Instance;
            com.Close();

            base.OnClosed(e);
        }
        public frmVendorBarcode()
        {
            InitializeComponent();
            BinDataToControls();
            SystemSettings.Read();
            CommPort com = CommPort.Instance;
            com.StatusChanged += OnStatusChanged;
            com.Open();
        }

        private void BinDataToControls()
        {
            lblVersion.Text = Ultils.GetRunningVersion();
        }


        /// <summary>
        /// Active Windows Title
        /// </summary>
        /// <param name="title"></param>
        private void ActiveProcess(string title)
        {
            Process[] processes = Process.GetProcesses();
            int windowHandle = 0;
            foreach (Process p in processes)
            {
                if (p.MainWindowTitle.Contains(title))
                {
                    windowHandle = (int)p.MainWindowHandle;
                    break;
                }

            }
            NativeWin32.SetForegroundWindow(windowHandle);
        }
        private void ActiveWindows(string title)
        {
            int windowHandle = NativeWin32.FindWindow(null, title);
            NativeWin32.SetForegroundWindow(windowHandle);
        }




        private void lblReset_Click(object sender, EventArgs e)
        {
            txtBarcode.ResetText();
            txtBarcode.Focus();
            ShowMessage("Default", @"[N\A]", "no result");
        }


        private void txtPcbA_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region Old
                bcNo = txtBarcode.Text.Trim();
                if (string.IsNullOrEmpty(bcNo))
                {
                    txtBarcode.ResetText();
                    return;
                }
                upnEntity = UsapHelper.GetUpn(bcNo);
                var flag = upnEntity == null;
                if (flag)
                {
                    ShowMessage("FAIL", "NG", "Bar Code not found!");
                    ClearData();
                    ng++;
                    total++;
                    ViewResult();
                    return;
                }
                flag = !string.IsNullOrEmpty(upnEntity.BC_SITE) && !string.IsNullOrEmpty(upnEntity.DATE_CODE);
                if (flag)
                {
                    ShowMessage("FAIL", "NG", $"Bar Code site is {upnEntity.BC_SITE}!");
                    return;
                }
                flag = upnEntity.OS_QTY == 0;
                if (flag)
                {
                    ShowMessage("FAIL", "NG", $"Bar Code balance is zero!");
                    return;
                }
                info = UsapHelper.GetData(bcNo);

                //  var manualData = UsapHelper.GetBarcode(bcNo);
                txtUMCPartno.Text = upnEntity.PART_NO;
                exist = info.Any(r => r.BC_NO != null && r.VEN_PART != null && r.DATE_CODE != null) || upnEntity.DATE_CODE != null;
                if (exist)
                {
                    if (info.Any(r => r.BC_NO != null && r.VEN_PART != null && r.DATE_CODE != null))
                    {
                        var element = info.FirstOrDefault(r => r.BC_NO.Equals(bcNo));
                        txtVendorPartno.Text = element.VEN_PART;
                        txtDatecode.Text = element.DATE_CODE;
                        txtDatecode.Focus();
                        txtDatecode.SelectAll();
                    }
                    else
                    {
                        txtVendorPartno.ResetText();
                        txtDatecode.Text = upnEntity.DATE_CODE;
                        txtDatecode.Focus();
                        txtDatecode.SelectAll();
                    }
                }
                else if (info.Count > 0)
                {
                    txtVendorPartno.Focus();
                    type = Type.AUTO;
                }
                else
                {
                    txtDatecode.Focus();
                    type = Type.MANUAL;
                }
                #endregion
                var partInfo = DAL.ErpHelper.FindPart(upnEntity.PART_NO);
                if (partInfo != null)
                {
                    using (var conn = new FluentFTP.FtpClient(Constant.FTP_ADDRESS, Constant.FTP_USER, Constant.FTP_PASS))
                    {
                        conn.AutoConnect();
                        // open an read-only stream to the file
                        using (var istream = conn.OpenRead(partInfo.FullPath))
                        {
                            try
                            {
                                var bmp = new Bitmap(istream);
                                pictureBox2.Image = (Bitmap)bmp.Clone();
                            }
                            finally
                            {
                                Console.WriteLine();
                                istream.Close();
                            }
                        }
                    }

                }

                txtVendorPartno.ResetText();
                txtVendorPartno.Focus();
            }
        }


        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtVendorPartno.Text))
                {
                    txtDatecode.ResetText();
                    txtDatecode.Focus();
                    return;
                }
                string year = DateTime.Now.Year.ToString();
                vendorPartno = txtVendorPartno.Text.Contains("WR") && txtVendorPartno.Text.Substring(txtVendorPartno.Text.Length - 8).Contains(year)
                    ? txtVendorPartno.Text.Substring(0, txtVendorPartno.Text.Length - 8).Trim()
                    : txtVendorPartno.Text.Trim();
                if (String.IsNullOrEmpty(vendorPartno))
                {
                    txtVendorPartno.ResetText();
                    return;
                }
                if (info.Any(r => r.VEN_PART == null))
                {
                    //if (setting.useComPort) Ultils.SendData(comControl, setting.signalNG);
                    ShowMessage("FAIL", "NG", "Venmasm parts not found!");
                    ClearData();
                    ng++;
                    total++;
                    ViewResult();
                    return;
                }
                if (!info.Any(r => r.VEN_PART.Contains(vendorPartno)))
                {
                    //  if (setting.useComPort) Ultils.SendData(comControl, setting.signalNG);
                    ShowMessage("FAIL", "NG", "Vendor part not found!");
                    ClearData();
                    ng++;
                    total++;
                    ViewResult();
                    return;
                }
                else
                {
                    txtDatecode.ResetText();
                    txtDatecode.Focus();
                }

            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtDatecode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var bcNo = txtBarcode.Text;
                var lotNo = txtDatecode.Text;
                if (string.IsNullOrEmpty(lotNo))
                {
                    return;
                }
                CommPort com = CommPort.Instance;
                var flag = UsapHelper.LotNoLocked(upnEntity.PART_NO, lotNo);
                if (flag)
                {
                    ShowMessage("FAIL", "NG", $"Lot [{lotNo}] blocked!");
                    MessageBox.Show($"Lot [{lotNo}] blocked!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string namesoft = Ultils.FindApplication("UMC SAP");
                flag = string.IsNullOrEmpty(namesoft);
                if (flag)
                {
                    MessageBox.Show($"Not open [UMC SAP]!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ActiveProcess(namesoft);
                var data = UsapHelper.GetData(bcNo);

                flag = data.Any(r => r.BC_NO != null && r.VEN_PART != null && r.DATE_CODE != null);
                if (flag)
                {
                    Clipboard.SetText(bcNo, TextDataFormat.Text);
                    SendKeys.SendWait("^V");
                    Thread.Sleep(300);
                    SendKeys.SendWait("{ENTER}");
                    Thread.Sleep(300);
                    SendKeys.SendWait("{TAB}");
                    // SendKeys.SendWait(txtDatecode.Text);
                    Clipboard.SetText(txtDatecode.Text, TextDataFormat.Text);
                    SendKeys.SendWait("^V");
                    Thread.Sleep(300);
                    SendKeys.SendWait("{ENTER}");
                    Thread.Sleep(300);
                    // SendKeys.SendWait("%{TAB}");
                    ActiveProcess("MC support");
                    ShowMessage("PASS", "OK", "Information match!");
                    com.Send(SystemSettings.Option.SignalOK);
                    ClearData();
                }
                else
                {
                    Clipboard.SetText(bcNo, TextDataFormat.Text);
                    SendKeys.SendWait("^V");
                    Thread.Sleep(300);
                    SendKeys.SendWait("{ENTER}");
                    SendKeys.Flush();
                    Thread.Sleep(300);
                    if (type == Type.AUTO)
                    {
                        vendorPartno = Regex.Replace(vendorPartno, "[+^%~()]", "{$0}");
                        // SendKeys.SendWait(vendorPartno);
                        Clipboard.SetText(vendorPartno, TextDataFormat.Text);
                        SendKeys.SendWait("^V");
                        SendKeys.Flush();
                        Thread.Sleep(300);
                        SendKeys.SendWait("{TAB}");

                        SendKeys.Flush();
                        Thread.Sleep(300);
                    }
                    //SendKeys.SendWait(txtDatecode.Text);
                    Clipboard.SetText(txtDatecode.Text, TextDataFormat.Text);
                    SendKeys.SendWait("^V");
                    Thread.Sleep(300);
                    SendKeys.SendWait("{ENTER}");
                    Thread.Sleep(300);
                    //SendKeys.SendWait("%{TAB}");
                    ActiveProcess("MC support");
                    total++;
                    pass++;
                    ViewResult();
                    ShowMessage("PASS", "OK", "Information match!");
                    com.Send(SystemSettings.Option.SignalOK);
                    ActiveProcess("USAP SUPPORT");
                    ClearData();
                }


            }
        }

        private void ShowMessage(string key, string str_status, string str_message)
        {
            switch (key)
            {
                case "PASS":
                    this.BeginInvoke(new Action(() => { lblStatus.Text = str_status; }));
                    this.BeginInvoke(new Action(() => { lblStatus.BackColor = Color.DarkGreen; }));
                    this.BeginInvoke(new Action(() => { lblMessage.Text = str_message; }));
                    this.BeginInvoke(new Action(() => { lblMessage.BackColor = Color.DarkGreen; }));
                    break;
                case "FAIL":
                    this.BeginInvoke(new Action(() => { lblStatus.Text = str_status; }));
                    this.BeginInvoke(new Action(() => { lblStatus.BackColor = Color.DarkRed; }));
                    this.BeginInvoke(new Action(() => { lblMessage.Text = str_message; }));
                    this.BeginInvoke(new Action(() => { lblMessage.BackColor = Color.DarkRed; }));
                    break;
                case "Wait":
                    this.BeginInvoke(new Action(() => { lblStatus.Text = str_status; }));
                    this.BeginInvoke(new Action(() => { lblStatus.BackColor = Color.FromArgb(255, 128, 0); }));
                    this.BeginInvoke(new Action(() => { lblMessage.Text = str_message; }));
                    this.BeginInvoke(new Action(() => { lblMessage.BackColor = Color.FromArgb(255, 128, 0); }));
                    break;
                case "Default":
                    this.BeginInvoke(new Action(() => { lblStatus.Text = @"[N\A]"; }));
                    this.BeginInvoke(new Action(() => { lblStatus.BackColor = Color.FromArgb(255, 128, 0); }));
                    this.BeginInvoke(new Action(() => { lblMessage.Text = "no results"; }));
                    this.BeginInvoke(new Action(() => { lblMessage.BackColor = Color.FromArgb(255, 128, 0); }));
                    break;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ShowMessage("Default", "", "");
            txtBarcode.ResetText();
            txtUMCPartno.ResetText();
            txtVendorPartno.ResetText();
            txtDatecode.ResetText();
            txtBarcode.Focus();
        }

        public void ClearData()
        {
            this.BeginInvoke(new Action(() =>
            {
                txtBarcode.ResetText();
                txtVendorPartno.ResetText();
                txtUMCPartno.ResetText();
                txtDatecode.ResetText();
                txtBarcode.Select();
                txtBarcode.Focus();
            }));
        }
        public void ViewResult()
        {
            lblTOTAL.Text = total.ToString();
            lblNG.Text = ng.ToString();
            lblPASS.Text = pass.ToString();
        }
    }
}
