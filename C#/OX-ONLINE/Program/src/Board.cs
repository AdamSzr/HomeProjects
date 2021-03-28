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
    class Board
    {
        public static string[] GLOBAL_VAR = { " ", "X", "O"};
        public static string EMPTY = GLOBAL_VAR[0];
        public static string X     = GLOBAL_VAR[1];
        public static string O     = GLOBAL_VAR[2];

        private ArrayList board;
        public Board()
        {
            board = new ArrayList();
            {
                for (int i = 0; i < 9; i++)
                {
                    this.board.Add(Board.EMPTY);
                }
            }
        }

        public ArrayList get()  // NOT SURE
        {
            return new ArrayList(this.board);
        }
        public bool put(int where, string what)
        {
            if (!GLOBAL_VAR.Contains(what))
            {
                throw new Exception("Board dont expect this character");
            }

            if (!Enumerable.Range(0, board.Count).Contains(where)) // NOT SURE
            {
                throw new Exception("Board missed field on board.");
            }

            if (!this.board[where].Equals(Board.EMPTY))
            {
             //   Console.WriteLine("Already is somethink under this index");
                return false;
            }

            this.board[where] = what;
            return true;

        }
        public bool move_available()
        {
            return board.Contains(Board.EMPTY);
        }
    }
}
