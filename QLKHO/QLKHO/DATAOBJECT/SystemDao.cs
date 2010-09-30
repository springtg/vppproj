using System;
using System.Collections.Generic;
using COREBASE.COMMAND.Config;
using System.Data;
using QLKHO.BUSOBJECT;

namespace QLKHO.DATAOBJECT
{
    internal class SystemDao
    {
        public static void Backup (ConfigItem p_ConfigItem, string path)
        { 
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                string[] arrParaName = new string[] {
                    "@Path"
                 };
                string[] arrParaValue = new string[] {
                   path
                 };
                _sql.Connect(p_ConfigItem);
                _sql.ExecuteNonQuery("[USP_SYS_BACKUP]", arrParaName, arrParaValue);
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
        public static void Restore(ConfigItem p_ConfigItem, string file)
        {
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
            try
            {
                string[] arrParaName = new string[] {
                    "@Path"
                 };
                string[] arrParaValue = new string[] {
                   file
                 };
                _sql.Connect(p_ConfigItem);
                _sql.ExecuteNonQuery("[USP_SYS_Restore]", arrParaName, arrParaValue);
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
