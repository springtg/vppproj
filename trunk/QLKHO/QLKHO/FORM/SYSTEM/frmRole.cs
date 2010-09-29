using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLKHO.FORM.SYSTEM
{
    public partial class frmRole : COREBASE.FORM.BASEFORM
    {
        public frmRole(COREBASE.COMMAND.Config.ConfigItem _ConfItem)
        {
            _ConfigItem = _ConfItem;
            InitializeComponent();
        }
    }
}
