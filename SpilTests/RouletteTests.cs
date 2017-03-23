using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTests {
    [TestClass()]
    public class RouletteTests {
        [TestMethod()]
        public void RouletteInRangeTest() {
            Roulette roulette = new Roulette();

            for (int i = 0; i < 1000000; i++) {
                roulette.kast();
                Assert.IsTrue(roulette.getVærdi() >= 0 && roulette.getVærdi() <= 36);
            }
        }
    }
}