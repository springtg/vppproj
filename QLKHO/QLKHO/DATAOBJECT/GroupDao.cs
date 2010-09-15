using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using COREBASE.COMMAND.Config;

namespace QLKHO.DATAOBJECT
{
    internal class GroupDao
    {
        public static DataTable GetList(ConfigItem p_configItem)
        {
            COREBASE.COMMAND.SQL.AccessSQL l_sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
            try
            {
                l_sql.Connect(p_configItem);
                return l_sql.GetDataByStoredProcedure("USP_SEL_GROUP_All");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                l_sql.Disconnect();
            }
        }

        public static DataTable GetList(ConfigItem p_configItem, int p_Catalog_Pk)
        {
            COREBASE.COMMAND.SQL.AccessSQL l_sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
            try
            {
                string[] arrName = new string[] { "@Catalog_Pk" };
                object[] arrValue = new object[] { p_Catalog_Pk };
                l_sql.Connect(p_configItem);
                return l_sql.GetDataByStoredProcedure("USP_SEL_GROUP_BY_CATALOG_ID", arrName, arrValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                l_sql.Disconnect();
            }
        }

        public static int Insert(ConfigItem p_configItem, DataRow p_drGroup)
        {
            COREBASE.COMMAND.SQL.AccessSQL l_sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
            try
            {
                string[] l_arrName = new string[] { "@Name", "@Crt_By", "@Remark", "@ID_Cat" };
                object[] l_arrValue = new object[] {
                    p_drGroup["Name"],
                    p_configItem.Login_UserName,
                    p_drGroup["Remark"],
                    p_drGroup["Id_Cat"]
                };
                l_sql.Connect(p_configItem);
                return l_sql.ExecuteInsert("USP_INS_GROUP", l_arrName, l_arrValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                l_sql.Disconnect();
            }
        }

        public static int Delete(ConfigItem p_configItem, int p_Group_Pk)
        {
            COREBASE.COMMAND.SQL.AccessSQL l_sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
            try
            {
                string[] l_arrName = new string[] { "@Id" };
                object[] l_arrValue = new object[] { p_Group_Pk };
                l_sql.Connect(p_configItem);
                return l_sql.ExecuteNonQuery("USP_DEL_GROUP", l_arrName, l_arrValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                l_sql.Disconnect();
            }
        }

        public static int Update(ConfigItem p_configItem, DataRow p_drGroup)
        {
            COREBASE.COMMAND.SQL.AccessSQL l_sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
            try
            {
                string[] l_arrName = new string[] { "@Id","@Name","@Mod_By","@Remark","@ID_Cat" };
                object[] l_arrValue = new object[] { p_drGroup["Id"], p_drGroup["Name"], p_configItem.Login_UserName, p_drGroup["Remark"], p_drGroup["Id_Cat"] };
                l_sql.Connect(p_configItem);
                return l_sql.ExecuteNonQuery("USP_UPD_GROUP", l_arrName, l_arrValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                l_sql.Disconnect();
            }
        }

        
    }
}
