using COREBASE.COMMAND.LogUtils;
using System;
using System.Windows.Forms;
using COREBASE.COMMAND.MessageUtils;
using System.Collections;

namespace COREBASE.FORM
{
    public partial class BASEMDIPARENT : DevExpress.XtraBars.Ribbon.RibbonForm
    {
       protected COMMAND.Config.ConfigItem _ConfigItem;

        public BASEMDIPARENT()
        {
            InitializeComponent();
        }

        #region "Common log function"
        /// <summary>
        /// Format to string {msgID} {msg}
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="messageParam"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string Format(string msgId, params string[] messageParam)
        {
            return string.Format("{0} {1}", msgId);//, msgUtils.message(msgId, messageParam));
        }

        /// <summary>
        /// Output app debug info to log file
        /// </summary>
        /// <param name="msg"></param>
        /// <remarks></remarks>
        protected void AppDebug(object msg)
        {
            Logger.AppLog.Debug(this.Name, _ConfigItem.Login_ID, msg);
        }

        /// <summary>
        /// Output app debug info to log file
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="messageParam"></param>
        /// <remarks></remarks>
        protected void AppDebug(string msgId, params string[] messageParam)
        {
            if (messageParam.Length != 0)
            {
                Logger.AppLog.Debug(this.Name, _ConfigItem.Login_ID, string.Format(msgId, messageParam));
            }
            else
            {
                Logger.AppLog.Debug(this.Name, _ConfigItem.Login_ID, msgId);
            }
        }

        /// <summary>
        /// Output app error info to log file
        /// </summary>
        /// <param name="msg"></param>
        /// <remarks></remarks>
        protected void AppError(object msg)
        {
            Logger.AppLog.Error(this.Name, _ConfigItem.Login_ID, msg);
        }

        /// <summary>
        /// Output app error info to log file
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="messageParam"></param>
        /// <remarks></remarks>
        protected void AppError(string msgId, params string[] messageParam)
        {
            if (messageParam.Length != 0)
            {
                Logger.AppLog.Error(this.Name, _ConfigItem.Login_ID, string.Format(msgId, messageParam));
            }
            else
            {
                Logger.AppLog.Error(this.Name, _ConfigItem.Login_ID, msgId);
            }
        }

        /// <summary>
        /// Output app fatal info to log file
        /// </summary>
        /// <param name="msg"></param>
        /// <remarks></remarks>
        protected void AppFatal(object msg)
        {
            Logger.AppLog.Fatal(this.Name, _ConfigItem.Login_ID, msg);
        }

        /// <summary>
        ///  Output app fatal info to log file
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="messageParam"></param>
        /// <remarks></remarks>
        protected void AppFatal(string msgId, params string[] messageParam)
        {
            if (messageParam.Length != 0)
            {
                Logger.AppLog.Fatal(this.Name, _ConfigItem.Login_ID, string.Format(msgId, messageParam));
            }
            else
            {
                Logger.AppLog.Fatal(this.Name, _ConfigItem.Login_ID, msgId);
            }
        }

        /// <summary>
        /// Output app info to log file
        /// </summary>
        /// <param name="msg"></param>
        /// <remarks></remarks>
        protected void AppInfo(object msg)
        {
            Logger.AppLog.Info(this.Name, _ConfigItem.Login_ID, msg);
        }

        /// <summary>
        ///  Output app info to log file
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="messageParam"></param>
        /// <remarks></remarks>
        protected void AppInfo(string msgId, params string[] messageParam)
        {
            if (messageParam.Length != 0)
            {
                Logger.AppLog.Info(this.Name, _ConfigItem.Login_ID, string.Format(msgId, messageParam));
            }
            else
            {
                Logger.AppLog.Info(this.Name, _ConfigItem.Login_ID, msgId);
            }
        }

        /// <summary>
        /// Output app warning info to log file
        /// </summary>
        /// <param name="msg"></param>
        /// <remarks></remarks>
        protected void AppWarn(object msg)
        {
            Logger.AppLog.Warn(this.Name, _ConfigItem.Login_ID, msg);
        }

        /// <summary>
        ///  Output app warning info to log file
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="messageParam"></param>
        /// <remarks></remarks>
        protected void AppWarn(string msgId, params string[] messageParam)
        {
            if (messageParam.Length != 0)
            {
                Logger.AppLog.Warn(this.Name, _ConfigItem.Login_ID, string.Format(msgId, messageParam));
            }
            else
            {
                Logger.AppLog.Warn(this.Name, _ConfigItem.Login_ID, msgId);
            }
        }

        #endregion

        #region "Phuong thuc MessageBox"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        protected DialogResult ShowMessageBox(string messageId, string messageText, MessageType messageType)
        {
            //1. Assign defaul return value
            DialogResult result = DialogResult.None;
            try
            {
                //2. Display COMMAND.MessageUtils.Message if found
                if (messageText != "")
                {
                    switch (messageType)
                    {
                        case MessageType.WARNING:
                            MessageBox.Show(messageText, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        case MessageType.INFORM:
                            MessageBox.Show(messageText, "INFORM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case MessageType.ERROR:
                            MessageBox.Show(messageText, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case MessageType.CONFIRM:
                            result = MessageBox.Show(messageText, "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            break;
                        default:
                            MessageBox.Show(messageText, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    //2.2. If not found then display inform COMMAND.MessageUtils.Message
                    MessageBox.Show(String.Format("COMMAND.MessageUtils.Message {0} is not found in resource file.", messageId), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //3.Return result
                return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //Write log
                //if (_logger.IsErrorEnabled)
                //    _logger.Error(ex);
                //4.Error handling
                //Write exception here
                return DialogResult.None;
            }
        }
        /// <summary>
        /// Show COMMAND.MessageUtils.Message with messageid from COMMAND.MessageUtils.Message resource
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="messageType"></param>
        /// <returns></returns>
        protected DialogResult ShowMessageBox(string messageId, MessageType messageType)
        {
            return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), messageType);
        }

        protected DialogResult ShowMessageBox(string messageId)
        {
            if (messageId.Contains("U"))
            {
                return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), MessageType.UNDEFINED);
            }
            if (messageId.Contains("W"))
            {
                return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), MessageType.WARNING);
            }
            if (messageId.Contains("I"))
            {
                return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), MessageType.INFORM);
            }
            if (messageId.Contains("E"))
            {
                return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), MessageType.ERROR);
            }
            if (messageId.Contains("C"))
            {
                return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), MessageType.CONFIRM);
            }
            return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), MessageType.NONE);
        }

        protected DialogResult ShowMessageBox(string messageId, MessageType messageType, params object[] objParam)
        {
            string strMsgTmp = COMMAND.MessageUtils.Message.GetMessageById(messageId);
            return ShowMessageBox(messageId, string.Format(strMsgTmp, objParam), messageType);
        }

        protected DialogResult ShowMessageBox(string messageId, MessageType messageType, object objParam)
        {
            string strMsgTmp = COMMAND.MessageUtils.Message.GetMessageById(messageId);
            return ShowMessageBox(messageId, string.Format(strMsgTmp, objParam), messageType);
        }

        protected DialogResult ShowMultiMessage(ArrayList arrMsgInfo)
        {
            try
            {
                string msgTemp = string.Empty;
                for (int i = 0; i < arrMsgInfo.Count; i++)
                {
                    MessageInf msfInfoTemp = (MessageInf)arrMsgInfo[i];
                    msgTemp += CreatMsg(msfInfoTemp);
                    if (i + 1 != arrMsgInfo.Count)
                    {
                        msgTemp += "\n";
                    }
                }
                if (msgTemp.Equals(string.Empty))
                {
                    return DialogResult.None;
                }
                else
                {
                    return MessageBox.Show(msgTemp, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return DialogResult.None;
            }
        }

        private string CreatMsg(MessageInf msgInfo)
        {
            string Msgrs = string.Empty;
            Msgrs = COMMAND.MessageUtils.Message.GetMessageById(msgInfo.MsgId);
            Msgrs = string.Format(Msgrs, msgInfo.ArrParam);
            return Msgrs;
        }

        #endregion
    }
}