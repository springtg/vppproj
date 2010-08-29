using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COREBASE.COMMAND.Config;
using System.Data;

namespace QLKHO.DATAOBJECT
{
    class CatalogDao
    {
        public ConfigItem confItem;
        public CatalogDao(ConfigItem _conf) {
            this.confItem = _conf;
        }
        public DataTable GetList()
        {
            DataTable dt = null;
            try
            {
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                dt = _sql.GetDataByStoredProcedure("usp_SelectVPP_CATALOGsAll");
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable GetList(object[] arrValue)
        {
            DataTable dt = null;
            try
            {
                string[] arrParaName = new string[] {
                    "@Id"
                };
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                dt = _sql.GetDataByStoredProcedure("usp_SelectVPP_CATALOGbyId",arrParaName,arrValue);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
