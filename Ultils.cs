using Microsoft.Win32;
using System;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Material_System
{
    public static class Ultils
    {
        public static string GetRunningVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static void RegisterInStartup(bool isChecked, string executablePath)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("ApplicationName", executablePath);
            }
            else
            {
                registryKey.DeleteValue("ApplicationName");
            }
        }

        /// <summary>
        /// create log
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="productionId"></param>
        /// <param name="status"></param>
        /// <param name="process"></param>
        public static void CreateFileLog(string model, string productId, string status, string process, DateTime dateCheck)
        {
            string _path = @"SOFTWARE\MC_SUPPOR\Configs";
            string dateTime = dateCheck.ToString("yyMMddHHmmss");
            string fileName = $"{dateTime}_{model}_{productId}.txt";
            //string fileName1 = String.Format("{0}_{1}_{2}.txt", dateTime, model, productId);
            string folderRoot = $@"{GetValueRegistryKey(_path, "OutputLog")}\";

            bool exists = Directory.Exists(folderRoot);
            if (!exists)
                Directory.CreateDirectory(folderRoot);

            string path = folderRoot + fileName;
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{model}|{productId}|{dateTime}|{status}|{process}");
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{model}|{productId}|{dateTime}|{status}|{process}");
                    tw.Close();
                }
            }
        }
        public static void WriteLog(string isWritelog, string umcBarcode, string vendorPartno, string dateCode)
        {
            //string _path = @"SOFTWARE\MC_SUPPOR\Configs";
            string dateTime = DateTime.Now.ToString("yyMMddHHmmss");
            string fileName = $"{dateTime}_{umcBarcode}.txt";
            //string fileName1 = String.Format("{0}_{1}_{2}.txt", dateTime, model, productId);
            //isWritelog = GetValueRegistryKey(_path, "OutputLog");
            string path = $@"C:\LOGPROCESS\{fileName}";
            bool exists = Directory.Exists(@"C:\LOGPROCESS");
            if (!exists)
                Directory.CreateDirectory(path);

            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine($"{umcBarcode}|{vendorPartno}|{dateCode}|{dateTime}");
                tw.Close();
            }


        }

        //public static bool IsCreateFileLog(string model, string productId, string status, string process, DateTime dateCheck)
        //{
        //    string dateTime = dateCheck.ToString("yyMMddHHmmss");
        //    string fileName = $"{dateTime}_{model}_{productId}.txt";
        //    string folderRoot = $@"{GetValueRegistryKey("OutputLog")}\";

        //    bool exists = Directory.Exists(folderRoot);
        //    if (!exists)
        //        Directory.CreateDirectory(folderRoot);

        //    string path = folderRoot + fileName;
        //    try
        //    {
        //        if (!File.Exists(path))
        //        {
        //            File.Create(path).Dispose();
        //            using (TextWriter tw = new StreamWriter(path))
        //            {
        //                tw.WriteLine($"{model}|{productId}|{dateTime}|{status}|{process}");
        //                tw.Close();
        //                return true;
        //            }
        //        }
        //        else if (File.Exists(path))
        //        {
        //            using (TextWriter tw = new StreamWriter(path))
        //            {
        //                tw.WriteLine($"{model}|{productId}|{dateTime}|{status}|{process}");
        //                tw.Close();
        //                return true;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //    return false;
        //}

        /// <summary>
        /// Đường dẫn log
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        //public static string FullPath()
        //{
        //    string folderRoot = GetValueRegistryKey("InputLog").ToString();
        //    string extension = GetValueRegistryKey("FileExtension").ToString();
        //    if (extension.Contains("*"))
        //        extension = extension.Replace("*", "");
        //    string month = "";
        //    if (GetDateTime().Month > 0 && GetDateTime().Month < 10)
        //    {
        //        month = $"0{GetDateTime().Month}";
        //    }
        //    else
        //    {
        //        month = GetDateTime().Month.ToString();
        //    }

        //    string fileName = $"2V1-9003-1_{GetDateTime().Year}_{month}{extension}";

        //    string genratePath = string.Format("{0}\\{1}", folderRoot, fileName);

        //    return genratePath;
        //}

        /// <summary>
        /// Lấy
        /// </summary>
        /// <param name="boardNo"></param>
        /// <returns></returns>
        public static bool CheckOddNumberInBoardNo(string boardNo)
        {
            string strFirst = boardNo.Substring(0, 11);
            string strLast = boardNo.Substring(11);
            try
            {
                int value = int.Parse(strLast);
                if ((value % 2) == 0)
                    return false;
            }
            catch (Exception)
            {
                return true;
            }
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardNo"></param>
        /// <returns></returns>
        public static string BoardGenrationByBoardNo(string boardNo)
        {
            string strFirst = boardNo.Substring(0, 11);
            string strLast = boardNo.Substring(11);
            try
            {
                int value = int.Parse(strLast);

                strLast = (value + 1).ToString();
                return strFirst + strLast;
            }
            catch (Exception)
            {
                return "error";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        /// <param name="newline"></param>
        /// <returns></returns>
        public static string ReadLastLine(string path, Encoding encoding, string newline)
        {
            string line = null;
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (reader.Peek() == -1)
                    {
                        return line;
                    }
                }
                reader.Close();
            }
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int CountLine(string path)
        {
            int count = 0;
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(file))
            {
                while (reader.ReadLine() != null)
                {
                    count++;
                }
                reader.Close();
                return count;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string GetValueInLine(string path, int line)
        {
            string value;
            using (var sr = new StreamReader(path))
            {
                for (int i = 1; i < line; i++)
                {
                    sr.ReadLine();
                }
                value = sr.ReadLine();
                sr.Dispose();
                return value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string GetLine(string path, int line)
        {
            string value;
            using (var sr = new StreamReader(path))
            {
                for (int i = 1; i < line; i++)
                {
                    sr.ReadLine();
                }
                value = sr.ReadLine();
                sr.Dispose();
                return value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="content"></param>
        public static void WriteRegistry(string path, string keyName, string content)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(path);
            if (!string.IsNullOrEmpty(keyName) && !string.IsNullOrEmpty(content))
            {
                key.SetValue(keyName, content);
                key.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="content"></param>
        public static void WriteRegistryArray(string path, string keyName, string content)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(path);
            if (!string.IsNullOrEmpty(keyName) && !string.IsNullOrEmpty(content))
            {
                string exitsValue = GetValueRegistryKey(path, keyName);
                if (exitsValue != null)
                {
                    exitsValue += content + ";";
                    key.SetValue(keyName, exitsValue);
                }
                else
                {
                    key.SetValue(keyName, content + ";");
                }
                key.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetValueRegistryKey(string path, string keyName)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(path);
            string value = null;
            if (key != null)
            {
                if (key.GetValue(keyName) != null)
                {
                    value = key.GetValue(keyName).ToString();
                    key.Close();
                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileProcessName(string filePath)
        {
            Process[] procs = Process.GetProcesses();
            string fileName = Path.GetFileName(filePath);

            foreach (Process proc in procs)
            {
                if (proc.MainWindowHandle != new IntPtr(0) && !proc.HasExited)
                {
                    ProcessModule[] arr = new ProcessModule[proc.Modules.Count];

                    foreach (ProcessModule pm in proc.Modules)
                    {
                        if (pm.ModuleName == fileName)
                            return proc.ProcessName;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsFileLocked(string filePath)
        {
            try
            {
                using (File.Open(filePath, FileMode.Open)) { }
                return false;
            }
            catch (IOException e)
            {
                var errorCode = Marshal.GetHRForException(e) & ((1 << 16) - 1);

                return errorCode == 32 || errorCode == 33;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }


        const int ERROR_SHARING_VIOLATION = 32;
        const int ERROR_LOCK_VIOLATION = 33;
        private static bool IsFileLocked(Exception exception)
        {
            int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
            return errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION;
        }

        public static bool CanReadFile(string filePath)
        {
            //Try-Catch so we dont crash the program and can check the exception
            try
            {
                //The "using" is important because FileStream implements IDisposable and
                //"using" will avoid a heap exhaustion situation when too many handles  
                //are left undisposed.
                using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    if (fileStream != null)
                        fileStream.Close();  //This line is me being overly cautious, fileStream will never be null unless an exception occurs... and I know the "using" does it but its helpful to be explicit - especially when we encounter errors - at least for me anyway!
                }
            }
            catch (IOException ex)
            {
                //THE FUNKY MAGIC - TO SEE IF THIS FILE REALLY IS LOCKED!!!
                if (IsFileLocked(ex))
                {
                    // do something, eg File.Copy or present the user with a MsgBox - I do not recommend Killing the process that is locking the file
                    return false;
                }
            }
            finally
            {
            }
            return true;
        }

        /// <summary>
        /// Lấy thời gian từ máy chủ SQL
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DateTime GetDateTime()
        {
            string connection = @"Data Source=172.28.64.8\MSSQLPVS;Initial Catalog=UMC_MESDB_TEST;Persist Security Info=True;User ID=sa;Password=$umcevn123;";
            string sql = "SELECT GETDATE() as CurrentTime";
            try
            {
                SqlConnection sqlConnect = new SqlConnection(connection);

                sqlConnect.Open();
                using (SqlCommand cmd = new SqlCommand(sql, sqlConnect))
                {
                    object obj = cmd.ExecuteScalar();
                    cmd.Prepare();
                    return obj != null ? DateTime.Parse(obj.ToString()) : DateTime.MinValue;
                }
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }
        /// <summary>
        /// Gửi dữ liệu qua Serial Port
        /// </summary>
        /// <param name="comport">Serial Port</param>
        /// <param name="data">Dữ liệu</param>
        public static void SendData(SerialPort comport, string data)
        {
            if (comport.IsOpen) comport.WriteLine(data);
            else System.Windows.Forms.MessageBox.Show(comport.PortName + " not open!");

        }
        public static string FindApplication(string NameSoft)
        {

            //string astring = null;
            foreach (Process p in Process.GetProcesses())
            {
                string h = p.MainWindowTitle.ToString(); //lay tung title cua tung process
                if (h.Length > 0)
                {
                    if (h.Contains(NameSoft))
                    {
                        return h;
                    }
                }
                p.Refresh();

            }
            return null;

        }
        public static void SetDoubleBuffering(this DataGridView dgv, bool value)
        {
            // Double buffering can make DGV slow in remote desktop
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                System.Type dgvType = dgv.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                        BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dgv, value, null);
            }
        }

        public static Form GetForm(string name)
        {

            switch (name)
            {
                case "FormTokusaiAlarm":
                    return new FormTokusaiAlarm();
                default:
                    return new frmMain();
            }
        }
    }
}
