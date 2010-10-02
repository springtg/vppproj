using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLKHO.FORM.BAOCAO.N_X_TON;
using DevExpress.XtraPrinting.Control;
using DevExpress.XtraPrinting.Preview;

namespace QLKHO.FORM.BAOCAO
{
    public partial class frmRptNhap : COREBASE.FORM.BASEFORM
    {
        public frmRptNhap(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();

        }
        public DataSet GetData()
        {
            DataSet ds = null;

            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
            try
            {

                string[] arrParaName = new string[] { "@Item_Id", "@From", "@To" };
                object[] arrValue = new object[] { 79, dateFrom.EditValue, dateTo.EditValue };
                _sql.Connect(_ConfigItem);
                ds = _sql.GetDataByStoredProcedure_DS("USP_RPT_NHAPKHO", arrParaName, arrValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _sql.Disconnect();
            }
            return ds;
        }

        public void ShowRPT(DataSet ds)
        {
            rptNhapHis rpt = new rptNhapHis();
            rpt.DataSource = ds;
            rpt.FillDataSource();
            printControl1.PrintingSystem = rpt.PrintingSystem;
            // Generate the report's print document. 
            rpt.CreateDocument();
            rpt.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.Parameters, new object[] { true });

        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowRPT(GetData());
        }
    }
}
