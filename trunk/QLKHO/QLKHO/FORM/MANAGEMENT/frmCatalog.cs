using System;
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
    public partial class frmCatalog : COREBASE.FORM.BASEFORM
    {
        CatalogDao DaoCat;
        public frmCatalog(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();
            DaoCat = new CatalogDao(_ConfigItem);
            this.Load += new EventHandler(frmCatalog_Load);
        }

        void frmCatalog_Load(object sender, EventArgs e)
        {
            LoadGird();
        }
        public void LoadGird()
        {
            gvCat.DataSource = DaoCat.GetList();

        }
    }
}