using ClosedXML.Excel;
using DocumentFormat.OpenXml.VariantTypes;
using ExcelDataReader;
using Material_System.DAL;
using Material_System.Entities;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelApp = Microsoft.Office.Interop.Excel;

namespace Material_System.Business
{
    public class ExcelHelper2
    {
        public static void ReadExcel(string fileName)
        {
            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();

            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }

            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(fileName);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;

            for (int i = 2; i <= rows; i++)
            {
                // read new line
                for (int j = 1; j <= 6; j++)
                {

                    //write to cell
                    if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                        Console.WriteLine(excelRange.Cells[i, j].Value2);

                }
            }
            //after reading, relaase the excel project
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }
        public static List<WH_Tokusai> GetListTokusai(string fileName)
        {
            List<WH_Tokusai> lst = new List<WH_Tokusai>();
            //Create COM Objects.
            ExcelApp.Application excelApp = new ExcelApp.Application();

            if (excelApp == null)
            {
                // Console.WriteLine("Excel is not installed!!");
                System.Windows.Forms.MessageBox.Show("Excel is not installed!!", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                return null;
            }

            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(fileName);
            ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
            ExcelApp.Range excelRange = excelSheet.UsedRange;

            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;

            for (int i = 2; i <= rows; i++)
            {
                if (excelRange.Cells[i, 2] == null || excelRange.Cells[i, 2].Value2 == null)
                {
                    break;
                };
                //var issuaDate = DateTime.FromOADate(excelRange.Cells[i, 1].Value2);
                //var emNo = excelRange.Cells[i, 2].Value2.ToString();
                //var partFM = excelRange.Cells[i, 3].Value2.ToString();
                //var partTO = excelRange.Cells[i, 4].Value2.ToString();
                //var productID = excelRange.Cells[i, 6].Value2.ToString();
                var tmp = (string)excelRange.Cells[i, 5].Value2.ToString();
                var qty = Convert.ToInt32(tmp.Trim());
                lst.Add(new WH_Tokusai()
                {
                    ISSUA_DATE = DateTime.FromOADate(excelRange.Cells[i, 1].Value2),
                    EM_NO = excelRange.Cells[i, 2].Value2.ToString(),
                    PART_FM = excelRange.Cells[i, 3].Value2.ToString(),
                    PART_TO = excelRange.Cells[i, 4].Value2.ToString(),
                    OS_QTY = qty,
                    PRODUCT_ID = excelRange.Cells[i, 6].Value2.ToString()
                });
            }
            //after reading, relaase the excel project
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            foreach (var item in lst.GroupBy(r => new { r.EM_NO, r.PRODUCT_ID }))
            {
                var tmp = item.ToList();
                Console.WriteLine("{0},{1}", item.Key.EM_NO, item.Key.PRODUCT_ID);
            }
            var res = lst.GroupBy(r => new { r.EM_NO, r.PRODUCT_ID }).Select(s => new WH_Tokusai()
            {
                EM_NO = s.Key.EM_NO,
                PRODUCT_ID = s.Key.PRODUCT_ID,
                ISSUA_DATE = s.FirstOrDefault().ISSUA_DATE,
                OS_QTY = s.FirstOrDefault().OS_QTY,
                PART_FM = s.FirstOrDefault().PART_FM,
                PART_TO = s.FirstOrDefault().PART_TO
            }).ToList();
            return res;
        }
        public static System.Data.DataTable ExcelImport(string filePath)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            //using (XLWorkbook workBook = new XLWorkbook(filePath))
            //{
            //    //Read the first Sheet from Excel file.
            //    IXLWorksheet workSheet = workBook.Worksheet(1);

            //    //Create a new DataTable.
            //    DataTable dt = new DataTable();

            //    //Loop through the Worksheet rows.
            //    bool firstRow = true;
            //    foreach (IXLRow row in workSheet.Rows())
            //    {
            //        //Use the first row to add columns to DataTable.
            //        if (firstRow)
            //        {
            //            foreach (IXLCell cell in row.Cells())
            //            {
            //                dt.Columns.Add(cell.Value.ToString());
            //            }
            //            firstRow = false;
            //        }
            //        else
            //        {
            //            //Add rows to DataTable.
            //            dt.Rows.Add();
            //            int i = 0;
            //            foreach (IXLCell cell in row.Cells())
            //            {
            //                dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
            //                i++;
            //            }
            //        }

            //    }
            //    return dt;
            //}

            //Started reading the Excel file.  
            using (XLWorkbook workbook = new XLWorkbook(filePath))
            {

                IXLWorksheet worksheet = workbook.Worksheet(1);
                bool FirstRow = true;
                //Range for reading the cells based on the last cell used.  
                string readRange = "1:1";
                foreach (IXLRow row in worksheet.RowsUsed())
                {
                    //If Reading the First Row (used) then add them as column name  
                    if (FirstRow)
                    {
                        //Checking the Last cellused for column generation in datatable  
                        readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                        foreach (IXLCell cell in row.Cells(readRange))
                        {
                            dt.Columns.Add(cell.Value.ToString().Trim().ToUpper());
                        }
                        FirstRow = false;
                    }
                    else
                    {
                        //Adding a Row in datatable  
                        dt.Rows.Add();
                        int cellIndex = 0;
                        //Updating the values of datatable  
                        foreach (IXLCell cell in row.Cells(readRange))
                        {
                            dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                            cellIndex++;
                        }
                    }
                }
                //If no data in Excel file  
                if (FirstRow)
                {
                    //ViewBag.Message = "Empty Excel File!";
                }
            }
            return dt;
        }
        public static System.Data.DataTable ReadBomlist(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });
                    #region Create Datatable
                    var table1 = result.Tables["Sheet1"];
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Columns.Add("ID", typeof(Guid));
                    dt.Columns.Add("MATERIAL_NUMBER", typeof(string));
                    dt.Columns.Add("CUSTOMER_ID", typeof(string));
                    dt.Columns.Add("ALTERNATIVE_BOM", typeof(string));
                    dt.Columns.Add("PLANT", typeof(string));
                    dt.Columns.Add("ASSEMBLE_MATERIAL_NUMBER", typeof(string));
                    dt.Columns.Add("BOM_LEVEL", typeof(int));
                    dt.Columns.Add("BOM_ITEM_NUMBER", typeof(string));
                    dt.Columns.Add("BOM_COMPONENT", typeof(string));
                    dt.Columns.Add("PART_NAME", typeof(string));
                    dt.Columns.Add("ALT_GROUP", typeof(string));
                    dt.Columns.Add("ALT_RANKING", typeof(string));
                    dt.Columns.Add("ALT_STRATEGY", typeof(string));
                    dt.Columns.Add("USAGE_PROBABILITY", typeof(int));
                    dt.Columns.Add("DIS_INDICATOR", typeof(string));
                    dt.Columns.Add("DIS_GROUP", typeof(string));
                    dt.Columns.Add("FLLOW_UP", typeof(string));
                    dt.Columns.Add("VALID_PERIOD", typeof(string));
                    dt.Columns.Add("ROHS", typeof(string));
                    dt.Columns.Add("DETAIL_SPEC", typeof(string));
                    dt.Columns.Add("MANUFACTURER_PART", typeof(string));
                    dt.Columns.Add("MANUFACTURER", typeof(string));
                    dt.Columns.Add("UNIT", typeof(string));
                    dt.Columns.Add("FILE_NAME", typeof(string));
                    dt.Columns.Add("QTY", typeof(decimal));
                    dt.Columns.Add("BASE_QTY", typeof(decimal));
                    dt.Columns.Add("LOCATION", typeof(string));
                    dt.Columns.Add("SUPLLY", typeof(string));
                    dt.Columns.Add("ECO_NO", typeof(string));
                    dt.Columns.Add("REMASK", typeof(string));
                    dt.Columns.Add("CUSTOMER_PART_NO", typeof(string));
                    dt.Columns.Add("INDICATOR_BULK_MATERIAL", typeof(string));
                    dt.Columns.Add("INDICATOER_COSTING", typeof(string));
                    dt.Columns.Add("REVISION_LEVEL", typeof(string));
                    dt.Columns.Add("QUOTATION", typeof(string));
                    dt.Columns.Add("NET_WEIGHT", typeof(decimal));
                    dt.Columns.Add("WEIGHET_UNIT", typeof(string));
                    dt.Columns.Add("MATERIAL_GROUP", typeof(string));
                    dt.Columns.Add("MATERIAL_GROUP_DES", typeof(string));
                    dt.Columns.Add("MPN_PART_NO", typeof(string));
                    dt.Columns.Add("PUR_DES", typeof(string));
                    dt.Columns.Add("ALT_GROUP_2", typeof(string));
                    dt.Columns.Add("DIS_FLLOW_UP", typeof(string));
                    dt.Columns.Add("INSTALL_POS_1", typeof(string));
                    dt.Columns.Add("INSTALL_POS_2", typeof(string));
                    dt.Columns.Add("INSTALL_POS_3", typeof(string));
                    dt.Columns.Add("INSTALL_POS_4", typeof(string));
                    dt.Columns.Add("INSTALL_POS_5", typeof(string));
                    dt.Columns.Add("INSTALL_POS_6", typeof(string));
                    dt.Columns.Add("INSTALL_POS_7", typeof(string));
                    dt.Columns.Add("QTY_ACTUAL", typeof(decimal));
                    #endregion
                    #region Old
                    string[] componentEndWith = { "SMT", "FAT", "SMTA", "SMTB", "AI", "IND", "IND1", "IND2" };
                    var lstComponetExchange = ExchangeComponentHelper.GetAll();
                    foreach (DataRow row in table1.Rows)
                    {
                        decimal qtyBalance = 0;
                        decimal.TryParse(row[23].ToString(), out qtyBalance);
                        decimal? qtyActual = null;
                        var qt = row[23].ToString();
                        int? usage = null;
                        // Bỏ MPN và running change
                        if (!row[5].ToString().Contains("MPN") && !row[41].ToString().EndsWith("F"))
                        {
                            var usageValue = row[12].ToString();
                            if (string.IsNullOrEmpty(usageValue))
                            {
                                qtyActual = qtyBalance;
                            }
                            else
                            {
                                var tmp = int.Parse(usageValue);
                                qtyActual = tmp * qtyBalance / 100;
                            }
                            var bomComponent = row[7].ToString();
                            var partName = row[8].ToString();
                            if (partName.StartsWith("JPL060") || lstComponetExchange.Contains(bomComponent))//Jumper hoặc linh kiện cần quy đổi
                            {
                                qtyActual = qtyActual / 1000;
                            }

                            if (componentEndWith.Any(x => bomComponent.EndsWith(x)))
                            {
                                qtyActual = 0;
                            }

                            int bomLevel = int.Parse(row[5].ToString());
                            dt.Rows.Add(new object[]
                            {
                            Guid.NewGuid(),
                            row[0].ToString(),
                            row[1].ToString(),
                            row[2].ToString(),
                            row[3].ToString(),
                            row[4].ToString(),
                            bomLevel,
                            row[6].ToString(),
                            bomComponent,
                            partName,
                            row[9].ToString(),
                            row[10].ToString(),
                            row[11].ToString(),
                           string.IsNullOrEmpty(row[12].ToString())?usage:int.Parse(row[12].ToString()),
                            row[13].ToString(),
                            row[14].ToString(),
                            row[15].ToString(),
                            row[16].ToString(),
                            row[17].ToString(),
                            row[18].ToString(),
                            row[19].ToString(),
                            row[20].ToString(),
                            row[21].ToString(),
                            row[22].ToString(),
                            row[23].ToString(),
                            row[24].ToString(),
                            row[25].ToString(),
                            row[26].ToString(),
                            row[27].ToString(),
                            row[28].ToString(),
                            row[29].ToString(),
                            row[30].ToString(),
                            row[31].ToString(),
                            row[32].ToString(),
                            row[33].ToString(),
                            row[34].ToString(),
                            row[35].ToString(),
                            row[36].ToString(),
                            row[37].ToString(),
                            row[38].ToString(),
                            row[39].ToString(),
                            row[40].ToString(),
                            row[41].ToString(),
                            row[42].ToString(),
                            row[43].ToString(),
                            row[44].ToString(),
                            row[45].ToString(),
                            row[46].ToString(),
                            row[47].ToString(),
                            row[48].ToString(),
                            qtyActual
                            });
                        }

                    }
                    #endregion
                    return dt;
                }
            }
        }

        public static List<ExchangeComponentEntity> GetExchangeComponent(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });
                    var table = result.Tables[0];
                    var res = new List<ExchangeComponentEntity>();
                    res = (from DataRow dr in table.Rows
                           select new ExchangeComponentEntity()
                           {
                               Material = dr["Material"].ToString(),
                               Total = int.Parse(dr["Total"].ToString())
                           }).ToList();
                    return res;
                }
            }
        }
        public static System.Data.DataTable GetModelExchange(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });
                    var table = result.Tables[0];
                    return table;
                }
            }
        }

        internal static bool ExportSubMainToExcel(System.Data.DataTable dataTable)
        {
            System.Data.DataTable mainSubList = MainSubHelper.GetAllMainSub(); // tất cả main sub trên con 8.


            var result = (from l2 in mainSubList.AsEnumerable()
                          join l1 in dataTable.AsEnumerable()
                          on new { Main = l2.Field<object>("Main"), Sub = l2.Field<object>("Sub") }
                          equals new { Main = l1.Field<object>("Part From"), Sub = l1.Field<object>("Part To") } into i
                          from subrow in i.DefaultIfEmpty()
                          where subrow == null
                          select l2).CopyToDataTable();


            // Display the SaveFileDialog to let the user choose the file location and name
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Excel File";
                saveFileDialog.FileName = $"Main_sub_{DateTime.Now.ToString("yyyyMMddhhmmss")}.xlsx"; // Default file name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Create a new Excel workbook
                    using (var workbook = new XLWorkbook())
                    {
                        // Add a worksheet to the workbook

                        var worksheet = workbook.Worksheets.Add("Main sub đặc biệt");
                        worksheet.Cell(1, 1).Value = "NHẬP THÔNG TIN MAIN SUB";

                        worksheet.Cell(2, 1).Value = "Là Main sub đặc biệt điền: 1";
                        worksheet.Cell(3, 1).Value = "KHÔNG phải Main sub đặc biệt điền: 0";

                        worksheet.Cell(4, 1).Value = "Part From";
                        worksheet.Cell(4, 2).Value = "Part To";
                        worksheet.Cell(4, 3).Value = "Main Sub(1/0)";

                        worksheet.Cell(1, 1).Style.Font.FontSize = 15;
                        worksheet.Cell(1, 1).Style.Font.FontColor = XLColor.White;
                        worksheet.Cell(1, 1).Style.Font.Bold = true;
                        worksheet.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.Blue;
                        worksheet.Cell(1, 2).Style.Fill.BackgroundColor = XLColor.Blue;
                        worksheet.Cell(1, 3).Style.Fill.BackgroundColor = XLColor.Blue;

                        worksheet.Cell(2, 1).Style.Font.FontColor = XLColor.Red;
                        worksheet.Cell(3, 1).Style.Font.FontColor = XLColor.Red;

                        worksheet.Cell(4, 1).Style.Font.FontSize = 12;
                        worksheet.Cell(4, 1).Style.Font.Bold = true;
                        worksheet.Cell(4, 1).Style.Fill.BackgroundColor = XLColor.Yellow;
                        worksheet.Cell(4, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        worksheet.Cell(4, 2).Style.Font.FontSize = 12;
                        worksheet.Cell(4, 2).Style.Font.Bold = true;
                        worksheet.Cell(4, 2).Style.Fill.BackgroundColor = XLColor.Yellow;
                        worksheet.Cell(4, 2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        worksheet.Cell(4, 3).Style.Font.FontSize = 12;
                        worksheet.Cell(4, 3).Style.Font.Bold = true;
                        worksheet.Cell(4, 3).Style.Fill.BackgroundColor = XLColor.Yellow;
                        worksheet.Cell(4, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        worksheet.Column(1).Width = 20;
                        worksheet.Column(2).Width = 20;
                        worksheet.Column(3).Width = 20;

                        var range1 = worksheet.Range("A1:C1");
                        var range2 = worksheet.Range("A2:C2");
                        var range3 = worksheet.Range("A3:C3");

                        range1.Merge();
                        range2.Merge();
                        range3.Merge();

                        // Insert data from the DataTable into the worksheet starting from the second row
                        IXLRange iXLRange = worksheet.Cell(5, 1).InsertData(ConvertData(result).AsEnumerable());

                        // Save the workbook to the specified file path
                        workbook.SaveAs(filePath);

                        return true;
                    }
                }
                return false;
            }
        }

        private static void SetBorder(IXLWorksheet worksheet)
        {
            for (int row = 1; row < 6; row++)
            {
                worksheet.Row(row).Style.Border.TopBorder = XLBorderStyleValues.Thick;
                worksheet.Row(row).Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                worksheet.Row(row).Style.Border.LeftBorder = XLBorderStyleValues.Thick;
                worksheet.Row(row).Style.Border.RightBorder = XLBorderStyleValues.Thick;
            }
        }

        private static System.Data.DataTable ConvertData(System.Data.DataTable data)
        {
            data.Columns.Add();
            return data;
        }

        internal static System.Data.DataTable ImportExcel(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                // Create ExcelDataReader
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose which sheet to read, if the file has multiple sheets
                    reader.Read(); // Reads the first sheet

                    // DataSet to hold the result
                    var result = reader.AsDataSet();

                    // Iterate through the rows of the sheet
                    foreach (System.Data.DataTable table in result.Tables)
                    {
                        return table;
                    }
                    return null;
                }
            }
        }
    }
}
