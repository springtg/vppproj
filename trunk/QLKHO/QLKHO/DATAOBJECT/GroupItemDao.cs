﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COREBASE.COMMAND.Config;
using System.Data;

namespace QLKHO.DATAOBJECT
{
    class GroupItemDao
    {
        public ConfigItem confItem;
        public GroupItemDao(ConfigItem _conf)
        {
            this.confItem = _conf;
        }
        public DataTable GetList()
        {
            DataTable dt = null;
            try
            {
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                dt = _sql.GetDataByStoredProcedure("usp_SelectVPP_GROUPsAll");
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public int Insert(object [] arrValue)
        {
            int ma = 0;
            try
            {

                string[] arrParaName = new string[] {
                    "@Name",
	                "@Crt_Dt",
	                "@Crt_By",
	                "@Is_Del",
	                "@Remark",
                    "@Id_Cat"
                };

                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                ma = _sql.ExecuteInsert("usp_InsertVPP_GROUP", arrNames: arrParaName, arrValues: arrValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ma;
        }

        public bool Update(object [] arrValue )
        {
            try
            {

                string[] arrParaName = new string[] {
                    "@Id",
                    "@Name",
	                "@Mod_Dt",
	                "@Mod_By",
	                "@Is_Del",
	                "@Remark",
                    "@Id_Cat"};

                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                _sql.ExecuteNonQuery("usp_UpdateVPP_GROUP", arrNames: arrParaName, arrValues: arrValue);
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
                _sql.ExecuteNonQuery("usp_DeleteVPP_GROUP", arrParaName, arrParaValue);
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
