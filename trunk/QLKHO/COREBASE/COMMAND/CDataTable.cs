using System.Collections.Generic;
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

        /// <summary>
        /// Kiem tra 1 row la moi duoc them vo
        /// </summary>
        /// <param name="dtRow"></param>
        /// <returns></returns>
        public static bool isNewRow(DataRow dtRow)
        {
            if (dtRow.RowState == DataRowState.Added)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Kiem tra 1 dong la da bi xoa
        /// </summary>
        /// <param name="dtRow"></param>
        /// <returns></returns>
        public static bool isDeletedRow(DataRow dtRow)
        {
            if (dtRow.RowState == DataRowState.Deleted)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Kiem tra 1 dong la da sua doi du lieu
        /// </summary>
        /// <param name="dtRow"></param>
        /// <returns></returns>
        public static bool isModifedRow(DataRow dtRow)
        {
            if (dtRow.RowState == DataRowState.Modified)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Lay gia tri truoc do cua row
        /// </summary>
        /// <param name="dtrRow"></param>
        /// <param name="sFieldID"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static object GetOriginalItemData(DataRow dtrRow, string sFieldID)
        {
            if (isNewRow(dtrRow))
            {
                return dtrRow[sFieldID];
            }
            else
            {
                return dtrRow[sFieldID, DataRowVersion.Original];
            }
        }

    }
}
