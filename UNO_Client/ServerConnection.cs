using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UNO_Client
{
    public class ServerConnection
    {
        private static ServerConnection instance;
        private TcpClient client;

        public ServerConnection()
        {
            // Inizializza la connessione al server
            client = new TcpClient();
        }

        public static ServerConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new ServerConnection();
            }
            return instance;
        }

        public TcpClient GetClient
        {
            get { return client; }
        }
    }
}
