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
    public partial class frmPhongBan : COREBASE.FORM.BASEFORM
    {
        DepartmentsDao Dao;
        public frmPhongBan(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            Dao = new DepartmentsDao(_ConfigItem);
            InitializeComponent();
        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            LoadGird();
        }
        public void LoadGird()
        {
            grdDepartment.DataSource = Dao.GetList();
        }
        private void Insert(DataRow row)
        {
            //            "@Name",
            //            "@Crt_Dt",
            //            "@Crt_By",
            //            "@Is_Del",
            //            "@Remark",
            //            "@Phone
            try
            {
                object[] arrParaValue = new object[] {
                    row["Name"],
                    DateTime.Now,
                    _ConfigItem.Login_UserName,
                    0,
                    row["Remark"],
                    row["Phone"]
                };
                Dao.Insert(arrValue: arrParaValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DataTable tbl = (DataTable)grdDepartment.DataSource;
            DataRow r = tbl.NewRow();
            tbl.Rows.Add(r);
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {

                DataTable Tmp = (DataTable)(grdDepartment.DataSource);
                for (int i = 0; i < Tmp.Rows.Count; i++)
                {
                    DataRow dr = Tmp.Rows[i];
                    if (isModifedRow(dr))
                    {
                        Update(dr);
                    }
                    if (isNewRow(dr))
                    {
                        Insert(dr);
                    }
                    if (isDeletedRow(dr))
                    {
                        Delete((int)GetOriginalItemData(dr, "Id"));
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
        private void Delete(int _id)
        {
            try
            {
                Dao.Delete(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private bool Update(DataRow row)
        {
            try
            {
                object[] arrParaValue = new object[] {
                    row["Id"],
                    row["Name"],
                    DateTime.Now,
                    _ConfigItem.Login_UserName,
                    0,

                    row["Remark"],
                    row["Phone"]
                };
                Dao.Update(arrValue: arrParaValue);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                int[] _IndexRowSelected = gridView1.GetSelectedRows();

                int _CurIndexRow = _IndexRowSelected[0];
                DataTable tmp = (DataTable)grdDepartment.DataSource;
                Delete(CnvToInt32(tmp.Rows[_CurIndexRow]["Id"]));
                LoadGird();
            }
            catch (Exception ex)
            {
                //TODO: Ghi log tai day nhe
                throw ex;
            }
        }
       

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(System.Windows.Forms.Keys.Delete))
            {
                try
                {
                    int[] _IndexRowSelected = gridView1.GetSelectedRows();
                    int _CurIndexRow = _IndexRowSelected[0];
                    DataTable tmp = (DataTable)grdDepartment.DataSource;
                    Delete(CnvToInt32(tmp.Rows[_CurIndexRow]["Id"]));
                    LoadGird();
                }
                catch (Exception ex)
                {
                    //TODO: Ghi log tai day nhe
                    throw ex;
                }
            }
        }

        private void bntUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

    }
}