using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLKHO.FORM.NHAPXUAT
{
    public partial class ChuyenPhong : COREBASE.FORM.BASEFORM
    {
        public ChuyenPhong(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            InitializeComponent();
            _ConfigItem = _ConfItem;
        }
    }
}