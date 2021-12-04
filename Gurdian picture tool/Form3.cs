using System;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;
namespace Gurdian_picture_tool
{
    public partial class Form3 : SfForm
    {
        public Form3()
        {
            InitializeComponent();
            this.Style.Border.Color = Color.FromArgb(194, 140, 23);
            this.comboBox1.SelectedIndex = Properties.Settings.Default.format.Equals("jpg")?0:1;
            this.numericUpDown2.Value = Convert.ToDecimal(Properties.Settings.Default.jpgQuality);
            this.numericUpDown1.Value = Convert.ToDecimal(Properties.Settings.Default.pngQualityInKB);
            if (this.comboBox1.SelectedIndex == 0)
            {
                this.label3.Visible = true;
                this.numericUpDown2.Visible = true;                
                this.label2.Visible = false;
                this.numericUpDown1.Visible = false;
            }
            else if (this.comboBox1.SelectedIndex == 1)
            {
                this.label2.Visible = true;
                this.numericUpDown1.Visible = true;               
                this.label3.Visible = false;
                this.numericUpDown2.Visible = false;
            }

        }       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
            {
                this.label3.Visible = true;
                this.numericUpDown2.Visible = true;
                this.label2.Visible = false;
                this.numericUpDown1.Visible = false;

            }
            else if (this.comboBox1.SelectedIndex == 1)
            {
                this.label2.Visible = true;
                this.numericUpDown1.Visible = true;
                this.label3.Visible = false;
                this.numericUpDown2.Visible = false;
            }
        }

        #region Hover Buttons
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
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
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.format = this.comboBox1.SelectedItem.ToString();
            if(this.comboBox1.SelectedItem.ToString().Equals("jpg"))
                Properties.Settings.Default.jpgQuality = this.numericUpDown2.Value.ToString();
            else if (this.comboBox1.SelectedItem.ToString().Equals("png"))
                Properties.Settings.Default.pngQualityInKB = (int)(this.numericUpDown1.Value);
        }
    }
}
