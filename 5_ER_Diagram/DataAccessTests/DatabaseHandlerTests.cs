using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ShoppingTests {
    [TestClass()]
    public class DatabaseHandlerTests {
        DatabaseHandler dh = new DatabaseHandler();

        [TestMethod()]
        public void GetUserByTest() {
            User u = dh.GetUserBy(100001);

            Assert.AreEqual("Troels", u.username);
        }

        [TestMethod()]
        public void GetUserByTest1() {
            User u = dh.GetUserBy("Troels");

            Assert.AreEqual("Troels", u.username);
        }

        [TestMethod()]
        public void SaveUserTest() {
            dh.SaveUser(new User() { username = "Troels", password = "12345678"});

            User u = dh.GetUserBy("Troels");

            Assert.AreEqual("Troels", u.username);
        }
    }
}