using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DieSimulation
{
    /// <summary>
    /// Describes a die.
    /// </summary>
    public sealed class Die
    {
        /// <summary>
        /// The values on sides of the die.
        /// </summary>
        private readonly static int[] values = { 1, 2, 3, 4, 5, 6 };

        /// <summary>
        /// A delegate type for events.
        /// </summary>
        public delegate void SomeDelegate();

        /// <summary>
        /// A field for random.
        /// </summary>
        private Random random;

        /// <summary>
        /// Two sixes in a row appear event.
        /// </summary>
        public event SomeDelegate TwoSixesInARow;

        /// <summary>
        /// The sum of 5 tosses is greater than 20 event.
        /// </summary>
        public event SomeDelegate SumIsGreater;

        /// <summary>
        /// The end of the program event.
        /// </summary>
        public event SomeDelegate EndOfTheProgram;

        /// <summary>
        /// Creates a new die.
        /// </summary>
        public Die()
        {
            this.random = new Random();
        }

        /// <summary>
        /// Simulate the die's actions.
        /// </summary>
        /// <param name="count">The count of rolles.</param>
        public void Simulate(int count)
        {
            List<int> valuesList = new List<int>();
            bool wasThePreviousSix = false;

            while(count != 0)
            {
                int value = this.Roll();
                Console.WriteLine(value);

                valuesList.Add(value);

                if(valuesList.Count() == 6)
                {
                    if(valuesList.Sum() - value >= 20)
                    {
                        SumIsGreater?.Invoke();
                    }
                    valuesList.RemoveRange(0, 5);
                }
                else if (valuesList.Count == 5)
                {
                    if (valuesList.Sum() >= 20)
                    {
                        SumIsGreater?.Invoke();
                    }
                    valuesList.Clear();
                }
 
                if (value == 6)
                {
                    if(wasThePreviousSix)
                    {
                        TwoSixesInARow?.Invoke();
                    }
                    wasThePreviousSix = true;
                }
                else
                {
                    wasThePreviousSix = false;
                }
                count--;

                Thread.Sleep(400);
            }
            EndOfTheProgram?.Invoke();
        }

        /// <summary>
        /// Rolls the die and returns the value on the top side.
        /// </summary>
        /// <returns>Returns the value.</returns>
        private int Roll()
        {
            return values[this.random.Next(0, values.Length)];
        }

    }
}
