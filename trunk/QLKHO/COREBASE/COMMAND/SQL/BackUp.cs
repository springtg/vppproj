using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using System.Windows.Forms;

namespace COREBASE.COMMAND.SQL
{
    public class BACKUP
    {
        private static Server srvSql =null;

        public static void CreateBackUp(string p_FileName, COMMAND.Config.ConfigItem p_confItem)
        {

            // If there was a SQL connection created
            if (srvSql != null)
            {
                // If the user has chosen a path where to save the backup file
                // Create a new backup operation
                Backup bkpDatabase = new Backup();
                // Set the backup type to a database backup
                bkpDatabase.Action = BackupActionType.Database;
                // Set the database that we want to perform a backup on
                bkpDatabase.Database = p_confItem.StrDBName;
                // Set the backup device to a file
                BackupDeviceItem bkpDevice = new BackupDeviceItem(p_FileName, DeviceType.File);
                // Add the backup device to the backup
                bkpDatabase.Devices.Add(bkpDevice);
                // Perform the backup
                bkpDatabase.SqlBackup(srvSql);
            }
            else
            {
                // There was no connection established; probably the Connect button was not clicked
                MessageBox.Show("A connection to a SQL server was not established.", "Not Connected to Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    }
}
