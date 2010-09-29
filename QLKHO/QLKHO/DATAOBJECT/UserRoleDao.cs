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

        public static DataTable GetListRoleByUID(ConfigItem p_ConfigItem, object[] arrValue)
        {
            DataTable dt = null;
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                string[] arrParaName = new string[] {
                    "@UserId"
                 };
                _sql.Connect(p_ConfigItem);
                dt = _sql.GetDataByStoredProcedure("USP_SEL_USER_ROLE_ByUser", arrParaName, arrValue);
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
        public static bool Update(ConfigItem p_ConfigItem, object[] arrValue)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                string[] arrParaName = new string[] {
                    "@Id",
                    "@RoleList"
                 };
                _sql.Connect(p_ConfigItem);
                _sql.ExecuteNonQuery("USP_Update_USERROLE", arrParaName, arrValue);
                return true;
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
