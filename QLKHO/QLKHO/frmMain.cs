﻿using System;
using DevExpress.XtraBars;
using QLKHO.FORM.MANAGEMENT;
using System.Windows.Forms;
using System.Data;
using QLKHO.DATAOBJECT;
using System.Collections;
namespace QLKHO
{
    public partial class frmMain : COREBASE.FORM.BASEMDIPARENT
    {
        public frmMain(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            InitializeComponent();
            _ConfigItem = _ConfItem;
            barlblUser.Caption = _ConfigItem.Login_FullName;
            bntLogin.Visibility = BarItemVisibility.Never;
            AccessRole();
            bar1tab1btn1.Visibility = BarItemVisibility.Never;

        }
        public void HideTab()
        {
            bar1.Visible = false;
            bar2.Visible = false;
            bar3.Visible = false;
            bar4.Visible = false;
            navBar1.Visible = false;
            navBar2.Visible = false;

        }

        private void AccessRole()
        {
            HideTab();
            object[] arrParaValue = new object[] {
                  _ConfigItem.Login_ID
                };
            DataTable dt = UserRoleDao.GetListRoleByUID(_ConfigItem, arrParaValue);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Is_Active"].ToString() == "1")
                {
                    switch (dt.Rows[i]["NameControl"].ToString().Trim())
                    {
                        case "bar1":
                            bar1.Visible = true;
                            navBar1.Visible = true;
                            break;
                        case "bar2":
                            bar2.Visible = true;
                            break;
                        case "bar3":
                            bar3.Visible = true;
                            break;
                        case "bar4":
                            bar4.Visible = true;
                            navBar2.Visible = true;
                            break;

                    }
                }
            }
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
            BarEditItem tmp = (BarEditItem)sender;
            try
            {
                if (!DevExpress.Skins.SkinManager.AllowFormSkins)
                    DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = tmp.EditValue.ToString(); ;
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, tmp.Name);
            }
        }

        private void bar1tab2btn1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongtinUser frm = new frmThongtinUser();
            try
            {
                if (!isOpen(frm))
                {
                    frm.MdiParent = this;
                    frm.Show();
                }
                else
                {
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, frm.Text);
            }

        }

        #region "Quản lý đối tượng"
        /// <summary>
        /// Su kien goi form hien thi nha cung cap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bar2tab1btn1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNCC frm = new frmNCC(_ConfigItem);
            try
            {

                if (!isOpen(frm))
                {
                    frm.MdiParent = this;
                    frm.Show();
                }
                else
                {
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, frm.Text);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bar2tab1btn2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNCC frm = new frmNCC(_ConfigItem);
            try
            {

                if (!isOpen(frm))
                {
                    frm.MdiParent = this;
                    frm.Show();
                }
                else
                {
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, frm.Text);
            }
        }

        #endregion
        #region"Quản lý hàng hóa"
        private void bar2tab2btn1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCatalog frm = new frmCatalog(_ConfigItem);
            try
            {
                if (!isOpen(frm))
                {
                    frm.MdiParent = this;
                    frm.Show();
                }
                else
                {
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, frm.Text);
            }
        }

        private void bar2tab2btn2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmGroupItem frm = new frmGroupItem(_ConfigItem);
            try
            {

                if (!isOpen(frm))
                {
                    frm.MdiParent = this;
                    frm.Show();
                }
                else
                {
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, frm.Text);
            }
        }

        private void bar2tab2btn3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmItem frm = new frmItem(_ConfigItem);
            try
            {

                if (!isOpen(frm))
                {
                    frm.MdiParent = this;
                    frm.Show();
                }
                else
                {
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, frm.Text);
            }
        }

        private void bar2tab2btn4_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDonVi f = new frmDonVi(_ConfigItem);
            try
            {
                if (!isOpen(f))
                {
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    f.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }
        #endregion
        #region "Quản lý tổ chức"
        private void bar2tab3btn1_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmPhongBan frm = new frmPhongBan(_ConfigItem);
            try
            {
                if (!isOpen(frm))
                {
                    frm.MdiParent = this;
                    frm.Show();
                }
                else
                {
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, frm.Text);
            }
        }
        #endregion
        #region "Hệ thống"
        private void bar1tab1bt2_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        private void bar1tab1btn1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        private void bar1tab1btn2_ItemClick(object sender, ItemClickEventArgs e)
        {
            FORM.SYSTEM.frmBacupkRestore f = new FORM.SYSTEM.frmBacupkRestore(_ConfigItem);
            try
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }
        private void bar1tab1btn4_ItemClick(object sender, ItemClickEventArgs e)
        {
            QLKHO.FORM.SYSTEM.frmRole f = new QLKHO.FORM.SYSTEM.frmRole(_ConfigItem);
            try
            {

                if (!isOpen(f))
                {
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    f.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }
        #endregion

        #region "Báo Cáo"

        private void bar4tab1btn1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FORM.BAOCAO.frmRptNhap f = new FORM.BAOCAO.frmRptNhap(_ConfigItem);
            try
            {

                if (!isOpen(f))
                {
                    f.MdiParent = this;
                    f.ShowRPT(0);
                }
                else
                {
                    f.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }

        private void bar4tab1btn2_ItemClick(object sender, ItemClickEventArgs e)
        {
            FORM.BAOCAO.frmRptNhap f = new FORM.BAOCAO.frmRptNhap(_ConfigItem);
            try
            {

                f.MdiParent = this;
                f.ShowRPT(1);
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }

        private void bar4bnt6_ItemClick(object sender, ItemClickEventArgs e)
        {
            FORM.BAOCAO.frmRptNhap f = new FORM.BAOCAO.frmRptNhap(_ConfigItem);
            try
            {

                f.MdiParent = this;
                f.ShowRPT(2);

            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }
        private void bar4tab2btn2_ItemClick(object sender, ItemClickEventArgs e)
        {
            FORM.BAOCAO.frmRptNhap f = new FORM.BAOCAO.frmRptNhap(_ConfigItem);
            try
            {

                    f.MdiParent = this;
                    f.ShowRPT(3);
            
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }

        private void bar4tab1btn3_ItemClick(object sender, ItemClickEventArgs e)
        {
            FORM.BAOCAO.frmRptTonKho f = new FORM.BAOCAO.frmRptTonKho(_ConfigItem);
            try
            {

                    f.MdiParent = this;
                    f.ShowRPT(0);
            
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }


        #endregion
        private void bar2tab3btn2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUser f = new frmUser(_ConfigItem);
            try
            {

                if (!isOpen(f))
                {
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    f.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }

        private void bar3tab1btn1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FORM.NHAPXUAT.NhapKho f = new FORM.NHAPXUAT.NhapKho(_ConfigItem);
            try
            {

                if (!isOpen(f))
                {
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    f.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }

        private void bar3tab1btn2_ItemClick(object sender, ItemClickEventArgs e)
        {
            FORM.NHAPXUAT.XuatKho f = new FORM.NHAPXUAT.XuatKho(_ConfigItem);
            try
            {

                if (!isOpen(f))
                {
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    f.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }

        private void bar3tab2btn4_ItemClick(object sender, ItemClickEventArgs e)
        {
            //goi sp usp_vpp_ketchuyenkho

            if (COREBASE.COMMAND.VPP_COMMAND.CInventory.ketchuyen(_ConfigItem) == true)
                MessageBox.Show("Đã kết chuyển thành công", MessageBoxManager.Caption);
            else
                MessageBox.Show("Tháng này kết chuyển rồi", MessageBoxManager.Caption);


        }

        private void bar1tab3btn1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// Su kien goi form quy cach hang hoa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bartab2bnt5_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUnitStyle f = new frmUnitStyle(_ConfigItem);
            try
            {

                if (!isOpen(f))
                {
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    f.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }

        private void bar1tab2btn3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //try
            //{
            //    REPORT.Demo f = new  REPORT.Demo(_ConfigItem);
            //    f.MdiParent = this;
            //    f.Show();
            //}
            //catch (Exception ex)
            //{

            //}
        }


        private void bntLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("http://kimhoangad.com");
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            bar4tab1btn3_ItemClick(null, null);
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            bar4tab2btn2_ItemClick(null, null);
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            bar4tab1btn1_ItemClick(null, null);
        }

        private void navBarNhap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            bar3tab1btn1_ItemClick(null, null);
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            bar3tab1btn2_ItemClick(null, null);
        }

        private bool isOpen(Form p_Form)
        {
            foreach (Form f in tabMdi.MdiParent.MdiChildren)
            {
                if (f.Name.Equals(p_Form.Name))
                {
                    f.Activate();
                    f.ActiveMdiChild.BringToFront();
                    return true;
                }
            }
            return false;
        }



        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void bar4bnt5_ItemClick(object sender, ItemClickEventArgs e)
        {
            FORM.BAOCAO.frmRptTonKho f = new FORM.BAOCAO.frmRptTonKho(_ConfigItem);
            try
            {

                    f.MdiParent = this;
                    f.ShowRPT(1);
              
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }

        private void bar2bnt3_ItemClick(object sender, ItemClickEventArgs e)
        {
            FORM.NHAPXUAT.ChuyenPhong f = new FORM.NHAPXUAT.ChuyenPhong(_ConfigItem);
            try
            {

                if (!isOpen(f))
                {
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    f.Dispose();
                }
            }
            catch (Exception ex)
            {
                AppError(ex);
                ShowMessageBox("MAIN_E_000", COREBASE.COMMAND.MessageUtils.MessageType.ERROR, f.Text);
            }
        }

    }
}