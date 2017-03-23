using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTests {
    [TestClass()]
    public class TerningTests {
        [TestMethod()]
        public void TerningTest() {
            Terning terning = new Terning();

            for (int i = 0; i < 1000; i++) {
                terning.kast();
                Assert.IsTrue(terning.getVærdi() >= 1 && terning.getVærdi() <= 6 );
            }
        }
    }
}