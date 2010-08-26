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
        Supplier supplier = null;

        public frmAddSupplier(ConfigItem _config, Supplier _SupperCurrEdit)
        {
            InitializeComponent();
            //Neu la edit thi co gia tri supplier truyen qua. Neu khong co thi la them moi!
            if (_SupperCurrEdit != null)
            {
                supplier = _SupperCurrEdit;
            }
            _ConfigItem = _config;
            this.Load += new EventHandler(frmAddSupplier_Load);
        }

        void frmAddSupplier_Load(object sender, EventArgs e)
        {            
            //Neu la them moi, thi neu obj ra
            if (supplier == null)
            {
                Dao = new SupplierDao(_ConfigItem);
                supplier = new Supplier();
            }
            else//Neu la edit lay thong tin hien thi len form
            {
                SetFormSupplier(supplier);
            }
            AssignTagValueOnDXControl(this);//gan gia tri ban dau cho form
        }

        private void SetFormSupplier(Supplier _SupperCurrEdit)
        {
            try
            {
                txtName.Text = _SupperCurrEdit.Name;
                txtPhone1.Text = _SupperCurrEdit.Phone;
                txtPhone2.Text = _SupperCurrEdit.Phone1;
                txtAddress1.Text = _SupperCurrEdit.Address;
                txtAddress2.Text = _SupperCurrEdit.Address1;
                txtFax.Text = _SupperCurrEdit.Fax;
                txtEmail.Text = _SupperCurrEdit.Email;
                txtWeb.Text = _SupperCurrEdit.Website;
                txtTax.Text = _SupperCurrEdit.TaxCode;
                txtCredit.Text = _SupperCurrEdit.Credit;
                txtDebit.Text = _SupperCurrEdit.Debit;
            }
            catch (Exception ex)
            {
                AppError("frmAddSupplier:GetFormSupplier():" + ex);
            }
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

        private void frmAddSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasChangedOnDXControl(this))
            {
                if (ShowMessageBox("FRMADDSUPPLIER_C_001", COREBASE.COMMAND.MessageUtils.MessageType.CONFIRM) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }



    }
}