using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COREBASE.COMMAND.Config;
using System.Data;
using QLKHO.BUSOBJECT;
namespace QLKHO.DATAOBJECT
{
    class UserDao
    {
        public ConfigItem confItem;
        public UserDao(ConfigItem _confItem)
        {
            this.confItem = _confItem;

        }
        public IList<User> GetUserList()
        {
            IList<User> lUser = null;
            try
            {
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                DataTable dt = _sql.GetDataByStoredProcedure("USP_SEL_USER");
                lUser = COREBASE.COMMAND.SQL.CMapping.MapList<User>(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lUser;
        }
        public DataTable GetList()
        {
            DataTable dt = null;
            try
            {
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                dt = _sql.GetDataByStoredProcedure("USP_SEL_USER");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public int Insert(object[] arrValue)
        {
            int ma = 0;
            try
            {
                string[] arrParaName = new string[] {
                    "@Name_Dis",
                    "@Name",
                   "@Password",
	                "@Crt_Dt",
	                "@Crt_By",
	                "@Is_Del",
	                "@Remark",
                    "@Phone",
                    "@Address"
                };

                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                ma = _sql.ExecuteInsert("usp_InsertVPP_USER", arrNames: arrParaName, arrValues: arrValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ma;
        }

        public bool Update(object[] arrValue)
        {
            try
            {
                string[] arrParaName = new string[] {
                    "@Id",
                    "@Name_Dis",
                    "@Name",
                    "@Password",
	                "@Mod_Dt",
	                "@Mod_By",
	                "@Is_Del",
	                "@Remark",
                    "@Phone",
                    "@Address"};

                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                _sql.ExecuteNonQuery("usp_UpdateVPP_USER", arrNames: arrParaName, arrValues: arrValue);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool Delete(int _idSuppiler)
        {
            try
            {
                string[] arrParaName = new string[] { "@Id" };
                object[] arrParaValue = new object[] { _idSuppiler };
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                _sql.ExecuteNonQuery("usp_DeleteVPP_USER", arrParaName, arrParaValue);
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
