using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLKHO.DATAOBJECT;

namespace QLKHO.FORM.NHAPXUAT
{
    public partial class ChuyenPhong : COREBASE.FORM.BASEFORM
    {
        DepartmentsDao Dao;
        public ChuyenPhong(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            InitializeComponent();
            _ConfigItem = _ConfItem;
            Dao = new DepartmentsDao(_ConfigItem);
        }

        private void ChuyenPhong_Load(object sender, EventArgs e)
        {
            //cmbPBChuyen.d
        }

        private void cmbPBChuyen_EditValueChanged(object sender, EventArgs e)
        {

        }

   
    }
}