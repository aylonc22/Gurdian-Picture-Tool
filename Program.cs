using System;
using System.Windows.Forms;

namespace Gurdian_Picture_Tool
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Properties.Settings.Default.SfFormKey);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Properties.Settings.Default.r = "255";
            Properties.Settings.Default.g = "255";
            Properties.Settings.Default.b = "255";
            Properties.Settings.Default.format = "jpg";
            Properties.Settings.Default.jpgQuality = "80";
            Properties.Settings.Default.pngQualityInKB = 250;
            //Properties.Settings.Default.savePath = "";
            //Properties.Settings.Default.first = true;
            bool flag = false;
            if (Properties.Settings.Default.first)
            {               
                while (Properties.Settings.Default.savePath.Equals("") && !flag)
                { 
                    Form5 f = new Form5(true);
                    if (f.ShowDialog() == DialogResult.Cancel)
                        flag = true;                    
                }               
            }
            Properties.Settings.Default.first = false;
            Properties.Settings.Default.Save();            
            if(!flag)
            Application.Run(new Form1());
        }
    }
}
