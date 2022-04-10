using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Threading;
using Syncfusion.WinForms.Controls;

namespace Gurdian_Picture_Tool
{
    public partial class Form1 : SfForm
    {
        Settings settings = Settings.Instance;
        private string toSave;//Properties.Settings.Default.savePath;
        private List<string> imgs = new List<string>();
        private List<Thread> tasks = new List<Thread>();        
        public static List<string> FailedImages = new List<string>();       
        public Form1()
        {
            InitializeComponent();
            toSave = settings.savePath;
            this.Style.Border.Color = Color.FromArgb(194, 140, 23);
            this.label1.Text = settings.savePath;//Properties.Settings.Default.savePath;           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                toSave = dialog.FileName;
                this.label1.Text = toSave;
                var temp = new {
                 r = settings.r,
                 g = settings.g,
                 b =settings.b,
                 pngQualityInKB = settings.pngQualityInKB,
                 jpgQuality = settings.jpgQuality,
                 format = settings.format,                 
                 server_ip = settings.server_ip,
                 server_port = settings.server_port,
                 announcement = settings.announcement,
                 patch = settings.patch,
                 js = settings.js,
                };
                Settings.Sync();
                settings.savePath = toSave;
                Settings.Update();
                settings.r = temp.r;
                settings.g = temp.g;
                settings.b = temp.b;
                settings.pngQualityInKB = temp.pngQualityInKB; 
                settings.jpgQuality = temp.jpgQuality;
                settings.format = temp.format;
                settings.server_ip = temp.server_ip;
                settings.server_port = settings.server_port;
                settings.announcement = temp.announcement;
                settings.patch = temp.patch;
                settings.js = temp.js;
       
    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog();
            f.Multiselect = true;
            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK && f.FileNames.Length > 0)
            {
                imgs = f.FileNames.ToList();

            }
            else
                if (f.FileNames.Length == 0)
                MessageBox.Show("no image was chosen", "alert");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (imgs.Count > 0 && toSave.Equals(""))
            {
                MessageBox.Show("Please choose a place to save", "Alert");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            Thread t = new Thread(() =>
            {
                foreach (var img in imgs)
                {
                    if (!img.Contains("full"))
                    {

                        this.Invoke((MethodInvoker)(() => { this.pictureBox1.ImageLocation = img; }));
                        var full = img.Substring(0, img.LastIndexOf('\\')) +
                         img.Substring(img.LastIndexOf('\\'), img.Length - img.LastIndexOf('\\') - (img.Length - img.LastIndexOf('.'))) +
                        "-full" + img.Substring(img.LastIndexOf('.'), img.Length - img.LastIndexOf('.'));
                        if (!File.Exists(full))
                        {
                            MessageBox.Show("Missing full image", "Attention");
                            return;
                        }
                        Bitmap bm = new Bitmap(img);
                        Bitmap bmFull = new Bitmap(full);
                        string bmName = img.Substring(img.LastIndexOf('\\'), img.Substring(img.LastIndexOf('\\')).Length - (img.Substring(img.LastIndexOf('.'))).Length);
                        if (this.checkBox1.Checked)
                            Form2.Apply(bm, bmFull, bmName, img, full, toSave==null? settings.savePath : toSave);
                        else
                        {
                            Form2 form2 = new Form2(bm, bmFull, bmName, img, full, toSave == null ? settings.savePath : toSave);
                            form2.ShowDialog();
                        }
                    }
                }
                this.Invoke((MethodInvoker)(() => {
                    this.Cursor = Cursors.Default;
                    this.pictureBox1.Image = Properties.Resources.logo;
                }));
                if (FailedImages.Count > 0)
                {
                    Form4 f = new Form4();
                    f.Show();
                    FailedImages.Clear();
                }
            });
            t.Start();
            tasks.Add(t);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var task in tasks)
                task.Abort();
            Program.app.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }


        #region Hover Buttons
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
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
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.ShowDialog();
        }

       
    }
}
