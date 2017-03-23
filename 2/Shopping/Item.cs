namespace Shopping {
    public class Item {
        /// <summary>
        /// id of the item
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Whether the item has a generally available discount
        /// </summary>
        public bool hasGeneralDiscount { get; set; }

        /// <summary>
        /// The generally available discount amount
        /// </summary>
        public float generalDiscountAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float membershipDiscountAmount { get; set; }

        /// <summary>
        /// The items price without any discount
        /// </summary>
        public float normalPrice { get; set; }

        /// <summary>
        /// The items current price
        /// </summary>
        public float currentPrice { get; set; }

        /// <summary>
        /// How many of the item are in stock
        /// </summary>
        public int currentStock { get; set; }

        public static Item getCopy(Item item) {
            return new Item 
            {
                id = item.id,
                hasGeneralDiscount = item.hasGeneralDiscount,
                generalDiscountAmount = item.generalDiscountAmount,
                normalPrice = item.normalPrice,
                currentStock = item.currentStock
            };
        }


    }
}
