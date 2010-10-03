using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using COREBASE.COMMAND.Config;

namespace QLKHO.DATAOBJECT
{
   internal class ReportDao
    {
       public static DataSet GetListTakeIn(int p_Take_In_Pk, ConfigItem p_ConfigItem)
       { 
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                _sql.Connect(p_ConfigItem);
                string[] arrParaName = new string[] { "@Take_In_Pk" };
                object[] arrParaValue = new object[] { p_Take_In_Pk };
                return _sql.GetDataByStoredProcedure_DS("USP_RPT_TAKE_IN", arrParaName, arrParaValue);
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
       public static DataSet GetListTakeOut(int p_Take_Out_Pk, ConfigItem p_ConfigItem)
       {
           COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
           try
           {
               _sql.Connect(p_ConfigItem);
               string[] arrParaName = new string[] { "@Take_Out_Pk" };
               object[] arrParaValue = new object[] { p_Take_Out_Pk };
               return _sql.GetDataByStoredProcedure_DS("USP_RPT_TAKE_OUT", arrParaName, arrParaValue);
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
