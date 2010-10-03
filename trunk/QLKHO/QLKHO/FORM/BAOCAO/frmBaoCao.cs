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

        public void ShowBaoCao(XtraReport p_XtraReport, DataSet p_DataSource, Form p_Parent)
        {
            if (p_XtraReport == null)
                p_XtraReport = new XtraReport();
            p_XtraReport.DataSource = p_DataSource;
            p_XtraReport.FillDataSource();
            printControl1.PrintingSystem = p_XtraReport.PrintingSystem;
            p_XtraReport.CreateDocument();
            this.MdiParent = p_Parent;
            this.Show();
        }

        public void ShowBaoCao(XtraReport p_XtraReport, DataSet p_DataSource)
        {
            if (p_XtraReport == null)
                p_XtraReport = new XtraReport();
            p_XtraReport.DataSource = p_DataSource;
            p_XtraReport.FillDataSource();
            printControl1.PrintingSystem = p_XtraReport.PrintingSystem;
            p_XtraReport.CreateDocument();
            this.Show();
        }

        public void ShowBaoCaoDlg(XtraReport p_XtraReport, DataSet p_DataSource)
        {
            if (p_XtraReport == null)
                p_XtraReport = new XtraReport();
            p_XtraReport.DataSource = p_DataSource;
            p_XtraReport.FillDataSource();
            printControl1.PrintingSystem = p_XtraReport.PrintingSystem;
            p_XtraReport.CreateDocument();
            this.ShowDialog();
        }

    }
}
