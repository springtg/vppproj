using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COREBASE.COMMAND.Config;
using System.Data;

namespace QLKHO.DATAOBJECT
{
    internal class TakeInDao
    {
        //public static bool Delete(ConfigItem p_ConfigItem, int p_idTakeinPk)
        //{
        //    COREBASE.COMMAND.SQL.AccessSQL l_Sql = new COREBASE.COMMAND.SQL.AccessSQL(p_ConfigItem);
        //    l_Sql.Connect(p_ConfigItem);
        //    System.Data.SqlClient.SqlConnection _sqlConnection = new System.Data.SqlClient.SqlConnection(p_ConfigItem.StrConnection);
        //    if (_sqlConnection.State != ConnectionState.Open) _sqlConnection.Open();
        //    System.Data.SqlClient.SqlTransaction _sqlTransaction = _sqlConnection.BeginTransaction();
        //    try
        //    {
        //        _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL();
        //        string[] arrName = new string[] { "@Id", "@Mod_By" };
        //        object[] arrValue = new object[] { p_IdTakeIn, _ConfigItem.Login_UserName };
        //        _providerSQL.ExecuteNonQuery(_sqlConnection, _sqlTransaction, "USP_DEL_TAKE_IN", arrName, arrValue);
        //        _sqlTransaction.Commit();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _sqlTransaction.Rollback();
        //        AppDebug(ex);
        //        if (_sqlConnection.State != ConnectionState.Closed) _sqlConnection.Close();
        //        return false;
        //    }
        //}
    }
}
