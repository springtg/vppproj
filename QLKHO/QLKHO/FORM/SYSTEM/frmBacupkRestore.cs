﻿using System;
using System.Windows.Forms;

namespace QLKHO.FORM.SYSTEM
{
    public partial class frmBacupkRestore : COREBASE.FORM.BASEFORM
    {
        public frmBacupkRestore(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();
        }

        private void btnEdit_EditValueChanged(object sender, EventArgs e)
        {



        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "bak files (*.bak)|*.bak|(*.BAK)|*.BAK";
            dialog.InitialDirectory = "C:"; dialog.Title = "Chọn 1 file đã sao lưu!";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                btnEdit.Text = dialog.FileName;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit l_Tmp=(DevExpress.XtraEditors.TextEdit)sender;
            if (l_Tmp.Text.Trim() != "")
                COREBASE.COMMAND.SQL.BACKUP.CreateBackUp(l_Tmp.Text, _ConfigItem);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit l_Tmp = (DevExpress.XtraEditors.TextEdit)sender;
            if (l_Tmp.Text.Trim() != "")
                COREBASE.COMMAND.SQL.RESTORE.CreateRestore(l_Tmp.Text, _ConfigItem);
        }
    }
}
