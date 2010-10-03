using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLKHO.FORM.BAOCAO.NHAPXUAT
{
    public partial class rptTakeIns : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTakeIns()
        {
            InitializeComponent();
        }

        private void xrLabel40_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel40.Text = (int.Parse(xrLabel18.Text) * int.Parse(xrLabel19.Text)).ToString();
        }

  
    }
}
