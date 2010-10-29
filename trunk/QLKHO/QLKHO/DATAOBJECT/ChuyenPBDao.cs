using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COREBASE.COMMAND.Config;
using System.Data;

namespace QLKHO.DATAOBJECT
{
    internal class ChuyenPBDao
    {
        public ConfigItem confItem;
        public ChuyenPBDao(ConfigItem _conf)
        {
            this.confItem = _conf;
        }
        public DataTable GetItembyPB(int idDepart)
        {
            DataTable dt = null;
            try
            {
                string[] arrParaName = new string[] {
                    "@IdPartment"
                };
                object[] arrvalue = new object[] { idDepart };
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                dt = _sql.GetDataByStoredProcedure("USP_SEL_GETITEMByPART", arrParaName, arrvalue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable GetnumChuyenFrom(int idDepart, int idItem)
        {
            DataTable dt = null;
            try
            {
                string sql = string.Format("select sum( Num) as Num from dbo.viNumDepartmentFrom where Department_Form_Pk={0} and Item_Pk={1}", idDepart, idItem);
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                dt = _sql.GetDataBySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable GetnumChuyenTo(int idDepart, int idItem)
        {
            DataTable dt = null;
            try
            {
                string sql = string.Format("select sum( Num) as Num from dbo.viNumDepartmentTo where Department_To_Pk={0} and Item_Pk={1}", idDepart, idItem);
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                dt = _sql.GetDataBySQL(sql);
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
                    	"@Item_Pk" ,
                        "@Department_Form_Pk",
                        "@Department_To_Pk",
                        "@Number_Item"
                };
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(confItem);
                ma = _sql.ExecuteInsert("USP_INS_TRANFERITEM", arrNames: arrParaName, arrValues: arrValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ma;
        }
    }
}
