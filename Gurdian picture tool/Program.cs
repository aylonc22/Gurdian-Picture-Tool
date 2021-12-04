using System;
using System.Windows.Forms;
namespace Gurdian_picture_tool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Properties.Settings.Default.SfFormKey);          
            Properties.Settings.Default.r = "255";
            Properties.Settings.Default.g = "255";
            Properties.Settings.Default.b = "255";
            Properties.Settings.Default.format = "jpg";
            Properties.Settings.Default.jpgQuality = "80";
            Properties.Settings.Default.pngQualityInKB = 250;           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
