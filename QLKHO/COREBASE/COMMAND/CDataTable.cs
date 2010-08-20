using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace COREBASE.COMMAND
{
    public class CDataTable
    {
        public static string getContent(string ID, DataTable dtSource)
        {
            //kiem tra noi dung Resource Message co null khong?
            if (dtSource == null)
            {
                return string.Empty;
            }
            return dtSource.Select("MsgID = '" + ID + "'")[0]["MsgContent"].ToString(); 
        }

        public static string getContent(string ID, DataTable dtSource, List<string> lstStrParam)
        {
            //kiem tra noi dung Resource Message co null khong?
            if (dtSource == null)
            {
                return string.Empty;
            }
           DataRow[] dr= dtSource.Select("MsgID = '" + ID + "'");//[0]["MsgContent"].ToString();

           if (dr == null) return string.Empty;
           if (dr.Length == 0) return string.Empty;
           return Convert.Convert.replaceMessageText(Convert.Convert.CnvToString(dr[0]["MsgContent"]), lstStrParam);      
            
        }
    }
}
