using System;
using DevExpress.XtraBars;
using QLKHO.FORM.MANAGEMENT;

namespace QLKHO
{
    public partial class frmMain : COREBASE.FORM.BASEMDIPARENT// DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
        public frmMain(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            InitializeComponent();
            _ConfigItem = _ConfItem; 
        }

        private bool IsExist(string frmName)
        {
            if (tabMdi.Pages.Count < 1) return false;
            for (int i = 0; i < tabMdi.Pages.Count; i++)
            {
                if (tabMdi.Pages[i].Text.Equals(frmName)) return true;
            }
            return false;
        }

        private int getIndexPages(string frmName)
        {
            if (tabMdi.Pages.Count < 1) return -1;
            for (int i = 0; i < tabMdi.Pages.Count; i++)
            {
                if (tabMdi.Pages[i].Text.Equals(frmName)) return i;
            }
            return -1;
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                BarEditItem tmp = (BarEditItem)sender;

                //DevExpress.UserSkins.BonusSkins.Register();
                //DevExpress.UserSkins.OfficeSkins.Register();
                if (!DevExpress.Skins.SkinManager.AllowFormSkins)
                    DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = tmp.EditValue.ToString(); ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void bar1tab2btn1_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmThongtinUser frm = new frmThongtinUser();
            frm.MdiParent = this;
            frm.Show();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
        #region "Quản lý đối tượng"
        private void bar2tab1btn1_ItemClick(object sender, ItemClickEventArgs e)
        {
           if ( !IsExist("frmNCC"))
            {
                frmNCC frm = new frmNCC(_ConfigItem);
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                //TODO: active page suo mo roi
            }
        }

        private void bar2tab1btn2_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmNCC frm = new frmNCC(_ConfigItem);
            frm.MdiParent = this;
            frm.Show();
        }

        #endregion
        #region"Quản lý hàng hóa"
        private void bar2tab2btn1_ItemClick(object sender, ItemClickEventArgs e)
        {
             


            frmNCC frm = new frmNCC(_ConfigItem);
            frm.MdiParent = this;
            frm.Show();
        }
        private void bar2tab2btn2_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmNCC frm = new frmNCC(_ConfigItem);
            frm.MdiParent = this;
            frm.Show();
        }

        private void bar2tab2btn3_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmNCC frm = new frmNCC(_ConfigItem);
            frm.MdiParent = this;
            frm.Show();
        }

        private void bar2tab2btn4_ItemClick(object sender, ItemClickEventArgs e)
        {
            //DONVI
            if (!IsExist("frmDonVi"))
            {
                frmDonVi f = new frmDonVi(_ConfigItem);
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion
        #region "Quản lý tổ chức"
        private void bar2tab3btn1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsExist("frmPhongBan"))
            {
                frmPhongBan frm = new frmPhongBan(_ConfigItem);
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                //TODO: active page suo mo roi
            }
        }
        #endregion



    }
}