using System;
using System.Collections.Generic;

namespace ngSightAPI.Helpers
{
    public class SeedHelper
    {
        private static readonly Random Random = new Random();

        private static string GetRandom(IList<string> items)
        {
            return items[Random.Next(items.Count)];
        }

        private static readonly List<string> BizPrefix = new List<string>()
        {
            "ABC",
            "XYZ",
            "Acme",
            "MainSt",
            "Ready",
            "Magic",
            "Fluent",
            "Peak",
            "Forward",
            "Enterprise",
            "Sales"
        };

        public static readonly List<string> BizSuffix = new List<string>()
        {
            "Co",
            "Corp",
            "Holdings",
            "Corporation",
            "Movers",
            "Cleaners",
            "Bakery",
            "Apparel",
            "Rentals",
            "Storage",
            "Transit",
            "Logistics"
        };

        internal static readonly List<string> States = new List<string>()
        {
            "AK", "AL", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
            "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
            "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
            "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
        };


        public static string MakeUniqueCustomerName(List<string> names)
        {
            var maxNames = BizPrefix.Count * BizSuffix.Count;
            if (names.Count == maxNames)
            {
                throw new InvalidOperationException("Maximum number of unique names exceeded.");
            }

            var prefix = GetRandom(BizPrefix);
            var suffix = GetRandom(BizSuffix);
            var bizNames = $"{prefix} {suffix}";

            if (names.Contains(bizNames))
            {
                MakeUniqueCustomerName(names);
            }

            return bizNames;
        }

        public static string MakeCustomerEmail(string customerName)
        {
            var customer = customerName.Replace(" ", String.Empty);
            return $"contact@{customer.ToLower()}.com";
        }

        public static string GetRandomState()
        {
            return GetRandom(States);
        }


        public static decimal GetRandomTotal()
        {
            return Random.Next(25, 1000);
        }


        public static DateTime GetRandomOrderPlaced()
        {
            var end = DateTime.Now;
            var start = end.AddDays(-90);

            TimeSpan possibleSpan = end - start;
            TimeSpan newTimeSpan = new TimeSpan(0, Random.Next(0, (int)possibleSpan.TotalMinutes), 0);

            return start + newTimeSpan;
        }

        public static DateTime? GetRandomOrderCompleted(DateTime orderPlaced)
        {
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            var timePassed = now - orderPlaced;

            if (timePassed < minLeadTime)
            {
                return null;
            }

            return orderPlaced.AddHours(Random.Next(10, 90));
        }
    }
}