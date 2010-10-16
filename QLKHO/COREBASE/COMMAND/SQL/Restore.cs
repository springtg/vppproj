using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;


namespace COREBASE.COMMAND.SQL
{
    public class RESTORE
    {
        private static Form objFormCall = null;

        /// <summary>
        /// phuc thuc phuc hoi du lieu , voi duong dan mac dinh se duoc tai cho thu muc cua chuong trinh
        /// </summary>
        /// <param name="p_FileName"></param>
        /// <param name="p_confItem"></param>
        public static void CreateRestore(string p_FileName, COMMAND.Config.ConfigItem p_confItem, object p_objCall)
        {
            try
            {
                objFormCall = (Form)p_objCall;
                objFormCall.Enabled = false;
                objFormCall.Controls["groupControl1"].Controls["lblStatus"].Text = COMMAND.MessageUtils.Message.GetMessageById("BKRS_E_015");
                string l_PathApp = Application.StartupPath + "\\App_Data";
                if (!System.IO.Directory.Exists(l_PathApp))
                {
                    System.IO.Directory.CreateDirectory(l_PathApp);
                }

                //khai bao thiet bi du lieu phuc hoi
                BackupDeviceItem deviceItem = new BackupDeviceItem(p_FileName, DeviceType.File);
                //khai bao doi tuong server 
                ServerConnection connection = new ServerConnection(p_confItem.StrServerName, p_confItem.StrUserName, p_confItem.StrPassword);
                Server sqlServer = new Server(connection);
                //khai bao doi tuong database
                Database db = sqlServer.Databases[p_confItem.StrDBName];
                if (db != null)
                    sqlServer.KillAllProcesses(p_confItem.StrDBName);
                //khai bao doi tuong phuc hoi du lieu
                Restore sqlRestore = new Restore();
                sqlRestore.Devices.Add(deviceItem);
                sqlRestore.Database = p_confItem.StrDBName;
                sqlRestore.Action = RestoreActionType.Database;
                String dataFileLocation = l_PathApp + "\\" + p_confItem.StrDBName + ".mdf";
                String logFileLocation = l_PathApp + "\\" + p_confItem.StrDBName + "_Log.ldf";
                RelocateFile rf = new RelocateFile(p_confItem.StrDBName, dataFileLocation);
                sqlRestore.RelocateFiles.Add(new RelocateFile(p_confItem.StrDBName, dataFileLocation));
                sqlRestore.RelocateFiles.Add(new RelocateFile(p_confItem.StrDBName + "_log", logFileLocation));
                sqlRestore.ReplaceDatabase = true;
                sqlRestore.Complete += new ServerMessageEventHandler(sqlRestore_Complete);
                sqlRestore.PercentCompleteNotification = 10;
                sqlRestore.PercentComplete += new PercentCompleteEventHandler(sqlRestore_PercentComplete);
                objFormCall.Controls["groupControl1"].Controls["lblStatus"].Text = COMMAND.MessageUtils.Message.GetMessageById("BKRS_E_014");
                sqlRestore.SqlRestore(sqlServer);
                db = sqlServer.Databases[p_confItem.StrDBName];
                db.SetOnline();
                sqlServer.Refresh();

            }
            catch (Exception ex)
            {
                if (objFormCall != null)
                {
                    objFormCall.Controls["groupControl1"].Controls["lblStatus"].Text = COMMAND.MessageUtils.Message.GetMessageById("BKRS_E_010");
                    objFormCall.Enabled = true;
                    LogUtils.Logger.AppLog.Debug(objFormCall.Name, p_confItem.Login_UserName,
                        objFormCall.Controls["groupControl1"].Controls["lblStatus"].Text, ex);
                }
            }
        }


        static void sqlRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            if (objFormCall != null)
            {
                objFormCall.Controls["groupControl1"].Controls["lblStatus"].Text = string.Format(COMMAND.MessageUtils.Message.GetMessageById("BKRS_E_011"), e.Percent);
            }
            //WriteToLogAndConsole(e.Percent.ToString() + "% Complete");
        }

        static void sqlRestore_Complete(object sender, ServerMessageEventArgs e)
        {
            if (objFormCall != null)
            {
                objFormCall.Controls["groupControl1"].Controls["lblStatus"].Text = COMMAND.MessageUtils.Message.GetMessageById("BKRS_E_013");//string.Format("Sao luu du lieu: {0}%", e.ToString());
                objFormCall.Enabled = true;
            }
            // WriteToLogAndConsole(e.ToString() + "% Complete");
        }
    }
}