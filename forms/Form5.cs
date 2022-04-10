using Microsoft.WindowsAPICodePack.Dialogs;
using Syncfusion.WinForms.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gurdian_Picture_Tool
{
    public partial class Form5 : SfForm
    {
        bool first;
        Settings settings = Settings.Instance;
        public Form5(bool first = false)
        {
            InitializeComponent();
            this.first = first;
            this.Style.Border.Color = Color.FromArgb(194, 140, 23);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (first)
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = "C:\\Users";
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                    settings.savePath = dialog.FileName;
                else
                {
                    MessageBox.Show("Please choose a defualt directory", "Alert");
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region  Hover Buttons
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void button5_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void Form5_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Form5_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region Can find us 
        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/aylonc22");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.lorguardian.com/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.com/invite/jNrpFAC");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/LoRCommunity");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/LoR_Guardian");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.reddit.com/r/LoR_Community/");

        }
        #endregion

    }
}
