using System.Collections.Generic;

namespace Shopping {
    public class Cart {
        /// <summary>
        /// Reference to the owner of this cart
        /// </summary>
        private Customer _customer;

        /// <summary>
        /// The list of items currently in the cart
        /// </summary>
        public List<Item> items { get; set; } = new List<Item>();

        /// <summary>
        /// The total price of all the items in the cart
        /// </summary>
        public float totalPrice { get; set; } = 0;

        /// <summary>
        /// The available discount for the customer
        /// </summary>
        public float totalDiscount { get; set; } = 0;

        /// <summary>
        /// Number of items in the cart
        /// </summary>
        public int numberOfItems { get; set; } = 0;

        /// <summary>
        /// Adds an item to the cart
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item) {
            // Make copy of item to use in cart
            Item _item = Item.getCopy(item);

            // Calculate price of item using available discounts
            float _memberDiscount = 0;
            if (_customer.isPremium) {
                _memberDiscount = 0.05f;
            } else if (_customer.isGold) {
                _memberDiscount = 0.125f;
            } else if (_customer.isDiamond) {
                _memberDiscount = 0.252f;
            }

            _item.currentPrice = _item.normalPrice * (1 - (_memberDiscount + _item.generalDiscountAmount));

            // Add savings to total discount
            totalDiscount = _item.normalPrice - _item.currentPrice;

            // Add item to list
            items.Add(_item);

            // Update number of items in cart
            numberOfItems++;

            // Update total price of cart
            totalPrice += _item.currentPrice;
        }

        /// <summary>
        /// Removes the specified item from the cart. Needs to be a reference to the actual object from the items list.
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(Item item) {
            //Item found = items.Find(i => i.id == item.id);
            //if (found != null) {
            //    numberOfItems--;
            //    totalDiscount -= found.normalPrice - found.currentPrice;
            //    totalPrice -= found.currentPrice;
            //    items.Remove(found);
            //}

            numberOfItems--;
            totalDiscount -= item.normalPrice - item.currentPrice;
            totalPrice -= item.currentPrice;
            items.Remove(item);


        }

        /// <summary>
        /// Initializes a new cart for specified customer
        /// </summary>
        /// <param name="customer">Customer to initialize cart for</param>
        public Cart(Customer customer) {
            _customer = customer;
        }


        public void PurchaseOrder() {
            _customer.totalPurchases += numberOfItems;
            numberOfItems = 0;

            _customer.totalPurchaseAmount += totalPrice;
            totalPrice = 0;

            items.Clear();
        }
    }
}
