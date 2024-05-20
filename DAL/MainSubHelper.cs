using Material_System.Business;
using Material_System.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_System.DAL
{
    public class MainSubHelper
    {
        internal static DataTable GetAllMainSub()
        {
            InitSqlServer1();
            string sql = @"SELECT PART_ID as 'Main', ALTER_PART_ID as 'Sub'" +
                         "FROM [UMC_MESDB_TEST].[dbo].[ALTER_PART_DATA] group by ALTER_PART_ID, PART_ID ";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }

        internal static bool ImportMainSub(DataTable dt)
        {
            try
            {
                InitSqlServer2();

                if (dt.Rows.Count <= 4) return false;
                for (int row = 4; row < dt.Rows.Count; row++)
                {
                    string PartFrom = dt.Rows[row].Field<object>(0) == null ? "" : dt.Rows[row].Field<object>(0).ToString();
                    string PartTo = dt.Rows[row].Field<object>(1) == null ? "" : dt.Rows[row].Field<object>(1).ToString();
                    int? special = ConvertSpecial(dt.Rows[row].Field<object>(2));
                    if (string.IsNullOrEmpty(PartFrom) || string.IsNullOrEmpty(PartTo) || special == null) continue;

                    MainSubModel mainSubModel = new MainSubModel
                    {
                        ID = Guid.NewGuid().ToString(),
                        PART_FROM = PartFrom,
                        PART_TO = PartTo,
                        UPDATOR = Program.userEntity.User.ID,
                        UPD_TIME = DateTime.Now,
                    };
                    if (special == 0) // sub main thuong
                    {
                        mainSubModel.IS_SPECIAL = false;
                    }
                    else if (special == 1) // special submain
                    {
                        mainSubModel.IS_SPECIAL = true;
                    }
                    else
                    {
                        continue;
                    }
                    bool isConfirm = SQLHelper.ExecQueryData<bool>("select count(1) from MainSub_Model where " +
                      " PART_FROM = @PART_FROM AND PART_TO = @PART_TO OR  PART_FROM = @PART_TO AND PART_TO = @PART_FROM ",
                      new { PART_FROM = mainSubModel.PART_FROM, PART_TO = mainSubModel.PART_TO }).FirstOrDefault();
                    if (isConfirm)
                    {
                        continue;
                    }
                    var result = SQLHelper.Insert(mainSubModel);
                    if (result < 0) return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private static int? ConvertSpecial(object special)
        {
            int result;
            if (special != null)
            {
                if (int.TryParse(special.ToString(), out result)) return result;
            }
            return null;
        }

        private static void InitSqlServer1()
        {
            SQLHelper.SERVER_NAME = "172.28.10.8";
            SQLHelper.USERNAME_DB = "dev";
            SQLHelper.PASSWORD_DB = "umc@123";
            SQLHelper.DATABASE = "UMC_MESDB_TEST";
            SQLHelper.ConnectString();
        }
        private static void InitSqlServer2()
        {
            SQLHelper.SERVER_NAME = "172.28.10.17";
            SQLHelper.USERNAME_DB = "sa";
            SQLHelper.PASSWORD_DB = "umc@2019";
            SQLHelper.DATABASE = "SMT";
            SQLHelper.ConnectString();
        }
    }
}
