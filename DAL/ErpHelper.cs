using Material_System.Business;
using Material_System.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Script.Serialization;

namespace Material_System.DAL
{
    public class ErpHelper
    {
        static BaseContext context = new BaseContext();
        static UmesContext umesContext = new UmesContext();
        private static void InitSqlServerUsap()
        {
            SQLHelper.SERVER_NAME = "172.28.10.9";
            SQLHelper.USERNAME_DB = "sa";
            SQLHelper.PASSWORD_DB = "$umcevn123";
            SQLHelper.DATABASE = "UMC3000";
            SQLHelper.ConnectString();
        }
        public static bool ChangePass(string newPass)
        {
            Program.userEntity.User.PASSWORD = newPass;
            string sql = $@"UPDATE [UMC_MESDB_TEST].[dbo].[USERS] SET PASSWORD = '{newPass}' where ID = '{Program.userEntity.User.ID}'";
            try
            {
                umesContext.Database.ExecuteSqlCommand(sql, "");
                return true;
            }
            catch
            {

                return false;
            }
        }
        public static List<LotPicture> GetAllLotNo()
        {
            return context.Parts.OrderByDescending(r => r.UPD_TIME).Take(20).ToList();
        }

        public static void SaveLotPicture(LotPicture entity)
        {
            var exits = context.Parts.Find(entity.PART_NO);
            if (exits == null)
            {
                context.Parts.Add(entity);
                context.SaveChanges();
            }
        }

        public static LotPicture FindPart(string partNo)
        {
            return context.Parts.FirstOrDefault(r => r.PART_NO == partNo);
        }

        public static List<Tokusai_Item> FindTokusaiAlert(string type)
        {
            var lst = FindAllTokusaiItem();
            var lstNy = new List<Tokusai_Item>();
            if (type == "NY")
            {
                foreach (var item in lst)
                {
                    Console.WriteLine(item.EM_NO);
                    var count = context.WH_Tokusais.Where(r => r.EM_NO == item.EM_NO).Count();
                    if (count == 0)
                    {
                        if (!UsapHelper.TokusaiAcceptAll(item.EM_NO))
                        {
                            lstNy.Add(item);
                        }
                    }
                }
                return lstNy.OrderBy(r => r.EM_NO).ToList();
            }
            else
            {
                return lst.OrderBy(r => r.EM_NO).ToList();
            }

        }
        private static List<Tokusai_Item> FindAllTokusaiItem()
        {
            string sql = @"SELECT TOP 1000 [UPN_ID]
                          ,[EM_NO]
                          ,[MATERIAL_ORDER_ID]
                          ,[PART_ID]
                          ,[MACHINE_SLOT]
                          ,[MACHINE_ID]
                          ,[PRODUCT_ID]
                          ,[LINE_ID]
                          ,[UPD_TIME]
                          ,[IS_FAILED]
                          ,[ERR_TYPE]
                      FROM [SMT].[dbo].[Tokusai_Item]";
            return context.Database.SqlQuery<Tokusai_Item>(sql, "").ToList();
        }
        public static List<WH_Tokusai> FindPartLike(string partTo)
        {
            if (string.IsNullOrEmpty(partTo))
            {
                return context.WH_Tokusais.Take(1000).ToList();
            }
            return context.WH_Tokusais.Where(r => r.PART_TO.Contains(partTo)).OrderByDescending(r => r.UPD_DATE).Take(10000).ToList();
        }
        public static List<WH_Tokusai> FindModelLike(string modelNo)
        {
            if (string.IsNullOrEmpty(modelNo))
            {
                return context.WH_Tokusais.Take(1000).ToList();
            }
            return context.WH_Tokusais.Where(r => r.PRODUCT_ID.Contains(modelNo)).OrderByDescending(r => r.UPD_DATE).Take(10000).ToList();
        }

        public static List<WH_Tokusai> FindEmNoLike(string emNo)
        {
            if (string.IsNullOrEmpty(emNo))
            {
                return context.WH_Tokusais.Take(10000).ToList();
            }
            return context.WH_Tokusais.Where(r => r.EM_NO.Contains(emNo)).OrderByDescending(r => r.UPD_DATE).Take(10000).ToList();
        }

        public static List<WH_Tokusai> FindListTokusai()
        {
            string sql = @"SELECT TOP 60000 [ID]
                          ,[EM_NO]
                          ,[ISSUA_DATE]
                          ,[PART_FM]
                          ,[PART_TO]
                          ,[PRODUCT_ID]
                          ,[OS_QTY]
                          ,[UPD_DATE]
                          ,[UPD_NAME]
                      FROM [UMCVN_BASE].[dbo].[WH_Tokusai] ORDER BY UPD_DATE DESC";
            var res = context.Database.SqlQuery<WH_Tokusai>(sql);
            return res.ToList();
        }
        public static List<WH_Tokusai> GetAllTokusai()
        {
            string sql = @"SELECT [ID]
                          ,[EM_NO]
                          ,[ISSUA_DATE]
                          ,[PART_FM]
                          ,[PART_TO]
                          ,[PRODUCT_ID]
                          ,[OS_QTY]
                          ,[UPD_DATE]
                          ,[UPD_NAME]
                      FROM [UMCVN_BASE].[dbo].[WH_Tokusai] ORDER BY UPD_DATE DESC";
            var res = context.Database.SqlQuery<WH_Tokusai>(sql);
            return res.ToList();
        }
        public static List<WH_Tokusai_His> GetTokusaiChange(string emNo)
        {
            List<WH_Tokusai_His> result = new List<WH_Tokusai_His>();
            if (string.IsNullOrEmpty(emNo))
            {
                result = context.WH_Tokusai_His.OrderByDescending(r => r.UPD_DATE).Take(10000).ToList();

            }
            else
            {
                result = context.WH_Tokusai_His.Where(r => r.EM_NO == emNo).OrderByDescending(r => r.UPD_DATE).ToList();
            }
            return result;
        }
        public static List<TokusaiStock> GetStock(string emNo)
        {
           // IDatabase database = DataFactory.Database("USAP");
            InitSqlServerUsap();

            string sql = $@"SELECT TOP 1000 t1.[EM_NO],t3.REQ_QTY,t1.[BC_TO],t3.PART_FM,t3.PART_TO,t2.BC_SITE
                              FROM [UMC3000].[dbo].[EMRMISM] t1
                              INNER JOIN [UMC3000].[dbo].[BCLBFLM] t2 ON t1.BC_TO = t2.BC_NO
                              INNER JOIN [UMC3000].[dbo].[EMRDETM] t3 ON t3.EM_NO = t1.EM_NO AND t3.EM_LINE = t1.EM_LINE
                              WHERE t1.EM_NO = '{emNo}'";
            //var listOrigin = database.FindListBySql<TokusaiStock>(sql);
            var listOrigin = SQLHelper.ExecQueryData<TokusaiStock>(sql);
            var listCheck = listOrigin.Where(r => r.BC_SITE != "16").ToList();
            var upn = " AND UPN_ID IN('" + string.Join("','", listCheck.Select(r => r.BC_TO)) + "')";

            sql = $@"SELECT [UPN_ID]
                          FROM [UMC_MESDB_TEST].[dbo].[OPERATION_LOGS]
                          where PART_ID = '{listCheck.First().PART_TO}' {upn}
                     UNION ALL
                          SELECT [UPN_ID]
                          FROM [UMC_MESDB_BK].[dbo].[OPERATION_LOGS1]
                          where PART_ID = '{listCheck.First().PART_TO}' {upn}
                     UNION ALL
                          SELECT [UPN_ID]
                          FROM [UMC_MESDB_BK].[dbo].[OPERATION_LOGS_2019]
                          where PART_ID = '{listCheck.First().PART_TO}' {upn}";
            var listSx = umesContext.Database.SqlQuery<string>(sql).Distinct().ToList();
            foreach (var item in listOrigin)
            {
                if (listSx.Contains(item.BC_TO))
                {
                    item.BC_SITE = "99";
                }
            }
            return listOrigin.ToList();
        }

        public static void SaveTokusai(List<WH_Tokusai> lst)
        {
            if (lst == null || lst.Count == 0) return;
            var emNo = lst.First().EM_NO;
            string sql = $"Delete FROM [UMCVN_BASE].[dbo].[WH_Tokusai] where EM_NO = '{emNo}'";
            try
            {
                context.Database.ExecuteSqlCommand(sql );
                context.SaveChanges();
                foreach (var item in lst)
                {
                    var exist = context.WH_Tokusais.FirstOrDefault(r => r.EM_NO == item.EM_NO && r.PRODUCT_ID == item.PRODUCT_ID);
                    if (exist == null)
                    {
                        context.WH_Tokusais.Add(item);
                        var his = new WH_Tokusai_His()
                        {
                            EM_NO = item.EM_NO,
                            ISSUA_DATE = item.ISSUA_DATE,
                            OS_QTY = item.OS_QTY,
                            PART_FM = item.PART_FM,
                            PART_TO = item.PART_TO,
                            PRODUCT_ID = item.PRODUCT_ID,
                            HIS_TYPE = 1
                        };
                        context.WH_Tokusai_His.Add(his);
                        context.SaveChanges();
                    }
                    else
                    {
                        if (exist.PART_FM != item.PART_FM || exist.PART_TO != item.PART_TO || exist.PRODUCT_ID != item.PRODUCT_ID || exist.OS_QTY != item.OS_QTY)
                        {
                            context.WH_Tokusai_His.Add(new WH_Tokusai_His()
                            {
                                EM_NO = item.EM_NO,
                                ISSUA_DATE = item.ISSUA_DATE,
                                OS_QTY = item.OS_QTY,
                                PART_FM = item.PART_FM,
                                PART_TO = item.PART_TO,
                                PRODUCT_ID = item.PRODUCT_ID,
                                HIS_TYPE = 2
                            });
                        }
                        exist.PART_FM = item.PART_FM;
                        exist.PART_TO = item.PART_TO;
                        exist.OS_QTY = item.OS_QTY;
                        context.Entry(exist).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }


        public static List<WH_Tokusai> FindTokusaiByEmNo(string emNo)
        {
            if (string.IsNullOrEmpty(emNo))
            {
                return null;
            }
            return context.WH_Tokusais.Where(r => r.EM_NO == emNo).OrderBy(r => r.PRODUCT_ID).ToList();
        }

        public static void RemoveTokusai(string emNo)
        {
            if (string.IsNullOrEmpty(emNo))
            {
                return;
            }
            var lst = FindTokusaiByEmNo(emNo);

            if (lst != null)
            {
                context.WH_Tokusais.RemoveRange(lst);
                context.SaveChanges();
            }
        }

        public static bool RemoveTokusai(string emNo, string productID)
        {
            if (string.IsNullOrEmpty(emNo) || string.IsNullOrEmpty(productID))
            {
                return true;
            }
            try
            {
                var entity = context.WH_Tokusais.FirstOrDefault(r => r.EM_NO == emNo && r.PRODUCT_ID == productID);
                if (entity != null)
                {
                    var his = new WH_Tokusai_His()
                    {
                        EM_NO = entity.EM_NO,
                        ISSUA_DATE = entity.ISSUA_DATE,
                        OS_QTY = entity.OS_QTY,
                        PART_FM = entity.PART_FM,
                        PART_TO = entity.PART_TO,
                        PRODUCT_ID = entity.PRODUCT_ID,
                        HIS_TYPE = 3
                    };
                    context.WH_Tokusais.Remove(entity);
                    context.WH_Tokusai_His.Add(his);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<ERP_RULES> FindRule(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return null;
            var res = context.ERP_RULES.Where(r => r.USER_ID == userId);
            return res.ToList();
        }

        public static List<int> FindRule(Module module)
        {
            if (Program.userEntity == null) return null;
            var res = context.ERP_RULES.Where(r => r.USER_ID == Program.userEntity.User.ID && r.MODULE == module.ToString()).Select(r => r.RULE_ID);
            return res.ToList();
        }

        public static void RemoveRule(string userId, string module, int ruleId)
        {
            var tmp = context.ERP_RULES.FirstOrDefault(r => r.USER_ID == userId && r.MODULE == module);
            if (tmp != null)
            {
                context.ERP_RULES.Remove(tmp);
                context.SaveChanges();
            }
        }

        public static List<TokusaiHis> FindHisTokusai(DateTime fr, DateTime to)
        {
            List<TokusaiHis> his = new List<TokusaiHis>();
            string sql = $@"  WITH Cte AS
                            (
                            SELECT id, Date, Message,
                            RnAsc = ROW_NUMBER() OVER(PARTITION BY Message ORDER BY Id)
                            FROM [SMT].[dbo].[Log4Net]
	                        where Message like '%TOKUSAI_NG%' AND level = 'ERROR' AND Date >= '{fr}' AND Date < '{to}'
                             )
                            SELECT
                                id, Date, Message
                            FROM Cte
                            WHERE
                                RnAsc = 1 ";
            var logs = context.Database.SqlQuery<Log4Net>(sql, "").ToList();
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();

            foreach (var item in logs)
            {
                try
                {
                    TokusaiHis entity = (TokusaiHis)Newtonsoft.Json.JsonConvert.DeserializeObject(item.Message, typeof(TokusaiHis));
                    entity.ERROR_TIME = item.Date;
                    his.Add(entity);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return his.OrderByDescending(r => r.ERROR_TIME).ToList();
        }

        public static bool SaveModule(ERP_RULES entity)
        {
            var flag = context.ERP_RULES.FirstOrDefault(r => r.USER_ID == entity.USER_ID && r.MODULE == entity.MODULE && r.RULE_ID == entity.RULE_ID) == null;
            if (flag)
            {
                context.ERP_RULES.Add(entity);
                context.SaveChanges();
                return true;
            }
            return false;
        }
      
        public static void SaveTokusaiAlert(UsapService.EMRMISMEntity entity)
        {
            context.WH_Tokusais.Find(entity.BC_FM);
        }

        public static List<string> GetAllModule()
        {
            return (from std in context.ERP_RULES
                    select std.MODULE).Distinct().ToList();
        }

        public static string GetDescriptionFromModule(string module)
        {
            var moduleObj =  context.ERP_RULES.Where(m => m.MODULE == module && !string.IsNullOrEmpty(m.DESCRIPTION)).FirstOrDefault();
            if (moduleObj != null) return moduleObj.DESCRIPTION;
            else return "";
        }
    }
}
