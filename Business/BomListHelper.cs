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
    public class BomListHelper
    {
        private static void InitSqlServer()
        {
            SQLHelper.SERVER_NAME = "172.28.10.22";
            SQLHelper.USERNAME_DB = "sa";
            SQLHelper.PASSWORD_DB = "$umcevn123";
            SQLHelper.DATABASE = "COST_SYSTEM";
            SQLHelper.ConnectString();
        }
        public static DataTable GetTop1000()
        {
            InitSqlServer();
            string sql = @"SELECT TOP (100) 
                           [MATERIAL_NUMBER] 'Material Number'
                          ,[CUSTOMER_ID] 'Customer Number'
                          ,[ALTERNATIVE_BOM] 'Alternative BOM'
                          ,[PLANT] 'Plant'
                          ,[ASSEMBLE_MATERIAL_NUMBER] 'Assemble Material Number'
                          ,[BOM_LEVEL] 'BOM Level'
                          ,[BOM_ITEM_NUMBER] 'BOM Item Number'
                          ,[BOM_COMPONENT] 'BOM Component'
                          ,[PART_NAME] 'PART NAME'
                          ,[ALT_GROUP] 'Alternative item: group'
                          ,[ALT_RANKING] 'Alternative item: ranking order'
                          ,[ALT_STRATEGY] 'Alternative item: strategy'
                          ,[USAGE_PROBABILITY] 'Usage probability in %'
                          ,[DIS_INDICATOR] 'Discontinuation indicator'
                          ,[DIS_GROUP] 'Discontinuation group'
                          ,[FLLOW_UP] 'Follow-up group'
                          ,[VALID_PERIOD] 'VALID PERIOD(H)'
                          ,[ROHS] 'RoHS'
                          ,[DETAIL_SPEC] 'Detailed specification'
                          ,[MANUFACTURER_PART] 'Manufacturer Part Number'
                          ,[MANUFACTURER] 'Manufacturer'
                          ,[UNIT] 'UNIT'
                          ,[FILE_NAME] 'File Name'
                          ,[QTY]
                          ,[BASE_QTY] 'Base quantity'
                          ,[LOCATION] 'LOC'
                          ,[SUPLLY] 'SUPLLY'
                          ,[ECO_NO] 'ECO NO'
                          ,[REMASK] 'REMARK'
                          ,[CUSTOMER_PART_NO] 'CUSTOMER PART NO'
                          ,[INDICATOR_BULK_MATERIAL] 'Indicator: Bulk Material'
                          ,[INDICATOER_COSTING] 'Indicator for relevancy to costing'
                          ,[REVISION_LEVEL] 'Revision Level'
                          ,[QUOTATION] 'Quotation'
                          ,[NET_WEIGHT] 'Net Weight'
                          ,[WEIGHET_UNIT] 'Weight Unit'
                          ,[MATERIAL_GROUP] 'Material Group'
                          ,[MATERIAL_GROUP_DES] 'Material Group Description'
                          ,[MPN_PART_NO] 'MPN PART NO'
                          ,[PUR_DES] 'purchase description'
                          ,[ALT_GROUP_2] 'Alternative item: group'
                          ,[DIS_FLLOW_UP] 'Discontinuation Follow-up'
                          ,[INSTALL_POS_1] 'Installation position1'
                          ,[INSTALL_POS_2] 'Installation position2'
                          ,[INSTALL_POS_3] 'Installation position3'
                          ,[INSTALL_POS_4] 'Installation position4'
                          ,[INSTALL_POS_5] 'Installation position5'
                          ,[INSTALL_POS_6] 'Installation position6'
                          ,[INSTALL_POS_7] 'Installation position7'
                          ,[QTY_ACTUAL] 'Qty Actual'
                          FROM [COST_SYSTEM].[dbo].[BOM_LIST]";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }
        public static DataTable GetByModel(string modelNo)
        {
            InitSqlServer();
            string sql = $@"SELECT TOP (1000) 
       [MATERIAL_NUMBER] 'Material Number'
      ,[CUSTOMER_ID] 'Customer Number'
      ,[ALTERNATIVE_BOM] 'Alternative BOM'
      ,[PLANT] 'Plant'
      ,[ASSEMBLE_MATERIAL_NUMBER] 'Assemble Material Number'
      ,[BOM_LEVEL] 'BOM Level'
      ,[BOM_ITEM_NUMBER] 'BOM Item Number'
      ,[BOM_COMPONENT] 'BOM Component'
      ,[PART_NAME] 'PART NAME'
      ,[ALT_GROUP] 'Alternative item: group'
      ,[ALT_RANKING] 'Alternative item: ranking order'
      ,[ALT_STRATEGY] 'Alternative item: strategy'
      ,[USAGE_PROBABILITY] 'Usage probability in %'
      ,[DIS_INDICATOR] 'Discontinuation indicator'
      ,[DIS_GROUP] 'Discontinuation group'
      ,[FLLOW_UP] 'Follow-up group'
      ,[VALID_PERIOD] 'VALID PERIOD(H)'
      ,[ROHS] 'RoHS'
      ,[DETAIL_SPEC] 'Detailed specification'
      ,[MANUFACTURER_PART] 'Manufacturer Part Number'
      ,[MANUFACTURER] 'Manufacturer'
      ,[UNIT] 'UNIT'
      ,[FILE_NAME] 'File Name'
      ,[QTY]
      ,[BASE_QTY] 'Base quantity'
      ,[LOCATION] 'LOC'
      ,[SUPLLY] 'SUPLLY'
      ,[ECO_NO] 'ECO NO'
      ,[REMASK] 'REMARK'
      ,[CUSTOMER_PART_NO] 'CUSTOMER PART NO'
      ,[INDICATOR_BULK_MATERIAL] 'Indicator: Bulk Material'
      ,[INDICATOER_COSTING] 'Indicator for relevancy to costing'
      ,[REVISION_LEVEL] 'Revision Level'
      ,[QUOTATION] 'Quotation'
      ,[NET_WEIGHT] 'Net Weight'
      ,[WEIGHET_UNIT] 'Weight Unit'
      ,[MATERIAL_GROUP] 'Material Group'
      ,[MATERIAL_GROUP_DES] 'Material Group Description'
      ,[MPN_PART_NO] 'MPN PART NO'
      ,[PUR_DES] 'purchase description'
      ,[ALT_GROUP_2] 'Alternative item: group'
      ,[DIS_FLLOW_UP] 'Discontinuation Follow-up'
      ,[INSTALL_POS_1] 'Installation position1'
      ,[INSTALL_POS_2] 'Installation position2'
      ,[INSTALL_POS_3] 'Installation position3'
      ,[INSTALL_POS_4] 'Installation position4'
      ,[INSTALL_POS_5] 'Installation position5'
      ,[INSTALL_POS_6] 'Installation position6'
      ,[INSTALL_POS_7] 'Installation position7'
      ,[QTY_ACTUAL] 'Qty Actual'
       FROM [COST_SYSTEM].[dbo].[BOM_LIST]
       where MATERIAL_NUMBER = '{modelNo}'";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }
        public static DataTable GetData()
        {
            var top = fBomListSearch.lstCustomer.Count == 0 && fBomListSearch.lstMaterial.Count == 0 ? "TOP (100)" : "";
            var sql = string.Format(@"SELECT {0}
       [MATERIAL_NUMBER] 'Material Number'
      ,[CUSTOMER_ID] 'Customer Number'
      ,[ALTERNATIVE_BOM] 'Alternative BOM'
      ,[PLANT] 'Plant'
      ,[ASSEMBLE_MATERIAL_NUMBER] 'Assemble Material Number'
      ,[BOM_LEVEL] 'BOM Level'
      ,[BOM_ITEM_NUMBER] 'BOM Item Number'
      ,[BOM_COMPONENT] 'BOM Component'
      ,[PART_NAME] 'PART NAME'
      ,[ALT_GROUP] 'Alternative item: group'
      ,[ALT_RANKING] 'Alternative item: ranking order'
      ,[ALT_STRATEGY] 'Alternative item: strategy'
      ,[USAGE_PROBABILITY] 'Usage probability in %'
      ,[DIS_INDICATOR] 'Discontinuation indicator'
      ,[DIS_GROUP] 'Discontinuation group'
      ,[FLLOW_UP] 'Follow-up group'
      ,[VALID_PERIOD] 'VALID PERIOD(H)'
      ,[ROHS] 'RoHS'
      ,[DETAIL_SPEC] 'Detailed specification'
      ,[MANUFACTURER_PART] 'Manufacturer Part Number'
      ,[MANUFACTURER] 'Manufacturer'
      ,[UNIT] 'UNIT'
      ,[FILE_NAME] 'File Name'
      ,[QTY]
      ,[BASE_QTY] 'Base quantity'
      ,[LOCATION] 'LOC'
      ,[SUPLLY] 'SUPLLY'
      ,[ECO_NO] 'ECO NO'
      ,[REMASK] 'REMARK'
      ,[CUSTOMER_PART_NO] 'CUSTOMER PART NO'
      ,[INDICATOR_BULK_MATERIAL] 'Indicator: Bulk Material'
      ,[INDICATOER_COSTING] 'Indicator for relevancy to costing'
      ,[REVISION_LEVEL] 'Revision Level'
      ,[QUOTATION] 'Quotation'
      ,[NET_WEIGHT] 'Net Weight'
      ,[WEIGHET_UNIT] 'Weight Unit'
      ,[MATERIAL_GROUP] 'Material Group'
      ,[MATERIAL_GROUP_DES] 'Material Group Description'
      ,[MPN_PART_NO] 'MPN PART NO'
      ,[PUR_DES] 'purchase description'
      ,[ALT_GROUP_2] 'Alternative item: group'
      ,[DIS_FLLOW_UP] 'Discontinuation Follow-up'
      ,[INSTALL_POS_1] 'Installation position1'
      ,[INSTALL_POS_2] 'Installation position2'
      ,[INSTALL_POS_3] 'Installation position3'
      ,[INSTALL_POS_4] 'Installation position4'
      ,[INSTALL_POS_5] 'Installation position5'
      ,[INSTALL_POS_6] 'Installation position6'
      ,[INSTALL_POS_7] 'Installation position7'
      ,[QTY_ACTUAL] 'Qty Actual'
       FROM [COST_SYSTEM].[dbo].[BOM_LIST]
       WHERE '1' = '1' ", top);

            if (fBomListSearch.lstMaterial.Count > 0)
            {
                sql += $" AND MATERIAL_NUMBER IN('{string.Join("','", fBomListSearch.lstMaterial)}')";
            }
            if (fBomListSearch.lstCustomer.Count > 0)
            {
                sql += $" AND CUSTOMER_ID IN('{string.Join("','", fBomListSearch.lstCustomer)}')";
            }
            sql += " ORDER BY [MATERIAL_NUMBER],[ASSEMBLE_MATERIAL_NUMBER]";
            return SQLHelper.ExecQueryDataAsDataTable(sql);
        }
        public static void Save(DataTable dt)
        {
            InitSqlServer();
            SQLHelper.ExecProcedureNonData("BomList_Update_All", new { Data = dt, windowUser = "System" });
        }
    }
}
