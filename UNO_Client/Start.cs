using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace UNO_Client
{
    public partial class Start : Form
    {
        string server = "127.0.0.1";
        int porta = 8000;
        TcpClient client = new TcpClient();
        NetworkStream ns;
        public Start()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Byte[] sendBytes = Encoding.ASCII.GetBytes("mi sto connettendo connesso a te");
                Byte[] ReceiveBytes=new Byte[client.ReceiveBufferSize];
                string receivedData;
                client.Connect(server, porta);
                ns = client.GetStream();
                ns.Write(sendBytes,0,sendBytes.Length);

                ns.Read(ReceiveBytes);
                receivedData = Encoding.ASCII.GetString(ReceiveBytes);
                MessageBox.Show(receivedData);
            }
        }
    }
}
