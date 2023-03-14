using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Entities
{
    public class Order
    {
        private const double _startersPrice = 4.00;
        private const double _mainsPrice = 7.00;
        private const double _drinksPrice = 2.50;
        private const int _serviceChargePercantage = 10;
        private const int _drinksDiscountPercantage = 30;

        public DateTime OrderTime { get; set; }
        public int AmountStarters { get; set; }
        public int AmountMains { get; set; }
        public int AmountDrinks { get; set; }
        public double StartersTotalPrice { get; set; }
        public double MainsTotalPrice { get; set; }
        public double DrinksTotalPrice { get; set; }
        public double Total { get; set; }
        public double ServiceCharge { get; set; }
        public double TotalWithServiceCharge { get; set; }

        public Order()
        {
        }

        public Order(
            DateTime orderTime,
            int amountStarters,
            int amountMains,
            int amountDrinks,
            double startersTotalPrice,
            double mainsTotalPrice,
            double drinksTotalPrice)
        {
            OrderTime = orderTime;
            AmountStarters = amountStarters;
            AmountMains = amountMains;
            AmountDrinks = amountDrinks;
            StartersTotalPrice = startersTotalPrice;
            MainsTotalPrice = mainsTotalPrice;
            DrinksTotalPrice = drinksTotalPrice;
            Total = startersTotalPrice + mainsTotalPrice + drinksTotalPrice;
            ServiceCharge = Math.Round((double)_serviceChargePercantage / 100 * Total, 2);
            TotalWithServiceCharge = Total + ServiceCharge;
        }

        public static Order Create(
            DateTime orderTime,
            int amountStarters,
            int amountMains,
            int amountDrinks)
        {
            var startersTotalPrice = _startersPrice * amountStarters;
            var mainsTotalPrice = _mainsPrice * amountMains;
            var drinksTotalPrice = _drinksPrice * amountDrinks;

            if (orderTime.Hour <= 19)
            {
                drinksTotalPrice = Math.Round(drinksTotalPrice - ((double)_drinksDiscountPercantage / 100 * drinksTotalPrice));
            }

            return new Order(
                orderTime,
                amountStarters,
                amountMains,
                amountDrinks,
                startersTotalPrice,
                mainsTotalPrice,
                drinksTotalPrice);
        }
    }
}