using System;
using System.Linq;

namespace GameLogic
{
    class InputCon : IInput
    {
        public int? get_move()
        {
            int x = -5;
            try
            {
                x = int.Parse(Console.ReadLine().Trim());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message); // TODO: RECUR get_move
            }

            if (System.Linq.Enumerable.Range(0, 9).Contains(x))
            {
                return x;
            }
            return null;
        }
    }



}
