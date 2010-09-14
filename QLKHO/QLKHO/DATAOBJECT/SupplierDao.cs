using System;
using System.Collections.Generic;
using QLKHO.BUSOBJECT;
using System.Data;
using COREBASE.COMMAND.Config;

namespace QLKHO.DATAOBJECT
{
    internal class SupplierDao
    {
        public static IList<Supplier> GetList(ConfigItem p_ConfigItem)
        {
            IList<Supplier> lUser = null;
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                _sql.Connect(p_ConfigItem);
                DataTable dt = _sql.GetDataByStoredProcedure("USP_SEL_SUPPLIER");
                lUser = COREBASE.COMMAND.SQL.CMapping.MapList<Supplier>(dt);
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

        public static int Insert(ConfigItem p_ConfigItem, Supplier p_Supplier)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                string[] arrParaName = new string[] {
                    "@Name",
                    "@Phone",
                    "@Phone1",
                    "@Address",
                    "@Address1",
                    "@Fax",
                    "@Email",
                    "@Website",
                    "@Crt_By",
                    "@TaxCode",
                    "@Credit",
                    "@Debit"};
                object[] arrParaValue = new object[] {
                    p_Supplier.Name,
                    p_Supplier.Phone,
                    p_Supplier.Phone1,
                    p_Supplier.Address,
                    p_Supplier.Address1,
                    p_Supplier.Fax,
                    p_Supplier.Email,
                    p_Supplier.Website,
                    p_ConfigItem.Login_UserName,
                    p_Supplier.TaxCode,
                    p_Supplier.Credit,
                    p_Supplier.Debit};
                _sql.Connect(p_ConfigItem);
                return _sql.ExecuteInsert("USP_INS_SUPPLIER",arrParaName, arrParaValue);
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

        public static bool Update(ConfigItem p_ConfigItem,Supplier p_Supplier)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {

                string[] arrParaName = new string[] {
                    "@Id",
                    "@Name",
                    "@Phone",
                    "@Phone1",
                    "@Address",
                    "@Address1",
                    "@Fax",
                    "@Email",
                    "@Website",
                    "@Mod_By",
                    "@TaxCode",
                    "@Credit",
                    "@Debit"};
                object[] arrParaValue = new object[] {
                    p_Supplier.Id,
                    p_Supplier.Name,
                    p_Supplier.Phone,
                    p_Supplier.Phone1,
                    p_Supplier.Address,
                    p_Supplier.Address1,
                    p_Supplier.Fax,
                    p_Supplier.Email,
                    p_Supplier.Website,
                    p_ConfigItem.Login_UserName,
                    p_Supplier.TaxCode,
                    p_Supplier.Credit,
                    p_Supplier.Debit

                };
                
                _sql.Connect(p_ConfigItem);
                _sql.ExecuteNonQuery("USP_UPD_SUPPLIER", arrNames: arrParaName, arrValues: arrParaValue);
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
                _sql.ExecuteNonQuery("USP_DEL_SUPPLIER", arrParaName, arrParaValue);
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
