using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using System.Windows.Forms;


namespace COREBASE.COMMAND.SQL
{
    public class RESTORE
    {
        private static Server srvSql = null;

        public static void CreateRestore(string p_FileName, COMMAND.Config.ConfigItem p_confItem)
        {

            // If there was a SQL connection created
            srvSql = new Server(p_confItem.StrServerName);
            if (srvSql != null)
            {
                // Create a new database restore operation
                Restore rstDatabase = new Restore();
                // Set the restore type to a database restore
                rstDatabase.Action = RestoreActionType.Database;
                // Set the database that we want to perform the restore on
                rstDatabase.Database = p_confItem.StrDBName;
                // Set the backup device from which we want to restore, to a file
                BackupDeviceItem bkpDevice = new BackupDeviceItem(p_FileName, DeviceType.File);
                // Add the backup device to the restore type
                rstDatabase.Devices.Add(bkpDevice);
                // If the database already exists, replace it
                rstDatabase.ReplaceDatabase = true;
                // Perform the restore
                rstDatabase.SqlRestore(srvSql);
            }
            else
            {
                // There was no connection established; probably the Connect button was not clicked
                MessageBox.Show("A connection to a SQL server was not established.", "Not Connected to Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

    }
}
