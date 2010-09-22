using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using QLKHO.DATAOBJECT;
namespace QLKHO.REPORT
{
    public partial class Demo : COREBASE.FORM.BASEFORM
    {
        public Demo(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XtraReport1 rpt = new XtraReport1();

            DataTable dt = CatalogDao.GetList(_ConfigItem);
            rpt.DataSource = dt;
            rpt.FillDataSource();

            printControl1.PrintingSystem = rpt.PrintingSystem;

            // Generate the report's print document. 
            rpt.CreateDocument();  
          //  rpt.ShowPreview();

        }



    }
}