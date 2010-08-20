using System;
using System.Data;

namespace COREBASE.COMMAND.MessageUtils
{
    public class Message
    {
        public const string MessageTableMappingName = "MSG";
        public const string MessageIdMappingName = "MsgID";
        public const string MessageValueMappingName = "MsgValue";


        /// <summary>
        /// Lay gia tri cua Msg thong qua ID cua Msg
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public static string GetMessageById(string messageId)
        {
            try
            {
                //1.Loading message file
                DataSet ds = new DataSet();
                ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\Messages.xml");
                //2.Get message by ID
                DataRow[] msgs = ds.Tables[Message.MessageTableMappingName].Select(MessageIdMappingName + "='" + messageId + "'");
                //3.Read message content if found
                if (msgs.Length > 0)
                {
                    //3.2. Create message structure and return
                    if (msgs[0][MessageValueMappingName] != System.DBNull.Value)
                    {
                        return msgs[0][MessageValueMappingName].ToString();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    //3.1. If message is not defined yet then return null
                    return string.Empty;
                }
            }
            catch
            {
                //4.Exception handling
                throw;
            }
        }
    }
}
