using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(Utilities.LargestNumberOfThree(1, 2, 3));
            Console.WriteLine(Utilities.LargestNumberOfThree(3, 1, 2));
            Console.WriteLine(Utilities.LargestNumberOfThree(2, 3, 1));

        }

        
    }

    public class Utilities {
        /// <summary>
        /// Returns the largest of the three numbers provided
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int LargestNumberOfThree(int a, int b, int c) {
            return Math.Max(a, Math.Max(b, c));
        }
    }
}
