using System;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 // Gyn cz 3            ->                  48:20


namespace C_Sharp_Client
{
    class Program
    {
        NetSock s;
        XoXoXo xo;
        static int Main(string[] args)
        {
            Program prog = new Program();
            prog.xo = new XoXoXo();
            Console.WriteLine(string.Join(' ', args));

            if (args.Length != 2) // in c# we dont have args[0] == file.exe 
            {
                prog.usage();
                return 1;
            }
            int port;
            try
            {
                port = System.Convert.ToInt32(args[1]);
            }
            catch (FormatException) { return 2; }

            string host = args[0];
            prog.s = new NetSock(host, port);

            if (!prog.s.IsConnected())
            {
                Console.WriteLine("Could not connect! ");
                return 3;
            }

            while(true)
            {
                if (!prog.xo.HandleSingleRequest(prog.s))
                    break;
            }



            prog.s.Disconnect();
            return 0;
        }
        void usage()
        {
            Console.WriteLine("Usage: XOXOXOO <host> <port> ");
        }
    }
    class XoXoXo
    {
        public XoXoXo()
        {
        }
        public bool HandleSingleRequest(NetSock s)
        {
            Socket socket = s.GetSocket;
            byte[] packet_ID = new byte[32];
            int ret = socket.Receive(packet_ID, 1, SocketFlags.None); // przyjety tylko 1 byte
            if (ret == 0) { Console.WriteLine("Disconected_1_"); return false; }
            char z = System.Convert.ToChar(packet_ID[0]);
            Console.WriteLine($"SwitchArg BY [ {z} ]");

            switch (System.Convert.ToChar(packet_ID[0]))
            {
                case 'G':
                    int move = this.HandleGetMoveRequest();

                    System.Collections.Generic.List<byte> bytes_to_send = new List<byte>(System.Text.ASCIIEncoding.UTF8.GetBytes("g"+ move.ToString()));
                    socket.Send(bytes_to_send.ToArray());

                    break;
                case 'W':
                    this.HandleShowWelcome();
                    break;
                case 'D':
                    this.HandleShowDraw();
                    break;
                case 'B':
                    byte[] board = new byte[32];
                    int zzzz = socket.Receive(board,9,SocketFlags.None);
                    if (zzzz != 9)
                    {
                        Console.WriteLine("Disconected_2_");
                        return false;
                    }
                    this.HandleShowBoard(System.Text.ASCIIEncoding.UTF8.GetString(board));
                    break;
                case 'P':
                    byte[] player = new byte[32];
                    int ilosc = socket.Receive(player,1,SocketFlags.None);
                    if ( ilosc != 1)
                    {
                        Console.WriteLine("Disconeccted _1_");
                        return false;
                    }
                    this.HandleShowPlayerTurn(System.Convert.ToChar(player[0]));
                    break;
                case 'M':
                    player = new byte[32];
                    int rec_ved = socket.Receive(player,1,SocketFlags.None);
                    if (rec_ved != 1)
                    {
                        Console.WriteLine("Disconeccted _M_");
                        return false;
                    }
                    this.HandleShowMoveError(System.Convert.ToChar(player[0]));
                    break;
                case 'I':
                    player = new byte[32];
                    if (socket.Receive(player) != 1)
                    {
                        Console.WriteLine("Disconeccted _3_");
                        return false;
                    }
                    this.HandleShowWinner(System.Convert.ToChar(player[0]));
                    break;

                default:
                    Console.WriteLine("Invalid packet ID");
                    return false;
            }


            return true;
        }
        private void HandleShowWelcome()
        {
            Console.WriteLine("welcome");
        }
        private void HandleShowBoard(string board)
        {// TODO move safety
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]}");
        }
        private void HandleShowPlayerTurn(char player)
        {
            Console.WriteLine($"Player {player.ToString()} turn.");
        }
        private void HandleShowMoveError(char player)
        {
            Console.WriteLine($"error error wrong move player {player.ToString()}.");
        }
        private void HandleShowWinner(char player)
        {
            Console.WriteLine($"Player {player.ToString()} won.");
        }
        private void HandleShowDraw()
        {
            Console.WriteLine("Draw !");
        }

        private int HandleGetMoveRequest()
        {
            Console.WriteLine($"Your move (0-8) !");
            return int.Parse(Console.ReadLine());

        }

    }
    class NetSock
    {
        private Socket s;
        public NetSock(string host, int port)
        {
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(new IPEndPoint(IPAddress.Parse(host), port));
        }
        public bool IsConnected() => this.s.Connected;
        public void Disconnect()
        {
            this.s.Shutdown(SocketShutdown.Both);
            this.s.Close();
        }
        public Socket GetSocket
        {
            get => this.s;
        }

    }
}