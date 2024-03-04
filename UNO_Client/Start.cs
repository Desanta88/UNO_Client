using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
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
        ServerConnection serverConnection = new ServerConnection();
        Byte[] sendBytes;
        Byte[] ReceiveBytes;
        string receivedData;
        Label l = new Label();
        int secondi = 5;
        bool connesso = false;
        public Start()
        {
            InitializeComponent();

        }



        private void Start_Load(object sender, EventArgs e)
        {

        }

        

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                NetworkStream ns;
                sendBytes = Encoding.ASCII.GetBytes(textBox1.Text);
                ReceiveBytes = new Byte[serverConnection.Client.ReceiveBufferSize];
                receivedData = Encoding.ASCII.GetString(ReceiveBytes);
                serverConnection.Client.Connect(server, porta);
                ns = serverConnection.Client.GetStream();
                ns.Write(sendBytes, 0, sendBytes.Length);
                ns.Read(ReceiveBytes);
                receivedData = Encoding.ASCII.GetString(ReceiveBytes).Replace("\0", "");
                MessageBox.Show(receivedData);
                labelNotice.Visible = true;
                timerReady.Start();
            }
        }

        private void timerReady_Tick(object sender, EventArgs e)
        {
            ReceiveBytes = new Byte[serverConnection.Client.ReceiveBufferSize];
            NetworkStream ns = serverConnection.Client.GetStream();
            ns.Read(ReceiveBytes);
            receivedData = Encoding.ASCII.GetString(ReceiveBytes).Replace("\0", "");
            if (receivedData == "start")
            {
                timerReady.Stop();
                labelNotice.Text = $"la partità inizierà tra {secondi} secondi";
                labelNotice.Location = new Point(250, 373);
                timerStart.Start();
                connesso = false;
            }
        }

        private void timerStart_Tick(object sender, EventArgs e)
        {
            secondi--;
            labelNotice.Text = $"la partità inizierà tra {secondi} secondi";
            if (secondi == 0)
            {
                Form1 form1 = new Form1(serverConnection,textBox1.Text);
                timerStart.Stop();
                this.Hide();
                form1.ShowDialog();

            }
        }
    }
}
