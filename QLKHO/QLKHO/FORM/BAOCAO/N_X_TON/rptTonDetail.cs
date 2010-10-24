using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLKHO.FORM.BAOCAO.N_X_TON
{
    public partial class rptTonDetail : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTonDetail()
        {
            InitializeComponent();
        }

        private string[] GetSplit(string str) {

            string[] words = str.Split('|');
            for (int i = 0; i < words.Length;i++ )
                if (words[i] == "0")
                {
                    words[i] = "-";
                }
        return words  ;
        }

        private void xrLAll_TextChanged(object sender, EventArgs e)
        {


            string[] str = GetSplit(xrLAll.Text);
            if (str.Length >= 9)
            {
                xrLB1.Text = str[0];
                xrLB2.Text = str[1];
                xrLB3.Text = str[2];
                xrLB4.Text = str[3];
                xrLB5.Text = str[4];
                xrLB6.Text = str[5];
                xrLB7.Text = str[6];
                xrLB8.Text = str[7];
                
                xrLB9.Text = str[8];
            }
            //xrLB4.Text = str[3];
        }

        private void xrLabel16_TextChanged(object sender, EventArgs e)
        {
            string[] str = GetSplit(xrLabel16.Text);
            if (str.Length >= 9)
            {
              xrLabelB1.Text = str[0];
              xrLabelB2.Text = str[1];
              xrLabelB3.Text = str[2];
              xrLabelB4.Text = str[3];
              xrLabelB5.Text = str[4];
              xrLabelB6.Text = str[5];
              xrLabelB7.Text = str[6];
              xrLabelB8.Text = str[7];
              xrLabelB9.Text = str[8];
            }
        }



    }
}
