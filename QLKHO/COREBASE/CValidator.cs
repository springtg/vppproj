using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

namespace VXS.ERP.UTL0001
{
    public class CValidator
    {
        private const string strIPValidationExpression = @"^((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])$";
        
        public CValidator()
        { 
        }

        public static bool IsInValidEmail(string strEmailAddress)
        {
            string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            System.Text.RegularExpressions.Match match = Regex.Match(strEmailAddress, pattern, RegexOptions.IgnoreCase);
            if (match.Success)
                return true;//Email valid
            else
                return false;//Email not valid

        }

        public static bool IsValidEmail(string strEmail)
        {
             Regex re = new Regex(@"^(^\w.*@\w.*$)?$");
             Match theMatch = re.Match(strEmail);
             return theMatch.Success;
        }

        public static bool isNewRow(DataRow dr )
        {
            return (dr.RowState == DataRowState.Added) ? true : false;
        }

        public static bool IsModifiedRow(DataRow dr)
        {
            return (dr.RowState == DataRowState.Modified) ? true : false;
        }

        public static bool IsDeletedRow(DataRow dr)
        {
            return (dr.RowState == DataRowState.Deleted) ? true : false;
        }
        public static bool IsUnchangedRow(DataRow dr)
        {
            return (dr.RowState == DataRowState.Unchanged) ? true : false;
        }

        public static bool IsIPAddressValid(string strIP)
        {
            Regex re = new Regex(strIPValidationExpression);
            Match theMatch = re.Match(strIP);
            return theMatch.Success;
            //ErrorMessage = "The IP address must be in the form of 111.111.111.111";
        }
    }
}
