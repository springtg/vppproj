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
    public partial class frmAddSupplier : COREBASE.FORM.BASEFORM
    {
        SupplierDao Dao;
        Supplier supplier;
        public frmAddSupplier(ConfigItem _config)
        {
            _ConfigItem = _config;
            Dao = new SupplierDao(_ConfigItem);
            supplier = new Supplier();
            InitializeComponent();
            this.Load += new EventHandler(frmAddSupplier_Load);
        }

        void frmAddSupplier_Load(object sender, EventArgs e)
        {

        }

        private void GetFormSupplier()
        {
            try
            {
                supplier.Name = txtName.Text;
                supplier.Phone = txtPhone1.Text;
                supplier.Phone1 = txtPhone2.Text;
                supplier.Address = txtAddress1.Text;
                supplier.Address1 = txtAddress2.Text;
                supplier.Fax = txtFax.Text;
                supplier.Email = txtEmail.Text;
                supplier.Website = txtWeb.Text;
                supplier.Crt_Dt = DateTime.Now;
                supplier.Crt_By = _ConfigItem.Login_UserName;
                supplier.Mod_Dt = DateTime.Now;
                supplier.Mod_By = string.Empty;
                supplier.Is_Del = 0;
                supplier.TaxCode = txtTax.Text;
                supplier.Credit = txtCredit.Text;
                supplier.Debit = txtDebit.Text;
            }
            catch (Exception ex)
            {
                AppError("frmAddSupplier:GetFormSupplier():" + ex);
            }

        }
        private int Insert()
        {
            try
            {
                return Dao.Insert(supplier: supplier);
            }
            catch (Exception ex)
            {
                AppError("frmAddSupplier:Insert():" + ex);
                return 0;
            }
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            GetFormSupplier();
            if (Insert() != 0)
                ShowMessageBox("FORMMAIN_001");
            else ShowMessageBox("FORMMAIN_002");
            this.Close();
        }



    }
}