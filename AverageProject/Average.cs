using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageConsoleProject
{
    /// <summary>
    /// The following will implement the Average for any given list of numbers with Add feature
    /// </summary>
    public class Average
    {
        /// <summary>
        /// This will store the total sum of the numbers added
        /// </summary>
        private double _sum;

        /// <summary>
        /// This will store the count of numbers added (long to handle large input)
        /// </summary>
        private long _count;

        /// <summary>
        /// Adds a number to the sum and increments the count
        /// </summary>
        /// <param name="number">the input is double to handle other types like int, float, long, decimal </param>
        public void Add(double number)
        {
            _sum += number;
            _count++;
        }

        /// <summary>
        /// Gets the current average of the values added so far.
        /// </summary>
        public double CurrentAverage
        {
            get
            {
                // Handles division by zero
                if (_count == 0)
                {
                    return 0.0;
                }

                return _sum / _count;
            }
        }

        /// <summary>
        /// Gets the current count of items.
        /// </summary>
        public long Count => _count;

        /// <summary>
        /// Optional : Reset all the data
        /// </summary>
        public void Reset()
        {
            _sum = 0;
            _count = 0;
        }
    }
}
