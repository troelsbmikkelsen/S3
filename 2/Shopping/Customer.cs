using System;

namespace Shopping {
    public class Customer {
        /// <summary>
        /// Customer first name
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// Customer last name
        /// </summary>
        public string lastName { get; set; }

        /// <summary>
        /// Date of customer registration
        /// </summary>
        public DateTime firstRegistered { get; set; }

        /// <summary>
        /// Value of all purchased items
        /// </summary>
        public float totalPurchaseAmount { get; set; }

        /// <summary>
        /// Whether the customer is a premium member
        /// </summary>
        public bool isPremium { get; set; }

        /// <summary>
        /// Whether the customer is a gold member
        /// </summary>
        public bool isGold { get; set; }

        /// <summary>
        /// Whether the customer is a diamond member
        /// </summary>
        public bool isDiamond { get; set; }

        private DateTime _timeAsMember = new DateTime();
        /// <summary>
        /// Get returns how long the customer has been at the current member level.
        /// Set sets for how long the member has been at the current member level.
        /// When upgrading set to a 0 TimeSpan.
        /// </summary>
        public TimeSpan timeAsMember
        {
            get { return DateTime.Now.Subtract(_timeAsMember); }
            set { _timeAsMember = DateTime.Now.Subtract(value); }
        }

        /// <summary>
        /// Number of times the customer has purchased from the store
        /// </summary>
        public int totalPurchases { get; set; }

        /// <summary>
        /// Items that are to be purchased by the customer
        /// </summary>
        public Cart basket { get; set; }

        /// <summary>
        /// The customers id
        /// </summary>
        public int id { get; set; }

        public Customer() {
            basket = new Cart(this);
        }

        /// <summary>
        /// Get the time since the customer was registered
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetTimeSinceFirstRegistration() {
            return DateTime.Now.Subtract(firstRegistered);
        }

        /// <summary>
        /// Get the time until the customer can be upgraded.
        /// If customer can be upgraded immediately, returns 0 tick TimeSpan
        /// If customer lacks necessary purchases, returns -1 tick TimeSpan
        /// If customer is fully upgraded, returns -2 tick TimeSpan.
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetTimeToEligibility() {

            if (isPremium) {
                if (totalPurchases >= 10 && totalPurchaseAmount >= 129.9) {
                    TimeSpan tt = new TimeSpan(14, 0, 0, 0).Subtract(timeAsMember);
                    if (tt.TotalDays <= 0) {
                        return new TimeSpan(0);
                    }
                    return tt;
                } else {
                    return new TimeSpan(-1);
                }
            } else if (isGold) {
                if (totalPurchases >= 30 && totalPurchaseAmount >= 1629.85) {
                    TimeSpan tt = new TimeSpan(120, 0, 0, 0).Subtract(timeAsMember);
                    if (tt.TotalDays <= 0) {
                        return new TimeSpan(0);
                    }
                    return tt;
                } else {
                    return new TimeSpan(-1);
                }
            } else if (isDiamond) {
                return new TimeSpan(-2);
            } else {
                if (totalPurchases >= 5 && totalPurchaseAmount >= 99.95) {
                    TimeSpan tt = new TimeSpan(30, 0, 0, 0).Subtract(GetTimeSinceFirstRegistration());
                    if (tt.TotalDays <= 0) {
                        return new TimeSpan(0);
                    }
                    return tt;
                } else {
                    return new TimeSpan(-1);
                }
            }
        }
    }
}
