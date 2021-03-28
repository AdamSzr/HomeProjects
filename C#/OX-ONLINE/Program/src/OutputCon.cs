using System;
using System.Collections;

namespace GameLogic
{
    class OutputCon : IOutput
    {
        public void show_board(ArrayList value)
        {
            ArrayList board = value;
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]}");
        }

        public void show_draw()
        {
            Console.WriteLine("It's a draw! Nobody wins!");
        }

        public void show_move_error(string player)
        {
            Console.WriteLine("It's a no no what you've done! Plz repeat the move.");
        }

        public void show_player_turn(string player)
        {
            Console.WriteLine($"Now moves (0-8) :{player.ToString()}");
        }

        public void show_welcome()
        {
            Console.WriteLine("Welcome to XOXOXOX!!!" + Environment.NewLine);
        }

        public void show_winner(string player)
        {
            Console.WriteLine($"Player {player.ToString()} wins");
        }
    }



}
