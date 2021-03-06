﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MazeMVVM.ModelLib
{
    public class Client : IClient
    {
        private TcpClient client;
        private bool isConnected;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Client()
        {
        }


        /// <summary>
        /// Connect to server.
        /// </summary>
        /// <param name="ip"> ip address</param>
        /// <param name="port"> port number </param>
        public void connect(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            this.client = new TcpClient();
            client.Connect(ep);
            this.isConnected = true;
        }


        /// <summary>
        /// Disconnect from Server.
        /// </summary>
        public void disconnect()
        {
            this.isConnected = false;
            this.client.GetStream().Dispose();
            this.client.Close();
        }


        /// <summary>
        /// Read a string from stream.
        /// </summary>
        /// <returns> the string recieved </returns>
        public string read()
        {
            NetworkStream stream = this.client.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            return reader.ReadString();
        }


        /// <summary>
        /// Write a commant to stream.
        /// </summary>
        /// <param name="command"> the string to be send </param>
        public void write(string command)
        {
            NetworkStream stream = this.client.GetStream();
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(command);
        }
    }
}
