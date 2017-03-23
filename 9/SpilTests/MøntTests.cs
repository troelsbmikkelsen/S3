using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTests {
    [TestClass()]
    public class MøntTests {
        [TestMethod()]
        public void MøntTest() {
            Mønt mønt = new Mønt();

            for (int i = 0; i < 1000; i++) {
                mønt.kast();
                Assert.IsTrue(mønt.getVærdi() >= 1 && mønt.getVærdi() <= 2);
            }
        }
    }
}