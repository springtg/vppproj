using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using COREBASE.COMMAND.Config;
using QLKHO.DATAOBJECT;
using QLKHO.BUSOBJECT;

namespace QLKHO.FORM.MANAGEMENT
{
    public partial class frmNCC : COREBASE.FORM.BASEFORM
    {
        SupplierDao Dao;
        IList<Supplier> lSupplier = null;
        public frmNCC(ConfigItem _config)
        {
            _ConfigItem = _config;
            Dao = new SupplierDao(_config);
            InitializeComponent();
            this.Load += new EventHandler(frmNCC_Load);
        }

        void frmNCC_Load(object sender, EventArgs e)
        {
            BidingGrid();
        }
        public void BidingGrid()
        {
            lSupplier = Dao.GetUserList();
            grdSupplier.DataSource = lSupplier;
        }

        private void bntAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddSupplier frm = new frmAddSupplier(_ConfigItem,null);
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

                int[] _IndexRowSelected = grvSupplier.GetSelectedRows();
                int _CurIndexRow = _IndexRowSelected[0];
                Supplier _supplier = (Supplier)grvSupplier.GetRow(_CurIndexRow);
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

                int[] _IndexRowSelected = grvSupplier.GetSelectedRows();
                int _CurIndexRow = _IndexRowSelected[0];
                Supplier _supplier =(Supplier) grvSupplier.GetRow(_CurIndexRow);
                Dao = new SupplierDao(_ConfigItem);
                object[] obj = new object[1];
                obj[0] = _supplier.Name;
                if (ShowMessageBox("FRMADDSUPPLIER_C_002", COREBASE.COMMAND.MessageUtils.MessageType.CONFIRM,obj)== System.Windows.Forms.DialogResult.Yes)
                {
                    if (Dao.Delete(_supplier.Id))
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

    }
}