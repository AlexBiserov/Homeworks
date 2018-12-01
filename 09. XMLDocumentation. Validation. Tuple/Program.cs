using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.XMLDocumentation.Validation.Tuple
{

    class Distance
    {
        /// <summary>
        /// Converts kilometres to miles
        /// </summary>
        /// <param name="kilometres">
        /// kilometres
        /// </param>
        /// <exception cref="double">ArgumentException</exception>
        /// <returns>Returns miles(double)</returns>
        public static double KilometresToMiles(double kilometres)
        {
            if (kilometres < 0)
            {
                throw new ArgumentException("Kilometres must be greather 0");
            }
            return kilometres * 1.60934;
        }

        /// <summary>
        /// Converts miles to kilometres
        /// </summary>
        /// <param name="miles">
        /// miles
        /// </param>
        /// <exception cref="double">ArgumentException</exception>
        /// <returns>Returns kilometres(double)</returns>
        public static double MilesToKilometres(double miles)
        {
            if (miles < 0)
            {
                throw new ArgumentException("Miles must be greather 0");
            }
            return miles * 0.621371;
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");

            Console.Read();
        }
    }
}
