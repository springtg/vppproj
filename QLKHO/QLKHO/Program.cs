using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace QLKHO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.UserSkins.OfficeSkins.Register();
            if (!DevExpress.Skins.SkinManager.AllowFormSkins)
                DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Money Twins";
            //Coffee
            //Liquid Sky
            //London Liquid Sky
            //Glass Oceans
            //Stardust
            //Xmas 2008 Blue
            //Valentine
            //McSkin
            //Summer 2008
            //Pumpkin
            //Dark Side
            //Springtime
            //Darkroom
            //Foggy
            //High Contrast
            //Seven
            //Seven Classic
            //Sharp
            //Sharp Plus
            //Available skins in DevExpress.OfficeSkins.v10.1:

            //Office 2007 Blue
            //Office 2007 Black
            //Office 2007 Silver
            //Office 2007 Green
            //Office 2007 Pink
            //Office 2010 Blue
            //Office 2010 Black
            //Office 2010 Silver
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin ());
        }
    }
}
