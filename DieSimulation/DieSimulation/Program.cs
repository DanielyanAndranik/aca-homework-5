using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DieSimulation
{
    class Program
    {
        /// <summary>
        /// The number of times "two sixes in a row" appear.
        /// </summary>
        static int TwoSixesInARowCount = 0;

        static void Main(string[] args)
        {
            Die die = new Die();

            die.TwoSixesInARow += TwoSixesInARow;
            die.SumIsGreater += SumIsGreater;
            die.EndOfTheProgram += EndOfTheProgram;

            die.Simulate(50);
        }

        /// <summary>
        /// The "two sixes in a row" appear event handler.
        /// Increment the TwoSixesInARowCount.
        /// </summary>
        public static void TwoSixesInARow()
        {
            TwoSixesInARowCount++;
        }

        /// <summary>
        /// The "the sum of 5 tosses is greater than or equals to 20" event handler.
        /// Prints a message.
        /// </summary>
        public static void SumIsGreater()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The sum of 5 tosses is greater than or equal to 20");
            Console.ResetColor();
        }

        /// <summary>
        /// The end of the program event handler.
        /// Prints the number of times "two sixes in a row" appear.
        /// </summary>
        public static void EndOfTheProgram()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The number of times 'Two sixes in a row' appear is {0}", TwoSixesInARowCount);
            Console.ResetColor();
        }
    }
}
