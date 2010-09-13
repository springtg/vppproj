using System;
using COREBASE.COMMAND.Config;
using System.Data;

namespace QLKHO.DATAOBJECT
{
    internal class CatalogDao
    {
        public static DataTable GetList(ConfigItem p_ConfigItem)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                _sql.Connect(p_ConfigItem);
                return _sql.GetDataByStoredProcedure("USP_SEL_CATALOG_All");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _sql.Disconnect();
            }
        }
        public static DataTable GetList(ConfigItem p_ConfigItem, int p_Catalog_Pk)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                string[] arrParaName = new string[] { "@Id" };
                object[] arrValue = new object[] { p_Catalog_Pk };
                _sql.Connect(p_ConfigItem);
                return _sql.GetDataByStoredProcedure("USP_SEL_CATALOG_BY_ID", arrParaName, arrValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _sql.Disconnect();
            }
        }
    }
}
