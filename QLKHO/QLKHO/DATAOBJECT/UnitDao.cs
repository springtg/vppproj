using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COREBASE.COMMAND.Config;
using System.Data;

namespace QLKHO.DATAOBJECT
{
    internal class UnitDao
    {

        public static DataTable GetList(ConfigItem p_ConfigItem)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                _sql.Connect(p_ConfigItem);
                return _sql.GetDataByStoredProcedure("USP_SEL_UNIT");
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

        public static int Insert(ConfigItem p_ConfigItem, object[] arrValue)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                string[] arrParaName = new string[] {
                    "@Name",
                    "@Crt_Dt",
                    "@Crt_By",
                    "@Remark"};
                _sql.Connect(p_ConfigItem);
                return _sql.ExecuteInsert("USP_INS_UNIT", arrNames: arrParaName, arrValues: arrValue);
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

        public static bool Update(ConfigItem p_ConfigItem, object[] arrValue)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                string[] arrParaName = new string[] {
                    "@Id",
                    "@Name",
                    "@Crt_Dt",
                    "@Crt_By",
                    "@Remark"};
                _sql.Connect(p_ConfigItem);
                _sql.ExecuteNonQuery("USP_UPD_UNIT", arrParaName, arrValue);
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
            string[] arrParaName = new string[] { "@Id" };
            object[] arrParaValue = new object[] { _idSuppiler };
            try
            {
                _sql.Connect(p_ConfigItem);
                _sql.ExecuteNonQuery("USP_DEL_UNIT", arrParaName, arrParaValue);
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
