using Syncfusion.WinForms.Controls;
using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Gurdian_Picture_Tool
{
    public partial class botControl: SfForm
    {
        private string cmd = "Help";
        public botControl()
        {
            InitializeComponent();
            this.Style.Border.Color = Color.FromArgb(194, 140, 23);
            this.label1.Text = cmd;
        }
        private void SendUdpSocket(string msg)
        {
            IPAddress dest = Dns.GetHostAddresses(Properties.Settings.Default.server_ip)[0];
            IPEndPoint ePoint = new IPEndPoint(dest, int.Parse(Properties.Settings.Default.server_port));
            byte[] outBuffer = Encoding.ASCII.GetBytes(msg);
            Socket mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            mySocket.SendTo(outBuffer, ePoint);

            mySocket.Close();
        }

        private void botControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.app.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HandleText();
            cmd = "Help";
            this.label1.Text = cmd;
            this.textCommand1.SetText("**!Help** : Displays the help menu,\r\n**!Deck <code>** :  Displays the cards in a deck,\r\n * *!Card <name>** : Displays info of a card,\r\n * *!Find <riotName>** : Displays info of a player,	");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HandleText();
            cmd = "Announcement";
            this.label1.Text = cmd;
            this.textCommand1.SetText(Properties.Settings.Default.announcement);
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {

            this.Cursor = Cursors.Default;
        }
        
       

        private void button2_Click(object sender, EventArgs e)
        {
            HandleText();
            cmd = "Deck";
            this.label1.Text = cmd;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HandleText();
            cmd = "Card";
            this.label1.Text = cmd;
        }
        /// <summary>
        /// Send udp socket to discord bot and update his .cache
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save(); 
            SendUdpSocket("announcement\t" + Properties.Settings.Default.announcement);
            SendUdpSocket("patch\t" + Properties.Settings.Default.patch);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            HandleText();
            cmd = "Patch Notes";
            this.label1.Text = cmd;
            this.textCommand1.SetText(Properties.Settings.Default.patch);
        }
        private void HandleText()
        {
            if (cmd.Equals("Announcement"))
                Properties.Settings.Default.announcement = this.textCommand1.GetText();
               else
            if (cmd.Equals("Patch Notes"))
                Properties.Settings.Default.patch = this.textCommand1.GetText();


        }
    }
}
