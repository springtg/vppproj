﻿using System;
using System.Windows.Forms;
using System.Data;


namespace QLKHO
{
    public partial class frmLogin : COREBASE.FORM.BASEFORM
    {
        private bool listUserLoaded = false;
        DataTable tbUser = null;

        public frmLogin()
        {
            InitializeComponent();
        }
        public frmLogin(COREBASE.COMMAND.Config.ConfigItem _confItem)
        {
            InitializeComponent();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            FLASHSCREEN _flash = new FLASHSCREEN();
            if (_flash.ShowDialog() == DialogResult.OK)
            {
                tbUser = (DataTable)_flash.TbUser;
                lstMember.DisplayMember = "Name_Dis";
                lstMember.ValueMember = "ID";
                lstMember.DataSource = tbUser;
                _ConfigItem = _flash.getConfig;
            }
            else
            {
                Close();
            }
        }
        void LoadUser()
        {
            FLASHSCREEN _flash = new FLASHSCREEN();
            _flash.TbUser= COREBASE.COMMAND.VPP_COMMAND.CUser.ListUser(_flash.getConfig);
            
            if (_flash.ShowDialog() == DialogResult.OK)
            {
                tbUser = (DataTable)_flash.TbUser;
                lstMember.DisplayMember = "Name_Dis";
                lstMember.ValueMember = "ID";
                lstMember.DataSource = tbUser;
                _ConfigItem = _flash.getConfig;
            }
            else
            {
                Close();
            }
        }
        void config_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (MessageBox.Show("Bạn có muốn khởi động lại ứng dụng không?", MessageBoxManager.Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    Application.Restart();
            //}
            //else
            //{
            //    this.Close();
            //}
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            CheckLogin();
        }
        private void CheckLogin()
        {
            AppDebug("sdfdsfds");
            if (!ValidateForm())
            {
                return;
            }
            if (COREBASE.COMMAND.VPP_COMMAND.CUser.LoginUser(_ConfigItem, txtUserName.Text, txtPassword.Text))
            {
                DataRow rw = tbUser.Rows[lstMember.SelectedIndex];
                int pos = 0;
                for(int i=0;i<tbUser.Rows.Count;i++)
                    if (txtUserName.Text.Equals(tbUser.Rows[i]["Name"]) && txtPassword.Text.Equals(tbUser.Rows[i]["Password"]))
                    {
                        pos = i;
                        break;
                    }
                _ConfigItem.Login_FullName = CnvToString(tbUser.Rows[pos]["Name_Dis"]);
                _ConfigItem.Login_UserName=CnvToString(tbUser.Rows[pos]["Name"]);
                _ConfigItem.Login_ID = CnvToInt32(tbUser.Rows[pos]["Id"]);
                //_ConfigItem.Login_FullName = CnvToString(rw["Name_Dis"]);
                //_ConfigItem.Login_ID = CnvToInt32(rw["Id"]);
                //_ConfigItem.Login_UserName = CnvToString(rw["Name"]);
                frmMain frmmain = new frmMain(_ConfigItem);

                //formmain.Username = dtLoginInfo.Rows[0]["UserName"].ToString().Trim();
                //formmain.FullName = dtLoginInfo.Rows[0]["FullName"].ToString().Trim();
                //formmain.ID = int.Parse(dtLoginInfo.Rows[0]["ID"].ToString().Trim());
                //formmain.AuthenticationID = int.Parse(dtLoginInfo.Rows[0]["AuthenticationID"].ToString().Trim());
                //userLoginInfo.FullName = formmain.FullName;
                //userLoginInfo.UserName = formmain.Username;
                //userLoginInfo.ID = formmain.ID;
                //userLoginInfo.Authentication = formmain.AuthenticationID;
                //formmain.UserLoginInfo = userLoginInfo;
                this.Hide();
                frmmain.FormClosed += new FormClosedEventHandler(formmain_FormClosed);
                frmmain.Show();
            }
            else
            {
                MessageBox.Show("Đăng Nhập Không Thành Công!", MessageBoxManager.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void formmain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.txtPassword.Text = "";
            this.Show();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.ExitThread();
            Application.Exit();

        }

        private void lstMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listUserLoaded)
            {
                this.txtUserName.Text = lstMember.SelectedValue.ToString().Trim();
            }
        }

        private bool ValidateForm()
        {
            if (txtUserName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn Chưa nhập 'Tên Đăng Nhập'", MessageBoxManager.Caption);
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn Chưa nhập 'Mật Khẩu'", MessageBoxManager.Caption);
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                CheckLogin();
        }
    }
}