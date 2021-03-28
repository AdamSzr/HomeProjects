using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Application
{
    using GameLogic;
    class OutputProxy: IOutput
    {
        private List<IOutput> outputs;
       public OutputProxy()
        {
            this.outputs = new List<IOutput>();
        }

        public void register_output(IOutput item) 
        {
            this.outputs.Add(item);
        }

        public void show_board(ArrayList board)
        {
            foreach (IOutput x in outputs)
            {
                x.show_board (board);
            }
        }

        public void show_draw()
        {
            foreach (IOutput x in outputs)
            {
                x.show_draw();
            }
        }

        public void show_move_error(string player)
        {
            foreach (IOutput x in outputs)
            {
                x.show_move_error(player);
            }
        }

        public void show_player_turn(string player)
        {
            foreach (IOutput x in outputs)
            {
                x.show_player_turn(player);
            }
        }

        public void show_welcome()
        {
          foreach( IOutput x in outputs)
            {
                x.show_welcome();
            }
        }

        public void show_winner(string player)
        {
            foreach (IOutput x in outputs)
            {
                x.show_winner(player);
            }
        }
    }
}
