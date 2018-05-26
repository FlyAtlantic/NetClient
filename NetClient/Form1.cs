using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetClient
{
    public partial class Form1 : Form
    {
        public static string ServerName;
        public static string ServerIP;
        public static string ServerPort;

        public bool terminate = false;
        public bool terminated = false;

        Socket sck;

        public Form1()
        {
            InitializeComponent();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            cboxServer.Text = "Beta";

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
  
            sck.Connect("192.168.56.102", 6809);

            FSUIPCConnection.Open();

            lblStatus.Text = "Connected";
            lblStatus.ForeColor = Color.ForestGreen;
            txtChat.Text = "You are now connect on network server!";


        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            // terminate = true;
            // while (terminated == false) { }
            LATandLON.Stop();
            FSUIPCConnection.Close();
            sck.Close();
            sck.Dispose();

            txtCallsign.Enabled = true;
            txtAircraft.Enabled = true;
            txtChatText.Enabled = false;
            btnChatSend.Enabled = false;
            btnClose.Enabled = false;
            btnConnect.Enabled = false;

            lblStatus.Text = "Disconnected";
            lblStatus.ForeColor = Color.DarkRed;

            btnConnect.Text = "Connect";
            txtChat.Text = txtChat.Text + "\r\nYou are now disconnected on network server!";


        }
       
    }
}

