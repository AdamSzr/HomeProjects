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
    class Game
    {
        private Board board;
        public static string PLAYER1 = Board.X;
        public static string PLAYER2 = Board.O;
        public static string[] PLAYERS = { PLAYER1, PLAYER2 };

        public string turn;
        private bool end;
#nullable enable
        private string? win;
#nullable disable
        public Game()
        {
            this.board = new Board();
            this.turn = PLAYER1;
            this.end = false;
            this.win = null; //null, PLAYER1, PLAYER2
        }
        public int get_turn_no()
        {
            return GameLogic.Game.PLAYERS.ToList().IndexOf(this.turn);
        }

        /// <summary>
        /// Gets the end of game.
        /// </summary>
        /// <returns>true if game has ended, otherwise false </returns>
        public bool get_end() => this.end;

        /// <summary>
        /// Gets the winner.
        /// </summary>
        /// <returns>Null, PLAYER1, PLAYER2 </returns>
        public string get_winner() => this.win;

        /// <summary>
        /// Gets turn.
        /// </summary>
        /// <returns>PLAYER1, PLAYER2</returns>
        public string get_turn() => this.turn;

        /// <summary>
        /// Gets board.
        /// </summary>
        /// <returns>Copy of the orginal board.</returns>
        public ArrayList get_board() => this.board.get();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        public bool make_move(int where)
        {
         
            if (!Enumerable.Range(0, 9).Contains(where))
                return false;
            
            if (this.end)
                return false;
       
            if (!this.board.put(where, this.turn))
                return false;

            if (this.check_winner())
            {
                this.win = this.turn;
                this.end = true;
                return true;
            }

            if (!this.board.move_available())
            {
                this.end = true;
                return true;
            }

            this.turn = (this.turn == PLAYER1) ? PLAYER2 : PLAYER1;
            return true;
        }
        private bool check_winner()
        {
            ArrayList b = this.board.get();

            int[,] wining_positions =
            {
                {0,1,2 },
                {3,4,5 },
                {6,7,8 },
                {0,3,6 },
                {1,4,7 },
                {2,5,8 },
                {0,4,8 },
                {2,4,6 }
            };

           for(int i=0;i<wining_positions.Length/3;i++)
            {
                if( b[wining_positions[i,0]].Equals( b[wining_positions[i, 1]]) &&
                    b[wining_positions[i,1]].Equals( b[wining_positions[i, 2]]) &&
                    !b[wining_positions[i,0]].Equals( Board.EMPTY))
                {
                  //  Console.WriteLine($"WINING OPTION {b[wining_positions[i, 0]]} -  { b[wining_positions[i, 1]]} -  {b[wining_positions[i, 2]]}");
                    return true;
                }
            }
            return false;
            

        }
        public string _PythonPrintBoard()
        {
            return string.Join(',', this.board.get().ToArray());
        }
        public string _PythonGetWinner()
        {
            if (this.get_winner() == null)
                return "Null";
            else
                return this.get_winner().ToString();
        }


    }
}
