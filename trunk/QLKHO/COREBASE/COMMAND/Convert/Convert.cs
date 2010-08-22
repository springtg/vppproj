using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

namespace COREBASE.COMMAND.Convert
{
    public class Convert
    {
        /// <summary>
        /// Convert to string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        static public string CnvToString(object objvalue)
        {
            if (objvalue == null || objvalue.Equals(DBNull.Value))
            {
                return string.Empty;
            }
            else
                return objvalue.ToString();
        }

        /// <summary>
        /// Convert to bool
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        static public bool CnvToBool(object objvalue)
        {
            if (objvalue == null || objvalue.Equals(DBNull.Value))
            {
                return false;
            }
            else
            {
                return bool.Parse(CnvToString(objvalue));
            }
        }

        /// <summary>
        /// Convert to integer
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int CnvToInteger(object objvalue)
        {
            string strValue = CnvToString(objvalue);
            try
            {
                return int.Parse(strValue, System.Globalization.NumberStyles.Integer);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert to int16
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Int16 CnvToInt16(object objvalue)
        {
            string strValue = CnvToString(objvalue);
            try
            {
                return Int16.Parse(strValue, System.Globalization.NumberStyles.Integer);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert to int32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Int32 CnvToInt32(object objvalue)
        {
            string strValue = CnvToString(objvalue);
            try
            {
                return Int32.Parse(strValue, System.Globalization.NumberStyles.Integer);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert to int64
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Int64 CnvToInt64(object objvalue)
        {
            string strValue = CnvToString(objvalue);
            try
            {
                return Int64.Parse(strValue, System.Globalization.NumberStyles.Integer);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert to long
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static long CnvToLong(object objvalue)
        {
            string strValue = CnvToString(objvalue);
            try
            {
                return long.Parse(strValue, System.Globalization.NumberStyles.Any);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert to Decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static decimal CnvToDecimal(object objvalue)
        {
            string strValue = CnvToString(objvalue);
            try
            {
                return decimal.Parse(strValue, System.Globalization.NumberStyles.Any);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert to double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static double CnvToDouble(object objvalue)
        {
            string strValue = CnvToString(objvalue);
            try
            {
                return double.Parse(strValue, System.Globalization.NumberStyles.Any);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert to Single
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Single CnvToSingle(object objvalue)
        {
            string strValue = CnvToString(objvalue);
            try
            {
                return Single.Parse(strValue, System.Globalization.NumberStyles.Any);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert to byte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static byte CnvToByte(object objvalue)
        {
            string strValue = CnvToString(objvalue);
            try
            {
                return byte.Parse(strValue, System.Globalization.NumberStyles.Any);
            }
            catch
            {
                return 0;
            }
        }

        ///// <summary>
        ///// convert ymd, ym, y/m/d, y/m to date
        ///// </summary>
        ///// <param name="sValue"></param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public static DateTime CnvToDate(string strValue)
        //{
        //    string sY =string.Empty;
        //    string sM =string.Empty;
        //    string sD=string.Empty;
        //    if (string.IsNullOrEmpty(strValue))
        //    {
        //        return new DateTime();
        //    }
        //    else
        //    {
        //        int iYearCharCount=0;
        //        int iMonthCharCount=0;
        //        int iDayCharCount=0;
        //        int iMonthStartChar=0;
        //        int iDayStartChar=0;
        //        string sCharFormat = "Y";
        //        for( int i = 0; i< strValue.Length ;i++)
        //        {
        //            if (strValue.Chars(i).Equals("/"c) Then
        //                If sCharFormat.Equals("Y") Then
        //                    sCharFormat = "M"
        //                    iMonthStartChar = i + 1
        //                ElseIf sCharFormat.Equals("M") Then
        //                    sCharFormat = "D"
        //                    iDayStartChar = i + 1
        //                ElseIf sCharFormat.Equals("D") Then
        //                    sCharFormat = "E"
        //                    Exit For
        //                End If
        //                Continue For
        //            ElseIf Not Char.IsDigit(sValue.Chars(i)) Then
        //                ' error
        //                sCharFormat = "E"
        //                Exit For
        //            Else
        //                Select Case sCharFormat
        //                    Case "Y"
        //                        If iYearCharCount = 4 Then
        //                            sCharFormat = "M"
        //                            iMonthStartChar = i
        //                        End If
        //                    Case "M"
        //                        If iMonthCharCount = 2 Then
        //                            sCharFormat = "D"
        //                            iDayStartChar = i
        //                        End If
        //                End Select
        //            End If
        //            Select Case sCharFormat
        //                Case "Y"
        //                    iYearCharCount = iYearCharCount + 1
        //                Case "M"
        //                    iMonthCharCount = iMonthCharCount + 1
        //                Case "D"
        //                    iDayCharCount = iDayCharCount + 1
        //            End Select
        //        }
        //        If iYearCharCount = 0 OrElse iYearCharCount > 4 Then
        //            ' error
        //            sCharFormat = "E"
        //        End If
        //        If iMonthCharCount = 0 OrElse iMonthCharCount > 2 Then
        //            ' error
        //            sCharFormat = "E"
        //        End If
        //        If iDayCharCount > 2 Then
        //            ' error
        //            sCharFormat = "E"
        //        End If

        //        If sCharFormat.Equals("E") Then
        //            ' format error
        //            Return New Date
        //        End If

        //        ' get year
        //        sY = sValue.Substring(0, iYearCharCount)
        //        ' get month
        //        sM = sValue.Substring(iMonthStartChar, iMonthCharCount)
        //        ' get day
        //        sD = sValue.Substring(iDayStartChar, iDayCharCount)

        //        If Trim(sY) = "" OrElse Trim(sM) = "" Then
        //            ' error 
        //            Return New Date
        //        End If
        //        If Trim(sD) = "" Then
        //            sD = "1"
        //        End If
        //        Try
        //            Return New Date(CInt(sY), CInt(sM), CInt(sD))
        //        Catch
        //            Return New Date
        //        End Try
        //    End If
        //}

        ///// <summary>
        ///// Convert to string
        ///// </summary>
        ///// <param name="sValue"></param>
        ///// <param name="startIndex"></param>
        ///// <param name="length"></param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public 
        public static string SubString(string strValue, int startIndex, int length)
        {
            strValue = CnvToString(strValue);
            int iSrcLength = strValue.Length;
            if (startIndex > iSrcLength)
            {
                return "";
            }
            else
            {
                if (startIndex + length > iSrcLength)
                {
                    return strValue.Substring(startIndex);
                }
                else

                    return strValue.Substring(startIndex, length);
            }
        }

        /// <summary>
        /// Check object is null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsBlank(object objvalue)
        {
            return string.IsNullOrEmpty(CnvToString(objvalue));
        }

        /// <summary>
        /// chuyen doi chuoi ngay sang kieu datetime
        /// </summary>
        /// <param name="sValue">NGAY dang chuoi: 20100808</param>
        /// <param name="sFormat">yyyyMMdd</param>
        /// <returns></returns>
        public static DateTime CnvToDateTime(string sValue, string sFormat)
        {
            try
            {
                return System.DateTime.ParseExact(sValue,
                                                sFormat,
                                                System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Chuyen doi 1 so kieu double dang dang ngay thang
        /// </summary>
        /// <param name="dValue">10000092</param>
        /// <returns></returns>
        public static DateTime CnvToDateTime(double dValue)
        {
            try
            {
                return DateTime.FromOADate(dValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// chuyen doi kieu du lieu cua object
        /// </summary>
        /// <param name="value"></param>
        /// <param name="convertType"></param>
        /// <returns></returns>
        public static object CnvChangeType(object value, System.Type convertType)
        { 
            return System.Convert.ChangeType(value, convertType);
        }

        public static object CnvChangeType(object value, System.Type convertType, System.IFormatProvider provider)
        {
            return System.Convert.ChangeType(value, convertType, provider);
        }

        public static object CnvChangeType(object value, System.TypeCode typeCode)
        {
            return System.Convert.ChangeType(value, typeCode);
        }

        public static object CnvChangeType(object value, System.TypeCode typeCode, System.IFormatProvider provider)
        {
            return System.Convert.ChangeType(value, typeCode,provider);
        }

        public static byte[] CnvFromBase64String(string s)
        {
            return System.Convert.FromBase64String(s);
        }

        public static string CnvToBase64String(byte[] inbyteArr, int offset, int length)
        {
            return System.Convert.ToBase64String(inbyteArr, offset, length);
        }

        public static byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] RawSerialize(object anything)
        {
            int rawsize = Marshal.SizeOf(anything);
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.StructureToPtr(anything, buffer, false);
            byte[] rawdatas = new byte[rawsize];
            Marshal.Copy(buffer, rawdatas, 0, rawsize);
            Marshal.FreeHGlobal(buffer);
            return rawdatas;
        }

        public static object RawDeserialize(byte[] rawdatas, Type anytype)
        {
            int rawsize = Marshal.SizeOf(anytype);
            if (rawsize > rawdatas.Length)
                return null;
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.Copy(rawdatas, 0, buffer, rawsize);
            object retobj = Marshal.PtrToStructure(buffer, anytype);
            Marshal.FreeHGlobal(buffer);
            return retobj;
        }

        public static string replaceMessageText(string msgText, string[] msgParam)
        {
            string result = msgText;

            for (int i = 0; i <= msgParam.Length; i++)
            {
                result = result.Replace("{" + i + "}", msgParam[i]);
            }

            return result;
        }

        public static string replaceMessageText(string msgText, List<string> lstStrParam)
        {
            string result = msgText;

            for (int i = 0; i <= lstStrParam.Count; i++)
            {
                result = result.Replace("{" + i + "}", lstStrParam[i]);
            }

            return result;
        }

        public static string getDateTimetoFormatyyyyMMdd()
        {
            return string.Format(DateTime.Now.ToString(), "yyyyMMdd");
        }
        /*
         public class CCurrencyToWords
         {
             public CCurrencyToWords()
             {

             }
             public String changeNumericToWords(double numb)
             {
                 String num = numb.ToString();
                 return changeToWords(num, false);
             }
             public String changeCurrencyToWords(String numb)
             {
                 return changeToWords(numb, true);
             }
             public String changeNumericToWords(String numb)
             {
                 return changeToWords(numb, false);
             }
             public String changeCurrencyToWords(double numb)
             {
                 return changeToWords(numb.ToString(), true);
             }
             private String changeToWords(String numb, bool isCurrency)
             {
                 String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
                 String endStr = (isCurrency) ? ("đồng chẵn") : ("");
                 try
                 {
                     int decimalPlace = numb.IndexOf(".");
                     if (decimalPlace > 0)
                     {
                         wholeNo = numb.Substring(0, decimalPlace);
                         points = numb.Substring(decimalPlace + 1);
                         if (Convert.CnvToInt32(points) > 0)
                         {
                             andStr = (isCurrency) ? ("đồng lẻ") : ("phẩy ");// just to separate whole numbers from points/cents
                             endStr = (isCurrency) ? ("xu") : ("");
                             pointStr = translateCents(points);
                         }
                     }
                     val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
                 }
                 catch { ;}
                 return val;
             }
             private String translateWholeNumber(String number)
             {
                 string word = "";
                 try
                 {
                     bool beginsZero = false;//tests for 0XX
                     bool isDone = false;//test if already translated
                     double dblAmt = (Convert.ToDouble(number));
                     //if ((dblAmt > 0) && number.StartsWith("0"))
                     if (dblAmt > 0)
                     {//test for zero or digit zero in a nuemric
                         beginsZero = number.StartsWith("0");

                         int numDigits = number.Length;
                         int pos = 0;//store digit grouping
                         String place = "";//digit grouping name:hundres,thousand,etc...
                         switch (numDigits)
                         {
                             case 1://ones' range
                                 word = ones(number);
                                 isDone = true;
                                 break;
                             case 2://tens' range
                                 word = tens(number);
                                 isDone = true;
                                 break;
                             case 3://hundreds' range
                                 pos = (numDigits % 3) + 1;
                                 place = " trăm ";
                                 break;
                             case 4://thousands' range
                             case 5:
                             case 6:
                                 pos = (numDigits % 4) + 1;
                                 place = " nghìn ";
                                 break;
                             case 7://millions' range
                             case 8:
                             case 9:
                                 pos = (numDigits % 7) + 1;
                                 place = " triệu ";
                                 break;
                             case 10://Billions's range
                                 pos = (numDigits % 10) + 1;
                                 place = " tỉ ";
                                 break;
                             //add extra case options for anything above Billion...
                             default:
                                 isDone = true;
                                 break;
                         }
                         if (!isDone)
                         {//if transalation is not done, continue...(Recursion comes in now!!)
                             word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));
                             //check for trailing zeros
                             if (beginsZero) word = " lẻ " + word.Trim();
                         }
                         //ignore digit grouping names
                         if (word.Trim().Equals(place.Trim())) word = "";
                     }
                 }
                 catch { ;}
                 return word.Trim();
             }
             private String tens(String digit)
             {
                 int digt = Convert.ToInt32(digit);
                 String name = null;
                 switch (digt)
                 {
                     case 10:
                         name = "mười";
                         break;
                     case 11:
                         name = "mười một";
                         break;
                     case 12:
                         name = "mười hai";
                         break;
                     case 13:
                         name = "mười ba";
                         break;
                     case 14:
                         name = "mười bốn";
                         break;
                     case 15:
                         name = "mười lăm";
                         break;
                     case 16:
                         name = "mười sáu";
                         break;
                     case 17:
                         name = "mười bảy";
                         break;
                     case 18:
                         name = "mười tám";
                         break;
                     case 19:
                         name = "mười chín";
                         break;
                     case 20:
                         name = "hai mươi";
                         break;
                     case 30:
                         name = "ba mươi";
                         break;
                     case 40:
                         name = "bốn mươi";
                         break;
                     case 50:
                         name = "năm mươi";
                         break;
                     case 60:
                         name = "sáu mươi";
                         break;
                     case 70:
                         name = "bảy mươi";
                         break;
                     case 80:
                         name = "tám mươi";
                         break;
                     case 90:
                         name = "chín mươi";
                         break;
                     default:
                         if (digt > 0)
                         {
                             name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                         }
                         break;
                 }
                 return name;
             }
             private String ones(String digit)
             {
                 int digt = Convert.ToInt32(digit);
                 String name = "";
                 switch (digt)
                 {
                     case 1:
                         name = "một";
                         break;
                     case 2:
                         name = "hai";
                         break;
                     case 3:
                         name = "ba";
                         break;
                     case 4:
                         name = "bốn";
                         break;
                     case 5:
                         name = "năm";
                         break;
                     case 6:
                         name = "sáu";
                         break;
                     case 7:
                         name = "bảy";
                         break;
                     case 8:
                         name = "tám";
                         break;
                     case 9:
                         name = "chín";
                         break;
                 }
                 return name;
             }
             private String translateCents(String cents)
             {
                 String cts = "", digit = "", engOne = "";
                 for (int i = 0; i < cents.Length; i++)
                 {
                     digit = cents[i].ToString();
                     if (digit.Equals("0"))
                     {
                         engOne = "không";
                     }
                     else
                     {
                         engOne = ones(digit);
                     }
                     cts += " " + engOne;
                 }
                 return cts;
             }
         }*/
    }

}
