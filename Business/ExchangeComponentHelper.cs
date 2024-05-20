using Material_System.DAL;
using Material_System.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Material_System.Business
{
    public class ExchangeComponentHelper
    {
        private static void InitSqlServer()
        {
            SQLHelper.SERVER_NAME = "172.28.10.22";
            SQLHelper.USERNAME_DB = "sa";
            SQLHelper.PASSWORD_DB = "$umcevn123";
            SQLHelper.DATABASE = "COST_SYSTEM";
            SQLHelper.ConnectString();
        }

        public static List<string> GetAll()
        {
            InitSqlServer();
            string sql = "SELECT [PART_NO] FROM [COST_SYSTEM].[dbo].[PART_CONVERSION]";
            return SQLHelper.ExecQueryData<string>(sql).ToList();
        }
        public static DataTable GetListPart(List<ExchangeComponentEntity> lst)
        {
            InitSqlServer();
            DataTable dt = new DataTable();
            int i = 0;
            foreach (var item in lst)
            {
                string sql = $@"SELECT MATERIAL_NUMBER,BOM_LEVEL
                                  FROM [COST_SYSTEM].[dbo].[BOM_LIST]
                                  where ASSEMBLE_MATERIAL_NUMBER = '{item.Material}'";
                var entity = SQLHelper.ExecQueryDataFistOrDefault<BomListEntity>(sql);
                if (entity != null)
                {
                    i++;
                    sql = $@"SELECT MATERIAL_NUMBER, ASSEMBLE_MATERIAL_NUMBER, BOM_LEVEL,BOM_COMPONENT,QTY_ACTUAL*{item.Total} 'Qty Actual'
                               FROM [COST_SYSTEM].[dbo].[BOM_LIST]
                               WHERE MATERIAL_NUMBER = '{entity.MATERIAL_NUMBER}' AND QTY_ACTUAL <> 0 AND BOM_LEVEL >={entity.BOM_LEVEL}
                               order by BOM_LEVEL, ASSEMBLE_MATERIAL_NUMBER";
                    var dt1 = SQLHelper.ExecQueryDataAsDataTable(sql);
                    dt.Merge(dt1);
                    if (i >= 20)
                    {
                        break;
                    }
                }
            }
            return dt;
        }
        //Test ca ban thanh pham
        public static DataTable GetListExchange(DataTable tblExchange, string materialType)
        {
            InitSqlServer();
            if ("FG".Equals(materialType))
            {
                return SQLHelper.ExecProcedureDataAsDataTable("GetListExchangeFG", new { Data = tblExchange });
            }
            return SQLHelper.ExecProcedureDataAsDataTable("GetListExchange", new { Data = tblExchange });
        }
        public static void SaveTotal(List<ExchangeComponentEntity> lst)
        {
            InitSqlServer();
            string sql = "DELETE [COST_SYSTEM].[dbo].[EXCHANGE_TMP]";
            SQLHelper.ExecQueryNonData(sql);
            foreach (var item in lst)
            {
                sql = $"INSERT INTO [COST_SYSTEM].[dbo].[EXCHANGE_TMP](MATERIAL_NUMBER, TOTAL) VALUES ('{item.Material}','{item.Total}')";
                SQLHelper.ExecQueryNonData(sql);
            }
        }
        public static List<string> GetMaterialNotBomList(DataTable data)
        {
            InitSqlServer();
            //string sql = @"SELECT t1.MATERIAL_NUMBER
            //                  FROM [COST_SYSTEM].[dbo].[EXCHANGE_TMP] t1
            //                  LEFT JOIN [COST_SYSTEM].[dbo].[BOM_LIST] t2 ON t1.MATERIAL_NUMBER = t2.ASSEMBLE_MATERIAL_NUMBER
            //                  WHERE t2.MATERIAL_NUMBER is null";
            //return SQLHelper.ExecQueryData<string>(sql).ToList
            return SQLHelper.ExecProcedureData<string>("GetMaterialNotBomlist", new { Data = data }).ToList();
        }
    }
}
