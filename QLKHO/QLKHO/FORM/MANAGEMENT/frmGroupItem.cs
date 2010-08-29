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
    public partial class frmGroupItem : COREBASE.FORM.BASEFORM
    {
        CatalogDao DaoCat;
        GroupItemDao DaoGroup;
        public frmGroupItem(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();
            DaoCat = new CatalogDao(_ConfigItem);
            DaoGroup = new GroupItemDao(_ConfigItem);
        }

        private void frmGroupItem_Load(object sender, EventArgs e)
        {
            LoadGird();
        }
        public void LoadGird()
        {
            grdGroup.DataSource = DaoGroup.GetList();
            LoadCatalog();
        }
        private void LoadCatalog() {
            repositoryItemLookUpEdit1.DataSource = DaoCat.GetListCombo();
        }
        private void Insert(DataRow row)
        {
    //"@Name",
    //                "@Crt_Dt",
    //                "@Crt_By",
    //                "@Is_Del",
    //                "@Remark",
    //                "@Id_Cat"
            try
            {
                object[] arrParaValue = new object[] {
                    row["Name"],
                    DateTime.Now,
                    _ConfigItem.Login_UserName,
                    0,
                    row["Remark"],
                    row["Id_Cat"]
                };
                DaoGroup.Insert(arrValue: arrParaValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Delete(int _id)
        {
            try
            {
                DaoGroup.Delete(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private bool Update(DataRow row)
        {
            //"@Id",
            //        "@Name",
            //        "@Mod_Dt",
            //        "@Mod_By",
            //        "@Is_Del",
            //        "@Remark",
            //        "@Id_Cat"
            try
            {
                object[] arrParaValue = new object[] {
                    row["Id"],
                    row["Name"],
                    DateTime.Now,
                    _ConfigItem.Login_UserName,
                    0,

                    row["Remark"],
                    row["Id_Cat"]
                };
                DaoGroup.Update(arrValue: arrParaValue);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {

                DataTable Tmp = (DataTable)(grdGroup.DataSource);
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
                throw;
            }
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)System.Windows.Forms.Keys.Delete))
            {
                try
                {
                    int[] _IndexRowSelected = gridView1.GetSelectedRows();
                    int _CurIndexRow = _IndexRowSelected[0];
                    DataTable tmp = (DataTable)grdGroup.DataSource;
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

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] _IndexRowSelected = gridView1.GetSelectedRows();
                int _CurIndexRow = _IndexRowSelected[0];
                DataTable tmp = (DataTable)grdGroup.DataSource;
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
}