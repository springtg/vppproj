using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLKHO.DATAOBJECT;

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

        private void Restore()
        {
            if(btnEdit.Text.Trim()!="")
            SystemDao.Restore(_ConfigItem, btnEdit.Text);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Trim() != "")
                SystemDao.Backup(_ConfigItem, txtPath.Text);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            Restore();
        }
    }
}
