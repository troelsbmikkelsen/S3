using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTests {
    [TestClass()]
    public class FemFingretTests {
        Terning terning = new Terning();
        FemFingret femfingret = new FemFingret();

    [TestMethod()]
        public void tilføjDimsTest() {
            Assert.AreEqual(0, femfingret.dims.Count);

            femfingret.tilføjDims(terning);

            Assert.AreEqual(1, femfingret.dims.Count);
        }

        [TestMethod()]
        public void spilTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void sumTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void antalXereTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest() {
            Assert.Fail();
        }
    }
}