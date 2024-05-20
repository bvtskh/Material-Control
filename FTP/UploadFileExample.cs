using FluentFTP;
using Material_System.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Material_System.FTP
{
    internal static class UploadFileExample
    {

        public static void UploadFile()
        {
            using (var ftp = new FtpClient("127.0.0.1", "ftptest", "ftptest"))
            {
                ftp.Connect();

                // upload a file to an existing FTP directory
                ftp.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md");

                // upload a file and ensure the FTP directory is created on the server
                ftp.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true);

                // upload a file and ensure the FTP directory is created on the server, verify the file after upload
                ftp.UploadFile(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true, FtpVerify.Retry);

            }
        }
        public static void UploadFile(string localPath, string remotePath)
        {
            using (var ftp = new FtpClient(Constant.FTP_ADDRESS, Constant.FTP_USER, Constant.FTP_PASS))
            {
                //ftp.Connect();
                ftp.AutoConnect();
                // upload a file and ensure the FTP directory is created on the server, verify the file after upload
                ftp.UploadFile(localPath, remotePath, FtpRemoteExists.Overwrite, true, FtpVerify.Retry);
                //ftp.UploadFile(localPath, remotePath);
                //ftp.Disconnect();
            }
        }
        public static async Task UploadFileAsync()
        {
            var token = new CancellationToken();
            using (var ftp = new FtpClient("127.0.0.1", "ftptest", "ftptest"))
            {
                await ftp.ConnectAsync(token);

                // upload a file to an existing FTP directory
                await ftp.UploadFileAsync(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md");

                // upload a file and ensure the FTP directory is created on the server
                await ftp.UploadFileAsync(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true);

                // upload a file and ensure the FTP directory is created on the server, verify the file after upload
                await ftp.UploadFileAsync(@"D:\Github\FluentFTP\README.md", "/public_html/temp/README.md", FtpRemoteExists.Overwrite, true, FtpVerify.Retry);

            }
        }
        /// <summary>
        /// Tải file bất đồng bộ
        /// </summary>
        /// <param name="localPath">Đường dẫn file máy trạm</param>
        /// <param name="remotePath">Đường dẫn file máy chủ</param>
        /// <returns></returns>
        public static async Task UploadFileAsync(string localPath, string remotePath)
        {
            var token = new CancellationToken();
            using (var ftp = new FtpClient(Constant.FTP_ADDRESS, Constant.FTP_USER, Constant.FTP_PASS))
            {
                await ftp.ConnectAsync(token);

                // upload a file and ensure the FTP directory is created on the server, verify the file after upload
                await ftp.UploadFileAsync(localPath, remotePath, FtpRemoteExists.Overwrite, true, FtpVerify.Retry);

            }
        }
    }
}
