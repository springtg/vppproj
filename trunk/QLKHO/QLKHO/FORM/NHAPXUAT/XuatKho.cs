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
                txtDeparmentID.Properties.DataSource = LoadDataDepartment();
                cboWareHouse.Properties.DataSource = COREBASE.COMMAND.VPP_COMMAND.CWareHouse.ListWareHouse(_ConfigItem);
                lstTakeOut.DataSource = LoadData(L_Load_MASTER, -1);
                lstTakeOut.DisplayMember = "Take_Out_Date";
                lstTakeOut.ValueMember = "Id";
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
    }
}
