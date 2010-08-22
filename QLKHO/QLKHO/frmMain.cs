using System;
using DevExpress.XtraBars;

namespace QLKHO
{
    public partial class frmMain : COREBASE.FORM.BASEMDIPARENT// DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
           
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

        private void navBarControl1_Click(object sender, EventArgs e)
        {

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

     

  
     
    }
}