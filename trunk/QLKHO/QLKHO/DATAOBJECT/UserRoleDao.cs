using System;
using System.Collections.Generic;
using COREBASE.COMMAND.Config;
using System.Data;
using QLKHO.BUSOBJECT;

namespace QLKHO.DATAOBJECT
{
    internal class UserRoleDao
    {
        public static DataTable GetRole(ConfigItem p_ConfigItem)
        {
            DataTable dt = null;
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                _sql.Connect(p_ConfigItem);
                dt = _sql.GetDataByStoredProcedure("[USP_SEL_ROLE]");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _sql.Disconnect();
            }
            return dt;
        }
        

        public static DataTable GetList(ConfigItem p_ConfigItem)
        {
            DataTable dt = null;
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                _sql.Connect(p_ConfigItem);
                dt = _sql.GetDataByStoredProcedure("USP_SEL_USER_ROLE");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _sql.Disconnect();
            }
            return dt;
        }
        
     
    }
}
