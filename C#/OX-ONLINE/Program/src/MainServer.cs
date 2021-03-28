using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace GameLogic
{
    using Application;
    class MainServer
    {
        List<IInput> playersInputs;
        List<IOutput> playersOutputs;

        InputCon input_Con1;
        InputCon input_Con2;
        InputOutputTCP io_tcp;

        OutputCon outputcon;

        static void Main(string[] args)
        {
            MainServer program = new MainServer();

            

            program.input_Con1 = new InputCon();
            program.input_Con2 = new InputCon();
            program.outputcon = new OutputCon();
            program.io_tcp = new InputOutputTCP("0.0.0.0",31337);

            OutputProxy proxy = new OutputProxy();
            proxy.register_output(program.outputcon);
            proxy.register_output(program.io_tcp);



            program.playersInputs = new List<IInput>(); 
            program.playersInputs.Add(program.input_Con1); // TODO  (cz1) 1:35:50 GYNVEAL 
            program.playersInputs.Add(program.io_tcp);

            program.playersOutputs = new List<IOutput>();
            program.playersOutputs.Add(program.outputcon);


            Harness h = new Harness(proxy, program.playersInputs);
            h.Start();

        }

    }

}
