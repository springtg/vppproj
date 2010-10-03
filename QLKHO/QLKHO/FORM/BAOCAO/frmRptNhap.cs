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
        static int type = 0;
        public frmRptNhap(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();

        }
        public void ShowRPT(int _type) {
            type = _type;
            this.Show();
        }
        public DataSet GetData(int  type)
        {
            DataSet ds = null;
            string store = "USP_RPT_NHAPKHO";
            if (type == 1)
                store = "USP_RPT_XUATKHO";
            else if(type == 0)
                store = "USP_RPT_NHAPKHO";
            else  store = "USP_RPT_XUAT_PB";
            COREBASE.COMMAND.SQL.AccessSQL _sql = new COREBASE.COMMAND.SQL.AccessSQL(_ConfigItem);
            try
            {
                
                string[] arrParaName = new string[] { "@Item_Id", "@From", "@To" };
                object[] arrValue = new object[] { 79, dateFrom.EditValue, dateTo.EditValue };
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

        public void ShowRPT(DataSet ds, int type)
        {
            DevExpress.XtraReports.UI.XtraReport rpt;
            if (type == 0)
                rpt = new rptNhapHis();
            else if (type == 1)
                rpt = new rptXuatHis();
            else rpt = new rptXuatPBHis();
            rpt.DataSource = ds;
            rpt.FillDataSource();
            printControl1.PrintingSystem = rpt.PrintingSystem;
            // Generate the report's print document. 
            rpt.CreateDocument();
            rpt.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.Parameters, new object[] { true });

        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowRPT(GetData(type),type);
        }
    }
}
