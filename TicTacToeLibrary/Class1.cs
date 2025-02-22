using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TicTacToeLibrary
{
    public class Client
    {
        private TcpClient client;
        private NetworkStream stream;
        public char[] board = new char[9];
        private static StreamWriter writer;
        public char Symbol { get; private set; }
        public Client(string ip, int port)
        {
            client = new TcpClient(ip, port);
            stream = client.GetStream();
            Console.WriteLine("Подключено к серверу");
        }

        public void Play()
        {
            Thread recieveThread = new Thread(RecieveMessage);
            recieveThread.Start();
            //while (true)
            //{
            //    string str = Console.ReadLine();
            //    byte[] data = Encoding.UTF8.GetBytes(str);
            //    stream.Write(data, 0, data.Length);
            //}
        }
        public void RecieveMessage()
        {
            while (true)
            {
                byte[] buffer = new byte[256];
                int readBytes = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, readBytes);
                //Console.WriteLine(message);
                if (message == "X" || message == "O")
                {
                    Symbol = message[0];
                }
                if (message == "win")
                {

                }
                else if (message == "draw")
                {

                }
                else if (message == "lose")
                {

                }
            }
        }
        public char[] GetBoard()
        {
            return board;
        }
        public void SendIndex(int index)
        {

            byte[] data = Encoding.UTF8.GetBytes(index.ToString());
            stream.Write(data, 0, data.Length);
        }

    }
}
