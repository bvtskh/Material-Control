using Material_System.DAL;
using Material_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Business
{
    public class UmesHelper
    {
        private static void InitSqlServer()
        {
            SQLHelper.SERVER_NAME = "172.28.10.8";
            SQLHelper.USERNAME_DB = "sa";
            SQLHelper.PASSWORD_DB = "$umcevn123";
            SQLHelper.DATABASE = "UMC_MESDB_TEST";
            SQLHelper.ConnectString();
        }
        public static List<MachineDocumentLine> GetDocument(string component, string lineID)
        {
            string sql = $@"SELECT t2.COMPONENT_ID,t1.PART_ID,t1.UNIT_QUANTITY
                              FROM [UMC_MESDB_TEST].[dbo].[MACHINE_DOCUMENT_LINES] t1
                              INNER JOIN [UMC_MESDB_TEST].[dbo].[MACHINE_DOCUMENTS] t2 ON t2.ID = t1.DOCUMENT_ID
                              WHERE t1.DOCUMENT_ID = ( 
                              SELECT TOP 1 t2.ID
                              FROM [UMC_MESDB_TEST].[dbo].[MACHINE_DOCUMENTS] t2
                              WHERE t2.COMPONENT_ID = '{component}' AND t2.IS_READY = '1' AND LINE_ID = '{lineID}'
                              ORDER BY t2.CREATE_TIME DESC
                              )
                              AND t1.MACHINE_SLOT NOT IN ('0','999')";
            InitSqlServer();
            return SQLHelper.ExecQueryData<MachineDocumentLine>(sql).ToList();
            //foreach (var item in SQLHelper.ExecQueryData<MachineDocumentLine>(sql))
            //{
            //    Console.WriteLine(item.UNIT_QUANTITY);
            //}
        }

        public static bool Unlock(string username, string password, string module)
        {
            var user = SingletonHelper.PvsInstance.FindUser(username, password);
            if (user != null)
            {
                return user.Rules.Any(r => r.MODULE == module && r.RULE_ID == 1);
            }
            return false;
        }
    }
}
