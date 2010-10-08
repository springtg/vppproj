namespace COREBASE.COMMAND.Config
{
    public class ConfigItem
    {
        #region "Thong tin ve phan mem"
        private string strActiveKey;

        public string StrActiveKey
        {
            get { return strActiveKey; }
            set { strActiveKey = value; }
        }

        private string strSerial;

        public string StrSerial
        {
            get { return strSerial; }
            set { strSerial = value; }
        }

        private string strAppName;

        public string StrAppName
        {
            get { return strAppName; }
            set { strAppName = value; }
        }

        private string strAuthor;

        public string StrAuthor
        {
            get { return strAuthor; }
            set { strAuthor = value; }
        }

        private string versionApp;

        public string StrVersion
        {
            get { return versionApp; }
            set { versionApp = value; }
        }
        #endregion

        #region "Thong tin ve server - chuoi ket noi"
        private string strServerName;

        public string StrServerName
        {
            get { return strServerName; }
            set { strServerName = value; }
        }

        private string strPort;

        public string StrPort
        {
            get { return strPort; }
            set { strPort = value; }
        }

        private string strDBName;

        public string StrDBName
        {
            get { return strDBName; }
            set { strDBName = value; }
        }

        private string strUserID;

        public string StrUserID
        {
            get { return strUserID; }
            set { strUserID = value; }
        }

        private string strPassword;

        public string StrPassword
        {
            get { return strPassword; }
            set { strPassword = value; }
        }

        private string strTrustedConnection;

        public string StrTrustedConnection
        {
            get { return strTrustedConnection; }
            set { strTrustedConnection = value; }
        }

        public string StrConnection
        {
            get
            {
                string _strConnectionString = string.Empty;
                _strConnectionString = "Server = ";
                _strConnectionString += strServerName;
                _strConnectionString += ";Database = ";
                _strConnectionString += strDBName;
                _strConnectionString += ";User ID = ";
                _strConnectionString += strUserID;
                _strConnectionString += ";Password = ";
                _strConnectionString += strPassword;
                //_strConnectionString += ";Trusted_Connection = ";
                //_strConnectionString += strTrustedConnection;
                _strConnectionString += ";";
                return _strConnectionString;
            }
        }

        #endregion

        #region "Thiet lap ngon ngu"
        private string strCurrLang;

        public string StrCurrLang
        {
            get { return strCurrLang; }
            set { strCurrLang = value; }
        }
        #endregion

        #region "Thiet lap thong tin mail"
        private string strEmail;

        public string StrEmail
        {
            get { return strEmail; }
            set { strEmail = value; }
        }
        private string strDisplayName;

        public string StrDisplayName
        {
            get { return strDisplayName; }
            set { strDisplayName = value; }
        }
        private string strMailServerName;

        public string StrMailServerName
        {
            get { return strMailServerName; }
            set { strMailServerName = value; }
        }
        private string strMailPort;

        public string StrMailPort
        {
            get { return strMailPort; }
            set { strMailPort = value; }
        }
        private string strMailPass;

        public string StrMailPass
        {
            get { return strMailPass; }
            set { strMailPass = value; }
        }
        private string strUserName;

        public string StrUserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }

        #endregion

        #region "Thiet lap thong tin path- log, report, backup mac dinh"
        private string strPathLog;

        public string StrPathLog
        {
            get { return strPathLog; }
            set { strPathLog = value; }
        }
        private string strPathExport;

        public string StrPathExport
        {
            get { return strPathExport; }
            set { strPathExport = value; }
        }
        private string strReport;

        public string StrReport
        {
            get { return strReport; }
            set { strReport = value; }
        }
        private string strPathBackup;

        public string StrPathBackup
        {
            get { return strPathBackup; }
            set { strPathBackup = value; }
        }
        #endregion

        #region "Thiet lap tien te"
        private string strUnitVN;

        public string StrUnitVN
        {
            get { return strUnitVN; }
            set { strUnitVN = value; }
        }
        private string strUnitUSD;

        public string StrUnitUSD
        {
            get { return strUnitUSD; }
            set { strUnitUSD = value; }
        }
        #endregion

        #region "Thiet lap dinh dang so"
        private string strThousandSeparator;

        public string StrThousandSeparator
        {
            get { return strThousandSeparator; }
            set { strThousandSeparator = value; }
        }
        private string strDecimalSeparator;

        public string StrDecimalSeparator
        {
            get { return strDecimalSeparator; }
            set { strDecimalSeparator = value; }
        }
        #endregion

        #region "Thiet lap dinh dang ngay thang"
        private string strDateFormat;

        public string StrDateFormat
        {
            get { return strDateFormat; }
            set { strDateFormat = value; }
        }
        #endregion

        #region "Thiet lap chuoi ma hoa"
        private string strSecurityKey;

        public string StrSecurityKey
        {
            get { return strSecurityKey; }
            set { strSecurityKey = value; }
        }
        #endregion

        #region "Thiet lap scroll cho MDI child form"
        private bool bScrollMDIChild;

        public bool BScrollMDIChild
        {
            get { return bScrollMDIChild; }
            set { bScrollMDIChild = value; }
        }
        #endregion

        #region "Thiet lap cho FDP viewer"
        private string _xpdfrc;

        public string Xpdfrc
        {
            get { return _xpdfrc; }
            set { _xpdfrc = value; }
        }
        #endregion

        #region "Thiet lap thong tin user dang nhap hien hanh"
        private string _username;
        public string Login_UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _fullname;
        public string Login_FullName
        {
            get { return _fullname; }
            set { _fullname = value; }
        }

        private int _id;
        public int Login_ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _authentication;
        public int Login_Authentication
        {
            get { return _authentication; }
            set { _authentication = value; }
        }
        #endregion
    }
}