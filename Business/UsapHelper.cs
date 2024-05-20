using Material_System.DAL;
using Material_System.UsapService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Material_System.Business
{
    public class UsapHelper
    {

        public static List<VendorBarCode> GetData(string barcode)
        {
            //IDatabase database = DataFactory.Database("USAP");
            //List<DbParameter> parameters = new List<DbParameter>();
            InitSqlServerUsap();
            string sql = "";
            if (!barcode.IsEmpty())
            {
                //parameters.Add(DbFactory.CreateDbParameter("@BC_NO", barcode));
                sql = $@"SELECT BC.[BC_NO]
                              ,BC.[PART_NO]
                              ,BC.[DATE_CODE],UV.[VEN_PART]
                      FROM [dbo].[BCLBFLM] BC,[dbo].[UVPMASM] UV
                      WHERE     BC.[PART_NO] = UV.[PART_NO]
                            AND BC.BC_NO = '{barcode}'";
                // var data = database.FindEntityBySql<VendorBarCode>(sql, parameters.ToArray());
                //database.BeginTrans();
                //var data = database.FindListBySql<VendorBarCode>(sql, parameters.ToArray());
                var data = SQLHelper.ExecQueryData<VendorBarCode>(sql);
                if (data != null)
                {
                    return data.ToList();
                }
            }
            return null;
        }


        /// <summary>
        /// Lưu dữ liệu LotNo bị khóa
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static bool SaveListLotNo(List<WH_LOTNG> lst)
        {
            var lstHis = new List<WH_BCLBFLM_His>();
            try
            {
                using (BaseContext context = new BaseContext())
                {

                    foreach (var item in lst)
                    {
                        var count = context.WH_LOTNGs.Where(r => r.PART_NO == item.PART_NO && r.LOT_NO == item.LOT_NO).Count();
                        if (count == 0)
                        {
                            context.WH_LOTNGs.Add(item);
                            context.WH_BCLBFLM_His.Add(new WH_BCLBFLM_His()
                            {
                                ID = Guid.NewGuid().ToString(),
                                IS_LOCK = true,
                                LOT_NO = item.LOT_NO,
                                PART_NO = item.PART_NO,
                                UPDATER = item.UPDATER,
                                UPD_TIME = item.UPD_TIME
                            });
                        }
                    }
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }

        public static List<WH_LOTNG> FindListLotNoLocked()
        {
            using (BaseContext context = new BaseContext())
            {

                return context.WH_LOTNGs.Take(100).OrderByDescending(r => r.UPD_TIME).ToList();
            }
        }
        public static List<WH_BCLBFLM_His> FindListHis()
        {
            using (BaseContext context = new BaseContext())
            {
                return context.WH_BCLBFLM_His.Take(100).OrderByDescending(r => r.UPD_TIME).ToList();
            }
        }

        public static List<WH_LOTNG> FindListLotNoLockedLike(string lotNo)
        {
            if (lotNo.IsEmpty()) return FindListLotNoLocked();
            using (BaseContext context = new BaseContext())
            {
                return context.WH_LOTNGs.Where(r => r.LOT_NO.Contains(lotNo)).OrderByDescending(t => t.UPD_TIME).ToList();
            }
        }

        public static List<WH_LOTNG> FindListPartNoLockedLike(string partNo)
        {
            if (partNo.IsEmpty()) return FindListLotNoLocked();
            using (BaseContext context = new BaseContext())
            {
                return context.WH_LOTNGs.Where(r => r.PART_NO.Contains(partNo)).OrderByDescending(t => t.UPD_TIME).ToList();
            }
        }

        public static bool LotNoLocked(string partNo, string lotNo)
        {
            if (string.IsNullOrEmpty(lotNo))
            {
                return true;
            }
            var lotLock = SingletonHelper.UsapInstance.LotNoLockedFind(partNo, lotNo);
            if (lotLock != null)
            {
                return true;
            }
            return false;
        }

        public static UsapService.ResultEntity SaveLotNoLocked(UsapService.LotNo_LockedEntity entity)
        {
            UsapService.ResultEntity res = new UsapService.ResultEntity() { status = "OK" };
            var flag = !UsapHelper.LotNoLocked(entity.PART_NO, entity.LOT_NO);
            if (flag)
            {
                res = SingletonHelper.UsapInstance.LotNoLockedSave("", entity);
            }
            return res;
        }

        public static int LotNoUpdate(string id)
        {
            try
            {
                using (BaseContext context = new BaseContext())
                {
                    var entity = context.WH_LOTNGs.Find(id);
                    if (entity != null)
                    {

                        context.WH_LOTNGs.Remove(entity);
                        context.WH_BCLBFLM_His.Add(new WH_BCLBFLM_His()
                        {
                            ID = Guid.NewGuid().ToString(),
                            IS_LOCK = false,
                            LOT_NO = entity.LOT_NO,
                            PART_NO = entity.PART_NO,
                            UPDATER = Environment.MachineName,
                            UPD_TIME = DateTime.Now
                        });
                    }
                    return context.SaveChanges();
                }
            }
            catch
            {

                return -1;
            }

        }

        public static UsapService.BCLBFLMEntity GetUpn(string bcNo)
        {
            if (string.IsNullOrEmpty(bcNo)) return null;
            return SingletonHelper.UsapInstance.GetByBcNo(bcNo);
        }

        public static List<WH_BCLBFLM_His> FindHisByPartNo(string partNo)
        {
            List<WH_BCLBFLM_His> res = new List<WH_BCLBFLM_His>();
            try
            {
                using (BaseContext context = new BaseContext())
                {
                    res = context.WH_BCLBFLM_His.Where(r => r.PART_NO.Contains(partNo)).ToList();
                }
            }
            catch
            {

                throw;
            }
            return res;
        }

        public static List<WH_BCLBFLM_His> FindHisByLotNo(string lotNo)
        {
            List<WH_BCLBFLM_His> res = new List<WH_BCLBFLM_His>();
            try
            {
                using (BaseContext context = new BaseContext())
                {
                    res = context.WH_BCLBFLM_His.Where(r => r.PART_NO.Contains(lotNo)).ToList();
                }
            }
            catch
            {

            }
            return res;
        }

        public static List<WH_BCLBFLM_His> FindHisByUser(string userId)
        {
            List<WH_BCLBFLM_His> res = new List<WH_BCLBFLM_His>();
            try
            {
                using (BaseContext context = new BaseContext())
                {
                    res = context.WH_BCLBFLM_His.Where(r => r.UPDATER.Contains(userId)).ToList();
                }
            }
            catch
            {

            }
            return res;
        }

        public static List<WH_LOTNG> ConvertToList(System.Data.DataTable dt)
        {
            List<WH_LOTNG> res = new List<WH_LOTNG>();
            try
            {
                res = (from System.Data.DataRow dr in dt.Rows
                       select new WH_LOTNG()
                       {
                           ID = Guid.NewGuid().ToString(),
                           PART_NO = dr["PART NO"].ToString(),
                           LOT_NO = dr["LOT NG"].ToString(),
                           UPDATER = Environment.MachineName,
                           UPD_TIME = DateTime.Now
                       }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return res;
        }
        //public static List<WH_Tokusai> FindTokusaiByEmNo(string emNo)
        //{
        //    if (string.IsNullOrEmpty(emNo))
        //    {
        //        return null;
        //    }
        //    return context.WH_Tokusais.Where(r => r.EM_NO == emNo).ToList();
        //}
        public static bool TokusaiAcceptAll(string emNo)
        {
            // IDatabase database = DataFactory.Database("USAP");
            InitSqlServerUsap();
            List<DbParameter> parameters = new List<DbParameter>();
            string sql = "";

            sql = $@"SELECT COUNT(EM_NO)
                          FROM [UMC3000].[dbo].[EMRDETM]
                          WHERE EM_NO = '{emNo}' AND EM_RMK like '%all%'";
            //var count = database.FindCountBySql(sql);
            var count = (int)SQLHelper.ExecQuerySacalar(sql);
            return count >= 1 ? true : false;
        }
        //public static List<BCLBFLMEntity> GetAllTokusai()
        //{
        //    string sql = @"
        //                    SELECT BC_NO,TN_NO,PART_NO,OS_QTY,PO_NO,BC_SITE,WH_LOC,UPD_DATE 
        //                    FROM [UMC3000].[dbo].[BCLBFLM] 
        //                    where PO_NO like 'u%'
        //                    AND BC_SITE NOT IN ('20','21','99','21@','28','')
        //                    AND OS_QTY <> '0'
        //                    AND UPD_DATE < '2023-1-1' 
        //                    UNION ALL
        //                    SELECT BC_NO,TN_NO,PART_NO,OS_QTY,PO_NO,BC_SITE,WH_LOC,UPD_DATE 
        //                    FROM [UMC3000].[dbo].[BCLBFLM] 
        //                    where PO_NO like 'u%'
        //                    AND BC_SITE NOT IN ('28')
        //                    AND UPD_DATE > '2023-1-1'";
        //    var res = SQLHelper.ExecQueryData<BCLBFLMEntity>(sql).ToList();
        //    return res;
        //}
        public static DataTable GetTokusaiStock(string partNo = "")
        {
            InitSqlServerUsap();
            StringBuilder s = new StringBuilder();
            s.Append("SELECT BC_NO,TN_NO,PART_NO,OS_QTY,PO_NO,BC_SITE,WH_LOC,UPD_DATE" +
                " FROM [UMC3000].[dbo].[BCLBFLM]" +
                " WHERE PO_NO like 'u%' AND BC_SITE NOT IN ('20','21','99','21@','28','') AND OS_QTY <> '0' AND UPD_DATE < '2023-1-1'");
            if (!string.IsNullOrEmpty(partNo))
            {
                s.Append($" AND PART_NO = '{partNo}'");
            }
            s.Append(" UNION ALL" +
                " SELECT BC_NO,TN_NO,PART_NO,OS_QTY,PO_NO,BC_SITE,WH_LOC,UPD_DATE" +
                " FROM [UMC3000].[dbo].[BCLBFLM]" +
                " WHERE PO_NO like 'u%'" +
                " AND BC_SITE NOT IN ('28')" +
                " AND UPD_DATE > '2023-1-1'");
            if (!string.IsNullOrEmpty(partNo))
            {
                s.Append($" AND PART_NO = '{partNo}'");
            }
            string sql = @"
                            SELECT BC_NO,TN_NO,PART_NO,OS_QTY,PO_NO,BC_SITE,WH_LOC,UPD_DATE 
                            FROM [UMC3000].[dbo].[BCLBFLM] 
                            where PO_NO like 'u%'
                            AND BC_SITE NOT IN ('20','21','99','21@','28','')
                            AND OS_QTY <> '0'
                            AND UPD_DATE < '2023-1-1' 
                            UNION ALL
                            SELECT BC_NO,TN_NO,PART_NO,OS_QTY,PO_NO,BC_SITE,WH_LOC,UPD_DATE 
                            FROM [UMC3000].[dbo].[BCLBFLM] 
                            where PO_NO like 'u%'
                            AND BC_SITE NOT IN ('28')
                            AND UPD_DATE > '2023-1-1'";
            var res = SQLHelper.ExecQueryDataAsDataTable(s.ToString());
            return res;
        }

        public static DataTable GetECOStock(string partNo = "")
        {

            var lstTN = DXHelper.GetListTN();
            InitSqlServerUsap();
            StringBuilder s = new StringBuilder();
            s.Append("SELECT BC_NO,TN_NO,PART_NO,OS_QTY,PO_NO,BC_SITE,WH_LOC,UPD_DATE");
            s.Append(" FROM [UMC3000].[dbo].[BCLBFLM]");
            s.Append($" WHERE TN_NO IN('{string.Join("','", lstTN.ToArray())}')");
            if (!string.IsNullOrEmpty(partNo))
            {
                s.Append($" AND PART_NO LIKE '{partNo}%'");
            }
            var res = SQLHelper.ExecQueryDataAsDataTable(s.ToString());
            return res;
        }
        public static DataTable GetSMTReel(string partNo = "")
        {
            InitSqlServerUsap();
            //StringBuilder s = new StringBuilder();
            //s.Append("SELECT [BC_NO],[BC_SITE],[PART_NO],[REQ_QTY],[OS_QTY],[WH_LOC],[WH_CODE],UPD_DATE\r\n FROM [UMC3000].[dbo].[BCLBFLM]\r\n  where WH_LOC like '[CKMNFB][A-Z][0-9][0-9][0-9]-[0-9]' AND BC_SITE NOT IN ('20','21','21@','29') AND BC_TYPE = 'TN'");
            //s.Append("UNION ALL\r\n SELECT [BC_NO],[BC_SITE],[PART_NO],[REQ_QTY],[OS_QTY],[WH_LOC],[WH_CODE],UPD_DATE\r\n FROM [UMC3000].[dbo].[BCLBFLM]\r\n where WH_LOC like '[CKMNFB][A-Z][T][-][1-5][-][1-5]' AND BC_SITE NOT IN ('20','21','21@','29') AND BC_TYPE = 'TN'");
            //s.Append($"UNION ALL\r\n SELECT  [BC_NO],[BC_SITE],[PART_NO],[REQ_QTY],[OS_QTY],[WH_LOC],[WH_CODE],UPD_DATE\r\n FROM [UMC3000].[dbo].[BCLBFLM]\r\n where WH_LOC like 'R-%' AND BC_TYPE = 'TN'");
            //var res = SQLHelper.ExecQueryDataAsDataTable(s.ToString());
            var res = SQLHelper.ExecProcedureDataAsDataTable("IT_GetSMTReel");
            return res;
        }
        public static List<string> GetListPart()
        {
            InitSqlServerUsap();
            var date = DateTime.Now.AddDays(-7);
            string sql = $@"SELECT PART_NO
                            FROM [UMC3000].[dbo].[BCLBFLM]
                            WHERE BC_TYPE = 'TN' AND UPD_DATE > '{date.ToString("yyy-MM-dd")}'
                            GROUP BY PART_NO";
            return SQLHelper.ExecQueryData<string>(sql).ToList();
        }
        public static List<BCLBFLMEntity> GetUpn86(string partNo)
        {
            InitSqlServerUsap();
            string sql = $@"SELECT TOP (1000) [BC_NO]
                              ,[TN_NO]
                              ,[PART_NO]
                              ,[OS_QTY]
                              ,[PO_NO]
                              ,[WH_LOC]
	                          ,[UPD_DATE]
                          FROM [UMC3000].[dbo].[BCLBFLM]
                          where  PART_NO = '{partNo}' AND  BC_SITE like '1%' AND OS_QTY <> '0'
                          ORDER BY UPD_DATE";
            var res = SQLHelper.ExecQueryData<BCLBFLMEntity>(sql).ToList();
            return res;

        }

        public static DataTable GetStockByPart(string partNo)
        {
            InitSqlServerUsap();
            string sql = $@"SELECT [BC_NO] ' UPN ID'
                          ,[TN_NO] 'TN No'
                          ,[PART_NO] 'Part No'
                          ,[OS_QTY] 'Qty'
                          ,[WH_CODE] 'WH Code'
                          ,[UPD_DATE] 'Update Date'
                          ,[WH_LOC] 'Location',
	                      CASE 
	                      WHEN BC_TYPE = 'TN' THEN N'Tem Trắng'
	                      ELSE  N'Tem Hồng'
	                      END AS 'Type'
                      FROM [UMC3000].[dbo].[BCLBFLM]
                      where PART_NO = '{partNo}' AND BC_SITE like '1%'
                      order by UPD_DATE DESC";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }
        private static void InitSqlServerUsap()
        {
            SQLHelper.SERVER_NAME = "172.28.10.9";
            SQLHelper.USERNAME_DB = "sa";
            SQLHelper.PASSWORD_DB = "$umcevn123";
            SQLHelper.DATABASE = "UMC3000";
            SQLHelper.ConnectString();
        }
    }
}
