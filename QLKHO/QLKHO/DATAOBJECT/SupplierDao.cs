using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLKHO.BUSOBJECT;
using System.Data;
using COREBASE.COMMAND.Config;

namespace QLKHO.DATAOBJECT
{
    class SupplierDao
    {
         public ConfigItem confItem;
         public SupplierDao(ConfigItem _confItem)
        {
            this.confItem = _confItem;

        }
        public IList<Supplier> GetUserList()
        {
            IList<Supplier> lUser = null;
            try
            {
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                DataTable dt = _sql.GetDataByStoredProcedure("usp_SelectVPP_SUPPLIER");
                lUser = COREBASE.COMMAND.SQL.CMapping.MapList<Supplier>(dt);
            }
            catch (Exception ex)
            {

            }
            return lUser;
        }

    }
}
