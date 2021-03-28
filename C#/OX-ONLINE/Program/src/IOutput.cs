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
    public interface IOutput
    {
        void show_welcome();
        void show_board(ArrayList board);
        void show_player_turn(string player);
        void show_move_error(string player);
        void show_draw();
        void show_winner(string player);


    }

}
