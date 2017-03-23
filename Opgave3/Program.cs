using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave3 {
    class Program {
        static void Main(string[] args) {
            int[] ints = { 37, 88, 65, 14, 17, 20, 31, 5 };
            foreach (int i in Utilities.IntArrayToSortedListOfInts(ints)) {
                Console.WriteLine(i);
            }
        }
    }

    public class Utilities {
        public static List<int> IntArrayToSortedListOfInts(int[] ints) {
            List<int> listOfInts = ints.ToList();
            listOfInts.Sort();
            return listOfInts;
        }

    }
}
