using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLKHO.DATAOBJECT;

namespace QLKHO.FORM.NHAPXUAT
{
    public partial class XuatKho : COREBASE.FORM.BASEFORM
    {
        private string CurFormState = EVENT_FORM_LOAD;
        private const string L_Load_MASTER = "MASTER";
        private const string L_Load_DETAIL = "DETAIL";
        private DataTable l_dtMaster;
        private BindingSource l_BindingSource;

        public XuatKho(COREBASE.COMMAND.Config.ConfigItem _config)
        {
            InitializeComponent();
            _ConfigItem = _config;
        }

        private void MasterBind()
        {
            txtTakeOutDate.DataBindings.Add("DateTime", l_dtMaster, "Take_Out_Date");
            txtTakeOutID.DataBindings.Add("Text", l_dtMaster, "Id_Dis");

            txtDeparment.DataBindings.Add("EditValue", l_dtMaster, "Department_Pk");
            txtTakeOutRemark.DataBindings.Add("Text", l_dtMaster, "Remark");
        }
        private void XuatKho_Load(object sender, EventArgs e)
        {
            l_BindingSource = new BindingSource();
            l_BindingSource.ResetBindings(true);
            try
            {
                l_dtMaster = LoadData(L_Load_MASTER, -1);
                l_BindingSource.DataSource = l_dtMaster;
                lstTakeOut.DataSource = l_dtMaster;
                lstTakeOut.DisplayMember = "TakeOutDate";
                lstTakeOut.ValueMember = "Id";
                txtDeparment.Properties.DataSource = LoadDataDepartment();
                cboWareHouse.Properties.DataSource = COREBASE.COMMAND.VPP_COMMAND.CWareHouse.ListWareHouse(_ConfigItem);
                repositoryItemLookUpEdit_Item.DataSource = ItemDao.GetList(_ConfigItem);
                repositoryItemLookUpEdit_Style.DataSource = UnitStyleDao.GetList(_ConfigItem);
                //Load Data master
                MasterBind();
                AssignTagValueOnDXControl(this);
            }
            catch (Exception ex)
            {
                AppDebug(ex);
                //BeginInvoke(CloseMe);
            }
        }

        private void btn_TakeOut_TaoMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                NewPage();
                CurFormState = EVENT_FORM_NEW;
            }
            catch (Exception ex)
            {
                AppDebug(ex);
            }
        }

        private DataTable LoadData(string strParam, int idMaster)
        {
            _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
            switch (strParam)
            {
                case L_Load_MASTER:
                    return _providerSQL.GetDataByStoredProcedure("USP_SEL_TAKE_OUT");
                case L_Load_DETAIL:
                    string[] arrName = new string[] { "@Take_Out_Pk" };
                    object[] arrValue = new object[] { idMaster };
                    return _providerSQL.GetDataByStoredProcedure("USP_SEL_TAKE_OUT_DETAIL", arrName, arrValue);
                default:
                    return null;
            }

        }

        private DataTable LoadDataDepartment()
        {
            _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
            return _providerSQL.GetDataByStoredProcedure("USP_SEL_DEPARTMENT");
        }

        private void lstTakeOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurFormState.Equals(EVENT_FORM_NEW) || CurFormState.Equals(EVENT_FORM_UPDATE))
            {
                if (HasChangedOnDXControl(this))
                {
                    if (ShowMessageBox("XUATKHO_C_001", COREBASE.COMMAND.MessageUtils.MessageType.CONFIRM) == System.Windows.Forms.DialogResult.Yes)
                    {
                        btn_TakeOut_Luu_ItemClick(btn_TakeOut_Luu, null);
                    }
                }
            }
            ListBoxControl lstTmp = (ListBoxControl)sender;
            if (lstTmp.SelectedIndex == -1)
            {
                return;
            }

            DataTable tbTmp = (DataTable)lstTmp.DataSource;
            if (tbTmp.Rows.Count > 0)
            {
                DataRow dr = tbTmp.Rows[lstTmp.SelectedIndex];
                int _idMaster = CnvToInt32(dr["Id"]);
                tbTmp = LoadData("DETAIL", _idMaster);
                grdTakeOutDetail.DataSource = tbTmp;
            }
            this.CurFormState = EVENT_FORM_NONE;
        }

        private void btn_TakeOut_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuatKho_Load(this, new EventArgs());
        }

        private void btn_TakeOut_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CurrencyManager cm = (CurrencyManager)this.BindingContext[l_dtMaster];
            cm.EndCurrentEdit();
            DataTable l_Detail = (DataTable)grdTakeOutDetail.DataSource;
            if (CurFormState.Equals(EVENT_FORM_NEW))
            {
                DataRow dr = ((DataTable)lstTakeOut.DataSource).NewRow();
                dr["Number_Item"] = grvTakeOutDetail.RowCount;
                dr["Remark"] = txtTakeOutRemark.Text;
                dr["Crt_By"] = _ConfigItem.Login_ID;
                dr["Department_pk"] = ((DataRowView)txtDeparment.GetSelectedDataRow()).Row["Id"];
                dr["Take_Out_Date"] = txtTakeOutDate.DateTime;
                int l_totalmat = 100;// CnvToInt32(grvTakeOutDetail.Columns["bandedGridColumn8"].SummaryItem.SummaryValue);
                dr["PriceTotal"] = l_totalmat;
                if (TakeOutDao.Insert(_ConfigItem, dr, l_Detail))
                {
                    CurFormState = EVENT_FORM_NONE;
                    lstTakeOut.SelectedIndexChanged -= new EventHandler(lstTakeOut_SelectedIndexChanged);
                    l_dtMaster = TakeOutDao.GetList(_ConfigItem);
                    lstTakeOut.DataSource = l_dtMaster;
                    ShowMessageBox("XUATKHO_I_005", COREBASE.COMMAND.MessageUtils.MessageType.INFORM);
                    lstTakeOut.SelectedIndexChanged += new EventHandler(lstTakeOut_SelectedIndexChanged);
                }
                else
                {
                    ShowMessageBox("XUATKHO_E_003", COREBASE.COMMAND.MessageUtils.MessageType.ERROR);
                }
            }
            DataRow dr1 = ((DataTable)lstTakeOut.DataSource).Rows[lstTakeOut.SelectedIndex];
            if (isModifedRow(dr1))
            {
                CurFormState = EVENT_FORM_UPDATE;
            }
            if (CurFormState.Equals(EVENT_FORM_UPDATE))
            {
                if (TakeOutDao.Update(_ConfigItem, dr1, l_Detail))
                {
                    CurFormState = EVENT_FORM_NONE;
                    lstTakeOut.SelectedIndexChanged -= new EventHandler(lstTakeOut_SelectedIndexChanged);
                    l_dtMaster = TakeOutDao.GetList(_ConfigItem);
                    lstTakeOut.DataSource = l_dtMaster;
                    ShowMessageBox("XUATKHO_I_006", COREBASE.COMMAND.MessageUtils.MessageType.INFORM);
                    lstTakeOut.SelectedIndexChanged += new EventHandler(lstTakeOut_SelectedIndexChanged);
                }
                else
                {
                    ShowMessageBox("XUATKHO_E_003", COREBASE.COMMAND.MessageUtils.MessageType.ERROR);
                }
            }
        }

        private DataRow getMasterInfo()
        {
            DataRow dr = ((DataTable)lstTakeOut.DataSource).Rows[lstTakeOut.SelectedIndex];
            dr["Number_Item"] = grvTakeOutDetail.RowCount;
            dr["Remark"] = txtTakeOutRemark.Text;
            dr["Crt_By"] = _ConfigItem.Login_ID;
            dr["Department_pk"] = ((DataRowView)txtDeparment.GetSelectedDataRow()).Row["Id"];
            dr["Take_Out_Date"] = txtTakeOutDate.DateTime;
            int l_totalmat = CnvToInt32(grvTakeOutDetail.Columns["bandedGridColumn8"].SummaryItem.SummaryValue);
            dr["PriceTotal"] = l_totalmat;
            return dr;
        }

        private void NewPage()
        {
            txtDeparment.Text = string.Empty;
            cboWareHouse.Text = string.Empty;
            txtTakeOutID.Text = COREBASE.COMMAND.VPP_COMMAND.CTakeOut.getNextIDTakeOut(_ConfigItem);
            txtTakeOutDate.Text = string.Empty;
            txtTakeOutRemark.Text = string.Empty;
            grdTakeOutDetail.DataSource = makeTableDetail();

        }
        private DataTable makeTableDetail()
        {
            DataTable tb = new DataTable("TAKEOUTDETAIL");
            tb.Columns.Add("Id", typeof(int));
            tb.Columns.Add("ROWID", typeof(int));
            tb.Columns.Add("Id_Dis", typeof(string));
            tb.Columns.Add("Take_Out_Pk", typeof(int));
            tb.Columns.Add("Crt_By", typeof(string));
            tb.Columns.Add("Crt_Dt", typeof(DateTime));
            tb.Columns.Add("Mod_By", typeof(string));
            tb.Columns.Add("Mod_Dt", typeof(int));
            tb.Columns.Add("Is_Del", typeof(DateTime));
            tb.Columns.Add("Remark", typeof(string));
            tb.Columns.Add("Number_Bill", typeof(int));
            tb.Columns.Add("Number_Real", typeof(int));
            tb.Columns.Add("Price", typeof(float));
            tb.Columns.Add("Item_Pk", typeof(int));
            tb.Columns.Add("Unit_Pk", typeof(int));
            tb.Columns["ROWID"].AutoIncrement = true;
            tb.Columns["ROWID"].AutoIncrementStep = 1;
            tb.Columns["ROWID"].AutoIncrementSeed = 1;
            return tb;
        }

        private void grdTakeOutDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Delete))
            {
                int[] l_selectRow = grvTakeOutDetail.GetSelectedRows();
                DataTable l_tmp = ((DataView)grdTakeOutDetail.DataSource).Table;
                if (CurFormState.Equals(EVENT_FORM_NEW))//Neu la truong hop them moi thi remote row do ra khoi grid
                {
                    for (int i = 0; i < l_selectRow.Length; i++)
                    {
                        l_tmp.Rows.RemoveAt(i);
                    }
                }
                //neu la truong hop cu du lieu o Db troi, thi goi cau update
                else
                {
                    if (DeleteItem(l_selectRow, l_tmp))
                    {
                        lstTakeOut.DataSource = LoadData("MASTER", -1);
                    }
                }
            }
        }
        private bool DeleteItem(int[] p_selectRow, DataTable p_datasource)
        {
            System.Data.SqlClient.SqlConnection _sqlConnection = new System.Data.SqlClient.SqlConnection(_ConfigItem.StrConnection); ;
            if (_sqlConnection.State != ConnectionState.Open) _sqlConnection.Open();
            System.Data.SqlClient.SqlTransaction _sqlTransaction = _sqlConnection.BeginTransaction();
            try
            {
                _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL();
                string[] arrName = new string[] { "@Id", "@Mod_By", "@Mod_Dt" };
                for (int i = 0; i < p_selectRow.Length; i++)
                {
                    object[] arrValue = new object[] { p_datasource.Rows[i]["Id"], _ConfigItem.Login_UserName, DateTime.Now };
                    _providerSQL.ExecuteNonQuery(_sqlConnection, _sqlTransaction, "USP_DEL_TAKE_OUT_DETAIL", arrName, arrValue);
                }
                _sqlTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _sqlTransaction.Rollback();
                AppDebug(ex);
                if (_sqlConnection.State != ConnectionState.Closed) _sqlConnection.Close();
                return false;
            }
        }

        private void grvTakeOutDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name.Equals("bandedGridColumn2"))
            {
                if (l_CurItem != null)
                {
                    int l_Unit_pk = CnvToInt32(((DataRowView)l_CurItem.GetSelectedDataRow()).Row["Unit_Pk"]);
                    repositoryItemLookUpEdit_Style.DataSource = UnitStyleDao.GetList(_ConfigItem, l_Unit_pk);
                }
            }
        }
        LookUpEdit l_CurItem = null;
        private void repositoryItemLookUpEdit_Item_EditValueChanged(object sender, EventArgs e)
        {
            l_CurItem = (LookUpEdit)sender;

        }

        private void btn_TakeOut_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CurrencyManager cm = (CurrencyManager)this.BindingContext[l_dtMaster];
            cm.EndCurrentEdit();
            if (CurFormState.Equals(EVENT_FORM_NEW))
            {
                if (ShowMessageBox("XUATKHO_C_001", COREBASE.COMMAND.MessageUtils.MessageType.CONFIRM) == System.Windows.Forms.DialogResult.Yes)
                {
                    CurFormState = EVENT_FORM_NONE;
                    l_dtMaster = TakeOutDao.GetList(_ConfigItem);
                    lstTakeOut.DataSource = l_dtMaster;
                    l_BindingSource.ResetBindings(true);
                    return;
                }
                else
                {
                    return;
                }
            }
            DataRow dr1 = ((DataTable)lstTakeOut.DataSource).Rows[lstTakeOut.SelectedIndex];
            CurFormState = EVENT_FORM_DELETE;
            if (TakeOutDao.Delete(_ConfigItem, dr1))
            {
                CurFormState = EVENT_FORM_NONE;
                lstTakeOut.SelectedIndexChanged -= new EventHandler(lstTakeOut_SelectedIndexChanged);
                l_dtMaster = TakeOutDao.GetList(_ConfigItem);
                lstTakeOut.DataSource = l_dtMaster;
                ShowMessageBox("XUATKHO_I_006", COREBASE.COMMAND.MessageUtils.MessageType.INFORM);
                lstTakeOut.SelectedIndexChanged += new EventHandler(lstTakeOut_SelectedIndexChanged);
            }
            else
            {
                ShowMessageBox("XUATKHO_E_003", COREBASE.COMMAND.MessageUtils.MessageType.ERROR);
            }

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lstTakeOut.SelectedIndex == -1)
            {
                return;
            }
            int _idMaster = -1;
            DataTable tbTmp = (DataTable)lstTakeOut.DataSource;
            if (tbTmp.Rows.Count > 0)
            {
                DataRow dr = tbTmp.Rows[lstTakeOut.SelectedIndex];
                _idMaster = CnvToInt32(dr["Id"]);
            }
            if (_idMaster == -1) return;
            FORM.BAOCAO.NHAPXUAT.rptTakeOut frp = new FORM.BAOCAO.NHAPXUAT.rptTakeOut();
            FORM.BAOCAO.frmBaoCao f = new FORM.BAOCAO.frmBaoCao();
            f.ShowBaoCao(frp, ReportDao.GetListTakeOut(_idMaster, _ConfigItem), this.ParentForm);
        }

    }
}
