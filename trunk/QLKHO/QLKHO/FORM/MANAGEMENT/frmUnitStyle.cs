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

        public frmUnitStyle(ConfigItem p_ConfigItem)
        {
            _ConfigItem = p_ConfigItem;
            InitializeComponent();
        }

        private void frmUnitStyle_Load(object sender, EventArgs e)
        {
          //Lay thong tin cho cac control repository
            repositoryItemLookUpEdit_Unit.DataSource = QLKHO.DATAOBJECT.UnitDao.GetList(_ConfigItem);
            LoadUnitStyle();
        }

        #region "Phuong thuc"

        public void LoadUnitStyle()
        {            
            grdUnitStyle.DataSource = UnitStyleDao.GetList(_ConfigItem);
        }

        #endregion

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
                        UnitStyleDao.Insert(_ConfigItem, dr);
                    }
                    if (isDeletedRow(dr))
                    {
                        UnitStyleDao.Delete(_ConfigItem, (int)GetOriginalItemData(dr, "Id"));
                    }
                }
                LoadUnitStyle();
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

                    int[] _IndexRowSelected = grvUnitStyle.GetSelectedRows();
                    int _CurIndexRow = _IndexRowSelected[0];
                    DataTable tmp = (DataTable)grdUnitStyle.DataSource;
                    object[] obj = new object[] { string.Format("{0} _ {1} _ {2}", tmp.Rows[_CurIndexRow]["Id"], tmp.Rows[_CurIndexRow]["Name"], tmp.Rows[_CurIndexRow]["Num"]) };
                    if (ShowMessageBox("UNITSTYLE_C_001", COREBASE.COMMAND.MessageUtils.MessageType.CONFIRM, obj) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (UnitStyleDao.Delete(_ConfigItem, CnvToInt32(tmp.Rows[_CurIndexRow]["Id"])))
                            LoadUnitStyle();
                    }
                }
                catch (Exception ex)
                {
                    AppDebug(ex);
                }
            }
        }


        #region "Su kien form"
        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUnitStyle();
        }

        #endregion

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
                    LoadUnitStyle();
            }
        }

        private void grvUnitStyle_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridColumn4.View.SetRowCellValue(e.RowHandle, "gridColumn4", 0);
        }
        /*
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

      */


    }
}

