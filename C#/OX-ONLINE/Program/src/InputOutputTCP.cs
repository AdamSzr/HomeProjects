using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace GameLogic
{
    using System.Collections;

    class InputOutputTCP :IOutput,IInput
    {

        Socket s;
        Socket conn;

        public InputOutputTCP(string ipV4,int port)
        {
            this. s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.s.Bind(new IPEndPoint(IPAddress.Parse(ipV4), port));
            this.s.Listen(5); //Max ilość polaczen
            Console.WriteLine("Waiting for connection on port :"+port);
            this.conn = s.Accept();
            Console.WriteLine("Player 2 connect: " + (this.conn.RemoteEndPoint as IPEndPoint).Address);
            // this.s.Shutdown(SocketShutdown.Both);
            this.s.Close();
        }

        public int? get_move()
        {
            
            this.conn.Send(System.Text.ASCIIEncoding.UTF8.GetBytes("G"));
            byte[] rec=new byte[32];              // safe capacity
            this.conn.Receive(rec, 32, SocketFlags.None);
            char packet_ID = System.Convert.ToChar(rec[0]);
            if( packet_ID != 'g')
            {
                throw new Exception("invalid response");
            }
            string move = System.Convert.ToChar(rec[1]).ToString(); // rec ''  BŁĄD.
            int retu_= int.Parse(move);
            return retu_;
           
        }

        public void show_board(ArrayList board)
        {
         //   this.conn.Send(System.Text.ASCIIEncoding.UTF8.GetBytes("B"));
            System.Collections.Generic.List<byte> bytes_to_send = new List<byte>(System.Text.ASCIIEncoding.UTF8.GetBytes("B"));
            foreach(object x in board)
            {
                char z = System.Convert.ToChar(x.ToString());
                bytes_to_send.Add(System.Convert.ToByte(z));
            }
           
            string _t_ = System.Text.ASCIIEncoding.UTF8.GetString(bytes_to_send.ToArray());
            Console.WriteLine($"Sending: [" + _t_ + "] ");
            byte[] ar = bytes_to_send.ToArray();
            this.conn.Send(ar);
        //    bytes_to_send.AddRange(System.Text.ASCIIEncoding.UTF8.GetBytes(b));

        }

        public void show_draw()
        {
            this.conn.Send(System.Text.ASCIIEncoding.UTF8.GetBytes("D"));
        }

        public void show_move_error(string player)
        {
           
            if(player==GameLogic.Board.O)
            {
                this.conn.Send(System.Text.ASCIIEncoding.UTF8.GetBytes("M" + GameLogic.Board.O));
            }
            else
            {
                this.conn.Send(System.Text.ASCIIEncoding.UTF8.GetBytes("M" + GameLogic.Board.X));
            }

        }

        public void show_player_turn(string player)
        {
            System.Collections.Generic.List<byte> bytes_to_send = new List<byte>(System.Text.ASCIIEncoding.UTF8.GetBytes("P"));
            bytes_to_send.AddRange(System.Text.ASCIIEncoding.UTF8.GetBytes(player));
            this.conn.Send(bytes_to_send.ToArray());
        }

        public void show_welcome()
        {
            this.conn.Send(System.Text.ASCIIEncoding.UTF8.GetBytes("W"));
        }

        public void show_winner(string player)
        {
            System.Collections.Generic.List<byte> bytes_to_send = new List<byte>(System.Text.ASCIIEncoding.UTF8.GetBytes("I"));
            bytes_to_send.AddRange(System.Text.ASCIIEncoding.UTF8.GetBytes(player));
            
            this.conn.Send(bytes_to_send.ToArray());
            // :TODO
        }
    }

}
