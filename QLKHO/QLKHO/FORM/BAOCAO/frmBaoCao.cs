using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace QLKHO.FORM.BAOCAO
{
    public partial class frmBaoCao : COREBASE.FORM.BASEFORM
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }

        public void ShowBaoCao(XtraReport p_XtraReport, DataTable p_DataSource, Form p_Parent)
        {
            if (p_XtraReport == null)
                p_XtraReport = new XtraReport();
            p_XtraReport.DataSource = p_DataSource;
            p_XtraReport.FillDataSource();
            printControl1.PrintingSystem = p_XtraReport.PrintingSystem;

            // Generate the report's print document. 
            p_XtraReport.CreateDocument();
            //  rpt.ShowPreview();
            this.MdiParent = p_Parent;
            this.Show();
        }
    }
}
