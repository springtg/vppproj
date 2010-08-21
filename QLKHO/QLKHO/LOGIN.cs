using System;
using System.Windows.Forms;


namespace QLKHO
{
    public partial class frmLogin : COREBASE.FORM.BASEFORM
    {
        private bool listUserLoaded = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            FLASHSCREEN _flash = new FLASHSCREEN();
            if (_flash.ShowDialog() == DialogResult.OK)
            {

                //_ConfigItem = 
            }
            else
            {
                Close();
            }
            //LoginInfo = new CUserLoginInfo();
            //providerSQL = new VXS.ERP.UTL0001.SQL.CAccessSQL(ConfigSystem);
            //if (providerSQL.CheckConnect())
            //{
            //    ShowBTN1("Trợ Giúp", "Help");
            //   // LoadUser(providerSQL);
            //}
            //else
            //{
            //    //ConfigForm.ConfigForm config = new ConfigForm.ConfigForm();
            //    //config.FormClosed += new FormClosedEventHandler(config_FormClosed);
            //    //config.Show(0);

            //}
            //UTL0002.MDIPARENT mdi = new VXS.ERP.UTL0002.MDIPARENT();
            //mdi.Show();

            //GSM0002.GSM0002 gsm = new GSM0002.GSM0002();
            //gsm.Show();

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

        //private void LoadUser(VXS.ERP.UTL0001.SQL.CAccessSQL provider)
        //{
        //    //try
        //    //{
        //    //    lstMember.DataSource = provider.GetDataByStoredProcedure("sp_Select_ListMember");
        //    //    lstMember.DisplayMember = "FullName";
        //    //    lstMember.ValueMember = "UserName";
        //    //    listUserLoaded=true;
        //    //}
        //    //catch
        //    //{
        //    //    listUserLoaded = false;
        //    //}

        //}

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (!ValidateForm())
            //{
            //    return;
            //}
            //if (UserLogin())
            //{
            //    MainProject.MainMDIPaarent1 formmain = new MainProject.MainMDIPaarent1();
            //    formmain.Username = dtLoginInfo.Rows[0]["UserName"].ToString().Trim();
            //    formmain.FullName = dtLoginInfo.Rows[0]["FullName"].ToString().Trim();
            //    formmain.ID = int.Parse(dtLoginInfo.Rows[0]["ID"].ToString().Trim());
            //    formmain.AuthenticationID = int.Parse(dtLoginInfo.Rows[0]["AuthenticationID"].ToString().Trim());
            //    userLoginInfo.FullName = formmain.FullName;
            //    userLoginInfo.UserName = formmain.Username;
            //    userLoginInfo.ID = formmain.ID;
            //    userLoginInfo.Authentication = formmain.AuthenticationID;
            //    formmain.UserLoginInfo = userLoginInfo;
            //    formmain.Show();
            //    this.Hide();
            //    formmain.FormClosed += new FormClosedEventHandler(formmain_FormClosed);

            //}
            //else
            //{
            //    MessageBox.Show("Đăng Nhập Không Thành Công!", MessageBoxManager.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

        }

        void formmain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.txtPassword.Text = "";
            this.Show();
        }

        private bool UserLogin()
        {
            //try
            //{
            //    UTLDB.UTLDB provider = new UTLDB.UTLDB();
            //    string[] paraname = {"@username",   "@password"};
            //    string[] paravalue = {this.txtUserName.Text, UTLCOMMAND.CryptorEngine.Encrypt( this.txtPassword.Text.Trim(),true)};
            //    dtLoginInfo = new DataTable();
            //    dtLoginInfo = provider.GetDataByStoredProcedure("sp_Login", paraname, paravalue);
            //    if (dtLoginInfo.Rows.Count < 1)
            //    {
            //        return false;
            //    }
            return true;
            //}
            //catch
            //{
            //    dtLoginInfo = null;
            //    return  false;
            //}
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
            //if (txtUserName.Text.Trim().Equals(""))
            //{
            //    MessageBox.Show("Bạn Chưa nhập 'Tên Đăng Nhập'", MessageBoxManager.Caption);
            //    txtUserName.Focus();
            //    return false;
            //}
            //if (txtPassword.Text.Trim().Equals(""))
            //{
            //    MessageBox.Show("Bạn Chưa nhập 'Mật Khẩu'", MessageBoxManager.Caption);
            //    txtPassword.Focus();
            //    return false;
            //}
            return true;
        }
    }
}