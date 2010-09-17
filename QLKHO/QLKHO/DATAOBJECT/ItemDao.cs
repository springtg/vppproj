using System;
using COREBASE.COMMAND.Config;
using System.Data;

namespace QLKHO.DATAOBJECT
{
    internal class ItemDao
    {

        public static DataTable GetList(ConfigItem p_configItem, int p_GroupID)
        {
            COREBASE.COMMAND.SQL.AccessSQL l_sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
            try
            {
                l_sql.Connect();
                string[] l_arrName = new string[] { "@Group_Pk" };
                object[] l_arrValue = new object[] { p_GroupID };
                return l_sql.GetDataByStoredProcedure("USP_SEL_ITEM_BY_GROUP_ID", l_arrName, l_arrValue);
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

        public static DataTable GetList(ConfigItem p_configItem)
        {
            DataTable dt = null;
            try
            {
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
                dt = _sql.GetDataByStoredProcedure("USP_SEL_ITEM_All");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static int Insert(ConfigItem p_configItem, object[] arrValue)
        {
            int ma = 0;
            try
            {

                string[] arrParaName = new string[] {
                    "@Name",
                    "@Group_Pk",
	                "@Crt_By",
	                "@Remark",
                    "@number_in"
                };

                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
                ma = _sql.ExecuteInsert("USP_INS_ITEM", arrNames: arrParaName, arrValues: arrValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ma;
        }

        public static bool Update(ConfigItem p_configItem, object[] arrValue)
        {
            try
            {

                string[] arrParaName = new string[] {
                    "@Id",
                    "@Name",
                    "@Group_Pk",
	                "@Mod_Dt",
	                "@Mod_By",
	                "@Is_Del",
	                "@Remark",
                    "@number_in"   };

                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
                _sql.ExecuteNonQuery("USP_UPD_ITEM", arrNames: arrParaName, arrValues: arrValue);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static bool Delete(ConfigItem p_configItem, int _idSuppiler)
        {
            try
            {
                string[] arrParaName = new string[] { "@Id" };
                object[] arrParaValue = new object[] { _idSuppiler };
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
                _sql.ExecuteNonQuery("USP_DEL_ITEM", arrParaName, arrParaValue);
                return true;
            }
            catch (Exception ex)
            {
                //TODO: Ghi log cho nay.
                throw ex;
            }
        }

    }
}
