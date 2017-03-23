using System;
using Shopping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingTests {
    [TestClass]
    public class CustomerTests {
        public static Customer testCustomer = new Customer {
            firstName = "",
            lastName = "",
            firstRegistered = DateTime.Now.Subtract(new TimeSpan(25, 0, 0, 0)),
            id = 0
        };

        public static Customer testCustomerPremium = new Customer {
            firstName = "",
            lastName = "",
            firstRegistered = DateTime.Now.Subtract(new TimeSpan(35, 0, 0, 0)),
            id = 0,
            isPremium = true
        };

        public static Customer testCustomerGold = new Customer {
            firstName = "",
            lastName = "",
            firstRegistered = DateTime.Now.Subtract(new TimeSpan(48, 0, 0, 0)),
            id = 0,
            isPremium = false,
            isGold = true
        };

        public static Customer testCustomerDiamond = new Customer {
            firstName = "",
            lastName = "",
            firstRegistered = DateTime.Now.Subtract(new TimeSpan(170, 0, 0, 0)),
            id = 0,
            isPremium = false,
            isGold = false,
            isDiamond = true
        };

        Item item1 = new Item { id = 0, normalPrice = 10, currentStock = 5, hasGeneralDiscount = true, generalDiscountAmount = 0.05f };
        Item item2 = new Item { id = 1, normalPrice = 35, currentStock = 5, hasGeneralDiscount = false, generalDiscountAmount = 0.00f };
        Item item3 = new Item { id = 2, normalPrice = 22, currentStock = 5, hasGeneralDiscount = true, generalDiscountAmount = 0.04f };
        Item item4 = new Item { id = 3, normalPrice = 18, currentStock = 5, hasGeneralDiscount = true, generalDiscountAmount = 0.03f };
        Item item5 = new Item { id = 4, normalPrice = 95, currentStock = 5, hasGeneralDiscount = true, generalDiscountAmount = 0.02f };
        

        [TestMethod]
        public void GetTimeSinceFirstRegistrationTest() {
            Assert.AreEqual(DateTime.Now.Subtract(DateTime.Now.Subtract(new TimeSpan(25, 0, 0, 0))).Days, testCustomer.GetTimeSinceFirstRegistration().Days);
            Assert.AreEqual(DateTime.Now.Subtract(DateTime.Now.Subtract(new TimeSpan(25, 0, 0, 0))).Hours, testCustomer.GetTimeSinceFirstRegistration().Hours);
            Assert.AreEqual(DateTime.Now.Subtract(DateTime.Now.Subtract(new TimeSpan(25, 0, 0, 0))).Minutes, testCustomer.GetTimeSinceFirstRegistration().Minutes);
        }

        [TestMethod]
        public void GetTimeToEligibilityTest() {
            // testCustomer needs 5 more days, but is not eligible because it lacks purchases.
            Assert.AreEqual(new TimeSpan(-1).Ticks, testCustomer.GetTimeToEligibility().Ticks);

            testCustomer.basket.AddItem(item1);
            testCustomer.basket.AddItem(item2);
            testCustomer.basket.AddItem(item3);
            testCustomer.basket.AddItem(item4);
            testCustomer.basket.AddItem(item5);

            testCustomer.basket.PurchaseOrder();

            Assert.AreEqual(new TimeSpan(5, 0, 0, 0).TotalSeconds, testCustomer.GetTimeToEligibility().TotalSeconds, 0.1);

            // testCustomerPremium needs 9 more days, but is not eligible because it lacks purchases.
            Assert.AreEqual(new TimeSpan(-1).Ticks, testCustomerPremium.GetTimeToEligibility().Ticks);

            // testCustomerGold needs 116 more days, but is not eligible because it lacks purchases.
            Assert.AreEqual(new TimeSpan(-1).Ticks, testCustomerGold.GetTimeToEligibility().Ticks);

            // testCustomerDiamond is fully upgraded, and should return -2
            Assert.AreEqual(new TimeSpan(-2).Ticks, testCustomerDiamond.GetTimeToEligibility().Ticks);
            //Assert.IsTrue(new TimeSpan(0) == testCustomerDiamond.GetTimeToEligibility());
            //Assert.IsFalse(new TimeSpan(0) != testCustomerDiamond.GetTimeToEligibility());
        }
    }
}
