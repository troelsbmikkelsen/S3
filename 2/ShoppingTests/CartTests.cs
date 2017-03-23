using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping;
using System.Diagnostics;

namespace ShoppingTests {
    [TestClass]
    public class CartTests {
        Item item1 = new Item { id = 0, normalPrice = 10, currentStock = 5, hasGeneralDiscount = true, generalDiscountAmount = 0.05f };
        Item item2 = new Item { id = 1, normalPrice = 35, currentStock = 5, hasGeneralDiscount = false, generalDiscountAmount = 0.00f };
        Item item3 = new Item { id = 2, normalPrice = 22, currentStock = 5, hasGeneralDiscount = true, generalDiscountAmount = 0.04f };
        Item item4 = new Item { id = 3, normalPrice = 18, currentStock = 5, hasGeneralDiscount = true, generalDiscountAmount = 0.03f };
        Item item5 = new Item { id = 4, normalPrice = 95, currentStock = 5, hasGeneralDiscount = true, generalDiscountAmount = 0.02f };


        Cart testCart = new Cart(CustomerTests.testCustomer);

        [TestMethod]
        public void AddItemTest() {

            testCart.AddItem(item1);
            Assert.AreEqual(item1.normalPrice * (1-item1.generalDiscountAmount), testCart.totalPrice);
            Assert.AreEqual(item1.normalPrice * item1.generalDiscountAmount, testCart.totalDiscount);
            Assert.AreEqual(1, testCart.numberOfItems);
        }

        [TestMethod]
        public void RemoveItemTest() {

            testCart.AddItem(item1);
            testCart.RemoveItem(testCart.items[0]);
            Assert.AreEqual(0, testCart.totalPrice);
        }
    }
}