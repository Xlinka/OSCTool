﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;

namespace TeriziaMultitoolS
{
    public class OscSender
    {
        private UdpClient udpClient;
        private IPEndPoint remoteEndPoint;

        public OscSender(string ipAddress, int port)
        {
            remoteEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            udpClient = new UdpClient();
        }

        public void Connect()
        {
            udpClient.Connect(remoteEndPoint);
        }

        public void Send(string address, string data)
        {
            byte[] addressBytes = GetPaddedBytes(address);
            byte[] typeTagBytes = GetPaddedBytes(",s"); // ",s" indicates a single string argument
            byte[] dataBytes = GetPaddedBytes(data);

            byte[] message = new byte[addressBytes.Length + typeTagBytes.Length + dataBytes.Length];
            Array.Copy(addressBytes, 0, message, 0, addressBytes.Length);
            Array.Copy(typeTagBytes, 0, message, addressBytes.Length, typeTagBytes.Length);
            Array.Copy(dataBytes, 0, message, addressBytes.Length + typeTagBytes.Length, dataBytes.Length);

            udpClient.Send(message, message.Length);
        }

        public void Send(string address, float data)
        {
            byte[] addressBytes = GetPaddedBytes(address);
            byte[] typeTagBytes = GetPaddedBytes(",f"); // ",f" indicates a single float argument
            byte[] dataBytes = BitConverter.GetBytes(data);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(dataBytes);
            }

            byte[] message = new byte[addressBytes.Length + typeTagBytes.Length + dataBytes.Length];
            Array.Copy(addressBytes, 0, message, 0, addressBytes.Length);
            Array.Copy(typeTagBytes, 0, message, addressBytes.Length, typeTagBytes.Length);
            Array.Copy(dataBytes, 0, message, addressBytes.Length + typeTagBytes.Length, dataBytes.Length);

            udpClient.Send(message, message.Length);
        }

        private byte[] GetPaddedBytes(string input)
        {
            List<byte> bytes = new List<byte>(Encoding.ASCII.GetBytes(input));
            bytes.Add(0); // Null terminator
            while (bytes.Count % 4 != 0)
                bytes.Add(0); // Padding to 4 bytes

            return bytes.ToArray();
        }

        public void Close()
        {
            udpClient.Close();
        }
    }
}
