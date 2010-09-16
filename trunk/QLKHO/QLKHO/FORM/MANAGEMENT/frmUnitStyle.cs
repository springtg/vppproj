﻿using System;
using System.Data;
using System.Windows.Forms;
using COREBASE.COMMAND.Config;
using QLKHO.DATAOBJECT;

namespace QLKHO.FORM.MANAGEMENT
{
    public partial class frmUnitStyle : COREBASE.FORM.BASEFORM
    {
        public frmUnitStyle(ConfigItem p_ConfigItem)
        {
            _ConfigItem = p_ConfigItem;
            InitializeComponent();
        }

        private void frmUnitStyle_Load(object sender, EventArgs e)
        {

            LoadGird();
        }
        public void LoadGird()
        {
            InitData(L_CATALOG);
            InitData(L_SUPPLIER);
            InitData(L_UNIT_OUT);
            InitData(L_UNIT_IN);


            int l_Catalog_PK=0;
            int l_Group_PK=0;
            int l_Item_PK=0;
            if( lookUpEdit_Catalog.GetSelectedDataRow()!=null)
            l_Catalog_PK = CnvToInt32(((DataRowView)lookUpEdit_Catalog.GetSelectedDataRow()).Row["Id"]);
            if (lookUpEdit_Group.GetSelectedDataRow() != null)
            l_Group_PK = CnvToInt32(((DataRowView)lookUpEdit_Group.GetSelectedDataRow()).Row["Id"]);
            if (lookUpEdit_Item.GetSelectedDataRow() != null)
            l_Item_PK = CnvToInt32(((DataRowView)lookUpEdit_Item.GetSelectedDataRow()).Row["Id"]);
            grdUnitStyle.DataSource = UnitStyleDao.getList(_ConfigItem, l_Catalog_PK, l_Group_PK, l_Item_PK);
        }
        #region "Phuong thuc"

        private const string l_GROUP  ="GROUP";
        private const string l_ITEM = "ITEM";
        private const string L_CATALOG = "CATALOG";
        private const string L_UNIT_IN = "UNIT_IN";
        private const string L_UNIT_OUT = "UNIT_OUT";
        private const string L_SUPPLIER = "SUPPLIER";

        private void InitData(string p_Repo)
        {
            switch (p_Repo)//GetList
            {
                case l_GROUP:
                    if (lookUpEdit_Catalog.GetSelectedDataRow() != null)
                    {
                        int l_Catalog_PK = CnvToInt32(((DataRowView)lookUpEdit_Catalog.GetSelectedDataRow()).Row["Id"]);
                        lookUpEdit_Group.Properties.DataSource = QLKHO.DATAOBJECT.GroupDao.GetList(_ConfigItem, l_Catalog_PK);
                    }
                    break;
                case l_ITEM:

                    if (lookUpEdit_Group.GetSelectedDataRow() != null)
                    {
                        int l_Group_PK = CnvToInt32(((DataRowView)lookUpEdit_Group.GetSelectedDataRow()).Row["Id"]);
                        lookUpEdit_Item.Properties.DataSource = QLKHO.DATAOBJECT.ItemDao.GetList(_ConfigItem, l_Group_PK);
                    }
                    break;
                case L_CATALOG:
                    lookUpEdit_Catalog.Properties.DataSource = QLKHO.DATAOBJECT.CatalogDao.GetList(_ConfigItem);
                    break;
                case L_UNIT_IN:
                    repositoryItemLookUpEdit_Unit.DataSource = QLKHO.DATAOBJECT.UnitDao.GetList(_ConfigItem);
                    break;
                case L_UNIT_OUT:
                    repositoryItemLookUpEdit_Unit.DataSource = QLKHO.DATAOBJECT.UnitDao.GetList(_ConfigItem);
                    break;
                case L_SUPPLIER:
                    repositoryItemLookUpEdit_Supplier.DataSource = QLKHO.DATAOBJECT.SupplierDao.GetList(_ConfigItem);
                    repositoryItemLookUpEdit_sup.DataSource = QLKHO.DATAOBJECT.SupplierDao.GetList(_ConfigItem);
                    break;
                default:
                    break;
            }
        }
        

        #endregion

        private void lookUpEdit_Catalog_EditValueChanged(object sender, EventArgs e)
        {
            InitData(l_GROUP);

            int l_Catalog_PK = 0;
            int l_Group_PK = 0;
            int l_Item_PK = 0;
            if (lookUpEdit_Catalog.GetSelectedDataRow() != null)
                l_Catalog_PK = CnvToInt32(((DataRowView)lookUpEdit_Catalog.GetSelectedDataRow()).Row["Id"]);
            if (lookUpEdit_Group.GetSelectedDataRow() != null)
                l_Group_PK = CnvToInt32(((DataRowView)lookUpEdit_Group.GetSelectedDataRow()).Row["Id"]);
            if (lookUpEdit_Item.GetSelectedDataRow() != null)
                l_Item_PK = CnvToInt32(((DataRowView)lookUpEdit_Item.GetSelectedDataRow()).Row["Id"]);

            grdUnitStyle.DataSource = UnitStyleDao.getList(_ConfigItem, l_Catalog_PK, l_Group_PK, l_Item_PK);
        }

        private void lookUpEdit_Group_EditValueChanged(object sender, EventArgs e)
        {
            InitData(l_ITEM);
            int l_Catalog_PK = 0;
            int l_Group_PK = 0;
            int l_Item_PK = 0;
            if (lookUpEdit_Catalog.GetSelectedDataRow() != null)
                l_Catalog_PK = CnvToInt32(((DataRowView)lookUpEdit_Catalog.GetSelectedDataRow()).Row["Id"]);
            if (lookUpEdit_Group.GetSelectedDataRow() != null)
                l_Group_PK = CnvToInt32(((DataRowView)lookUpEdit_Group.GetSelectedDataRow()).Row["Id"]);
            if (lookUpEdit_Item.GetSelectedDataRow() != null)
                l_Item_PK = CnvToInt32(((DataRowView)lookUpEdit_Item.GetSelectedDataRow()).Row["Id"]);
            grdUnitStyle.DataSource = UnitStyleDao.getList(_ConfigItem, l_Catalog_PK, l_Group_PK, l_Item_PK);
        }

        private void lookUpEdit_Item_EditValueChanged(object sender, EventArgs e)
        {
            //TODO: lay thong tin style
            int l_Catalog_PK = 0;
            int l_Group_PK = 0;
            int l_Item_PK = 0;
            if (lookUpEdit_Catalog.GetSelectedDataRow() != null)
                l_Catalog_PK = CnvToInt32(((DataRowView)lookUpEdit_Catalog.GetSelectedDataRow()).Row["Id"]);
            if (lookUpEdit_Group.GetSelectedDataRow() != null)
                l_Group_PK = CnvToInt32(((DataRowView)lookUpEdit_Group.GetSelectedDataRow()).Row["Id"]);
            if (lookUpEdit_Item.GetSelectedDataRow() != null)
                l_Item_PK = CnvToInt32(((DataRowView)lookUpEdit_Item.GetSelectedDataRow()).Row["Id"]);
            grdUnitStyle.DataSource = UnitStyleDao.getList(_ConfigItem, l_Catalog_PK, l_Group_PK, l_Item_PK);
        }

        private void repositoryItemLookUpEdit_Unit_EditValueChanged(object sender, EventArgs e)
        {
            //TODO: lay thong tin test ung voi tung cot
            DataRow l_dr_in = grvUnitStyle.Columns[0].View.GetFocusedDataRow();
            DataRow l_dr_out = grvUnitStyle.Columns[1].View.GetFocusedDataRow();
            //string l_name_in = l_dr_in["Name"];
            //string l_name_out = l_dr_out["Name"];
            if (l_dr_in != null)
            { 
                
            }
            
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            
        }
        private void Insert(DataRow row)
        {

            try
            {
                string remark, supplier_pk, Name;
                int Item_Pk=0;
                if (lookUpEdit_Item.GetSelectedDataRow() != null)
                    Item_Pk = CnvToInt32(((DataRowView)lookUpEdit_Item.GetSelectedDataRow()).Row["Id"]);
                remark = row["Remark"].ToString();
                supplier_pk = row["Supplier_Pk"].ToString();
                Name = "";
                object[] arrParaValue = new object[] {
                     0,
                    Name,
                    row["Unit_In_Pk"],                                  
                    row["Unit_Out_Pk"],
                    remark,
                    row["Num"],
                    supplier_pk,
                    Item_Pk,
                     _ConfigItem.Login_UserName
                };
                UnitStyleDao.Insert(_ConfigItem, arrValue: arrParaValue);
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
                UnitStyleDao.Delete(_ConfigItem, _id);
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
                

                string remark, supplier_pk, Name;
                int Item_Pk = 0;
                if (lookUpEdit_Item.GetSelectedDataRow() != null)
                    Item_Pk = CnvToInt32(((DataRowView)lookUpEdit_Item.GetSelectedDataRow()).Row["Id"]);
                remark = row["Remark"].ToString();
                supplier_pk = row["Supplier_Pk"].ToString();
                Name = "";
                object[] arrParaValue = new object[] {
                     row["Id"],
                    row["Name"],
                    row["Unit_In_Pk"],                                  
                    row["Unit_Out_Pk"],
                    remark,
                    row["Num"],
                    supplier_pk,
                    Item_Pk,
                     _ConfigItem.Login_UserName
                };
                UnitStyleDao.Insert(_ConfigItem, arrValue: arrParaValue);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void grvUnitStyle_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {

                DataTable Tmp = (DataTable)(grdUnitStyle.DataSource);
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

        private void grvUnitStyle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(System.Windows.Forms.Keys.Delete))
            {
                try
                {
                    int[] _IndexRowSelected = grvUnitStyle.GetSelectedRows();
                    int _CurIndexRow = _IndexRowSelected[0];
                    DataTable tmp = (DataTable)grdUnitStyle.DataSource;
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

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void grdUnitStyle_Click(object sender, EventArgs e)
        {
            int[] _IndexRowSelected = grvUnitStyle.GetSelectedRows();
            int _CurIndexRow = _IndexRowSelected[0];
            int idgroup, idcat, idhh;
            DataTable tmp = (DataTable)grdUnitStyle.DataSource;
            idgroup=(CnvToInt32(tmp.Rows[_CurIndexRow]["Group_Pk"]));
            idcat = (CnvToInt32(tmp.Rows[_CurIndexRow]["ID_Cat"]));
            idhh = (CnvToInt32(tmp.Rows[_CurIndexRow]["Item_Pk"]));
            (((DataRowView)lookUpEdit_Group.GetSelectedDataRow()).Row["Id"]) = idgroup;
      

            
        }
    }
}

