using System;
using System.Data;

namespace COREBASE.COMMAND.VPP_COMMAND
{
    public class CTakeOut
    {
        public static string getNextIDTakeOut(Config.ConfigItem _confItem)
        {
            try
            {
                COMMAND.SQL.AccessSQL _sql = new SQL.AccessSQL(_confItem);
                DataTable tb = _sql.GetDataByStoredProcedure("USP_SEL_TAKE_OUT_ID");
                return Convert.Convert.CnvToString(tb.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
