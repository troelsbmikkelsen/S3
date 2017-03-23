using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3.Tests {
    [TestClass()]
    public class S3Tests {
        [TestMethod()]
        public void LargestNumberOfThreeTest() {
            
            Assert.AreEqual(3, Opgave1.Utilities.LargestNumberOfThree(1, 2, 3));
            Assert.AreEqual(3, Opgave1.Utilities.LargestNumberOfThree(3, 1, 2));
            Assert.AreEqual(3, Opgave1.Utilities.LargestNumberOfThree(2, 3, 1));
        }

        [TestMethod()]
        public void CombineAndCapitalizeStringArrayTest() {
            Assert.AreEqual("Hello World ", Opgave2.Utilities.CombineAndCapitalizeStringArray(new string[] { "hello", "world"}));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CombineAndCapitalizeStringArrayExceptionTest() {
            Opgave2.Utilities.CombineAndCapitalizeStringArray(new string[] { "23", "432" });
        }

        [TestMethod()]
        public void IntArrayToSortedListOfIntsTest() {
            int[] unsortedInts = { 37, 88, 65, 14, 17, 20, 31, 5 };
            List<int> sortedInts = new int[] { 5, 14, 17, 20, 31, 37, 65, 88}.ToList();

            CollectionAssert.AreEqual(sortedInts, Opgave3.Utilities.IntArrayToSortedListOfInts(unsortedInts));
        }
    }
}