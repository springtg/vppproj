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
    public partial class frmRole : COREBASE.FORM.BASEFORM
    {
        public frmRole(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();
        }

        private void frmRole_Load(object sender, EventArgs e)
        {
            LoadRole();
            LoadGird();
        }
        public void LoadGird()
        {
            gvUserRole.DataSource = UserRoleDao.GetList(_ConfigItem);

        }
        public void LoadRole()
        {
            chkCmbEdit1.DataSource = UserRoleDao.GetRole(_ConfigItem);

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {

                DataTable Tmp = (DataTable)(gvUserRole.DataSource);
                for (int i = 0; i < Tmp.Rows.Count; i++)
                {
                    DataRow dr = Tmp.Rows[i];
                    if (isModifedRow(dr))
                    {
                        Update(dr);
                    }
                 
                }
                LoadGird();
            }
            catch (Exception ex)
            {
                //TODOL Ghi log cho nay
                throw ex;
            }
        }
        private bool Update(DataRow row)
        {
            try
            {
                object[] arrParaValue = new object[] {
                    row["Id"],
                     row["RoleList"],
                  
                };
                UserRoleDao.Update(_ConfigItem,arrParaValue);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
