using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace QLKHO
{
    public partial class FLASHSCREEN : COREBASE.FORM.BASEFORM
    {
        public string LbMessage
        {
            set { lbMessage.Text = value; }
        }
        private frmLogin objLogin;
        private DataTable tbUser;

        public FLASHSCREEN()
        {
            InitializeComponent();
            this.Shown += new EventHandler(FLASHSCREEN_Shown);
        }
        private void FLASHSCREEN_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = true;
        }
        void FLASHSCREEN_Shown(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void WaitTime(int intTime)
        {
            DateTime dt = DateTime.Now;
            while (dt.AddSeconds(intTime) > DateTime.Now)
            {

            }
        }

        private void InitData(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker bg = (BackgroundWorker)sender;
            try
            {
                bg.ReportProgress(1, "Đang tìm tập tin cấu hình!");
                //Kiem tra tap tinh cau hinh
                WaitTime(1);
                if (File.Exists(Application.StartupPath + @"\QLKHO.exe.config"))
                {
                    bg.ReportProgress(1, "Đang đọc tập tin cấu hình, nạp vào chương trình.");
                    _ConfigItem = LoadConfigFileInfo();
                    WaitTime(1);
                }
                else
                {
                    ShowMessageBox("FLASHSCREEN_E_000");
                    Close();
                    WaitTime(1);
                    bg.ReportProgress(1, EVENT_CLOSE_APP);
                }
                //load thong tin resource: Neu khong co thong tin tai nguyenm dung lai thong bao loi, ket thuc
                bg.ReportProgress(1, "Kiểm tra thông tin tài nguyên!");
                WaitTime(1);
                if (File.Exists( Application.StartupPath + "\\Resources\\Messages.xml"))
                {
                    bg.ReportProgress(1, "'Messages.xml' đã được nạp vào chương trình!");
                    WaitTime(1);
                }
                else
                {
                    ShowMessageBox("FLASHSCREEN_E_001");
                    Close();
                    WaitTime(1);
                    bg.ReportProgress(1, EVENT_CLOSE_APP);
                }
                //load tap hop cac component hien co tai thu muc chuong trinh: Neu khong co cac component bat buoc, thong bao loi, va dung lai
                bg.ReportProgress(3, "Đang đọc các thành phần của ứng dụng!");
                WaitTime(1);
                if (File.Exists(Application.StartupPath + "\\Resources\\Messages.xml"))
                {
                    WaitTime(2);
                    bg.ReportProgress(1, "'s23333333");
                }
                else
                {
                    WaitTime(1);
                    bg.ReportProgress(1, string.Empty);
                }
                
                //kiem tra ket noi voi server: Neu ket noi khong duoc, thong bao loi, dung lai
                bg.ReportProgress(3, "Đang thử kết nối đến cơ sở dữ liệu!");
                WaitTime(1);
                _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
                if (_providerSQL.CheckConnect())
                {
                    bg.ReportProgress(3, "Kết nối đến cơ sở dữ liệu thanh công!");
                    WaitTime(1);
                }
                else
                {
                    ShowMessageBox("FLASHSCREEN_E_002");
                    Close();
                    WaitTime(1);
                    bg.ReportProgress(1, EVENT_CLOSE_APP);
                    //TODO:Thong bao, ke noi khong duoc; ket thuc form
                }
                //Lay thong tin cac component o server"TABLE FUNCTION": Neu co conponent bi that lat, canh bao cho nguoi dung, va hoi co tiep tuc chay kkhong?
                //Neu con co, thi chay va waring cho nguoi dung bit la chuc nang do khong duoc su dung, va ung dung chay co the phat sinh loi
                bg.ReportProgress(3, "Đang kiểm chứng thực thành phần!");
                WaitTime(1);
                //Kiem tra thong tin ban quyen cua nguoi dung, neu khong co thi yeu cau nguoi dung nahpp vo
                //Kiem tra thong tin nguoi dung dang nhap co hay chua? neu chua xuat hien wizad de nguoi dung nhap thong tin nguoi dung de dang nhap vao chuong trinh
                bg.ReportProgress(3, "Đang kiểm thông tin người dùng!");
                WaitTime(1);
                
                //Lay thong tin nguoi dung load len
                bg.ReportProgress(3, "Đang đọc danh sách người dùng!");
                WaitTime(1);
                //Chuan bi thu muc ghi log
                bg.ReportProgress(3, "Đang kiểm tra thông tin nhật ký!");
                WaitTime(1);
                bg.ReportProgress(100,string.Empty);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                AppError(ex);
                //throw ex;
                DialogResult = System.Windows.Forms.DialogResult.No;
            }

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitData(sender, e);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            lbMessage.Text = CnvToString(e.UserState);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result.Equals(EVENT_CLOSE_APP))
                {
                    return;
                    //ket thuc event, khong load form
                }
                objLogin = new frmLogin();
                this.Hide();
                objLogin.ShowDialog();
                this.Close();
            }
        }
    }
}
