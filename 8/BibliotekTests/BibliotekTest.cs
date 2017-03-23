using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bibliotek;

namespace BibliotekTests {
    [TestClass]
    public class BibliotekTest {
        Laaner laaner = new Laaner(false, "", "", new DateTime(2016, 5, 14), new Person("1234561234", "Fornavn", "Efternavn", "8600", "Gade 2"));
        Studentermedhjaelper st = new Studentermedhjaelper(1, new DateTime(2017, 1, 3), new Person("1234561234", "Fornavn", "Efternavn", "8600", "Gade 2"), 50);

        [TestMethod]
        public void LaanerToStringTest() {
            string laanerString = laaner.ToString();

            Assert.AreEqual("Fornavn Efternavn -- 1234561234\n8600, Gade 2\nNyhedsbrev: False\nInteresser: \nRetur profil: \nLånerkort dato: 14-05-2016", laanerString);
        }

        [TestMethod]
        public void StudenterMedhjaelperToStringTest() {
            string stString = st.ToString();

            Assert.AreEqual("Fornavn Efternavn -- 1234561234\n8600, Gade 2\nId: 1\nAnsættelsesdato: 03-01-2017\nLøn: 50", stString);
        }
    }
}
