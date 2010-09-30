using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using COREBASE.COMMAND.Config;

namespace QLKHO.DATAOBJECT
{
    internal class UnitStyleDao
    {
        public static DataTable GetList(ConfigItem p_configItem)
        {
            COREBASE.COMMAND.SQL.AccessSQL l_sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
            try
            {
                l_sql.Connect();
                return l_sql.GetDataByStoredProcedure("USP_SEL_UNIT_STYLE");
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

        public static DataTable GetList(ConfigItem p_configItem, int p_Unit_Out_Pk)
        {
            COREBASE.COMMAND.SQL.AccessSQL l_sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
            try
            {
                l_sql.Connect();
                string[] l_arrName = new string[] { "@Unit_Out_Pk" };
                object[] l_arrValue = new object[] { p_Unit_Out_Pk };
                return l_sql.GetDataByStoredProcedure("USP_SEL_UNIT_STYLE", l_arrName, l_arrValue);
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

        public static int Insert(ConfigItem p_configItem, DataRow p_dtRow)
        {
            int ma = 0;
            try
            {
                object[] arrValue = new object[] { 
                    p_dtRow["Unit_In_Pk"],
                    p_dtRow["Unit_Out_Pk"],
                    p_dtRow["Remark"],
                    p_dtRow["Num"],
                    p_configItem.Login_UserName
                };
                string[] arrParaName = new string[] {
                    "@Unit_In_Pk",
	                "@Unit_Out_Pk",	                
	                "@Remark",
                    "@Num",
                    "@Crt_By"
                };

                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
                ma = _sql.ExecuteInsert("USP_INS_UNIT_STYLE",  arrParaName,  arrValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ma;
        }       

        public static bool Update(ConfigItem p_configItem, DataRow p_dtRow)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
            try
            {
                object[] arrValue = new object[] { 
                    p_dtRow["Id"],
                    p_dtRow["Unit_In_Pk"],
                    p_dtRow["Unit_Out_Pk"],
                    p_dtRow["Remark"],
                    p_dtRow["Num"]
                };

                string[] arrParaName = new string[] {
                    "@Id",
                    "@Unit_In_Pk",
                    "@Unit_Out_Pk",	                
                    "@Remark",
                    "@Num"
                };

                _sql.Connect(p_configItem);
                _sql.ExecuteNonQuery("USP_UPD_UNIT_STYLE", arrParaName, arrValue);
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

        public static bool Delete(ConfigItem p_configItem, int _idSuppiler)
        {
            try
            {
                string[] arrParaName = new string[] { "@Id" };
                object[] arrParaValue = new object[] { _idSuppiler };
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
                _sql.ExecuteNonQuery("USP_DEL_UNIT_STYLE", arrParaName, arrParaValue);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
