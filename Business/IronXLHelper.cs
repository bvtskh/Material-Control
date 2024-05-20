using Material_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_System.Business
{
    public class IronXLHelper
    {
        //public static List<WH_Tokusai> ExcelImport(string fileName)
        //{
        //    List<WH_Tokusai> lst = new List<WH_Tokusai>();
        //    try
        //    {
        //        WorkBook workbook = WorkBook.Load(fileName);
        //        WorkSheet sheet = workbook.DefaultWorkSheet;
        //        for (int i = 1; i < sheet.RowCount; i++)
        //        {
        //            var col = sheet.Rows[i].ToArray();
        //            if (col[1].Value.ToString() == "")
        //            {
        //                break;
        //            }
        //            lst.Add(new WH_Tokusai()
        //            {
        //                ISSUA_DATE = col[0].Value.ToString(),
        //                EM_NO = col[1].Value.ToString(),
        //                PART_FM = col[2].Value.ToString(),
        //                PART_TO = col[3].Value.ToString(),
        //                OS_QTY = col[4].Value.ToInt(),
        //                PRODUCT_ID = col[5].Value.ToString()
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show($"{ex.Message}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //    }
        //    return lst;
        //}
    }
}
