using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLKHO.DATAOBJECT;

namespace QLKHO.FORM.MANAGEMENT
{
    public partial class frmUser : COREBASE.FORM.BASEFORM
    {
        UserDao DaoUser;
        public frmUser(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();
            DaoUser = new UserDao(_ConfigItem);
            this.Load += new EventHandler(frmUser_Load);
        }

        void frmUser_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid() {
            grvUser.DataSource = DaoUser.GetList();
        }

    }
}