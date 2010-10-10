using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QLKHO.FORM.SYSTEM
{
    public partial class Intro : COREBASE.FORM.BASEFORM
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void Intro_Load(object sender, EventArgs e)
        {
            try
            {
                labelControl1.Text = Environment.UserName;
            }
            catch (Exception ex)
            {
                AppDebug(ex);
            }
        }
    }
}
