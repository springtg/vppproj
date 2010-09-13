using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLKHO.DATAOBJECT;

namespace QLKHO.FORM.NHAPXUAT
{
    public partial class NhapKho : COREBASE.FORM.BASEFORM
    {
        private string CurrStateForm = EVENT_FORM_LOAD;
        private int SupplierIDSelected = -1;

        public NhapKho(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");

            InitializeComponent();
            _ConfigItem = _ConfItem;
        }

        private void NhapKho_Load(object sender, EventArgs e)
        {
            DataTable tbTmp = LoadData("MASTER", -1);
            lstTakeIn.DataSource = tbTmp;
            lstTakeIn.DisplayMember = "Date_Take_In";
            lstTakeIn.ValueMember = "Id";
            AssignTagValueOnDXControl(this);
            //LAY THONG TIN CHO CAC COMBOBOX
            _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
            txtSuppierID.Properties.DataSource = _providerSQL.GetDataByStoredProcedure("USP_SEL_SUPPLIER");
            cboWareHouse.Properties.DataSource = COREBASE.COMMAND.VPP_COMMAND.CWareHouse.ListWareHouse(_ConfigItem);
            repositoryItemGridLookUpEdit1.DataSource = ItemDao.GetList(_ConfigItem);
            repositoryItemGridLookUpEdit2.DataSource = UnitDao.GetList(_ConfigItem);
        }

        private DataTable LoadData(string strParam, int idMaster)
        {
            _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
            switch (strParam)
            {
                case "MASTER":
                    return _providerSQL.GetDataByStoredProcedure("USP_SEL_TAKE_IN");
                case "DETAIL":
                    string[] arrName = new string[] { "@Take_In_Pk" };
                    object[] arrValue = new object[] { idMaster };
                    return _providerSQL.GetDataByStoredProcedure("USP_SEL_TAKE_IN_DETAIL", arrName, arrValue);
                default:
                    return null;
            }
        }

        private bool InsertData(DataTable tbDetail, int _id_WareHouse, int _TotalAMT, int _iId_Supplier_Pk, DateTime _iTake_In_Date, string _Id_Use_Dis, string _BillNumber)
        {
            System.Data.SqlClient.SqlConnection _sqlConnection = new System.Data.SqlClient.SqlConnection(_ConfigItem.StrConnection);
            if (_sqlConnection.State != ConnectionState.Open) _sqlConnection.Open();
            System.Data.SqlClient.SqlTransaction _sqlTransaction = _sqlConnection.BeginTransaction();
            try
            {
                int _iNumberItem = tbDetail.Rows.Count;                
                string[] arrName = new string[] { "@Number_Item", "@Crt_By", "@TotalAMT", "@Id_WareHouse", "@Id_Supplier_Pk", "@Take_In_Date", "@Id_Use_Dis", "@Remark", "@BillNumber" };
                object[] arrValue = new object[] { _iNumberItem, _ConfigItem.Login_UserName, _TotalAMT, _id_WareHouse, _iId_Supplier_Pk, _iTake_In_Date, _Id_Use_Dis, "", _BillNumber };
                _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL();
                int _idMaster = _providerSQL.ExecuteInsert(_sqlConnection,_sqlTransaction ,"USP_INS_TAKE_IN", arrName, arrValue);
                for (int i = 0; i < _iNumberItem; i++)
                {
                    arrName = new string[] { 
                        "@Take_In_Pk", 
                        "@Crt_By", 
                        "@Remark", 
                        "@Number_Bill", 
                        "@Number_Real",
                        "@Price", 
                        "@Vat" ,
                        "@Item_Pk",
                        "@Unit_Pk"
                    };
                    arrValue = new object[] {
                        _idMaster,
                        _ConfigItem.Login_UserName,
                        string.Empty,
                        tbDetail.Rows[i]["Number_Bill"],
                        tbDetail.Rows[i]["Number_Real"],
                        tbDetail.Rows[i]["Price"],
                        tbDetail.Rows[i]["Vat"],
                        tbDetail.Rows[i]["Item_Pk"],
                        tbDetail.Rows[i]["Unit_Pk"]
                    };
                    _providerSQL.ExecuteNonQuery(_sqlConnection,_sqlTransaction, "USP_INS_TAKE_IN_DETAIL", arrName, arrValue);
                }
                _sqlTransaction.Commit();
                _providerSQL.Disconnect(_sqlConnection);
                return true;
            }
            catch (Exception ex)
            {
                _sqlTransaction.Rollback();
                AppDebug(ex);
                if (_providerSQL != null)
                    if (_sqlConnection != null)
                        _providerSQL.Disconnect(_sqlConnection);
                return false;
            }
        }

        private void lstTakeIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrStateForm.Equals(EVENT_FORM_NEW) || CurrStateForm.Equals(EVENT_FORM_UPDATE))
            {
                if (HasChangedOnDXControl(this))
                {
                    if (ShowMessageBox("NHAPKHO_C_001", COREBASE.COMMAND.MessageUtils.MessageType.CONFIRM) == System.Windows.Forms.DialogResult.Yes)
                    {
                        //TODO:GOI HAM SAVE LAI THONG TIN
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
                //LAY THONG TIN CHUYEN QUA MASTER CONTROL VA LOAD DETAIL CUA PHIEU NHAP TUONG UNG    
                //int l_Group_PK = CnvToInt32(((DataRowView)lookUpEdit_Group.GetSelectedDataRow()).Row["Id"]);

                txtSuppierID.Text = CnvToString(dr["Supplier_Pk"]);
                
                txtTakeInID.Text = CnvToString(dr["Id_Dis"]);
                txtTakeInDate.DateTime = DateTime.Parse(CnvToString(dr["Take_In_Date"]));
                txttakeInRemark.Text = CnvToString(dr["Remark"]);
                SupplierIDSelected = CnvToInt32(dr["Id"]);
                int _idMaster = CnvToInt32(dr["Id"]);
                tbTmp = LoadData("DETAIL", _idMaster);
                grdTakeInDetail.DataSource = tbTmp;
            }
            this.CurrStateForm = EVENT_FORM_NONE;
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CurrStateForm.Equals(EVENT_FORM_NEW))
            {
                DataRow dr = ((DataRowView)cboWareHouse.GetSelectedDataRow()).Row;
                int l_WareHouse = CnvToInt32(dr["Id"]);
                DateTime l_date = txtTakeInDate.DateTime;
                DataTable l_Detail = (DataTable)grdTakeInDetail.DataSource;
                dr = ((DataRowView)txtSuppierID.GetSelectedDataRow()).Row;
                int l_supplier = CnvToInt32(dr["Id"]);
                int l_totalmat = CnvToInt32(grvTakeInDetail.Columns["bandedGridColumn8"].SummaryItem.SummaryValue);
                if (InsertData(l_Detail, l_WareHouse, l_totalmat, l_supplier, l_date, txtTakeInID.Text, txtTakeInBillNumber.Text))
                {
                    lstTakeIn.DataSource = LoadData("MASTER", -1);
                    lstTakeIn_SelectedIndexChanged(lstTakeIn, new EventArgs());
                }
            }
        }

        private void ResetForm()
        {
            txtSuppierID.Text = string.Empty;
            txtSupplierAddress.Text = string.Empty;
            txtSupplierPhone.Text = string.Empty;
            txtSupplierTaxCode.Text = string.Empty;
            txtTakeInDate.DateTime = DateTime.Now;
            txtTakeInID.Text = COREBASE.COMMAND.VPP_COMMAND.CTakeIn.getNextIDTakeIn(_ConfigItem);
            grdTakeInDetail.DataSource = makeTableDetail();
            txttakeInRemark.Text = string.Empty;
            SupplierIDSelected = -1;
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                AppDebug(ex);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (lstTakeIn.ItemCount > 0)
                {
                    DataRow dr = ((DataRowView)lstTakeIn.SelectedItem).Row;
                    if (DeleteTakeIn(CnvToInt32(dr["Id"])))
                    {
                        lstTakeIn.DataSource = LoadData("MASTER", -1);
                        lstTakeIn_SelectedIndexChanged(lstTakeIn, new EventArgs());
                    }
                }
            }
            catch (Exception ex)
            {
                AppDebug(ex);
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HasChangedOnControl(this))
            {
                if (ShowMessageBox("NHAPKHO_C_001", COREBASE.COMMAND.MessageUtils.MessageType.CONFIRM) == System.Windows.Forms.DialogResult.Yes)
                {
                    //TODO:GOI HAM SAVE LAI THONG TIN
                    if (CurrStateForm.Equals(EVENT_FORM_NEW))
                    {
                        DataTable l_tb = (DataTable)grdTakeInDetail.DataSource;
                        int l_idwh = CnvToInt32(getValue(cboWareHouse, cboWareHouse.Properties.ValueMember));
                        string l_remark = txttakeInRemark.Text;
                        DateTime l_date = CnvToDateTime(txtTakeInDate.EditValue);
                        int l_supplier = CnvToInt32(getValue(txtSuppierID, txtSuppierID.Properties.ValueMember));
                        string l_takeinid = txtTakeInID.Text;
                        int l_totalamt = CnvToInt32(grvTakeInDetail.Columns["bandedGridColumn8"].SummaryText);
                        //int L_MoneyType = 1;
                        InsertData(l_tb, l_idwh, 0, l_supplier, l_date, l_takeinid, txtTakeInBillNumber.Text);

                    }
                }
            }
            ResetForm();
            CurrStateForm = EVENT_FORM_NEW;
            AssignTagValueOnDXControl(this);
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HasChangedOnControl(this))
            {
                if (ShowMessageBox("NHAPKHO_C_001", COREBASE.COMMAND.MessageUtils.MessageType.CONFIRM) == System.Windows.Forms.DialogResult.Yes)
                {
                    //TODO:GOI HAM SAVE LAI THONG TIN
                }
            }
            ResetForm();
            CurrStateForm = EVENT_FORM_LOAD;
            AssignTagValueOnDXControl(this);
        }

        private void txtSuppierID_Properties_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = ((DataRowView)((LookUpEdit)sender).GetSelectedDataRow()).Row;
                txtSupplierAddress.Text = (CnvToString(dr["Address"]) == string.Empty) ? CnvToString(dr["Address"]) : CnvToString(dr["Address1"]);
                txtSupplierPhone.Text = (CnvToString(dr["Phone"]) == string.Empty) ? CnvToString(dr["Address"]) : CnvToString(dr["Phone1"]);
                txtSupplierTaxCode.Text = CnvToString(dr["TaxCode"]);
            }
            catch (Exception ex)
            {
                AppDebug(ex);
            }
        }

        private DataTable makeTableDetail()
        {
            DataTable tb = new DataTable("TAKEINDETAIL");
            tb.Columns.Add("Id", typeof(int));
            tb.Columns.Add("ROWID", typeof(int));
            tb.Columns.Add("Id_Dis", typeof(string));
            tb.Columns.Add("Take_In_Pk", typeof(int));
            tb.Columns.Add("Crt_By", typeof(string));
            tb.Columns.Add("Crt_Dt", typeof(DateTime));
            tb.Columns.Add("Mod_By", typeof(string));
            tb.Columns.Add("Mod_Dt", typeof(int));
            tb.Columns.Add("Is_Del", typeof(DateTime));
            tb.Columns.Add("Remark", typeof(string));
            tb.Columns.Add("Number_Bill", typeof(int));
            tb.Columns.Add("Number_Real", typeof(int));
            tb.Columns.Add("Price", typeof(float));
            tb.Columns.Add("Vat", typeof(float));
            tb.Columns.Add("Item_Pk", typeof(int));
            tb.Columns.Add("Unit_Pk", typeof(int));
            tb.Columns["ROWID"].AutoIncrement = true;
            tb.Columns["ROWID"].AutoIncrementStep = 1;
            tb.Columns["ROWID"].AutoIncrementSeed = 1;
            return tb;
        }

        private bool DeleteTakeIn(int p_IdTakeIn)
        {
            System.Data.SqlClient.SqlConnection _sqlConnection = new System.Data.SqlClient.SqlConnection(_ConfigItem.StrConnection); ;
            if (_sqlConnection.State != ConnectionState.Open) _sqlConnection.Open();
            System.Data.SqlClient.SqlTransaction _sqlTransaction = _sqlConnection.BeginTransaction();
            try
            {
                _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL();
                string[] arrName = new string[] { "@Id", "@Mod_By", "@Mod_Dt" };
                object[] arrValue = new object[] { p_IdTakeIn, _ConfigItem.Login_UserName, DateTime.Now };
                _providerSQL.ExecuteNonQuery(_sqlConnection, _sqlTransaction, "USP_DEL_TAKE_IN", arrName, arrValue);
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
                    _providerSQL.ExecuteNonQuery(_sqlConnection, _sqlTransaction, "USP_DEL_TAKE_IN_DETAIL", arrName, arrValue);
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

        private void grvTakeInDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Delete))
            {
                int[] l_selectRow = grvTakeInDetail.GetSelectedRows();
                DataTable l_tmp = ((DataView)grvTakeInDetail.DataSource).Table;
                if (CurrStateForm.Equals(EVENT_FORM_NEW))//Neu la truong hop them moi thi remote row do ra khoi grid
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
                        lstTakeIn.DataSource = LoadData("MASTER", -1);
                    }
                }
            }
        }

    }
}