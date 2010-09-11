using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLKHO.FORM.NHAPXUAT
{
    public partial class XuatKho : COREBASE.FORM.BASEFORM
    {
        private string CurFormState = EVENT_FORM_LOAD;
        private const string  L_Load_MASTER = "MASTER";
        private const string L_Load_DETAIL = "DETAIL";
        
        public XuatKho(COREBASE.COMMAND.Config.ConfigItem _config)
        {
            InitializeComponent();
            _ConfigItem = _config;
        }

        private void txtSuppierID_Properties_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void XuatKho_Load(object sender, EventArgs e)
        {
            try
            {
                lstTakeOut.DataSource = LoadData(L_Load_MASTER, -1);
                lstTakeOut.DisplayMember = "Take_Out_Date";
                lstTakeOut.ValueMember = "Id";
                AssignTagValueOnDXControl(this);
                txtDeparmentID.Properties.DataSource = LoadDataDepartment();
                cboWareHouse.Properties.DataSource = COREBASE.COMMAND.VPP_COMMAND.CWareHouse.ListWareHouse(_ConfigItem);
               
                DATAOBJECT.ItemDao _item = new DATAOBJECT.ItemDao(_ConfigItem);
                repositoryItemGridLookUpEdit1.DataSource = _item.GetList();
                DATAOBJECT.UnitDao _unit = new DATAOBJECT.UnitDao(_ConfigItem);
                repositoryItemGridLookUpEdit2.DataSource = _unit.GetList();
            }
            catch (Exception ex)
            {
                AppDebug(ex);
                this.Close();
            }
        }

        private void btn_TakeOut_TaoMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ResetForm();
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
                case  L_Load_DETAIL:
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
                txtDeparmentID.Text = CnvToString(dr["Id_Supplier_Pk"]);
                txtTakeOutID.Text = CnvToString(dr["Id_Dis"]);
                txtTakeOutDate.DateTime = DateTime.Parse(CnvToString(dr["Take_In_Date"]));
                txttakeOutRemark.Text = CnvToString(dr["Remark"]);
                //SupplierIDSelected = CnvToInt32(dr["Id"]);
                int _idMaster = CnvToInt32(dr["Id"]);
                tbTmp = LoadData("DETAIL", _idMaster);
                grdTakeOutDetail.DataSource = tbTmp;
            }
            this.CurFormState = EVENT_FORM_NONE;

        }

        private void btn_TakeOut_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_TakeOut_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CurFormState.Equals(EVENT_FORM_NEW))
            {
                DataRow dr = ((DataRowView)cboWareHouse.GetSelectedDataRow()).Row;
                int l_WareHouse = CnvToInt32(dr["Id"]);
                DateTime l_date = txtTakeOutDate.DateTime;
                DataTable l_Detail = (DataTable)grdTakeOutDetail.DataSource;
                dr = ((DataRowView)txtDeparmentID.GetSelectedDataRow()).Row;
                int l_Deparment = CnvToInt32(dr["Id"]);
                int l_totalmat = CnvToInt32(grvTakeOutDetail.Columns["bandedGridColumn8"].SummaryItem.SummaryValue);
                //if (InsertData(l_Detail, l_WareHouse, l_totalmat, l_Deparment, l_date, txttakeOutRemark.Text, txtTakeOutID.Text))
                //{
                //    lstTakeOut.DataSource = LoadData("MASTER", -1);
                //    lstTakeOut_SelectedIndexChanged(lstTakeOut, new EventArgs());
                //}
            }
        }

        private void btn_TakeOut_Huy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HasChangedOnControl(this))
            {
                if (ShowMessageBox("XUATKHO_C_001", COREBASE.COMMAND.MessageUtils.MessageType.CONFIRM) == System.Windows.Forms.DialogResult.Yes)
                {
                    //TODO:GOI HAM SAVE LAI THONG TIN
                }
            }
            ResetForm();
            CurFormState = EVENT_FORM_LOAD;
            AssignTagValueOnDXControl(this);
        }
        private void ResetForm()
        {

            txtDeparmentID.Text = string.Empty;
            cboWareHouse.Text = string.Empty;
            txtDepartmentRemark.Text= string.Empty;
            txtDepartmentPhone.Text = string.Empty;
            txtTakeOutID.Text = COREBASE.COMMAND.VPP_COMMAND.CTakeOut.getNextIDTakeOut(_ConfigItem);
            txtTakeOutDate.Text = string.Empty;
            txttakeOutRemark.Text = string.Empty;
            grdTakeOutDetail.DataSource = makeTableDetail();

        
        }
        private DataTable makeTableDetail()
        {
            DataTable tb = new DataTable("TAKEOUTDETAIL");
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


    }
}
