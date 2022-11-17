using System.Net.Sockets;
using System.Net;

namespace Client
{
    public class AllAboutSocket
    {
        private const string IP = "127.0.0.1";
        private const int PORT = 8888;

        private readonly IPEndPoint tcpEndPoint = new IPEndPoint(IPAddress.Parse(IP), PORT);
        private readonly Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void Connect()
        {
            if (!socket.Connected)
                socket.Connect(tcpEndPoint);
        }

        public void Disconnect()
        {
            if (socket.Connected)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }

        public void Send(byte[] thing)
        {
            socket.Send(thing);
        }
        public int Receive(byte[] thing)
        {
            return socket.Receive(thing);
        }

        public bool AvailableBiggerThanZero()
        {
            if (socket.Available > 0)
                return true;
            else
                return false;
        }
    }
}

