using System;
using System.Data;
using System.Windows.Forms;
using COREBASE.COMMAND.Config;
using QLKHO.DATAOBJECT;

namespace QLKHO.FORM.MANAGEMENT
{
    public partial class frmUnitStyle : COREBASE.FORM.BASEFORM
    {
        private const string L_UNIT_IN = "UNIT_IN";
        private const string L_UNIT_OUT = "UNIT_OUT";
        private const string L_SUPPLIER = "SUPPLIER";
        private int l_Curr_Supplier = 0;

        public frmUnitStyle(ConfigItem p_ConfigItem)
        {
            _ConfigItem = p_ConfigItem;
            InitializeComponent();
        }

        private void frmUnitStyle_Load(object sender, EventArgs e)
        {
            DataSet ds = UnitStyleDao.GetList(_ConfigItem);
            DataTable dt = ds.Tables[0];
            lookUpEdit_Supplier.Properties.DataSource = dt;
            dt = ds.Tables[1];
            repositoryItemLookUpEdit_Unit.DataSource = dt;
            dt = ds.Tables[2];
            grdUnitStyle.DataSource = dt;
        }

        #region "Phuong thuc"

        private void InitData(string p_Repo)
        {
            switch (p_Repo)//GetList
            {
                case L_UNIT_IN:
                    repositoryItemLookUpEdit_Unit.DataSource = QLKHO.DATAOBJECT.UnitDao.GetList(_ConfigItem);
                    break;
                case L_UNIT_OUT:
                    repositoryItemLookUpEdit_Unit.DataSource = QLKHO.DATAOBJECT.UnitDao.GetList(_ConfigItem);
                    break;
                case L_SUPPLIER:
                    lookUpEdit_Supplier.Properties.DataSource = QLKHO.DATAOBJECT.SupplierDao.GetList(_ConfigItem);
                    break;
                default:
                    break;
            }
        }

        public void LoadGird()
        {
           // InitData(L_SUPPLIER);
            InitData(L_UNIT_OUT);
            InitData(L_UNIT_IN);
            grdUnitStyle.DataSource = UnitStyleDao.getList_new(_ConfigItem, l_Curr_Supplier);
        }

        #endregion


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

        private void grvUnitStyle_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                DataTable Tmp = ((DataView)((DevExpress.XtraGrid.Views.Grid.GridView)sender).DataSource).Table;
                if (Tmp.GetChanges() == null) return;
                for (int i = 0; i < Tmp.Rows.Count; i++)
                {
                    DataRow dr = Tmp.Rows[i];
                    if (isModifedRow(dr))
                    {
                        UnitStyleDao.Update(_ConfigItem, dr);
                    }
                    if (isNewRow(dr))
                    {
                        UnitStyleDao.Insert(_ConfigItem, dr, l_Curr_Supplier);
                    }
                    if (isDeletedRow(dr))
                    {
                        UnitStyleDao.Delete(_ConfigItem, (int)GetOriginalItemData(dr, "Id"));
                    }
                }
                LoadGird();
            }
            catch (Exception ex)
            {
                AppDebug(ex);
            }
            
        }
        /// <summary>
        /// Xu ly phim Del
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvUnitStyle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(System.Windows.Forms.Keys.Delete))
            {
                try
                {

                    btnDelete_ItemClick(btnDelete, null);
                }
                catch (Exception ex)
                {
                    AppDebug(ex);
                }
            }
        }

        private void lookUpEdit_Supplier_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int l_Supplier_PK = 0;
                DevExpress.XtraEditors.LookUpEdit l_Tmp = (DevExpress.XtraEditors.LookUpEdit)sender;
                if (l_Tmp.GetSelectedDataRow() != null)
                {
                    l_Supplier_PK = CnvToInt32(((DataRowView)lookUpEdit_Supplier.GetSelectedDataRow())["Id"]);
                }
                grdUnitStyle.DataSource = UnitStyleDao.getList_new(_ConfigItem, (l_Supplier_PK != 0) ? l_Supplier_PK : 0);
                l_Curr_Supplier = l_Supplier_PK;
            }
            catch (Exception ex)
            {
                AppDebug(ex);
            }
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lookUpEdit_Supplier_EditValueChanged(lookUpEdit_Supplier, new EventArgs());
        }

        private void grvUnitStyle_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (isNewRow(((DataRowView)e.Row).Row))
            {
                
                    e.Valid = false;
            }
        }

        private void grvUnitStyle_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] _IndexRowSelected = grvUnitStyle.GetSelectedRows();
            int _CurIndexRow = _IndexRowSelected[0];
            DataTable tmp = (DataTable)grdUnitStyle.DataSource;
            object[] obj = new object[] { string.Format("{0} _ {1} _ {2}", tmp.Rows[_CurIndexRow]["Id"], tmp.Rows[_CurIndexRow]["Name"], tmp.Rows[_CurIndexRow]["Num"]) };
            if (ShowMessageBox("UNITSTYLE_C_001", COREBASE.COMMAND.MessageUtils.MessageType.CONFIRM, obj) == System.Windows.Forms.DialogResult.Yes)
            {
                if (UnitStyleDao.Delete(_ConfigItem, CnvToInt32(tmp.Rows[_CurIndexRow]["Id"])))
                    LoadGird();
            }
        }

        private void grvUnitStyle_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView l_Tmp = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                DataTable l_TB = (DataTable)l_Tmp.DataSource;
                if (l_TB == null) return;
                if (l_TB.Rows.Count < 1) return;
                for (int i = 0; i < l_TB.Rows.Count; i++)
                {
                    if (isUnchangedRow(l_TB.Rows[i]))
                    { 
                       // l
                    }
                }
            }
            catch (Exception ex)
            {
                AppDebug(ex);
            }
        }

        private void grvUnitStyle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name.Equals("gridColumn5") || e.Column.Name.Equals("gridColumn6"))
            {
                DevExpress.XtraGrid.Views.Grid.GridView l_Tmp = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            }
        }

      


    }
}

