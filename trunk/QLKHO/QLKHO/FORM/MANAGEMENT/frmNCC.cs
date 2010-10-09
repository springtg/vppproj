using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using COREBASE.COMMAND.Config;
using QLKHO.DATAOBJECT;
using QLKHO.BUSOBJECT;

namespace QLKHO.FORM.MANAGEMENT
{
    public partial class frmNCC : COREBASE.FORM.BASEFORM
    {
        IList<Supplier> lSupplier = null;
        public frmNCC(ConfigItem _config)
        {            
            InitializeComponent();
            _ConfigItem = _config;
            this.Load += new EventHandler(frmNCC_Load);
        }

        void frmNCC_Load(object sender, EventArgs e)
        {
            BidingGrid();
        }
        public void BidingGrid()
        {

            gvSupplier.DataSource = SupplierDao.GetListTable(_ConfigItem);
        }

        private void bntAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddSupplier frm = new frmAddSupplier(_ConfigItem, null);
            frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frm_FormClosed);
            frm.ShowDialog();
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BidingGrid();
        }

        private void bntUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                int[] _IndexRowSelected = gridView1.GetSelectedRows();
                int _CurIndexRow = _IndexRowSelected[0];
                Supplier _supplier = (Supplier)gridView1.GetRow(_CurIndexRow);
                frmAddSupplier f = new frmAddSupplier(_ConfigItem, _supplier);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    BidingGrid();
                }
            }
            catch (Exception ex)
            {
                //TODO: Ghi log tai day nhe
                throw ex;
            }
        }


        private void grdSupplier_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                int[] _IndexRowSelected = gridView1.GetSelectedRows();

                int _CurIndexRow = _IndexRowSelected[0];
                DataTable tmp = (DataTable)gvSupplier.DataSource;
                object[] obj = new object[1];
                obj[0] = tmp.Rows[_CurIndexRow]["Name"];
                if (ShowMessageBox("FRMADDSUPPLIER_C_002", COREBASE.COMMAND.MessageUtils.MessageType.CONFIRM, obj) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (SupplierDao.Delete(_ConfigItem, CnvToInt32(tmp.Rows[_CurIndexRow]["Id"])))
                    {
                        BidingGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Ghi log tai day nhe
                throw ex;
            }
        }
        private void Insert(DataRow row)
        {
            try
            {
                object[] arrParaValue = new object[] {
                    row["Name"],
                    row["Phone"],
                    row["Address"],
                    row["Fax"],
                    row["Email"],
                    row["Website"],
                    _ConfigItem.Login_UserName,
                    row["TaxCode"],
                    row["Credit"],
                    row["Debit"],

                };
                SupplierDao.Insert(_ConfigItem, arrParaValue);
            }
            catch (Exception ex)
            {
                AppDebug(ex);
            }
        }

        private bool Update(DataRow row)
        {
            try
            {

                object[] arrParaValue = new object[] {
                    row["Id"],
                    row["Name"],
                    row["Phone"],
                    row["Address"],
                    row["Fax"],
                    row["Email"],
                    row["Website"],
                    _ConfigItem.Login_UserName,
                    row["TaxCode"],
                    row["Credit"],
                    row["Debit"],
                };
                SupplierDao.Update(_ConfigItem, arrParaValue); return true;
            }
            catch (Exception ex)
            {
                AppDebug(ex);
                return false;
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {

                DataTable Tmp = (DataTable)(gvSupplier.DataSource);
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
                        SupplierDao.Delete(_ConfigItem, (int)GetOriginalItemData(dr, "Id"));

                    }
                }
                BidingGrid();
            }
            catch (Exception ex)
            {
                AppDebug(ex);
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
                    DataTable tmp = (DataTable)gvSupplier.DataSource;

                    object[] obj = new object[1];
                    obj[0] = tmp.Rows[_CurIndexRow]["Name"];
                    if (ShowMessageBox("FRMADDSUPPLIER_C_002", COREBASE.COMMAND.MessageUtils.MessageType.CONFIRM, obj) == System.Windows.Forms.DialogResult.Yes)
                    {

                        SupplierDao.Delete(_ConfigItem, CnvToInt32(tmp.Rows[_CurIndexRow]["Id"]));
                        BidingGrid();
                    }
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