using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Material_System.DAL;
using Material_System.Entities;
using Material_System.UsapService;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Business
{
    public class DXHelper
    {
        private static void InitSqlServerDX()
        {
            SQLHelper.SERVER_NAME = "172.28.10.22";
            SQLHelper.USERNAME_DB = "sa";
            SQLHelper.PASSWORD_DB = "$umcevn123";
            SQLHelper.DATABASE = "Kitting";
            SQLHelper.ConnectString();
        }
        public static IEnumerable<string> GetListTN()
        {
            InitSqlServerDX();
            string sql = "SELECT [TN_NO] FROM [Kitting].[dbo].[ECO]";
            var lstTN = SQLHelper.ExecQueryData<string>(sql);
            return lstTN;
        }
        public static DataTable GetListQuota(string partNo = "")
        {
            InitSqlServerDX();
            StringBuilder s = new StringBuilder();
            s.Append("SELECT TOP(1000) * FROM[Kitting].[dbo].[Quota]");
            if (!string.IsNullOrEmpty(partNo))
            {
                s.Append($" WHERE Part_No LIKE '{partNo}%'");
            }
            return SQLHelper.ExecQueryDataAsDataTable(s.ToString());
        }
        public static DataTable GetReturnStock(string partNo = "")
        {
            InitSqlServerDX();
            StringBuilder s = new StringBuilder();
            s.Append("SELECT TOP(1000) BC_NO,PART_NO,TN_NO,BC_SITE,QTY,WH_LOC,WH_CODE,CREATE_TIME FROM [Kitting].[dbo].[Return]");
            if (!string.IsNullOrEmpty(partNo))
            {
                s.Append($" WHERE PART_NO LIKE '{partNo}%'");
            }
            return SQLHelper.ExecQueryDataAsDataTable(s.ToString());
        }
        public static void SaveQuota(QuotaEntity entity)
        {
            string query = $@"IF EXISTS(SELECT * FROM [Kitting].[dbo].[Quota] WHERE Part_No = '{entity.Part_No}')
	  UPDATE [Kitting].[dbo].[Quota] SET Pitch = '{entity.Pitch}', R_Max = '{entity.R_Max}', R_Min = '{entity.R_Min}' WHERE Part_No = '{entity.Part_No}'
	  ELSE
      INSERT INTO [Kitting].[dbo].[Quota] VALUES('{entity.Part_No}','{entity.Pitch}','{entity.R_Max}','{entity.R_Min}')";
            InitSqlServerDX();
            var res = SQLHelper.ExecQueryNonData(query);

        }
        public static QuotaEntity GetQuota(string partNo)
        {
            InitSqlServerDX();
            string sql = $"SELECT * FROM [Kitting].[dbo].[Quota] WHERE Part_No = '{partNo}'";
            return SQLHelper.ExecQueryDataFistOrDefault<QuotaEntity>(sql);
        }
        public static void SaveTnECO(string tnNo)
        {
            InitSqlServerDX();
            string sql = string.Format(@"IF EXISTS(SELECT * FROM [Kitting].[dbo].[ECO] WHERE TN_NO = '{0}')
                                          UPDATE [Kitting].[dbo].[ECO] SET TN_NO = '{1}' WHERE TN_NO = '{2}'
                                          ELSE 
                                          INSERT INTO [Kitting].[dbo].[ECO] VALUES('{3}',GETDATE())", tnNo, tnNo, tnNo, tnNo);
            SQLHelper.ExecQueryNonData(sql);
        }
        public static void RemoveTnECO(string tnNo)
        {
            InitSqlServerDX();
            string sql = string.Format(@"DELETE [Kitting].[dbo].[ECO] WHERE TN_NO = '{0}' ", tnNo);
            SQLHelper.ExecQueryNonData(sql);
        }
        public static List<QuotaEntity> GetNewPart()
        {
            List<QuotaEntity> result = new List<QuotaEntity>();
            var lstPart = UsapHelper.GetListPart();
            InitSqlServerDX();
            foreach (var partNo in lstPart)
            {
                string sql = string.Format("SELECT [Part_No] FROM [Kitting].[dbo].[Quota] WHERE Part_No = '{0}'", partNo);
                var obj = SQLHelper.ExecQueryDataFirstOrDefaultAsync<QuotaEntity>(sql);
                if (obj is null)
                {
                    result.Add(new QuotaEntity()
                    {
                        Part_No = partNo
                    });
                }
            }
            return result;
        }
        public static DataTable GetWokingOrder()
        {
            InitSqlServerDX();
            string sql = $"SELECT *  FROM [Kitting].[dbo].[Details] ORDER BY UPD_TIME DESC";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }
        public static DataTable GetWokingOrderItem()
        {
            InitSqlServerDX();
            string sql = $@"SELECT TOP (1000) [ORDER_NO]
                              ,[BC_NO]
                              ,[PART_NO]
                              ,[QTY]
                              ,[WH_LOC]
                               FROM [Kitting].[dbo].[Material_Order_Part] WHERE BC_NO <> ''";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }
        public static DataTable GetWokingOrderItem86()
        {
            InitSqlServerDX();
            string sql = $@"SELECT TOP (1000) [ORDER_NO]
                              ,[PART_NO]
                              ,[QTY]
                               FROM [Kitting].[dbo].[Material_Order_Part]   where BC_NO is null";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }
        public static string GetRefNo()
        {
            var str = DateTime.Now.ToString("yyMMdd");
            InitSqlServerDX();
            string sql = $"SELECT TOP 1 REF_NO FROM [Kitting].[dbo].[Details] where REF_NO like '{str}%'  order by REF_NO DESC";
            var res = SQLHelper.ExecQueryDataFistOrDefault<string>(sql);
            return string.IsNullOrEmpty(res) ? str + "01" : res.Left(6) + (Convert.ToInt32(res.Right(2)) + 1).ToString("D2");
        }
        public static string SaveWorkingOrder(DataTable dt)
        {
            InitSqlServerDX();
            string refNo = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                refNo = row["Ref No"].ToString();
                string sql = $@"IF NOT EXISTS(SELECT * FROM [Kitting].[dbo].[Details] WHERE ORDER_NO = '{row["WO"]}')
                                INSERT INTO [Kitting].[dbo].[Details] VALUES (NEWID()
                                ,'{row["Ref No"]}'
                                ,'{row["WO"]}'
                                ,'{row["Model"]}'
                                ,'{row["Qty"]}'
                                ,'{row["Line"]}'
                                ,'{row["Bom"]}'
                                ,'{row["Priority"]}'
                                ,'{row["ECO old"]}'
                                ,'{row["ECO new"]}'
                                ,'{row["TOKUSAI old"]}'
                                ,'{row["TOKUSAI new"]}'
                                ,'System'
                                ,GETDATE())";
                SQLHelper.ExecQueryNonData(sql);
            }
            return refNo;
        }
        public static void SavePart(string refNo)
        {
            foreach (var materialItem in GetByRefNo(refNo))
            {
                foreach (var item in UmesHelper.GetDocument(materialItem.COMPONENT_ID, materialItem.LINE_ID))
                {
                    var qty = item.UNIT_QUANTITY * materialItem.QTY;
                    int total = 0;
                    // Lấy dữ liệu trong kho vợt về
                    foreach (var returnItem in GetUpnReturn(item.PART_ID))
                    {
                        total += returnItem.QTY;
                        JObject keys = new JObject();
                        keys.Add("ORDER_NO", materialItem.ORDER_NO);
                        keys.Add("BC_NO", returnItem.BC_NO);
                        keys.Add("PART_NO", item.PART_ID);
                        keys.Add("WH_LOC", returnItem.WH_LOC);
                        keys.Add("QTY", returnItem.QTY);
                        UpdatePart(keys);
                        if (total >= qty)
                        {
                            break;
                        }
                    }
                    qty = qty - total;
                    //Lấy dữ liệu trên 86
                    if (qty > 0)
                    {
                        total = 0;
                        int t = 0;
                        foreach (var usapItem in UsapHelper.GetUpn86(item.PART_ID))
                        {
                            t++;
                            total += (int)usapItem.OS_QTY;
                            if (total >= qty)
                            {
                                JObject keys = new JObject();
                                keys.Add("ORDER_NO", materialItem.ORDER_NO);
                                keys.Add("PART_NO", item.PART_ID);
                                keys.Add("WH_LOC", usapItem.WH_LOC);
                                keys.Add("QTY", t);
                                UpdatePart86(keys);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private static List<MaterialItem> GetByRefNo(string refNo)
        {
            string sql = $@"SELECT [ORDER_NO]
                          ,[COMPONENT_ID]
                          ,[QTY]
                          ,[LINE_ID]
                           FROM [Kitting].[dbo].[Details]
                           where REF_NO = '{refNo}'";
            InitSqlServerDX();
            return SQLHelper.ExecQueryData<MaterialItem>(sql).ToList();
        }
        private static List<ReturnStockEntity> GetUpnReturn(string partNo)
        {
            InitSqlServerDX();
            string sql = $@"SELECT [BC_NO]
                          ,[PART_NO]
                          ,[QTY]
                          ,[WH_LOC]
                      FROM [Kitting].[dbo].[Return]
                      where PART_NO = '{partNo}' ORDER BY [CREATE_TIME] DESC";
            return SQLHelper.ExecQueryData<ReturnStockEntity>(sql).ToList();
        }
        private static void UpdatePart(JObject keys)
        {
            var bcNo = keys["BC_NO"].ToString();
            InitSqlServerDX();
            string sql = $@"UPDATE [Kitting].[dbo].[Return] SET ISSUE = '1' WHERE BC_NO = '{bcNo}'";
            SQLHelper.ExecQueryNonData(sql);
            sql = $@"INSERT INTO [Kitting].[dbo].[Material_Order_Part] VALUES(
                    '{keys["ORDER_NO"]}'
                    ,'{keys["BC_NO"]}'
                    ,'{keys["PART_NO"]}'
                    ,'{keys["QTY"]}'
                    ,'{keys["WH_LOC"]}')";
            SQLHelper.ExecQueryNonData(sql);
        }
        private static void UpdatePart86(JObject keys)
        {
            InitSqlServerDX();
            var sql = $@"INSERT INTO [Kitting].[dbo].[Material_Order_Part](ORDER_NO,PART_NO,QTY,WH_LOC) VALUES(
                    '{keys["ORDER_NO"]}'
                    ,'{keys["PART_NO"]}'
                    ,'{keys["QTY"]}'
                    ,'{keys["WH_LOC"]}')";
            SQLHelper.ExecQueryNonData(sql);
        }
        private static void InsertPart(JObject keys)
        {
            InitSqlServerDX();
            string sql = $@"INSERT INTO [Kitting].[dbo].[Material_Order_Part] VALUES(
                    '{keys["ORDER_NO"]}'
                    ,'{keys["BC_NO"]}'
                    ,'{keys["PART_NO"]}'
                    ,'{keys["QTY"]}'
                    ,'{keys["WH_LOC"]}')";
            SQLHelper.ExecQueryNonData(sql);
        }
    }
}
