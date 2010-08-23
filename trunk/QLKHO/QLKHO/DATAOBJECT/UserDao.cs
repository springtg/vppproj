using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COREBASE.COMMAND.Config;
using System.Data;
using QLKHO.BUSOBJECT;
namespace QLKHO.DATAOBJECT
{
    class UserDao
    {
        public ConfigItem confItem;
        public UserDao(ConfigItem _confItem)
        {
            this.confItem = _confItem;

        }
        public IList<User> GetUserList()
        {
            IList<User> lUser = null;
            try
            {
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                DataTable dt = _sql.GetDataByStoredProcedure("SP_SEL_USER");
                lUser = COREBASE.COMMAND.SQL.CMapping.MapList<User>(dt);
            }
            catch (Exception ex)
            {

            }
            return lUser;
        }
    }
}
