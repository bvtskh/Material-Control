using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentFTP;
using Material_System.Business;

namespace Material_System.FTP
{

    internal static class UploadManyFiles
    {

        public static void UploadFiles()
        {
            using (var ftp = new FtpClient("127.0.0.1", "ftptest", "ftptest"))
            {
                ftp.Connect();

                // upload many files, skip if they already exist on server
                ftp.UploadFiles(
                    new[] {
                        @"D:\Drivers\test\file0.exe",
                        @"D:\Drivers\test\file1.exe",
                        @"D:\Drivers\test\file2.exe",
                        @"D:\Drivers\test\file3.exe",
                        @"D:\Drivers\test\file4.exe"
                    },
                    "/public_html/temp/", FtpRemoteExists.Skip);

            }
        }
        public static void UploadFiles(string[] localPaths, string remoteDir)
        {
            using (var ftp = new FtpClient(Constant.FTP_ADDRESS, Constant.FTP_USER, Constant.FTP_PASS))
            {
                ftp.AutoConnect();
                ftp.UploadFiles(localPaths, remoteDir, FtpRemoteExists.Overwrite);
            }
        }

        public static async Task UploadFilesAsync()
        {
            var token = new CancellationToken();
            using (var ftp = new FtpClient("127.0.0.1", "ftptest", "ftptest"))
            {
                await ftp.ConnectAsync(token);

                // upload many files, skip if they already exist on server
                await ftp.UploadFilesAsync(
                    new[] {
                        @"D:\Drivers\test\file0.exe",
                        @"D:\Drivers\test\file1.exe",
                        @"D:\Drivers\test\file2.exe",
                        @"D:\Drivers\test\file3.exe",
                        @"D:\Drivers\test\file4.exe"
                    },
                    "/public_html/temp/", FtpRemoteExists.Skip);

            }
        }

    }
}