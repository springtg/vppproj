using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLKHO.BUSOBJECT;
using System.Data;
using COREBASE.COMMAND.Config;

namespace QLKHO.DATAOBJECT
{
    class SupplierDao
    {
        public ConfigItem confItem;
        public SupplierDao(ConfigItem _confItem)
        {
            this.confItem = _confItem;

        }
        public IList<Supplier> GetUserList()
        {
            IList<Supplier> lUser = null;
            try
            {
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                DataTable dt = _sql.GetDataByStoredProcedure("usp_SelectVPP_SUPPLIER");
                lUser = COREBASE.COMMAND.SQL.CMapping.MapList<Supplier>(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lUser;
        }
        public int Insert(Supplier supplier)
        {
            int ma = 0;
            try
            {

                string[] arrParaName = new string[] {"@Name",
                    "@Phone",
                    "@Phone1",
                    "@Address",
                    "@Address1",
                    "@Fax",
                    "@Email",
                    "@Website",
                    "@Crt_Dt",
                    "@Crt_By",
                    "@Mod_Dt",
                    "@Mod_By",
                    "@Is_Del",
                    "@TaxCode",
                    "@Credit",
                    "@Debit"};
                object[] arrParaValue = new object[] {
                    supplier.Name,
                    supplier.Phone,
                    supplier.Phone1,
                    supplier.Address,
                    supplier.Address1,
                    supplier.Fax,
                    supplier.Email,
                    supplier.Website,
                    supplier.Crt_Dt,
                    supplier.Crt_By,
                    supplier.Mod_Dt,
                    supplier.Mod_By,
                    supplier.Is_Del,
                    supplier.TaxCode,
                    supplier.Credit,
                    supplier.Debit

                };
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                ma = _sql.ExecuteInsert("usp_InsertVPP_SUPPLIER", arrNames: arrParaName, arrValues: arrParaValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ma;
        }

    }
}
