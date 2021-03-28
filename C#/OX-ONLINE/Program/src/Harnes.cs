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
    class Harness
    {
        private GameLogic.Game game;
        private OutputProxy output;
        private List<IInput> inputs;
        public Harness(OutputProxy output, List<IInput> inputs)
        {
            
            

            this.game = new Game();
            this.output = output;
            this.inputs = inputs;

        }
        public void Start()
        {
            this.output.show_welcome();
            while (true)
            {
                this.output.show_board(this.game.get_board());

                int player_id = (this.game.get_turn_no());
                this.output.show_player_turn(this.game.get_turn());

                while (true)
                {
                    string move = this.inputs[player_id].get_move().ToString();
                 
                    if (string.IsNullOrEmpty(move))
                    {
                       
                        this.output.show_move_error(this.game.get_turn());
                        continue;
                    }
                    if(!this.game.make_move(int.Parse(move)))
                    {
                        this.output.show_move_error(this.game.get_turn());
                        continue;
                    }
                    break;
                }
                if(!this.game.get_end())
                {
                    continue;
                }
                // End of game.
                this.output.show_board(this.game.get_board());
#nullable enable
                string? winerrrr = this.game.get_winner();
#nullable disable
                if (winerrrr==null) //Draw
                {
                    this.output.show_draw();
                }
                else
                {
                    this.output.show_winner(winerrrr);
                }
                break;
                

            }

        }

    }


}
