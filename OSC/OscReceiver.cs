using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TeriziaMultitoolS
{
    public class OscReceiver
    {
        private UdpClient udpClient;
        private IPEndPoint remoteEndPoint;

        public delegate void OscMessageReceivedHandler(string address, string data);
        public event OscMessageReceivedHandler OnOscMessageReceived;

        public OscReceiver(int port)
        {
            remoteEndPoint = new IPEndPoint(IPAddress.Any, port);
            udpClient = new UdpClient(port);
        }

        public void StartListening()
        {
            udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            byte[] receivedBytes = udpClient.EndReceive(ar, ref remoteEndPoint);
            udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), null); // Continue listening

            string address = ExtractStringFromBytes(receivedBytes, 0);
            string data = ExtractStringFromBytes(receivedBytes, address.Length + 4); // Skip address and type tag

            OnOscMessageReceived?.Invoke(address, data);
        }

        private string ExtractStringFromBytes(byte[] bytes, int startIndex)
        {
            int length = 0;
            for (int i = startIndex; i < bytes.Length; i++)
            {
                if (bytes[i] == 0)
                {
                    break;
                }
                length++;
            }
            return Encoding.ASCII.GetString(bytes, startIndex, length);
        }

        public void Close()
        {
            udpClient.Close();
        }
    }
}
