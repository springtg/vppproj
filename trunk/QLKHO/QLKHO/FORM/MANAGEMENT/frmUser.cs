﻿using System;
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

        private void bntDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

    }
}