using System;
using System.Collections.Generic;
using COREBASE.COMMAND.Config;
using System.Data;
using QLKHO.BUSOBJECT;

namespace QLKHO.DATAOBJECT
{
    internal class UserDao
    {
        public static IList<User> GetUserList(ConfigItem p_ConfigItem)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            IList<User> lUser = null;
            try
            {                
                _sql.Connect(p_ConfigItem);
                DataTable dt = _sql.GetDataByStoredProcedure("USP_SEL_USER");
                lUser = COREBASE.COMMAND.SQL.CMapping.MapList<User>(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _sql.Disconnect();
            }
            return lUser;
        }

        public static DataTable GetList(ConfigItem p_ConfigItem)
        {
            DataTable dt = null;
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                _sql.Connect(p_ConfigItem);
                dt = _sql.GetDataByStoredProcedure("USP_SEL_USER");
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
        
        public static int Insert(ConfigItem p_ConfigItem,object[] arrValue)
        {
            int ma = 0;
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                string[] arrParaName = new string[] {
                    "@Name_Dis",
                    "@Name",
                   "@Password",
	                "@Crt_By",
	                "@Remark",
                    "@Phone",
                    "@Address"
                };
                _sql.Connect(p_ConfigItem);
                ma = _sql.ExecuteInsert("USP_INS_USER", arrNames: arrParaName, arrValues: arrValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _sql.Disconnect();
            }
            return ma;
        }

        public static bool Update(ConfigItem p_ConfigItem, object[] arrValue)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                string[] arrParaName = new string[] {
                    "@Id",
                    "@Name_Dis",
                    "@Name",
                    "@Password",
	                "@Mod_By",
	                "@Remark",
                    "@Phone",
                    "@Address"};
                _sql.Connect(p_ConfigItem);
                _sql.ExecuteNonQuery("USP_UPD_USER", arrNames: arrParaName, arrValues: arrValue);
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

        public static bool Delete(ConfigItem p_ConfigItem, int _idSuppiler)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                string[] arrParaName = new string[] { "@Id" };
                object[] arrParaValue = new object[] { _idSuppiler };
                _sql.Connect(p_ConfigItem);
                _sql.ExecuteNonQuery("USP_DEL_USER", arrParaName, arrParaValue);
                return true;
            }
            catch (Exception ex)
            {
                //TODO: Ghi log cho nay.
                throw ex;
            }
            finally
            {
                _sql.Disconnect();
            }
        }
    }
}
