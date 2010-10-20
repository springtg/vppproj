using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLKHO.FORM.BAOCAO.N_X_TON;
namespace QLKHO.FORM.BAOCAO
{
    public partial class frmRptTonKho : COREBASE.FORM.BASEFORM
    {
        public frmRptTonKho(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();
        }
        int type = 0;
        public void ShowRPT(int _type) {
            type = _type;
            this.Show();
        }
        public DataSet GetData()
        {
            DataSet ds = null;
            string store = "USP_RptTonKho";
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
            try
            {
                string[] arrParaName = new string[] {"@fromMonth", "@toMonth" };
                object[] arrValue = new object[] {dateFrom.EditValue, dateTo.EditValue };
                _sql.Connect(_ConfigItem);

                ds = _sql.GetDataByStoredProcedure_DS(store, arrParaName, arrValue);
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
        public DataSet GetDataDetail()
        {
            DataSet ds = null;
            string store = "USP_RptTonKhoDetail";
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
            try
            {
                string[] arrParaName = new string[] { "@fromMonth", "@toMonth" };
                object[] arrValue = new object[] { dateFrom.EditValue, dateTo.EditValue };
                _sql.Connect(_ConfigItem);

                ds = _sql.GetDataByStoredProcedure_DS(store, arrParaName, arrValue);
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
       // []
        public void Show(DataSet ds,int type)
        {
            DevExpress.XtraReports.UI.XtraReport rpt;
            if (type == 0)
                rpt = new rptTonDetail();
            else 
                rpt = new rptTonkho();
            rpt.DataSource = ds;
            rpt.FillDataSource();
            printControl1.PrintingSystem = rpt.PrintingSystem;
            // Generate the report's print document. 
            rpt.CreateDocument();
            rpt.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.Parameters, new object[] { true });

        
        }
        private void btnShow_Click_1(object sender, EventArgs e)
        {
            if(type==0)
             Show(GetData(),0);
            else
            Show(GetDataDetail(),1);
        }
    }
}
