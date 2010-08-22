using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace COREBASE.COMMAND.VPP_COMMAND
{
   public static class CUser
    {
       public static DataTable ListUser(COMMAND.Config.ConfigItem _confItem)
       {
           COMMAND.SQL.AccessSQL _sql = new SQL.AccessSQL(_confItem);
           return _sql.GetDataByStoredProcedure("SP_SEL_USER");
       }

       public static bool LoginUser(COMMAND.Config.ConfigItem _confItem, string strUserName, string strPassword)
       {
           COMMAND.SQL.AccessSQL _sql = new SQL.AccessSQL(_confItem);
           string[] arrParaName = new string[] {"@Name","@Password" };
           object[] arrParaValue = new string[] { strUserName,strPassword};
           DataTable tb = _sql.GetDataByStoredProcedure("sp_Login", arrParaName, arrParaValue);
           if (tb.Rows.Count > 0)
           {
               return true;
           }
           return false;           
       }
    }
}
