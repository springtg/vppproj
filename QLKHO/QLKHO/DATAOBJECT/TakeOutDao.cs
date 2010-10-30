using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COREBASE.COMMAND.Config;
using System.Data;

namespace QLKHO.DATAOBJECT
{
    internal class TakeOutDao
    {
        public static DataTable GetList(ConfigItem p_ConfigItem)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                _sql.Connect(p_ConfigItem);
                return _sql.GetDataByStoredProcedure("USP_SEL_TAKE_OUT");
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

        public static bool Insert(ConfigItem p_ConfigItem, DataRow p_drValue, DataTable p_dtValue)
        {
            bool l_rs = false;
            System.Data.SqlClient.SqlConnection _sqlConnection = new System.Data.SqlClient.SqlConnection(p_ConfigItem.StrConnection);
            if (_sqlConnection.State != ConnectionState.Open) _sqlConnection.Open();
            System.Data.SqlClient.SqlTransaction _sqlTransaction = _sqlConnection.BeginTransaction();
            COREBASE.COMMAND.SQL.AccessSQL _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL(); 
            try
            {
                string[] arrParaName = new string[] {
                    "@Number_Item",
                    "@Remark",
                    "@Crt_By",
                    "@Department_pk",
                    "@PriceTotal",
                    "@Take_Out_Date",
                    "@User_Pk"
                };
                object[] arrValue = new object[] {
                    p_drValue["Number_Item"],
                    p_drValue["Remark"],
                    p_ConfigItem.Login_ID,
                    p_drValue["Department_pk"],
                    p_drValue["PriceTotal"],
                    p_drValue["Take_Out_Date"],
                    p_drValue["User_Pk"]
                };
                int _idMaster = _providerSQL.ExecuteInsert(_sqlConnection, _sqlTransaction, "USP_INS_TAKE_OUT", arrParaName, arrValue);
                arrParaName = new string[] { 
                    "@Take_Out_Pk",
                    "@Crt_By",
                    "@Remark",
	                "@Take_Out_Number",
                    "@Price",
                    "@Item_Pk",
                    "@UnitStyle_Pk"
                };
                for (int i = 0; i < p_dtValue.Rows.Count; i++)
                {
                    DataRow l_drValue = p_dtValue.Rows[i];
                    arrValue = new object[] { 
                        _idMaster,
                        p_ConfigItem.Login_ID,
                        l_drValue["Remark"],
                        l_drValue["Number_Real"],
                        l_drValue["Price"],
                        l_drValue["Item_Pk"],
                        l_drValue["UnitStyle_Pk"]
                    };
                    _providerSQL.ExecuteNonQuery(_sqlConnection, _sqlTransaction, "USP_INS_TAKE_OUT_DETAIL", arrParaName, arrValue);
                }
                _sqlTransaction.Commit();
                l_rs =  true;
            }
            catch (Exception ex)
            {
                _sqlTransaction.Rollback();
                throw ex;
            }
            finally
            {
                _providerSQL.Disconnect(_sqlConnection);
            }
            return l_rs;
        }

        public static bool Update(ConfigItem p_ConfigItem, DataRow p_drValue, DataTable p_dtValue)
        {
            bool l_rs = false;
            System.Data.SqlClient.SqlConnection _sqlConnection = new System.Data.SqlClient.SqlConnection(p_ConfigItem.StrConnection);
            if (_sqlConnection.State != ConnectionState.Open) _sqlConnection.Open();
            System.Data.SqlClient.SqlTransaction _sqlTransaction = _sqlConnection.BeginTransaction();
            COREBASE.COMMAND.SQL.AccessSQL _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL(); 
            try
            {
                string[] arrParaName = new string[] {
                    "@Id",
                    "@Number_Item",
                    "@Remark",
                    "@Crt_By",
                    "@Department_pk",
                    "@PriceTotal",
                    "@Take_Out_Date",
                    "@User_Pk"
                };
                object[] arrValue = new object[] {
                    p_drValue["Id"],
                    p_drValue["Number_Item"],
                    p_drValue["Remark"],
                    p_ConfigItem.Login_ID,
                    p_drValue["Department_pk"],
                    p_drValue["PriceTotal"],
                    p_drValue["Take_Out_Date"],
                    p_drValue["User_Pk"]
                };
                int _idMaster = _providerSQL.ExecuteNonQuery(_sqlConnection, _sqlTransaction, "USP_UPD_TAKE_OUT", arrParaName, arrValue);
        
                arrParaName = new string[] { 
                    "@Id",
                    "@Take_Out_Pk",
                    "@Number_Item",
	                "@Remark",
                    "@Crt_By",
                    "@Price",
                    "@Item_Pk",
                    "@UnitStyle_Pk"
                };
                for (int i = 0; i < p_dtValue.Rows.Count; i++)
                {
                    DataRow l_drValue = p_dtValue.Rows[i];
                    if (p_dtValue.Rows[i].RowState == DataRowState.Added)
                    {
                        arrValue = new object[] {                         
                        l_drValue["Take_Out_Pk"],
                        p_ConfigItem.Login_ID,   
                        l_drValue["Remark"],
                        l_drValue["Number_Real"],
                        l_drValue["Price"],
                        l_drValue["Item_Pk"],
                        l_drValue["UnitStyle_Pk"]
                    };
                        _providerSQL.ExecuteNonQuery(_sqlConnection, _sqlTransaction, "USP_INS_TAKE_OUT_DETAIL", arrParaName, arrValue);
                    }
                    if (p_dtValue.Rows[i].RowState == DataRowState.Modified)
                    {
                         arrValue = new object[] { 
                        l_drValue["Id"],
                        l_drValue["Take_Out_Pk"],
                        l_drValue["Number_Real"],
                        l_drValue["Remark"],
                        p_ConfigItem.Login_ID,                        
                        l_drValue["Price"],
                        l_drValue["Item_Pk"],
                        l_drValue["UnitStyle_Pk"]
                    };
                        _providerSQL.ExecuteNonQuery(_sqlConnection, _sqlTransaction, "USP_UPD_TAKE_OUT_DETAIL", arrParaName, arrValue);
                    }
                    
                }
                _sqlTransaction.Commit();
                l_rs =  true;
            }
            catch (Exception ex)
            {
                l_rs = false;
                _sqlTransaction.Rollback();
                throw ex;
            }
            finally
            {
                _providerSQL.Disconnect(_sqlConnection);
            }
            return l_rs;
        }

        public static bool Delete(ConfigItem p_ConfigItem, DataRow p_drValue)
        {
            bool l_rs = false;
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            string[] arrParaName = new string[] { "@Id" ,"@Crt_By"};
            object[] arrParaValue = new object[] { p_drValue["Id"], p_ConfigItem.Login_ID };
            try
            {
                _sql.Connect(p_ConfigItem);
                _sql.ExecuteNonQuery("USP_DEL_TAKE_OUT", arrParaName, arrParaValue);
                l_rs= true;
            }
            catch (Exception ex)
            {
                l_rs = false;
                throw ex;
            }
            finally
            {
                _sql.Disconnect();
            }
            return l_rs;
        }

        public static bool DeleteDetail(ConfigItem p_ConfigItem, DataRow p_drValue)
        {
            bool l_rs = false;
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            string[] arrParaName = new string[] { "@Id", "@Crt_By" };
            object[] arrParaValue = new object[] { p_drValue["Id"] ,p_ConfigItem.Login_ID};
            try
            {
                _sql.Connect(p_ConfigItem);
                _sql.ExecuteNonQuery("USP_DEL_TAKE_OUT_DETAIL", arrParaName, arrParaValue);
                l_rs =  true;
            }
            catch (Exception ex)
            {
                l_rs = false;
                throw ex;
            }
            finally
            {
                _sql.Disconnect();
            }
            return l_rs;
        }

    }
}
