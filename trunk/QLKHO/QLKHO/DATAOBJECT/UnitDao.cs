﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COREBASE.COMMAND.Config;
using System.Data;

namespace QLKHO.DATAOBJECT
{
    class UnitDao
    {
        public ConfigItem confItem;
        public UnitDao(ConfigItem _conf)
        {
            this.confItem = _conf;
        }
        public DataTable GetList()
        {
            DataTable dt = null;
            try
            {
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                dt = _sql.GetDataByStoredProcedure("USP_SEL_UNIT");

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
                    "@Name",
                    "@Crt_Dt",
                    "@Crt_By",
                    "@Remark"};

                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                ma = _sql.ExecuteInsert("USP_INS_UNIT", arrNames: arrParaName, arrValues: arrValue);
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
                    "@Name",
                    "@Crt_Dt",
                    "@Crt_By",
                    "@Remark"};

                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                _sql.ExecuteNonQuery("USP_UPD_UNIT", arrNames: arrParaName, arrValues: arrValue);
                return true;
            }
            catch (Exception ex)
            {
                return true;

            }
        }

        public bool Delete(int _idSuppiler)
        {
            try
            {
                string[] arrParaName = new string[] { "@Id" };
                object[] arrParaValue = new object[] { _idSuppiler };
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                _sql.ExecuteNonQuery("USP_DEL_UNIT", arrParaName, arrParaValue);
                return true;
            }
            catch (Exception ex)
            {
                //TODO: Ghi log cho nay.
                return false;
            }
        }
     
    }
}