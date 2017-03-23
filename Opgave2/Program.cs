using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave2 {
    class Program {
        static void Main(string[] args) {
            string[] words = { "hello", "world", "nice", "to", "meet", "you"};
            Console.WriteLine(Utilities.CombineAndCapitalizeStringArray(words));

            // Should throw exception because of the fourth element
            words = new string[]{ "h3ll0", "w0rld", "n1c3", "7o", "m337", "y0u" };
            Console.WriteLine(Utilities.CombineAndCapitalizeStringArray(words));
        }
    }

    public class Utilities {
        /// <summary>
        /// Combine and capitalize a string array, returning a string
        /// </summary>
        /// <param name="wordArray"></param>
        /// <returns></returns>
        public static string CombineAndCapitalizeStringArray(string[] wordArray) {
            string combined = "";
            foreach (string word in wordArray) {
                if (char.IsLetter(word.First())) {
                    combined += $"{word.First().ToString().ToUpper()}{word.Substring(1)} ";
                } else {
                    throw new ArgumentException($"First letter of word was not a letter: {word}");
                }
            }

            return combined;
        }
    }
}
