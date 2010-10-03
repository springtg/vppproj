using System.Data;
using System.Windows.Forms;
using System;
using System.Drawing;
using COREBASE.COMMAND.MessageUtils;
using System.Collections;
using COREBASE.COMMAND.LogUtils;
using DevExpress.XtraEditors;

namespace COREBASE.FORM
{
    public partial class BASEFORM : DevExpress.XtraEditors.XtraForm
    {
        public const string EVENT_LOAD_FORM = "EVENTLOADFORM";
        public const string EVENT_CLOSE_FORM = "EVENTCLOSEFORM";
        public const string EVENT_CLOSE_APP = "EVENTCLOSEAPP";
        public const string EVENT_FORM_LOAD = "LOAD";
        public const string EVENT_FORM_NEW = "NEW";
        public const string EVENT_FORM_UPDATE = "UPDATE";
        public const string EVENT_FORM_DELETE = "DELETE";
        public const string EVENT_FORM_CANCEL = "CANCEL";
        public const string EVENT_FORM_NONE = "NONE";

        protected object _rtnValue;

        protected COMMAND.SQL.AccessSQL _providerSQL;

        #region "Cac bien dung cho ke thua"
        protected COMMAND.Config.ConfigItem _ConfigItem = null;

        #endregion

        public BASEFORM()
        {
            InitializeComponent();            
        }

        #region "Thuoc tinh chung thuc Assembly cua cung dung"
        protected object PersonaCode
        {
            get { return "@#NguyenThanhXuan311826469#@!"; }
        }

        protected bool isTrial = false;
        protected bool IsTrial
        {
            get { return isTrial; }
            set { isTrial = value; }
        }
        #endregion

        protected void setTitle(string strTitle)
        {
            this.Text = strTitle;
        }

        #region "Dong vo du lieu, la xu lieu du tap hop du lieu tren luoi + form"
        protected void SynchronizeData(ref DataGridView grdObj)
        {
            CurrencyManager cm = (CurrencyManager)this.BindingContext[grdObj.DataSource, grdObj.DataMember];
            cm.EndCurrentEdit();
            grdObj.EndEdit();
        }

        /// <summary>
        /// Set value of control to its tag property
        /// </summary>
        /// <param name="baseCtrl"></param>
        /// <remarks></remarks>
        protected virtual void AssignTagValueOnControl(Control baseCtrl)
        {
            if ((baseCtrl == null))
            {
                return;
            }
            foreach (Control ctr in baseCtrl.Controls)
            {
                if ((ctr.GetType() == typeof(TextBox)))
                {
                    TextBox textBox = (TextBox)ctr;
                    textBox.Tag = textBox.Text;
                }
                else
                    if (ctr.GetType().Equals(typeof(RichTextBox)))
                    {
                        RichTextBox richtextbox = (RichTextBox)ctr;
                        richtextbox.Tag = richtextbox.Text;
                    }
                    else
                        if ((ctr.GetType() == typeof(System.Windows.Forms.ComboBox)))
                        {
                            System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)ctr;
                            comboBox.Tag = comboBox.SelectedValue;
                        }
                        else
                            if ((ctr.GetType() == typeof(RadioButton)))
                            {
                                RadioButton radio = (RadioButton)ctr;
                                radio.Tag = radio.Checked;
                            }
                            else
                                if ((ctr.GetType() == typeof(DataGridView)))
                                {
                                    DataGridView gcTemp = (DataGridView)(object)ctr;
                                    DataTable dt = (DataTable)(gcTemp.DataSource);
                                    if (!(dt == null))
                                    {
                                        dt.AcceptChanges();
                                    }
                                }
                if (ctr.HasChildren)
                {
                    AssignTagValueOnControl(ctr);
                }
            }
        }
        
        protected virtual void AssignTagValueOnDXControl(Control baseCtrl)
        {
            if ((baseCtrl == null))
            {
                return;
            }
            foreach (Control ctr in baseCtrl.Controls)
            {
                if ((ctr.GetType() == typeof(TextEdit)))
                {
                    TextEdit textBox = (TextEdit)ctr;
                    textBox.Tag = textBox.Text;
                }
                else
                    if (ctr.GetType().Equals(typeof(RichTextBox)))
                    {
                        RichTextBox richtextbox = (RichTextBox)ctr;
                        richtextbox.Tag = richtextbox.Text;
                    }
                    else
                        if ((ctr.GetType() == typeof(System.Windows.Forms.ComboBox)))
                        {
                            System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)ctr;
                            comboBox.Tag = comboBox.SelectedValue;
                        }
                        else
                            if ((ctr.GetType() == typeof(CheckEdit)))
                            {
                                //Xu ly la kieu check box
                                CheckEdit radio = (CheckEdit)ctr;
                                radio.Tag = radio.Checked;
                            }
                            else
                                if ((ctr.GetType() == typeof(DataGridView)))
                                {
                                    DataGridView gcTemp = (DataGridView)(object)ctr;
                                    DataTable dt = (DataTable)(gcTemp.DataSource);
                                    if (!(dt == null))
                                    {
                                        dt.AcceptChanges();
                                    }
                                }
                if (ctr.HasChildren)
                {
                    AssignTagValueOnDXControl(ctr);
                }
            }
        }

        /// <summary>
        /// Check if there is any changes on control
        /// </summary>
        /// <param name="baseControl"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected virtual bool HasChangedOnControl(Control baseControl)
        {
            if ((baseControl == null))
            {
                return false;
            }
            foreach (Control ctrl in baseControl.Controls)
            {
                if ((ctrl.GetType() == typeof(TextBox)))
                {
                    TextBox textBox = (TextBox)ctrl;
                    if (!textBox.Text.Trim().Equals(textBox.Tag.ToString().Trim()))
                    {
                        return true;
                    }
                }
                else
                    if (ctrl.GetType().Equals(typeof(RichTextBox)))
                    {
                        RichTextBox richtextbox = (RichTextBox)ctrl;
                        richtextbox.Tag = richtextbox.Text;
                    }
                    else
                        if ((ctrl.GetType() == typeof(System.Windows.Forms.ComboBox)))
                        {
                            System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)ctrl;
                            if ((!(comboBox.Tag == null)
                                        && !(comboBox.SelectedValue == null)))
                            {
                                if (!comboBox.Tag.Equals(comboBox.SelectedValue))
                                {
                                    return true;
                                }
                            }
                            else
                                if (!((comboBox.Tag == null)
                                        && (comboBox.SelectedValue == null)))
                                {
                                    return true;
                                }
                        }
                        else
                            if ((ctrl.GetType() == typeof(RadioButton)))
                            {
                                RadioButton radio = (RadioButton)ctrl;
                                if (!(bool.Parse(radio.Tag.ToString().Trim()) == radio.Checked))
                                {
                                    return true;
                                }
                            }
                            else
                                if ((ctrl.GetType() == typeof(DataGridView)))
                                {
                                    DataGridView grd = (DataGridView)(object)ctrl;
                                    if (HasChangedOnGrid(grd))
                                    {
                                        return true;
                                    }
                                }
                if (ctrl.HasChildren)
                {
                    if (HasChangedOnControl(ctrl))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
       
        protected virtual bool HasChangedOnDXControl(Control baseControl)
        {
            if ((baseControl == null))
            {
                return false;
            }
            foreach (Control ctrl in baseControl.Controls)
            {
                if ((ctrl.GetType() == typeof(TextEdit)))
                {
                    TextEdit textBox = (TextEdit)ctrl;
                    if (!textBox.Text.Trim().Equals(textBox.Tag.ToString().Trim()))
                    {
                        return true;
                    }
                }
                else
                    if (ctrl.GetType().Equals(typeof(RichTextBox)))
                    {
                        RichTextBox richtextbox = (RichTextBox)ctrl;
                        richtextbox.Tag = richtextbox.Text;
                    }
                    else
                        if ((ctrl.GetType() == typeof(System.Windows.Forms.ComboBox)))
                        {
                            System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)ctrl;
                            if ((!(comboBox.Tag == null)
                                        && !(comboBox.SelectedValue == null)))
                            {
                                if (!comboBox.Tag.Equals(comboBox.SelectedValue))
                                {
                                    return true;
                                }
                            }
                            else
                                if (!((comboBox.Tag == null)
                                        && (comboBox.SelectedValue == null)))
                                {
                                    return true;
                                }
                        }
                        else
                            if ((ctrl.GetType() == typeof(CheckEdit)))
                            {
                                CheckEdit radio = (CheckEdit)ctrl;
                                if (!(bool.Parse(radio.Tag.ToString().Trim()) == radio.Checked))
                                {
                                    return true;
                                }
                            }
                            else
                                if ((ctrl.GetType() == typeof(DataGridView)))
                                {
                                    DataGridView grd = (DataGridView)(object)ctrl;
                                    if (HasChangedOnGrid(grd))
                                    {
                                        return true;
                                    }
                                }
                if (ctrl.HasChildren)
                {
                    if (HasChangedOnDXControl(ctrl))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Check if data on grid ha changed
        /// </summary>
        /// <param name="grd"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected bool HasChangedOnGrid(DataGridView grd)
        {
            SynchronizeData(ref grd);
            DataTable dt = null;
            dt = ((DataTable)(grd.DataSource));
            if (!(dt == null))
            {
                if (!(dt.GetChanges() == null))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region "Xu ly doi tuong dong cua datatable"
        /// <summary>
        /// Kiem tra 1 row la moi duoc them vo
        /// </summary>
        /// <param name="dtRow"></param>
        /// <returns></returns>
        protected bool isUnchangedRow(DataRow dtRow)
        {
            return COMMAND.CDataTable.isUnchangedRow(dtRow);
        }

        /// <summary>
        /// Kiem tra 1 row la khong thay doi
        /// </summary>
        /// <param name="dtRow"></param>
        /// <returns></returns>
        protected bool isNewRow(DataRow dtRow)
        {
            return COMMAND.CDataTable.isNewRow(dtRow);
        }
        /// <summary>
        /// Kiem tra 1 dong la da bi xoa
        /// </summary>
        /// <param name="dtRow"></param>
        /// <returns></returns>
        protected bool isDeletedRow(DataRow dtRow)
        {
            return COMMAND.CDataTable.isDeletedRow(dtRow);
        }
        /// <summary>
        /// Kiem tra 1 dong la da sua doi du lieu
        /// </summary>
        /// <param name="dtRow"></param>
        /// <returns></returns>
        protected bool isModifedRow(DataRow dtRow)
        {
            return COMMAND.CDataTable.isModifedRow(dtRow);
        }
        /// <summary>
        /// Lay gia tri truoc do cua row
        /// </summary>
        /// <param name="dtrRow"></param>
        /// <param name="sFieldID"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected object GetOriginalItemData(DataRow dtrRow, string sFieldID)
        {
            return COMMAND.CDataTable.GetOriginalItemData(dtrRow, sFieldID);
        }

        #endregion

        #region "lay thong tin tu file config va set den bien toan cuc"

        /// <summary>
        /// Doc thong tin cau hinh tu file config
        /// </summary>
        /// <returns></returns>
        protected COMMAND.Config.ConfigItem LoadConfigFileInfo()
        {
            COMMAND.Config.Config _Config = new COMMAND.Config.Config();
            COMMAND.Config.ConfigItem _ConfigItem = new COMMAND.Config.ConfigItem();

            _ConfigItem.StrActiveKey = _Config.ReadSetting("ActiveKey");
            _ConfigItem.StrSerial = _Config.ReadSetting("Serial");
            _ConfigItem.StrAppName = _Config.ReadSetting("AppName");
            _ConfigItem.StrAuthor = _Config.ReadSetting("Author");
            _ConfigItem.StrVersion = _Config.ReadSetting("VersionApp");

            //Ngon ngu dang su dung
            _ConfigItem.StrCurrLang = _Config.ReadSetting("CurrLang");
            //Email
            _ConfigItem.StrEmail = _Config.ReadSetting("Email");
            //Ten hien thi
            _ConfigItem.StrDisplayName = _Config.ReadSetting("DisplayName");
            //Server mail dang smtp
            _ConfigItem.StrMailServerName = _Config.ReadSetting("MailServerName");
            //Port cua server mail
            _ConfigItem.StrMailPort = _Config.ReadSetting("MailPort");
            //Password cua mail
            _ConfigItem.StrMailPass = _Config.ReadSetting("MailPass");
            _ConfigItem.StrUserName = _Config.ReadSetting("UserName");

            _ConfigItem.StrServerName = _Config.ReadSetting("Server");
            _ConfigItem.StrPort = _Config.ReadSetting("Port");
            _ConfigItem.StrDBName = _Config.ReadSetting("DataBase");
            _ConfigItem.StrUserID = _Config.ReadSetting("UserID");
            _ConfigItem.StrPassword = _Config.ReadSetting("Password");
            _ConfigItem.StrTrustedConnection = _Config.ReadSetting("Trusted_Connection");

            //Duong dan mac dinh cua log file
            _ConfigItem.StrPathLog = _Config.ReadSetting("PathLogDefault");
            //Duong dan mac dinh cua file export
            _ConfigItem.StrPathExport = _Config.ReadSetting("PathExPortDefault");
            //Duong dan mac dinh cua file report bang pdf
            _ConfigItem.StrReport = _Config.ReadSetting("PathReportDefault");
            //Duong dan mac dinh cua file backup
            _ConfigItem.StrPathBackup = _Config.ReadSetting("PathBackUpDataDefault");
            _ConfigItem.StrThousandSeparator = _Config.ReadSetting("thousand_separator");
            //D?u th?p phân
            _ConfigItem.StrDecimalSeparator = _Config.ReadSetting("decimal_separator");
            //dinh dang ngay thang
            _ConfigItem.StrDateFormat = _Config.ReadSetting("DateFormat");
            //Bat tinh Scroll form cho ung dung hay khong? ==> 1 = Enable; 0 = Disable
            _ConfigItem.BScrollMDIChild = CnvToBool(_Config.ReadSetting("ScrollMDIChild"));
            // Key ma hoa mat khau
            _ConfigItem.StrSecurityKey = _Config.ReadSetting("SecurityKey");
            ////DefaultPageSettings.Margins.Top
            //_Config.ReadSetting("DefaultPageSettings.Margins.Top");
            ////DefaultPageSettings.Margins.Left
            //_Config.ReadSetting("DefaultPageSettings.Margins.Left");
            ////DefaultPageSettings.Margins.Right
            //_Config.ReadSetting("DefaultPageSettings.Margins.Right");
            ////DefaultPageSettings.Margins.Bottom
            //_Config.ReadSetting("DefaultPageSettings.Margins.Bottom");
            ////add data to center page
            //_Config.ReadSetting("CenterPartition");
            ////fit column to page
            //_Config.ReadSetting("FitColumnsToPage");
            //_Config.ReadSetting("LevelByLevel");
            //_Config.ReadSetting("AllowCurrentPage");
            //_Config.ReadSetting("AllowPrintToFile");
            //_Config.ReadSetting("AllowSelection");
            //_Config.ReadSetting("AllowSomePages");
            //_Config.ReadSetting("PrintToFile");
            //_Config.ReadSetting("ShowHelp");
            //_Config.ReadSetting("ShowNetwork");
            _ConfigItem.Xpdfrc = _Config.ReadSetting("xpdfrc");
            return _ConfigItem;
        }
        /// <summary>
        /// Luu thong tin cau hinh xuong file config
        /// </summary>
        /// <param name="configItem"></param>
        protected void UpdateConfigFileInfo(COMMAND.Config.ConfigItem configItem)
        {
            COMMAND.Config.Config _Config = new COMMAND.Config.Config();

            _Config.WriteSetting("ActiveKey", configItem.StrActiveKey);
            _Config.WriteSetting("Serial", configItem.StrSerial);
            _Config.WriteSetting("AppName", configItem.StrAppName);
            _Config.WriteSetting("Author", configItem.StrAuthor);
            _Config.WriteSetting("VersionApp", configItem.StrVersion);

            //Ngon ngu dang su dung
            _Config.WriteSetting("CurrLang", configItem.StrCurrLang);
            //Email
            _Config.WriteSetting("Email", configItem.StrEmail);
            //Ten hien thi
            _Config.WriteSetting("DisplayName", configItem.StrDisplayName);
            //Server mail dang smtp
            _Config.WriteSetting("MailServerName", configItem.StrMailServerName);
            //Port cua server mail
            _Config.WriteSetting("MailPort", configItem.StrMailPort);
            //Password cua mail
            _Config.WriteSetting("MailPass", configItem.StrMailPass);
            _Config.WriteSetting("UserName", configItem.StrUserName);

            _Config.WriteSetting("Server", configItem.StrServerName);
            _Config.WriteSetting("Port", configItem.StrPort);
            _Config.WriteSetting("DataBase", configItem.StrDBName);
            _Config.WriteSetting("UserID", configItem.StrUserID);
            _Config.WriteSetting("Password", configItem.StrPassword);
            _Config.WriteSetting("Trusted_Connection", configItem.StrTrustedConnection);

            //Duong dan mac dinh cua log file
            _Config.WriteSetting("PathLogDefault", configItem.StrPathLog);
            //Duong dan mac dinh cua file export
            _Config.WriteSetting("PathExPortDefault", configItem.StrPathExport);
            //Duong dan mac dinh cua file report bang pdf
            _Config.WriteSetting("PathReportDefault", configItem.StrReport);
            //Duong dan mac dinh cua file backup
            _Config.WriteSetting("PathBackUpDataDefault", configItem.StrPathBackup);
            _Config.WriteSetting("thousand_separator", configItem.StrThousandSeparator);
            //D?u th?p phân
            _Config.WriteSetting("decimal_separator", configItem.StrDecimalSeparator);
            //dinh dang ngay thang
            _Config.WriteSetting("DateFormat", configItem.StrDateFormat);
            //Bat tinh Scroll form cho ung dung hay khong? ==> 1 = Enable; 0 = Disable
            _Config.WriteSetting("ScrollMDIChild", CnvToString(configItem.BScrollMDIChild));
            // Key ma hoa mat khau
            _Config.WriteSetting("SecurityKey", configItem.StrSecurityKey);
            ////DefaultPageSettings.Margins.Top
            //_Config.WriteSetting("DefaultPageSettings.Margins.Top");
            ////DefaultPageSettings.Margins.Left
            //_Config.WriteSetting("DefaultPageSettings.Margins.Left");
            ////DefaultPageSettings.Margins.Right
            //_Config.WriteSetting("DefaultPageSettings.Margins.Right");
            ////DefaultPageSettings.Margins.Bottom
            //_Config.WriteSetting("DefaultPageSettings.Margins.Bottom");
            ////add data to center page
            //_Config.WriteSetting("CenterPartition");
            ////fit column to page
            //_Config.WriteSetting("FitColumnsToPage");
            //_Config.WriteSetting("LevelByLevel");
            //_Config.WriteSetting("AllowCurrentPage");
            //_Config.WriteSetting("AllowPrintToFile");
            //_Config.WriteSetting("AllowSelection");
            //_Config.WriteSetting("AllowSomePages");
            //_Config.WriteSetting("PrintToFile");
            //_Config.WriteSetting("ShowHelp");
            //_Config.WriteSetting("ShowNetwork");
            _Config.WriteSetting("xpdfrc", configItem.Xpdfrc);
        }

        #endregion

        #region "Convert function"
        protected string CnvToString(object objvalue)
        {
            return COMMAND.Convert.Convert.CnvToString(objvalue);
        }

        protected bool CnvToBool(object objvalue)
        {
            return COMMAND.Convert.Convert.CnvToBool(objvalue);
        }

        protected int CnvToInteger(object objvalue)
        {
            return COMMAND.Convert.Convert.CnvToInteger(objvalue);
        }

        protected Int16 CnvToInt16(object objvalue)
        {
            return COMMAND.Convert.Convert.CnvToInt16(objvalue);
        }

        protected Int32 CnvToInt32(object objvalue)
        {
            return COMMAND.Convert.Convert.CnvToInt32(objvalue);
        }

        protected Int64 CnvToInt64(object objvalue)
        {
            return COMMAND.Convert.Convert.CnvToInt64(objvalue);
        }

        protected long CnvToLong(object objvalue)
        {
            return COMMAND.Convert.Convert.CnvToLong(objvalue);
        }

        protected decimal CnvToDecimal(object objvalue)
        {
            return COMMAND.Convert.Convert.CnvToDecimal(objvalue);
        }

        protected double CnvToDouble(object objvalue)
        {
            return COMMAND.Convert.Convert.CnvToDouble(objvalue);
        }

        protected static Single CnvToSingle(object objvalue)
        {
            return COMMAND.Convert.Convert.CnvToSingle(objvalue);
        }

        protected byte CnvToByte(object objvalue)
        {
            return COMMAND.Convert.Convert.CnvToByte(objvalue);
        }

        protected string SubString(string strValue, int startIndex, int length)
        {
            return COMMAND.Convert.Convert.SubString(strValue, startIndex, length);
        }

        protected bool IsBlank(object objvalue)
        {
            return string.IsNullOrEmpty(CnvToString(objvalue));
        }

        protected byte[] imageToByteArray(Image imageIn)
        {
            return COMMAND.Convert.Convert.imageToByteArray(imageIn);
        }

        protected Image byteArrayToImage(byte[] byteArrayIn)
        {
            return COMMAND.Convert.Convert.byteArrayToImage(byteArrayIn);
        }

        protected byte[] RawSerialize(object anything)
        {
            return COMMAND.Convert.Convert.RawSerialize(anything);
        }

        protected object RawDeserialize(byte[] rawdatas, Type anytype)
        {
            return COMMAND.Convert.Convert.RawDeserialize(rawdatas, anytype);
        }

        protected string getDateTimetoFormatyyyyMMdd()
        {
            return COMMAND.Convert.Convert.getDateTimetoFormatyyyyMMdd();
        }

        protected object CnvChangeType(object value, System.Type convertType)
        {
            return COMMAND.Convert.Convert.CnvChangeType(value, convertType);

        }
        protected object CnvChangeType(object value, System.Type convertType, System.IFormatProvider provider)
        {
            return COMMAND.Convert.Convert.CnvChangeType(value, convertType, provider);

        }
        protected object CnvChangeType(object value, System.TypeCode typeCode)
        {
            return COMMAND.Convert.Convert.CnvChangeType(value, typeCode);

        }
        protected object CnvChangeType(object value, System.TypeCode typeCode, System.IFormatProvider provider)
        {
            return COMMAND.Convert.Convert.CnvChangeType(value, typeCode, provider);

        }

        protected DateTime CnvToDateTime(object value)
        {
            return COMMAND.Convert.Convert.CnvToDateTime(CnvToString(value), "yyyy/MM/dd");
        }
        #endregion

        #region "Phuong thuc MessageBox"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        protected DialogResult ShowMessageBox(string messageId, string messageText, MessageType messageType)
        {
            //1. Assign defaul return value
            DialogResult result = DialogResult.None;
            try
            {
                //2. Display COMMAND.MessageUtils.Message if found
                if (messageText != "")
                {
                    switch (messageType)
                    {
                        case MessageType.WARNING:
                            MessageBox.Show(messageText, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        case MessageType.INFORM:
                            MessageBox.Show(messageText, "INFORM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case MessageType.ERROR:
                            MessageBox.Show(messageText, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case MessageType.CONFIRM:
                            result = MessageBox.Show(messageText, "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            break;
                        default:
                            MessageBox.Show(messageText, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    //2.2. If not found then display inform COMMAND.MessageUtils.Message
                    MessageBox.Show(String.Format("COMMAND.MessageUtils.Message {0} is not found in resource file.", messageId), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //3.Return result
                return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //Write log
                //if (_logger.IsErrorEnabled)
                //    _logger.Error(ex);
                //4.Error handling
                //Write exception here
                return DialogResult.None;
            }
        }
        /// <summary>
        /// Show COMMAND.MessageUtils.Message with messageid from COMMAND.MessageUtils.Message resource
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="messageType"></param>
        /// <returns></returns>
        protected DialogResult ShowMessageBox(string messageId, MessageType messageType)
        {
            return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), messageType);
        }

        protected DialogResult ShowMessageBox(string messageId)
        {
            if (messageId.Contains("U"))
            {
                return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), MessageType.UNDEFINED);
            }
            if (messageId.Contains("W"))
            {
                return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), MessageType.WARNING);
            }
            if (messageId.Contains("I"))
            {
                return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), MessageType.INFORM);
            }
            if (messageId.Contains("E"))
            {
                return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), MessageType.ERROR);
            }
            if (messageId.Contains("C"))
            {
                return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), MessageType.CONFIRM);
            }
            return ShowMessageBox(messageId, COMMAND.MessageUtils.Message.GetMessageById(messageId), MessageType.NONE);
        }

        protected DialogResult ShowMessageBox(string messageId, MessageType messageType, params object[] objParam)
        {
            string strMsgTmp = COMMAND.MessageUtils.Message.GetMessageById(messageId);
            return ShowMessageBox(messageId, string.Format(strMsgTmp, objParam), messageType);
        }

        protected DialogResult ShowMessageBox(string messageId, MessageType messageType, object objParam)
        {
            string strMsgTmp = COMMAND.MessageUtils.Message.GetMessageById(messageId);
            return ShowMessageBox(messageId, string.Format(strMsgTmp, objParam), messageType);
        }

        protected DialogResult ShowMultiMessage(ArrayList arrMsgInfo)
        {
            try
            {
                string msgTemp = string.Empty;
                for (int i = 0; i < arrMsgInfo.Count; i++)
                {
                    MessageInf msfInfoTemp = (MessageInf)arrMsgInfo[i];
                    msgTemp += CreatMsg(msfInfoTemp);
                    if (i + 1 != arrMsgInfo.Count)
                    {
                        msgTemp += "\n";
                    }
                }
                if (msgTemp.Equals(string.Empty))
                {
                    return DialogResult.None;
                }
                else
                {
                    return MessageBox.Show(msgTemp, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return DialogResult.None;
            }
        }

        private string CreatMsg(MessageInf msgInfo)
        {
            string Msgrs = string.Empty;
            Msgrs = COMMAND.MessageUtils.Message.GetMessageById(msgInfo.MsgId);
            Msgrs = string.Format(Msgrs, msgInfo.ArrParam);
            return Msgrs;
        }

        #endregion

        #region "Common log function"
        /// <summary>
        /// Format to string {msgID} {msg}
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="messageParam"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string Format(string msgId, params string[] messageParam)
        {
            return string.Format("{0} {1}", msgId);//, msgUtils.message(msgId, messageParam));
        }

        /// <summary>
        /// Output app debug info to log file
        /// </summary>
        /// <param name="msg"></param>
        /// <remarks></remarks>
        protected void AppDebug(object msg)
        {
            Logger.AppLog.Debug(this.Name, _ConfigItem.Login_ID, msg);
        }

        /// <summary>
        /// Output app debug info to log file
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="messageParam"></param>
        /// <remarks></remarks>
        protected void AppDebug(string msgId, params string[] messageParam)
        {
            if (messageParam.Length != 0)
            {
                Logger.AppLog.Debug(this.Name, _ConfigItem.Login_ID, string.Format(msgId, messageParam));
            }
            else
            {
                Logger.AppLog.Debug(this.Name, _ConfigItem.Login_ID, msgId);
            }
        }

        /// <summary>
        /// Output app error info to log file
        /// </summary>
        /// <param name="msg"></param>
        /// <remarks></remarks>
        protected void AppError(object msg)
        {
            Logger.AppLog.Error(this.Name, _ConfigItem.Login_ID, msg);
        }

        /// <summary>
        /// Output app error info to log file
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="messageParam"></param>
        /// <remarks></remarks>
        protected void AppError(string msgId, params string[] messageParam)
        {
            if (messageParam.Length != 0)
            {
                Logger.AppLog.Error(this.Name, _ConfigItem.Login_ID, string.Format(msgId, messageParam));
            }
            else
            {
                Logger.AppLog.Error(this.Name, _ConfigItem.Login_ID, msgId);
            }
        }

        /// <summary>
        /// Output app fatal info to log file
        /// </summary>
        /// <param name="msg"></param>
        /// <remarks></remarks>
        protected void AppFatal(object msg)
        {
            Logger.AppLog.Fatal(this.Name, _ConfigItem.Login_ID, msg);
        }

        /// <summary>
        ///  Output app fatal info to log file
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="messageParam"></param>
        /// <remarks></remarks>
        protected void AppFatal(string msgId, params string[] messageParam)
        {
            if (messageParam.Length != 0)
            {
                Logger.AppLog.Fatal(this.Name, _ConfigItem.Login_ID, string.Format(msgId, messageParam));
            }
            else
            {
                Logger.AppLog.Fatal(this.Name, _ConfigItem.Login_ID, msgId);
            }
        }

        /// <summary>
        /// Output app info to log file
        /// </summary>
        /// <param name="msg"></param>
        /// <remarks></remarks>
        protected void AppInfo(object msg)
        {
            Logger.AppLog.Info(this.Name, _ConfigItem.Login_ID, msg);
        }

        /// <summary>
        ///  Output app info to log file
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="messageParam"></param>
        /// <remarks></remarks>
        protected void AppInfo(string msgId, params string[] messageParam)
        {
            if (messageParam.Length != 0)
            {
                Logger.AppLog.Info(this.Name, _ConfigItem.Login_ID, string.Format(msgId, messageParam));
            }
            else
            {
                Logger.AppLog.Info(this.Name, _ConfigItem.Login_ID, msgId);
            }
        }

        /// <summary>
        /// Output app warning info to log file
        /// </summary>
        /// <param name="msg"></param>
        /// <remarks></remarks>
        protected void AppWarn(object msg)
        {
            Logger.AppLog.Warn(this.Name, _ConfigItem.Login_ID, msg);
        }

        /// <summary>
        ///  Output app warning info to log file
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="messageParam"></param>
        /// <remarks></remarks>
        protected void AppWarn(string msgId, params string[] messageParam)
        {
            if (messageParam.Length != 0)
            {
                Logger.AppLog.Warn(this.Name, _ConfigItem.Login_ID, string.Format(msgId, messageParam));
            }
            else
            {
                Logger.AppLog.Warn(this.Name, _ConfigItem.Login_ID, msgId);
            }
        }

        #endregion

        #region "Doi Tuong tra du lieu"
        /// <summary>
        /// Lay tap thong tin cau hinh tu form truoc
        /// </summary>
        protected COMMAND.Config.ConfigItem getConfigItem
        {
            get { return _ConfigItem; }
        }
        /// <summary>
        /// Lay doi tuong tra ve tu form truoc
        /// </summary>
        public object returnValue
        {
            get { return _rtnValue; }
        }



        #endregion

        #region "Xu ly doi tuong datagridview"

        //protected int[] getRowSeleteIndex(DevExpress.XtraGrid.Views.Grid.GridView objGridView)
        //{
        //    try
        //    {
        //        int[] rs;
        //        for (int i = objGridView.SelectedRowsCount - 1; i >= 0; i--)
        //        {
        //            rs = objGridView.GetSelectedRows()[i];
        //        }
        //        return rs;
        //    }
        //    catch (Exception ex)
        //    {
        //        //TODO: Ghi log cho nay nhe
        //        return null;
        //    }
        //}

        #endregion

        #region "Xu ly control"
        protected object getValue(DevExpress.XtraEditors.ComboBoxEdit cboControl, string strValueMember)
        {
            try
            {
                DataRow dr = (DataRow)cboControl.SelectedItem;
                return dr[strValueMember];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected object getValue(DevExpress.XtraEditors.GridLookUpEdit cboControl, string strValueMember)
        {
            try
            {
                DataRow dr = (DataRow)cboControl.GetSelectedDataRow();
                return dr[strValueMember];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected object getValue(LookUpEdit lueControl, string strColName)
        {
            try
            {
                DataRow dr = ((DataRowView)lueControl.GetSelectedDataRow()).Row;
                return dr[strColName];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected object getSummaryValue()
        {
            return null;
        }

        #endregion

        private void BASEFORM_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Logger.Configure();
            }
        }

        protected void CloseMe()
        {
            this.Close();
        }
    }
}