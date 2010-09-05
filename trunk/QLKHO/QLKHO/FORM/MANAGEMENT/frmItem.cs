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
    public partial class frmItem : COREBASE.FORM.BASEFORM
    {
        UnitDao DaoUnit;
        GroupItemDao DaoGroup;
        ItemDao DaoItem;
        SupplierDao DaoSupp;
        public frmItem(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();
            DaoUnit = new UnitDao(_ConfigItem);
            DaoGroup = new GroupItemDao(_ConfigItem);
            DaoSupp = new SupplierDao(_ConfigItem);
            DaoItem = new ItemDao(_ConfigItem);
            this.Load += new EventHandler(frmItem_Load);
        }

        void frmItem_Load(object sender, EventArgs e)
        {
            LoadGird();
                }

        public void LoadGird()
        {
            grdItem.DataSource = DaoItem.GetList();
            LoadUnit();
            LoadGroup();
            LoadSupplier();
        }
        private void LoadUnit()
        {
            lookUpUnit.DataSource = DaoUnit.GetList();
        }
        private void LoadGroup()
        {
            lookUpGroup.DataSource = DaoGroup.GetList();
        }
        private void LoadSupplier()
        {
            lookUpSupplier.DataSource = DaoSupp.GetUserList();
        }
        private void Insert(DataRow row)
        {
            //"@Name",
            //        " @Id_Group_Pk",
            //         "@Crt_Dt",
            //         "@Crt_By",
            //         "@Is_Del",
            //         "@Remark",
            //         "@Id_Unit_Pk",
            //         "@Id_Supplier_Pk"
            try
            {
                object[] arrParaValue = new object[] {
                    row["Name"],
                    row["Id_Group_Pk"],
                    DateTime.Now,
                    _ConfigItem.Login_UserName,
                    0,
                    row["Remark"],
                    row["Id_Unit_Pk"],
                    row["Id_Supplier_Pk"]
                };
                DaoItem.Insert(arrValue: arrParaValue);
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
                DaoItem.Delete(_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private bool Update(DataRow row)
        {
            //           "@Id",
            //"@Name",
            //"@Id_Group_Pk",
            //"@Mod_Dt",
            //"@Mod_By",
            //"@Is_Del",
            //"@Remark",
            //"@Id_Unit_Pk",
            //"@Id_Supplier_Pk"};
            try
            {
                object[] arrParaValue = new object[] {
                    row["Id"],
                    row["Name"],
                     row["Id_Group_Pk"],
                    DateTime.Now,
                    _ConfigItem.Login_UserName,
                    0,
                    row["Remark"],
                    row["Id_Unit_Pk"],
                    row["Id_Supplier_Pk"]
                };
                DaoItem.Update(arrValue: arrParaValue);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {

                DataTable Tmp = (DataTable)(grdItem.DataSource);
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

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(System.Windows.Forms.Keys.Delete))
            {
                try
                {
                    int[] _IndexRowSelected = gridView1.GetSelectedRows();
                    int _CurIndexRow = _IndexRowSelected[0];
                    DataTable tmp = (DataTable)grdItem.DataSource;
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
}