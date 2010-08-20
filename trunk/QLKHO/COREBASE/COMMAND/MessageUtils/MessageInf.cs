using System.Collections;

namespace COREBASE.COMMAND.MessageUtils
{
     public class MessageInf
    {
         private string msgid = string.Empty;         
         private ArrayList arrpara = new ArrayList();
         private MessageType msgType = MessageType.NONE;
         
         public string MsgId
         {
             get { return msgid; }
             set { msgid = value; }
         }
         public ArrayList ArrParam
         {
             get { return arrpara; }
             set { arrpara =value; }
         }
         public void addParam(string strvalue)
         {
             arrpara.Add(strvalue);
         }
         public MessageType MsgType
         {
             get { return msgType; }
             set { msgType = value; }
         }
    }
}
