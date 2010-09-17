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
        public static DataTable getList(ConfigItem p_configItem,int idcat,int idgroup,int iditem) 
        {
            COREBASE.COMMAND.SQL.AccessSQL l_sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);

            try
            {
                l_sql.Connect();
                string[] l_arrName = new string[] { "@id_danhmuc", "@id_nhomhh", "@id_hanghoa" };
                object[] l_arrValue = new object[] { idcat, idgroup, iditem };
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
        public static DataTable getList_new(ConfigItem p_configItem, int idsupplier)
        {
            COREBASE.COMMAND.SQL.AccessSQL l_sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);

            try
            {
                l_sql.Connect();
                string[] l_arrName = new string[] { "@id_supplier" };
                object[] l_arrValue = new object[] { idsupplier};
                return l_sql.GetDataByStoredProcedure("USP_SEL_UNIT_STYLE_new", l_arrName, l_arrValue);
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

        public static int Insert(ConfigItem p_configItem, object[] arrValue)
        {

            int ma = 0;
            try
            {

                string[] arrParaName = new string[] {
                    "@Id1",
                    "@Name",
                    "@Unit_In_Pk",
	                "@Unit_Out_Pk",	                
	                "@Remark",
                    "@Num",
                    "@Supplier_Pk",
                    "@Item_Pk",
                    "@Crt_By"
                };

                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
                ma = _sql.ExecuteInsert("USP_INS_UNIT_STYLE", arrNames: arrParaName, arrValues: arrValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ma;




            //System.Data.SqlClient.SqlConnection _sqlConnection = new System.Data.SqlClient.SqlConnection(p_ConfigItem.StrConnection);
            //if (_sqlConnection.State != ConnectionState.Open) _sqlConnection.Open();
            //System.Data.SqlClient.SqlTransaction _sqlTransaction = _sqlConnection.BeginTransaction();
            //try
            //{
            //    int _iNumberItem = p_UnitStyle.Rows.Count;
            //    string[] arrName = new string[] { "@NAME", "@UNIT_IN_PK", "@UNIT_OUT_PK", "@REMARK", "@NUM" };
                
            //    //object[] arrValue = new object[] { };
            //    //COREBASE.COMMAND.SQL.AccessSQL _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL();
            //    //int _idMaster = _providerSQL.ExecuteInsert(_sqlConnection, _sqlTransaction, "USP_INS_UNIT_STYLE", arrName, arrValue);
            //    //for (int i = 0; i < _iNumberItem; i++)
            //    //{
            //    //    arrName = new string[] { 
            //    //        "@Take_In_Pk", 
            //    //        "@Crt_By", 
            //    //        "@Remark", 
            //    //        "@Number_Bill", 
            //    //        "@Number_Real",
            //    //        "@Price", 
            //    //        "@Vat" ,
            //    //        "@Item_Pk",
            //    //        "@Unit_Pk"
            //    //    };
            //    //    arrValue = new object[] {
            //    //        _idMaster,
            //    //        _ConfigItem.Login_UserName,
            //    //        string.Empty,
            //    //        tbDetail.Rows[i]["Number_Bill"],
            //    //        tbDetail.Rows[i]["Number_Real"],
            //    //        tbDetail.Rows[i]["Price"],
            //    //        tbDetail.Rows[i]["Vat"],
            //    //        tbDetail.Rows[i]["Item_Pk"],
            //    //        tbDetail.Rows[i]["Unit_Pk"]
            //    //    };
            //    //    _providerSQL.ExecuteNonQuery(_sqlConnection, _sqlTransaction, "USP_INS_TAKE_IN_DETAIL", arrName, arrValue);
            //    //}
            //    _sqlTransaction.Commit();
            //    //_providerSQL.Disconnect(_sqlConnection);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    _sqlTransaction.Rollback();
            //    //AppDebug(ex);
            //    //if (_providerSQL != null)
            //    //    if (_sqlConnection != null)
            //    //        _providerSQL.Disconnect(_sqlConnection);
            //    return false;
            //}
        }
        
        public static bool Update(ConfigItem p_configItem, object[] arrValue)
        {
            try
            {

                string[] arrParaName = new string[] {
                    "@Id",
                    "@Name",
                    "@Unit_In_Pk",
                    "@Unit_Out_Pk",	                
                    "@Remark",
                    "@Num",
                    "@Supplier_Pk",
                    "@Item_Pk"
                };

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
