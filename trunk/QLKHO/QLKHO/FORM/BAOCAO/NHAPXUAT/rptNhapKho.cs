using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLKHO.FORM.BAOCAO.NHAPXUAT
{
    public partial class rptNhapKho : DevExpress.XtraReports.UI.XtraReport
    {
        public rptNhapKho()
        {
            InitializeComponent();
        }

        private void xrLabel21_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel tmp = (XRLabel)sender;
            int l_billNumber = COREBASE.COMMAND.Convert.Convert.CnvToInt32(xrLabel17.Text);
            int l_Price = COREBASE.COMMAND.Convert.Convert.CnvToInt32(xrLabel19.Text);
            int l_vat = COREBASE.COMMAND.Convert.Convert.CnvToInt32(xrLabel20.Text);
            tmp.Text = COREBASE.COMMAND.Convert.Convert.CnvToString(l_billNumber * l_Price * l_vat);
        }

    }
}
