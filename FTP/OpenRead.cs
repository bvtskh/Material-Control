using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentFTP;
using Material_System.Business;

namespace Material_System.FTP
{
	internal static class OpenReadExample {

		public static void OpenRead(string relative) {
			using (var conn = new FtpClient(Constant.FTP_ADDRESS, Constant.FTP_USER, Constant.FTP_PASS)) {
				conn.Connect();

				// open an read-only stream to the file
				using (var istream = conn.OpenRead(relative)) {
					try {
                        // istream.Position is incremented accordingly to the reads you perform
                        // istream.Length == file size if the server supports getting the file size
                        // also note that file size for the same file can vary between ASCII and Binary
                        // modes and some servers won't even give a file size for ASCII files! It is
                        // recommended that you stick with Binary and worry about character encodings
                        // on your end of the connection.
					}
					finally {
						Console.WriteLine();
						istream.Close();
					}
				}
			}
		}

	}
}