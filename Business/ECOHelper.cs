using DocumentFormat.OpenXml.Office2010.Excel;
using Material_System.DAL;
using Material_System.Entities;
using Material_System.UCCustom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_System.Business
{
    public class ECOHelper
    {
        private static void InitSqlServer()
        {
            SQLHelper.SERVER_NAME = "172.28.10.17";
            SQLHelper.USERNAME_DB = "sa";
            SQLHelper.PASSWORD_DB = "umc@2019";
            SQLHelper.DATABASE = "SMT";
            SQLHelper.ConnectString();
        }
        public static DataTable GetListChanging()
        {
            InitSqlServer();
            string sql = @"SELECT TOP (1000) [ORDER_NO] as 'WO'
                                              ,[ECO_NO] as 'ECO No'
                                              ,[UPD_DATE] as 'Create Date'
                                               FROM [SMT].[dbo].[ECO_WoChanging]
                                               ORDER BY UPD_DATE DESC";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }

        public static DataTable Tokusai_GetCurrentLineConfirm(bool IsOnline, bool IsECO, string location)
        {
            try
            {
                InitSqlServer();
                List<Tokusai_GetCurrentLineConfirm> data = SQLHelper.ExecProcedureData<Tokusai_GetCurrentLineConfirm>
                    ("Tokusai_GetAllLineConfirm", new { IsOnline = IsOnline, IsECO = IsECO }).ToList();
                return AddDataToDataTable(data, location);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        private static DataTable AddDataToDataTable(List<Tokusai_GetCurrentLineConfirm> data, string location)
        {
            if (data.Count == 0) return null;
            var result = data.GroupBy(c => new
            {
                c.ID,
            }).Select(gcs => new
            {
                ID = gcs.Key.ID,
                LIST_CONFIRMs = gcs.ToList()
            });
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("NO", typeof(string));
            dt.Columns.Add("LINE_ID", typeof(string));
            dt.Columns.Add("WO", typeof(string));
            dt.Columns.Add("PRODUCT_ID", typeof(string));
            dt.Columns.Add("PART_ID", typeof(string));
            dt.Columns.Add("TIME_STOP", typeof(DateTime));
            dt.Columns.Add("REASON", typeof(string));
            dt.Columns.Add(DEPT.DM, typeof(string));
            dt.Columns.Add(DEPT.PD, typeof(string));
            dt.Columns.Add(DEPT.TE, typeof(string));
            dt.Columns.Add(DEPT.QA, typeof(string));
            dt.Columns.Add("WARM", typeof(string));
            int no = 1;
            var lstLine = GetAllLineByLocation(location);
            foreach (var line in result)
            {
                var firstItem = line.LIST_CONFIRMs.FirstOrDefault();
                bool flg = "ALL".Equals(location) ? true : lstLine.Contains(firstItem.LINE_ID);
                if (flg)
                {
                    var PD = line.LIST_CONFIRMs.Where(m => m.DEPT == DEPT.PD).FirstOrDefault();
                    var TE = line.LIST_CONFIRMs.Where(m => m.DEPT == DEPT.TE).FirstOrDefault();
                    var QA = line.LIST_CONFIRMs.Where(m => m.DEPT == DEPT.QA).FirstOrDefault();
                    string timeOut = "";
                    if (PD != null && TE != null && QA == null)
                    {
                        var newestConfirm = PD.TIME_CONFIRM > TE.TIME_CONFIRM ? PD.TIME_CONFIRM : TE.TIME_CONFIRM;
                        TimeSpan timeSpan = newestConfirm.AddHours(1) - DateTime.Now;
                        timeOut = Math.Round(timeSpan.TotalMinutes, 0, MidpointRounding.AwayFromZero).ToString();
                    }

                    dt.Rows.Add(
                        firstItem.ID,
                        no.ToString(),
                        firstItem.LINE_ID,
                        firstItem.WO,
                        firstItem.PRODUCT_ID,
                        firstItem.PART_ID,
                        firstItem.TIME_STOP,
                        firstItem.CHANGE_NAME,
                        firstItem.IS_DM_ACCEPT ? TEXT.OK : TEXT.NG,
                        PD != null ? PD.RESULT : firstItem.IS_DM_ACCEPT ? TEXT.CONFIRM : TEXT.NG,
                        TE != null ? TE.RESULT : firstItem.IS_DM_ACCEPT ? TEXT.CONFIRM : TEXT.NG,
                        GetTextQA(firstItem.IS_DM_ACCEPT, QA, timeOut),
                         !string.IsNullOrEmpty(timeOut) ? $"Còn {timeOut} phút để confirm, Nếu không line sẽ dừng" : "")
                        ;
                    no++;
                }
            }
            return dt;
        }
        private static string GetTextQA(bool IS_DM_ACCEPT, Tokusai_GetCurrentLineConfirm QA, string timeOut)
        {
            if (!IS_DM_ACCEPT) return TEXT.NG;
            if (QA != null) return QA.RESULT;
            if (!string.IsNullOrEmpty(timeOut)) return $"{TEXT.CONFIRM}({timeOut} phút)";
            return TEXT.CONFIRM;
        }
        internal static object Tokusai_GetAllLineConfirmCompletedByDate(bool IsOnline, bool IsECO, string location, DateTime from, DateTime to)
        {
            InitSqlServer();
            List<Tokusai_GetCurrentLineConfirm> data = SQLHelper.ExecProcedureData<Tokusai_GetCurrentLineConfirm>
                ("Tokusai_GetAllLineConfirmCompletedByDate", new { IsOnline = IsOnline, IsECO = IsECO, From = from, To = to }).ToList();
            return AddDataToDataTable(data, location);
        }

        public static DataTable Tokusai_GetAllLineConfirmCompleted(bool IsOnline, bool IsECO, string location)
        {
            try
            {
                InitSqlServer();
                List<Tokusai_GetCurrentLineConfirm> data = SQLHelper.ExecProcedureData<Tokusai_GetCurrentLineConfirm>
                    ("Tokusai_GetAllLineConfirmCompleted", new { IsOnline = IsOnline, IsECO = IsECO }).ToList();
                return AddDataToDataTable(data, location);
            }
            catch (Exception ex)


            {
                return null;
            }

        }
        public static string CheckUserConfirm(string username, string password, string dept)
        {
            if (UmesHelper.Unlock(username, password, MODULE_LOGIN.MODULE_CONFIRM_TOKUSAI))
            {
                var userInfo = SingletonHelper.PvsInstance.GetUserByID(username);
                if (userInfo.DESCRIPTION.Equals(dept) || userInfo.DESCRIPTION.Equals(DEPT.IT)) return TEXT.OK;
                return $"Bạn phải thuộc phòng ban {dept} mới có quyền confirm. Xem lại thông tin description trên user WIP";
            }
            else
            {
                return "Kiểm tra lại tài khoản đăng nhập";
            }
        }
        public static string Tokusai_LineConfirm(Tokusai_GetCurrentLineConfirm confirmInfo)
        {
            try
            {
                InitSqlServer();
                bool isConfirm = SQLHelper.ExecQueryData<bool>("select count(1) from Tokusai_LineConfirm where " +
                    " ID_HISTORY = @ID_HISTORY " +
                    "and DEPT = @DEPARTMENT",
                    new { ID_HISTORY = confirmInfo.ID, DEPARTMENT = confirmInfo.DEPT }).FirstOrDefault();
                if (isConfirm)
                {
                    return "Đã có người confirm tại phòng này rồi!";
                }
                long result = SQLHelper.Insert(new Tokusai_LineConfirm()
                {
                    ID_HISTORY = confirmInfo.ID,
                    DEPT = confirmInfo.DEPT,
                    UPD_TIME = SingletonHelper.PvsInstance.GetDateTime(),
                    USER_CONFIRM = confirmInfo.USER_CONFIRM,
                    RESULT_CONFIRM = true
                });
                if (result < 0) return TEXT.CONFIRM_NOT_SUCCESS;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            return TEXT.OK;
        }
        public static string[] GetLocation()
        {
            InitSqlServer();
            string sql = @"SELECT LocationId
                              FROM [SMT].[dbo].[Location]
                              GROUP BY LocationId";
            return SQLHelper.ExecQueryData<string>(sql).ToArray();
        }
        public static List<string> GetAllLineByLocation(string location)
        {
            List<string> lst = new List<string>();
            InitSqlServer();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT  [LineId] FROM [SMT].[dbo].[Location] WHERE '1' = '1' ");
            if ("ALL" != location)
            {
                stringBuilder.AppendFormat("AND LocationId = '{0}'", location);
            }
            return SQLHelper.ExecQueryData<string>(stringBuilder.ToString()).ToList();
        }

        public static DataTable GetTokusaiECOPlan()
        {
            InitSqlServer();
            return SQLHelper.ExecProcedureDataAsDataTable("GetTokusaiECOPlan");
        }

        public static DataTable GetListTokusaiPlan()
        {
            InitSqlServer();
            string sql = @"SELECT TOP (1000) [ORDER_NO] as 'WO'
                                              ,[MODEL_NO] as 'Model'
                                              ,[DUE_DATE] as 'Due Date'
                                              ,[QUANTITY] as 'WO Qty'
                                              ,[ORDER_TYPE] as 'Công đoạn'
                                               FROM [SMT].[dbo].[Tokusai_Plan]
                                               ORDER BY UPD_DATE DESC";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }

        public static string TokusaiPlanSave(Tokusai_Plan tokusai_Plan)
        {
            InitSqlServer();
            bool isConfirm = SQLHelper.ExecQueryData<bool>("select count(1) from Tokusai_Plan where " +
                   " ORDER_NO = @WO",
                   new { WO = tokusai_Plan.ORDER_NO }).FirstOrDefault();
            if (isConfirm)
            {
                return $"Đã thêm WO {tokusai_Plan.ORDER_NO} rồi!";
            }
            var result = SQLHelper.Insert(tokusai_Plan);
            return result < 0 ? "Xảy ra lỗi ở khi thêm vào db" : "";
        }

        public static string TokusaiPlanRemove(string WO)
        {
            InitSqlServer();
            bool isConfirm = SQLHelper.ExecQueryData<bool>("select count(1) from Tokusai_Plan where " +
                   " ORDER_NO = @WO",
                   new { WO = WO }).FirstOrDefault();
            if (!isConfirm)
            {
                return $"Chưa thêm WO {WO} !";
            }
            var result = SQLHelper.ExecQueryNonData("DELETE FROM Tokusai_Plan where ORDER_NO = @WO", new { @WO = WO });
            return result == 0 ? "Xảy ra lỗi ở khi xóa db" : "";
        }

        public static DataTable FindTokusaiPlanByModel(string Model)
        {
            InitSqlServer();
            string sql = @"SELECT TOP (1) [ORDER_NO] as 'WO'
                                              ,[MODEL_NO] as 'Model'
                                              ,[DUE_DATE] as 'DueDate'
                                              ,[QUANTITY] as 'WOQty'
                                              ,[ORDER_TYPE] as 'Công đoạn'
                                               FROM [SMT].[dbo].[Tokusai_Plan]
                                               Where MODEL_NO = '" + Model + "'";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }

        public static DataTable FindTokusaiPlanByWO(string WO)
        {
            InitSqlServer();
            string sql = @"SELECT TOP (1) [ORDER_NO] as 'WO'
                                              ,[MODEL_NO] as 'Model'
                                              ,[DUE_DATE] as 'DueDate'
                                              ,[QUANTITY] as 'WOQty'
                                              ,[ORDER_TYPE] as 'Công đoạn'
                                               FROM [SMT].[dbo].[Tokusai_Plan]
                                               Where ORDER_NO = '" + WO + "'";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }

        public static DataTable GetListECOPlan()
        {
            InitSqlServer();
            string sql = @"SELECT TOP (1000) [ORDER_NO] as 'WO'
                                              ,[MODEL_NO] as 'Model'
                                              ,[DUE_DATE] as 'DueDate'
                                              ,[QUANTITY] as 'WOQty'
                                              ,[ECO_NO] as 'ECONo'
                                              ,[ORDER_TYPE] as 'Công đoạn'

                                               FROM [SMT].[dbo].[ECO_WoChanging]
                                               ORDER BY UPD_DATE DESC";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }

        public static DataTable FindECOPlanByWO(string WO)
        {
            InitSqlServer();
            string sql = @"SELECT TOP (1) [ORDER_NO] as 'WO'
                                              ,[MODEL_NO] as 'Model'
                                              ,[DUE_DATE] as 'DueDate'
                                              ,[QUANTITY] as 'WOQty'
                                              ,[ECO_NO] as 'ECONo'
                                              ,[ORDER_TYPE] as 'Công đoạn'
                                               FROM [SMT].[dbo].[ECO_WoChanging]
                                               WHERE ORDER_NO = '" + WO + "'";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }

        public static DataTable FindECOPlanByModel(string Model)
        {
            InitSqlServer();
            string sql = @"SELECT TOP (1) [ORDER_NO] as 'WO'
                                              ,[MODEL_NO] as 'Model'
                                              ,[DUE_DATE] as 'DueDate'
                                              ,[QUANTITY] as 'WOQty'
                                              ,[ECO_NO] as 'ECONo'
                                              ,[ORDER_TYPE] as 'Công đoạn'
                                               FROM [SMT].[dbo].[ECO_WoChanging]
                                               WHERE MODEL_NO = '" + Model + "'";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }

        public static string ECOPlanSave(ECO_Plan ecoPlan)
        {
            InitSqlServer();
            bool isConfirm = SQLHelper.ExecQueryData<bool>("select count(1) from ECO_WoChanging where " +
                   " ORDER_NO = @WO",
                   new { WO = ecoPlan.ORDER_NO }).FirstOrDefault();
            if (isConfirm)
            {
                return $"Đã thêm WO {ecoPlan.ORDER_NO} rồi!";
            }
            var result = SQLHelper.Insert(ecoPlan);
            return result < 0 ? "Xảy ra lỗi ở khi thêm vào db" : "";
        }

        public static string ECOPlanRemove(string WO)
        {
            InitSqlServer();
            bool isConfirm = SQLHelper.ExecQueryData<bool>("select count(1) from ECO_WoChanging where " +
                   " ORDER_NO = @WO",
                   new { WO = WO }).FirstOrDefault();
            if (!isConfirm)
            {
                return $"Chưa thêm WO {WO} !";
            }
            var result = SQLHelper.ExecQueryNonData("DELETE FROM ECO_WoChanging where ORDER_NO = @WO", new { @WO = WO });
            return result == 0 ? "Xảy ra lỗi ở khi xóa db" : "";
        }

        public static DataTable GetListMainSub()
        {
            InitSqlServer();
            string sql = @"SELECT TOP (1000) [PART_FROM] as 'Part From'
                                              ,[PART_TO] as 'Part To'
                                              ,[UPD_TIME] as 'UpdateTime'
                                              ,
                                               CASE 
												when [IS_SPECIAL]  = 0  then 'NO'
												when [IS_SPECIAL] =1 then 'YES'
												ELSE ''
												END AS 'Main Sub đặc biệt'
                                              ,[UPDATOR] as 'Người cập nhật'
                                               FROM [SMT].[dbo].[MainSub_Model]
                                               ORDER BY UPD_TIME DESC";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }
        public static DataTable GetListMainSub(int type)
        {
            if (type == 1)
            {
                InitSqlServer();
                string sql = @"SELECT TOP (1000) [PART_FROM] as 'Part From'
                                              ,[PART_TO] as 'Part To'
                                              ,[UPD_TIME] as 'UpdateTime'
                                              ,
                                               CASE 
												when [IS_SPECIAL]  = 0  then 'NO'
												when [IS_SPECIAL] =1 then 'YES'
												ELSE ''
												END AS 'Main Sub đặc biệt'
                                              ,[UPDATOR] as 'Người cập nhật'
                                               FROM [SMT].[dbo].[MainSub_Model]
                                               where  [IS_SPECIAL] = 1
                                               ORDER BY UPD_TIME DESC";
                return SQLHelper.ExecQueryDataAsDataTable(sql);
            }
            return null;
        }
        public static DataTable GetListMainSubAll()
        {
            InitSqlServer();
            string sql = @"SELECT TOP (1000) [PART_FROM] as 'Part From'
                                              ,[PART_TO] as 'Part To'
                                              ,[UPD_TIME] as 'UpdateTime'
                                              ,[UPDATOR] as 'Người cập nhật'
                                               FROM [SMT].[dbo].[MainSub_Model]
                                               ORDER BY UPD_TIME DESC";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }
        public static DataTable FindMainSubByPart(string Part)
        {
            InitSqlServer();
            string sql = $@"SELECT TOP (1000) [PART_FROM] as 'Part From'
                                              ,[PART_TO] as 'Part To'
                                              ,[UPD_TIME] as 'UpdateTime'
                                              ,[UPDATOR] as 'Người cập nhật'
                                               FROM [SMT].[dbo].[MainSub_Model]
                                               WHERE PART_TO like '%" + Part + "%' OR PART_FROM like '%" + Part + "%'";

            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }


        public static string MainSubSave(MainSubModel model)
        {
            InitSqlServer();
            bool isConfirm = SQLHelper.ExecQueryData<bool>("select count(1) from MainSub_Model where " +
                   " PART_FROM = @PART_FROM AND PART_TO = @PART_TO",
                   new { PART_FROM = model.PART_FROM, PART_TO = model.PART_TO }).FirstOrDefault();
            if (isConfirm)
            {
                return $"Đã thêm PartFrom {model.PART_FROM} & PartTo {model.PART_TO} rồi!";
            }
            var result = SQLHelper.Insert(model);
            return result < 0 ? "Xảy ra lỗi ở khi thêm vào db" : "";
        }

        public static string MainSubRemove(string from, string to)
        {
            InitSqlServer();
            bool isConfirm = SQLHelper.ExecQueryData<bool>("select count(1) from MainSub_Model where " +
                   " PART_FROM = @PART_FROM AND PART_TO = @PART_TO",
                   new { PART_FROM = from, PART_TO = to }).FirstOrDefault();
            if (!isConfirm)
            {
                return $"Chưa thêm PartFrom {from} & PartTo {to}!";
            }
            var result = SQLHelper.ExecQueryNonData("DELETE FROM MainSub_Model where PART_FROM = @PART_FROM and PART_TO = @PART_TO",
                new { PART_FROM = from, PART_TO = to });
            return result == 0 ? "Xảy ra lỗi ở khi xóa db" : "";
        }

        internal static void AutoConfirmNGwoByDM(string woConfirmNG, string line)
        {
            InitSqlServer();

            using (SqlConnection connection = new SqlConnection(SQLHelper.ConnectString()))
            {
                SqlCommand command = new SqlCommand("AutoConfirmNGWO", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("@line", line);
                command.Parameters.AddWithValue("wo", woConfirmNG);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        internal static bool IS_RetryPDASuccess(string part, string woConfirmNG)
        {
            InitSqlServer();
            return SQLHelper.ExecQueryData<bool>("SELECT count(1)  FROM [SMT].[dbo].[Tokusai_Item] where " +
                "PRODUCTION_ORDER_ID = @PRODUCTION_ORDER_ID and PART_ID =@PART_ID AND IS_FAILED = 0",
                   new { PRODUCTION_ORDER_ID = woConfirmNG, PART_ID = part }).FirstOrDefault();
        }
    }

    public static class DEPT
    {
        public static string DM = "DM";
        public static string PD = "PD";
        public static string TE = "TE";
        public static string QA = "QA";
        public static string IT = "IT";
    }
    public static class TEXT
    {
        public static string CONFIRM = "Confirm";
        public static string CONFIRM_NOW = "Confirm Now";
        public static string NG = "NG";
        public static string OK = "OK";
        public static string CONFIRM_NOT_SUCCESS = "Confirm không thành công!";
        public static int CHANGE_TRANG_SANG_HONG = 1;
        public static int CHANGE_HONG_SANG_TRANG = 0;
        public static int ECO = 2;
    }
}
