using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;

namespace COREBASE.COMMAND.SQL
{
    public class BACKUP
    {
       private static Form objFormCall = null;
        /// <summary>
        /// Phuong thuc thuc hien backup du lieu
        /// </summary>
        /// <param name="p_FileName"></param>
        /// <param name="p_confItem"></param>
        /// <param name="p_objCall"></param>
        public static void CreateBackUp(string p_FileName, COMMAND.Config.ConfigItem p_confItem, object p_objCall)
        {
            try
            {
                objFormCall = (Form)p_objCall;
                objFormCall.Enabled = false;
                objFormCall.Controls["groupControl1"].Controls["lblStatus"].Text = COMMAND.MessageUtils.Message.GetMessageById("BKRS_E_005");// "Dang khoi dong qua trinh sao luu du lieu";
                //WriteToLogAndConsole("Backup the {0} database!", databaseName);
                //khai bao thong tin device backup
                BackupDeviceItem deviceItem = new BackupDeviceItem(p_FileName, DeviceType.File);
                //thiet lap thong tin sql backup
                Backup sqlBackup = new Backup();
                sqlBackup.Action = BackupActionType.Database;
                sqlBackup.Database = p_confItem.StrDBName;
                sqlBackup.BackupSetDescription = "ArchiveDataBase:" + DateTime.Now.ToShortDateString();
                sqlBackup.BackupSetName = "Archive";
                sqlBackup.Initialize = true;
                sqlBackup.Checksum = true;
                sqlBackup.ContinueAfterError = true;
                sqlBackup.Devices.Add(deviceItem);
                sqlBackup.Incremental = false;
                sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
                sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;
                sqlBackup.FormatMedia = false;
                sqlBackup.PercentComplete += new PercentCompleteEventHandler(sqlBackup_PercentComplete);
                sqlBackup.Complete += new ServerMessageEventHandler(sqlBackup_Complete);

                //thiet lap thong tin server va connection den server
                ServerConnection connection = new ServerConnection(p_confItem.StrServerName, p_confItem.StrUserID, p_confItem.StrPassword);
                Server sqlServer = new Server(connection);
                //Database db = sqlServer.Databases[p_confItem.StrDBName];
                objFormCall.Controls["groupControl1"].Controls["lblStatus"].Text = COMMAND.MessageUtils.Message.GetMessageById("BKRS_E_004");
                sqlBackup.SqlBackup(sqlServer);
            }
            catch (Exception ex)
            {
                if (objFormCall != null)
                {
                    objFormCall.Controls["groupControl1"].Controls["lblStatus"].Text = COMMAND.MessageUtils.Message.GetMessageById("BKRS_E_000");
                    objFormCall.Enabled = true;
                    LogUtils.Logger.AppLog.Debug(objFormCall.Name, p_confItem.Login_UserName,
                        objFormCall.Controls["groupControl1"].Controls["lblStatus"].Text, ex);
                }
            }
        }
        /// <summary>
        /// event khi thuc hien backup thanh cong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void sqlBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if (objFormCall != null)
            {
                objFormCall.Controls["groupControl1"].Controls["lblStatus"].Text = COMMAND.MessageUtils.Message.GetMessageById("BKRS_E_003");//string.Format("Sao luu du lieu: {0}%", e.ToString());
                objFormCall.Enabled = true;
            }
            // WriteToLogAndConsole(e.ToString() + "% Complete");
        }
        /// <summary>
        /// event trong qua trinh thuc hien back up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void sqlBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            if (objFormCall != null)
            {
                objFormCall.Controls["groupControl1"].Controls["lblStatus"].Text = string.Format(COMMAND.MessageUtils.Message.GetMessageById("BKRS_E_001"), e.Percent);
            }
            //WriteToLogAndConsole(e.Percent.ToString() + "% Complete");
        }

    }
}
