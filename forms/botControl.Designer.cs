namespace Gurdian_Picture_Tool
{
    partial class botControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(botControl));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textCommand1 = new Gurdian_Picture_Tool.textCommand();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 60);
            this.button1.TabIndex = 2;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button6_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button6_MouseLeave);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 60);
            this.button2.TabIndex = 3;
            this.button2.Text = "Deck";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button6_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button6_MouseLeave);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(21, 196);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 60);
            this.button3.TabIndex = 4;
            this.button3.Text = "Card";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button6_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.button6_MouseLeave);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(21, 284);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(190, 60);
            this.button4.TabIndex = 5;
            this.button4.Text = "Announcement";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.MouseEnter += new System.EventHandler(this.button6_MouseEnter);
            this.button4.MouseLeave += new System.EventHandler(this.button6_MouseLeave);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(21, 370);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(190, 60);
            this.button5.TabIndex = 6;
            this.button5.Text = "Patch Notes";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.MouseEnter += new System.EventHandler(this.button6_MouseEnter);
            this.button5.MouseLeave += new System.EventHandler(this.button6_MouseLeave);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(553, 380);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(126, 56);
            this.button6.TabIndex = 8;
            this.button6.Text = "Save";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            this.button6.MouseEnter += new System.EventHandler(this.button6_MouseEnter);
            this.button6.MouseLeave += new System.EventHandler(this.button6_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(282, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // textCommand1
            // 
            this.textCommand1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
            this.textCommand1.Location = new System.Drawing.Point(454, -2);
            this.textCommand1.Name = "textCommand1";
            this.textCommand1.Size = new System.Drawing.Size(351, 410);
            this.textCommand1.TabIndex = 7;
            // 
            // botControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textCommand1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "botControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Style.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(27)))), ((int)(((byte)(42)))));
            this.Style.TitleBar.BottomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(140)))), ((int)(((byte)(23)))));
            this.Style.TitleBar.CloseButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(140)))), ((int)(((byte)(23)))));
            this.Style.TitleBar.ForeColor = System.Drawing.Color.White;
            this.Style.TitleBar.MinimizeButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(140)))), ((int)(((byte)(23)))));
            this.Text = "Bot Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.botControl_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private textCommand textCommand1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
    }
}