﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLKHO.DATAOBJECT;

namespace QLKHO.FORM.MANAGEMENT
{
    public partial class frmUser : COREBASE.FORM.BASEFORM
    {
        UserDao DaoUser;
        public frmUser(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();
            DaoUser = new UserDao(_ConfigItem);
            this.Load += new EventHandler(frmUser_Load);
        }

        void frmUser_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid() {
            grvUser.DataSource = DaoUser.GetList();
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
                    row["Name"],
                    row["Name_Dis"],
                    row["Password"],
                    DateTime.Now,
                    _ConfigItem.Login_UserName,
                    0,
                    row["Remark"],
                    row["Phone"],
                    row["Address"]
                };
                DaoUser.Insert(arrValue: arrParaValue);
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
                DaoUser.Delete(_id);
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
                    DateTime.Now,
                    _ConfigItem.Login_UserName,
                    0,
                    row["Remark"],
                    row["Phone"],
                    row["Address"]
                };
                DaoUser.Update(arrValue: arrParaValue);
                return true;
            }
            catch (Exception ex)
            {
                return false;
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
                throw;
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
    }
}