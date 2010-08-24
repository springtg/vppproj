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
        IList<Supplier> lSupplier=null;
        public frmNCC(ConfigItem _config)
        {

            Dao = new SupplierDao(_config);
             InitializeComponent();
             this.Load += new EventHandler(frmNCC_Load);
        }

        void frmNCC_Load(object sender, EventArgs e)
        {
            BidingGrid();
        }
        public void BidingGrid() {
            lSupplier = Dao.GetUserList();
            grdSupplier.DataSource = lSupplier;
        }

        private void bntAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddSupplier frm = new frmAddSupplier();
            frm.ShowDialog();
        }

       

    
    


    }
}