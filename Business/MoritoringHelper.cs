using Material_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Business
{
    public static class MoritoringHelper
    {
        private static void InitSqlServer()
        {
            SQLHelper.SERVER_NAME = "172.28.10.17";
            SQLHelper.USERNAME_DB = "sa";
            SQLHelper.PASSWORD_DB = "umc@2019";
            SQLHelper.DATABASE = "SMT";
            SQLHelper.ConnectString();
        }
        public static DateTime LoadedOrderItemJob()
        {
            InitSqlServer();
            string sql = @"SELECT MAX(UPD_TIME) FROM [SMT].[dbo].[LoadedOrderItem]";
            return (DateTime)SQLHelper.ExecQuerySacalar(sql);
        }
        public static DateTime VerifedOrderItemJob()
        {
            InitSqlServer();
            string sql = @"SELECT MAX(UPD_VERIFY_TIME) FROM [SMT].[dbo].[LoadedOrderItem]";
            return (DateTime)SQLHelper.ExecQuerySacalar(sql);
        }
        public static DateTime TokusaiAlarmJob()
        {
            InitSqlServer();
            string sql = @"SELECT MAX(UPD_TIME) FROM [SMT].[dbo].[Tokusai_LineItem] ";
            return (DateTime)SQLHelper.ExecQuerySacalar(sql);
        }
        public static DateTime MainSubAlarmJob()
        {
            InitSqlServer();
            string sql = @"SELECT MAX(UPD_TIME) FROM [SMT].[dbo].[MainSub_LineItem] ";
            return (DateTime)SQLHelper.ExecQuerySacalar(sql);
        }
    }
}
