using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLKHO.FORM.NHAPXUAT
{
    public partial class NhapKho : COREBASE.FORM.BASEFORM
    {
        private string CurrStateForm = EVENT_FORM_LOAD;
        private int SupplierIDSelected = -1;

        public NhapKho(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            InitializeComponent();
            _ConfigItem = _ConfItem;
        }

        private void NhapKho_Load(object sender, EventArgs e)
        {
            DataTable tbTmp = LoadData("MASTER", -1);
            lstTakeIn.DataSource = tbTmp;
            lstTakeIn.DisplayMember = "Id_Dis";
            lstTakeIn.ValueMember = "Id";
            AssignTagValueOnDXControl(this);
            //LAY THONG TIN CHO CAC COMBOBOX
            _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
            txtSuppierID.Properties.DataSource = _providerSQL.GetDataByStoredProcedure("usp_SelectVPP_SUPPLIER");
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

        private bool TakeIn(DataTable tbDetail, int _id_WareHouse, int _TotalAMT,int _iId_Supplier_Pk,DateTime _iTake_In_Date)
        {

            System.Data.SqlClient.SqlConnection _sqlConnection = null;
            try
            {
                int _iNumberItem = tbDetail.Rows.Count;
                _sqlConnection = new System.Data.SqlClient.SqlConnection(_ConfigItem.StrConnection);
                _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
                _providerSQL.Connect(_sqlConnection, _ConfigItem);
                string[] arrName = new string[] { "@Number_Item", "@Crt_By", "@TotalAMT", "@Id_WareHouse", "@Id_Supplier_Pk", "@Take_In_Date" };
                object[] arrValue = new object[] { _iNumberItem, _ConfigItem.Login_UserName, _TotalAMT, _id_WareHouse, _iId_Supplier_Pk, _iTake_In_Date };
                int _idMaster = _providerSQL.ExecuteInsert(_sqlConnection, "USP_IN_TAKE_IN", arrName, arrValue);
                for (int i = 0; i < _iNumberItem; i++)
                {
                    arrName = new string[] { 
                        "@Item_Take_In_Pk", 
                        "@Crt_By", 
                        "@Remark", 
                        "@Number_Bill", 
                        "@Number_Real",
                        "@Unit_Price", 
                        "@Vat" 
                    };
                    arrValue = new object[] {
                        _idMaster,
                        _ConfigItem.Login_UserName,
                        string.Empty,
                        tbDetail.Rows[i]["Number_Bill"],
                        tbDetail.Rows[i]["Number_Real"],
                        tbDetail.Rows[i]["Unit_Price"],
                        tbDetail.Rows[i]["Vat"],
                    };
                    _providerSQL.ExecuteNonQuery(_sqlConnection, "USP_INS_TAKE_IN_DETAIL", arrName, arrValue);
                }
                _providerSQL.Disconnect(_sqlConnection);
                return true;
            }
            catch (Exception ex)
            {
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
                txtSuppierID.Text = CnvToString(dr["Id_Supplier_Pk"]);
                txtTakeInID.Text = CnvToString(dr["Id_Dis"]);
                txtTakeInDate.DateTime = DateTime.Parse(CnvToString(dr["Take_In_Date"]));
                txttakeInRemark.Text = CnvToString(dr["Remark"]);
                SupplierIDSelected = CnvToInt32(dr["Id"]);
                int _idMaster = CnvToInt32(dr["Id"]);
                tbTmp = LoadData("DETAIL", _idMaster);
                grdTakeInDetail.DataSource = tbTmp;
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CurrStateForm.Equals(EVENT_FORM_NEW))
            {

                DataRow dr = (DataRow)cboWareHouse.SelectedItem;
                int l_WareHouse = CnvToInt32(dr["Id"]);
                DateTime l_date = txtTakeInDate.DateTime;
                DataTable l_Detail = (DataTable)grdTakeInDetail.DataSource;
                // TakeIn
            }
        }

        private void ResetForm()
        {
            txtSuppierID.Text = string.Empty;
            txtSupplierAddress.Text = string.Empty;
            txtSupplierName.Text = string.Empty;
            txtSupplierPhone.Text = string.Empty;
            txtSupplierRemark.Text = string.Empty;
            txtSupplierTaxCode.Text = string.Empty;
            txtTakeInDate.DateTime = DateTime.Now;
            txtTakeInID.Text = string.Empty;
            _providerSQL=new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
            grdTakeInDetail.DataSource=null;
            txttakeInRemark.Text = CnvToString(_providerSQL.ExecuteInsert("USP_SEL_TAKE_IN_ID"));
            SupplierIDSelected = -1;
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HasChangedOnControl(this))
            {
                if (ShowMessageBox("NHAPKHO_C_001", COREBASE.COMMAND.MessageUtils.MessageType.CONFIRM) == System.Windows.Forms.DialogResult.Yes)
                {
                    //TODO:GOI HAM SAVE LAI THONG TIN
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

    }
}