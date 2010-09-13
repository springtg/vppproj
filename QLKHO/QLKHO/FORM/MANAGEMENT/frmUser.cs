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
            LoadGrid();
            PrintPreviewRibbonFormEx previewForm = new PrintPreviewRibbonFormEx();

            // Assign a Printing System to a Preview form.
            previewForm.PrintingSystem = printingSystem1;

            // Create a simple document.
            printingSystem1.Begin();
            printingSystem1.Graph.Modifier = BrickModifier.Detail;
            printingSystem1.Graph.DrawString("Ribbon Preview Form", Color.Black,
                new RectangleF(0, 20, 200, 20), BorderSide.None);
            printingSystem1.End();

            // Show the Print Preview form with a Ribbon.
            previewForm.Show();
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
                    row["Address"]
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
                    row["Address"]
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}