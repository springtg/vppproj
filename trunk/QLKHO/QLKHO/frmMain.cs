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
            frmNCC frm = new frmNCC();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bar2tab1btn2_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmNCC frm = new frmNCC();
            frm.MdiParent = this;
            frm.Show();
        }

        #endregion
        #region"Quản lý hàng hóa"
        private void bar2tab2btn1_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmNCC frm = new frmNCC();
            frm.MdiParent = this;
            frm.Show();
        }
        private void bar2tab2btn2_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmNCC frm = new frmNCC();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bar2tab2btn3_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmNCC frm = new frmNCC();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bar2tab2btn4_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmNCC frm = new frmNCC();
            frm.MdiParent = this;
            frm.Show();
        }
        #endregion




    }
}