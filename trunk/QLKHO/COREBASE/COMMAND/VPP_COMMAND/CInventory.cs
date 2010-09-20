using System.Data.SqlClient;
using System.Data;
using System;


namespace COREBASE.COMMAND.VPP_COMMAND
{
    public class CInventory
    {
        public static bool ketchuyen(COMMAND.Config.ConfigItem _confItem)
        {           

            try
            {
                string[] arrParaName = new string[] { "@Crt_By" };
                object[] arrParaValue = new object[] { _confItem.Login_UserName };
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(_confItem);
                if (_sql.ExecuteNonQuery("usp_vpp_ketchuyenkho", arrParaName, arrParaValue) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                //TODO: Ghi log cho nay.
                throw ex;
            }

            
            
        }
    }
}
