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
  
            sck.Connect("37.59.115.154", 6809);

            FSUIPCConnection.Open();

            lblStatus.Text = "Connected";
            lblStatus.ForeColor = Color.ForestGreen;
            txtChat.Text = "You are now connect on network server!";


        }
       
    }
}

