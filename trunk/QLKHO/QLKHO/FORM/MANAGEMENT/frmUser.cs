using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLKHO.DATAOBJECT;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraGrid.Views.Base;

namespace QLKHO.FORM.MANAGEMENT
{
    public partial class frmUser : COREBASE.FORM.BASEFORM
    {
        public frmUser(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();
            this.Load += new EventHandler(frmUser_Load);
        }

        void frmUser_Load(object sender, EventArgs e)
        {
            DepartmentsDao Dao = new DepartmentsDao(_ConfigItem);
            lkupDepartment.DataSource = Dao.GetList();
            LoadGrid();
            InitExportData();
        }
        private void OpenFile(string fileName)
        {
            if (XtraMessageBox.Show("Do you want to open this file?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, "Cannot find an application on your system suitable for openning the file with exported data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ExportTo(IExportProvider provider)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            this.FindForm().Refresh();
            BaseExportLink link = gridView1.CreateExportLink(provider);
            (link as GridViewExportLink).ExpandAll = false;
    
            link.ExportTo(true);
            provider.Dispose();

            Cursor.Current = currentCursor;
        }

        private void ExportToEx(String filename, string ext, BaseView exportView)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            DevExpress.XtraPrinting.IPrintingSystem ps = DevExpress.XtraPrinting.PrintHelper.GetCurrentPS();
            if (ext == "rtf") exportView.ExportToRtf(filename);
            if (ext == "pdf") exportView.ExportToPdf(filename);
            if (ext == "mht") exportView.ExportToMht(filename);
            if (ext == "htm") exportView.ExportToHtml(filename);
            if (ext == "txt") exportView.ExportToText(filename);
            if (ext == "xls") exportView.ExportToXls(filename);
            if (ext == "xlsx") exportView.ExportToXlsx(filename);
            Cursor.Current = currentCursor;
        }
        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = Application.ProductName;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = "Export To " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
        string[,] exportData = new string[,] {{"HTML Document", "HTML Documents|*.html", "htm"}, 
            {"XML Document", "XML Documents|*.xml", "xml"}, 
            {"Microsoft Excel 2007 Document", "Microsoft Excel|*.xlsx", "xlsx"}, 
            {"Microsoft Excel Document", "Microsoft Excel|*.xls", "xls"}, 
            {"RTF Document", "RTF Files|*.rtf", "rtf"},
            {"PDF Document", "PDF Files|*.pdf", "pdf"},
            {"MHT Document", "MHT Files|*.mht", "mht"},
            {"Text Document", "Text Files|*.txt", "txt"}};
         private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        void InitExportData()
        {
            for (int i = 0; i < exportData.GetLength(0); i++)
                cbExport.Properties.Items.Add(exportData.GetValue(i, 0));
            cbExport.SelectedIndex = 0;
        }
        private void LoadGrid()
        {
            grvUser.DataSource = UserDao.GetList(_ConfigItem);
        }
        private void Insert(DataRow row)
        {
            //   "@Name_Dis",
            // "@Name",
            //"@Password",
            // "@Crt_Dt",
            // "@Crt_By",
            // "@Is_Del",
            // "@Remark",
            // "@Phone",
            // "@Address"

            try
            {
                object[] arrParaValue = new object[] {
                   
                    row["Name_Dis"],
                    row["Name"],
                    row["Password"],
                    _ConfigItem.Login_UserName,
                    row["Remark"],
                    row["Phone"],
                    row["Address"],
                    row["Department_Pk"]
                };
                UserDao.Insert(_ConfigItem, arrParaValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Delete(int _id)
        {
            try
            {
                UserDao.Delete(_ConfigItem, _id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private bool Update(DataRow row)
        {
            //   "@Id",
            //                "@Name_Dis",
            //            "@Name",
            //           "@Password",
            //            "@Crt_Dt",
            //            "@Crt_By",
            //            "@Is_Del",
            //            "@Remark",
            //            "@Phone",
            //            "@Address"
            try
            {
                object[] arrParaValue = new object[] {
                    row["Id"],
                    row["Name_Dis"],
                    row["Name"],
                     row["Password"],
                    _ConfigItem.Login_UserName,
                    row["Remark"],
                    row["Phone"],
                    row["Address"],
                    row["Department_Pk"]
                };
                UserDao.Update(_ConfigItem, arrParaValue);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {

                DataTable Tmp = (DataTable)(grvUser.DataSource);
                for (int i = 0; i < Tmp.Rows.Count; i++)
                {
                    DataRow dr = Tmp.Rows[i];
                    if (isModifedRow(dr))
                    {
                        Update(dr);
                    }
                    if (isNewRow(dr))
                    {
                        Insert(dr);
                    }
                    if (isDeletedRow(dr))
                    {
                        Delete((int)GetOriginalItemData(dr, "Id"));
                    }
                }
                LoadGrid();
            }
            catch (Exception ex)
            {
                //TODOL Ghi log cho nay
                throw ex;
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(System.Windows.Forms.Keys.Delete))
            {
                try
                {
                    int[] _IndexRowSelected = gridView1.GetSelectedRows();
                    int _CurIndexRow = _IndexRowSelected[0];
                    DataTable tmp = (DataTable)grvUser.DataSource;
                    Delete(CnvToInt32(tmp.Rows[_CurIndexRow]["Id"]));
                    LoadGrid();
                }
                catch (Exception ex)
                {
                    //TODO: Ghi log tai day nhe
                    throw ex;
                }
            }
        }

 
        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "Phone")
            {
                //Get the currently edited value 
                double discount = Convert.ToDouble(e.Value);
                //Specify validation criteria 
                if (discount < 0)
                {
                    e.Valid = false;
                    e.ErrorText = "Nhập số lớn hơn 0";
                }
            }

        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

        }

        private void gridView1_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            //Do not perform any default action 
           // e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            //Show the message with the error text specified 
           // MessageBox.Show(e.ErrorText);

        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void cmDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] _IndexRowSelected = gridView1.GetSelectedRows();
                int _CurIndexRow = _IndexRowSelected[0];
                DataTable tmp = (DataTable)grvUser.DataSource;
                Delete(CnvToInt32(tmp.Rows[_CurIndexRow]["Id"]));
                LoadGrid();
            }
            catch (Exception ex)
            {
                //TODO: Ghi log tai day nhe
                throw ex;
            }
        }

        private void cmbExport_Click(object sender, EventArgs e)
        {
            int index = cbExport.SelectedIndex;
            if (index < 0) return;
            string fileName = ShowSaveFileDialog(exportData.GetValue(index, 0).ToString(), exportData.GetValue(index, 1).ToString());
            if (fileName == string.Empty) return;
            if (exportData.GetValue(index, 2).Equals("xml"))
            {
                ExportTo(new ExportXmlProvider(fileName));
                OpenFile(fileName);
            }
            else
            {
                ExportToEx(fileName, exportData.GetValue(index, 2).ToString(), gridView1);
                OpenFile(fileName);
            }
        }
 
    }
}