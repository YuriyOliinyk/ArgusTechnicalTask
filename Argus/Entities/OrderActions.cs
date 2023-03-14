using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Entities
{
    public class OrderActions
    {
        public static Order CancelOrder(
            Order existingOrder,
            int amountStartersToCancel = 0,
            int amountMainsToCancel = 0,
            int amountDrinksToCancel = 0)
        {
            return Order.Create(
                 existingOrder.OrderTime,
                 existingOrder.AmountStarters - amountStartersToCancel,
                 existingOrder.AmountMains - amountMainsToCancel,
                 existingOrder.AmountDrinks - amountDrinksToCancel);
        }

        public static Order AddToOrder(
            Order existingOrder,
            DateTime orderTime,
            int amountStartersToAdd = 0,
            int amountMainsToAdd = 0,
            int amountDrinksToAdd = 0)
        {

            var additionalOrder = Order.Create(
                orderTime,
                amountStartersToAdd,
                amountMainsToAdd,
                amountDrinksToAdd);

            return new Order()
            {
                OrderTime = additionalOrder.OrderTime,
                AmountStarters = existingOrder.AmountStarters + additionalOrder.AmountStarters,
                AmountMains = existingOrder.AmountMains + additionalOrder.AmountMains,
                AmountDrinks = existingOrder.AmountDrinks + additionalOrder.AmountDrinks,
                StartersTotalPrice = (double)existingOrder.StartersTotalPrice + additionalOrder.StartersTotalPrice,
                MainsTotalPrice = (double)existingOrder.MainsTotalPrice + additionalOrder.MainsTotalPrice,
                DrinksTotalPrice = (double)existingOrder.DrinksTotalPrice + additionalOrder.DrinksTotalPrice,
                Total = (double)existingOrder.Total + additionalOrder.Total,
                ServiceCharge = (double)existingOrder.ServiceCharge + additionalOrder.ServiceCharge,
                TotalWithServiceCharge = (double)existingOrder.TotalWithServiceCharge + additionalOrder.TotalWithServiceCharge
            };
        }

        public static Order GetActualOrderDetails() =>
            new Order()
            {
                OrderTime = DateTime.Today.AddHours(20),
                AmountStarters = 2,
                AmountMains = 2,
                AmountDrinks = 2,
                StartersTotalPrice = 10.00,
                MainsTotalPrice = 15.00,
                DrinksTotalPrice = 13.00,
                Total = 38.00,
                ServiceCharge = 12,
                TotalWithServiceCharge = 56.10
            };
    }
}
