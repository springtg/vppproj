using System;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace QLKHO.FORM.MANAGEMENT
{
    public partial class frmDonVi : COREBASE.FORM.BASEFORM
    {

        public frmDonVi(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            InitializeComponent();
            _ConfigItem = _ConfItem;
        }

        private void frmDonVi_Load(object sender, System.EventArgs e)
        {
            if (_ConfigItem != null)
            {
                gridControl1.DataSource = LoadData();
            }
        }

        private DataTable LoadData()
        {
            try
            {
                _providerSQL = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
                return _providerSQL.GetDataByStoredProcedure("SP_SEL_UNIT");
            }
            catch (Exception ex)
            {
                //TODO: Ghi log cho nay
                return null;
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {

                DataTable Tmp = (DataTable)(gridControl1.DataSource);
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
                gridControl1.DataSource = LoadData();
            }
            catch (Exception ex)
            {
                //TODOL Ghi log cho nay
                throw;
            }
        }

        private void Delete(int _id)
        {
            try
            {
                string[] arrParaName = new string[] {
                    "@Id"};
                object[] arrParaValue = new object[] {
                    _id
                };
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
                _sql.ExecuteNonQuery("SP_DEL_UNIT", arrNames: arrParaName, arrValues: arrParaValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void Insert(DataRow row)
        {
            try
            {
                string[] arrParaName = new string[] {
                    "@Name",
                    "@Crt_Dt",
                    "@Crt_By",
                    "@Remark"};
                object[] arrParaValue = new object[] {
                    row["Name"],
                    DateTime.Now,
                    _ConfigItem.Login_UserName,
                    row["Remark"]
                };
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
                _sql.ExecuteNonQuery("SP_INS_UNIT", arrNames: arrParaName, arrValues: arrParaValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Update(DataRow row)
        {
            try
            {
                string[] arrParaName = new string[] {
                    "@Id",
                    "@Name",
                    "@Crt_Dt",
                    "@Crt_By",
                    "@Remark"};
                object[] arrParaValue = new object[] {
                    row["Id"],
                    row["Name"],
                    DateTime.Now,
                    _ConfigItem.Login_UserName,
                    row["Remark"]
                };
                COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
                _sql.ExecuteNonQuery("SP_UPD_UNIT", arrNames: arrParaName, arrValues: arrParaValue);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable tbl = (DataTable)gridControl1.DataSource;
            DataRow r = tbl.NewRow();
            tbl.Rows.Add(r);
        }

    }
}