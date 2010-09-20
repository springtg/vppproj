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
                return l_sql.GetDataByStoredProcedure("USP_SEL_UNIT_STYLE_By_SupplierPK", l_arrName, l_arrValue);
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

        public static int Insert(ConfigItem p_configItem, DataRow p_dtRow, int p_SupplierId)
        {
            return Insert(p_configItem, p_dtRow, p_SupplierId, 0);
        }

        public static int Insert(ConfigItem p_configItem,DataRow p_dtRow, int p_SupplierId, int p_Id1)
        {

            int ma = 0;
            try
            {
                object[] arrValue = new object[] { 
                    p_Id1,
                    p_dtRow["Name"],
                    p_dtRow["Unit_In_Pk"],
                    p_dtRow["Unit_Out_Pk"],
                    p_dtRow["Remark"],
                    p_dtRow["Num"],
                    p_dtRow["Supplier_Pk"],
                    p_configItem.Login_UserName
                };

                string[] arrParaName = new string[] {
                    "@Id1",
                    "@Name",
                    "@Unit_In_Pk",
	                "@Unit_Out_Pk",	                
	                "@Remark",
                    "@Num",
                    "@Supplier_Pk",
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
                    "@Supplier_Pk",
                    "@Num"
                };

                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
                _sql.ExecuteNonQuery("USP_UPD_UNIT_STYLE", arrParaName, arrValue);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static bool Update(ConfigItem p_configItem, DataRow p_dtRow)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_configItem);
            try
            {
                object[] arrValue = new object[] { 
                    p_dtRow["Id"],
                    p_dtRow["Name"],
                    p_dtRow["Unit_In_Pk"],
                    p_dtRow["Unit_Out_Pk"],
                    p_dtRow["Remark"],
                    p_dtRow["Supplier_Pk"],
                    p_dtRow["Num"]
                };

                string[] arrParaName = new string[] {
                    "@Id",
                    "@Name",
                    "@Unit_In_Pk",
                    "@Unit_Out_Pk",	                
                    "@Remark",
                    "@Supplier_Pk",
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
