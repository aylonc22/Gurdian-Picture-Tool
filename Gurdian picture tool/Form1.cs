using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Threading;
using Syncfusion.WinForms.Controls;

namespace Gurdian_picture_tool
{
    public partial class Form1 : SfForm
    {
                private string toSave = null;
        private List<string> imgs = new List<string>();
        private List<Thread> tasks = new List<Thread>();
        public Form1()
        {            
            InitializeComponent();
            this.Style.Border.Color = Color.FromArgb(194, 140, 23);
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
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new OpenFileDialog();
            f.Multiselect = true;
            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK && f.FileNames.Length>0)
            {
              imgs = f.FileNames.ToList();
               
            }
            else
                if (f.FileNames.Length == 0)
                MessageBox.Show("no image was chosen", "alert");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (imgs.Count > 0 && toSave == null)
            {
                MessageBox.Show("Please choose a place to save", "Alert");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            Thread t = new Thread(() => 
            {
              foreach(var img in imgs)
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
                            Form2.Apply(bm, bmFull, bmName, img, full, toSave);
                        else
                        {
                            Form2 form2 = new Form2(bm, bmFull, bmName,img,full,toSave);
                            form2.ShowDialog();
                        }                        
                    }                    
                }
                this.Invoke((MethodInvoker)(() => { 
                    this.Cursor = Cursors.Default;
                    this.pictureBox1.Image = Properties.Resources.logo;
                }));
            });
            t.Start();
            tasks.Add(t);
            
        }                                   
       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var task in tasks)
                task.Abort();
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
        #endregion
    }
}
