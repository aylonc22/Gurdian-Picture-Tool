using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gurdian_Picture_Tool
{
    public partial class Form4 : SfForm
    {
        public Form4()
        {
            InitializeComponent();
            this.Style.Border.Color = Color.FromArgb(194, 140, 23);
            string text = "";
            foreach (var t in Form1.FailedImages)
                text += t + "\r\n";
            this.textBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
