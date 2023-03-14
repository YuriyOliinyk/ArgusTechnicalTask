using Argus.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace Argus.Tests
{
    public class Tests
    {
        [Test]
        [Description("Test #1 in Technical Task")]
        public void CreateOrder()
        {
            var expectedOrder = Order.Create(
                orderTime: DateTime.Today.AddHours(20),
                amountStarters: 4,
                amountMains: 4,
                amountDrinks: 4);

            //Image that method GetActualOrderDetails() get actual order details
            var actualOrder = OrderActions.GetActualOrderDetails();

            expectedOrder.TotalWithServiceCharge.Should()
                .Be(actualOrder.TotalWithServiceCharge);
        }

        [Test]
        [Description("Test #2 in Technical Task")]
        public void AddToOrder()
        {
            var expectedOrder = Order.Create(
                orderTime: DateTime.Today.AddHours(18),
                amountStarters: 1,
                amountMains: 2,
                amountDrinks: 2);

            var actualOrder = OrderActions.GetActualOrderDetails();

            var expectedOrderAfterAdjustment = OrderActions.AddToOrder(
                existingOrder: expectedOrder,
                orderTime: DateTime.Today.AddHours(20),
                amountMainsToAdd: 2,
                amountDrinksToAdd: 2);

            var actualOrderAfterAdjustment = OrderActions.GetActualOrderDetails();

            using (new AssertionScope())
            {
                expectedOrder.TotalWithServiceCharge.Should()
                    .Be(actualOrder.TotalWithServiceCharge);

                expectedOrderAfterAdjustment.TotalWithServiceCharge.Should()
                    .Be(actualOrderAfterAdjustment.TotalWithServiceCharge);
            }
        }

        [Test]
        [Description("Test #3 in Technical Task")]
        public void CancelOrder()
        {
            var expectedOrder = Order.Create(
                orderTime: DateTime.Today.AddHours(18),
                amountStarters: 4,
                amountMains: 4,
                amountDrinks: 4);

            var actualOrder = OrderActions.GetActualOrderDetails();

            var expectedOrderAfterAdjustment = OrderActions.CancelOrder(
                existingOrder: expectedOrder,
                amountStartersToCancel: 1,
                amountMainsToCancel: 1,
                amountDrinksToCancel: 1);

            var actualOrderAfterAdjustment = OrderActions.GetActualOrderDetails();

            using (new AssertionScope())
            {
                expectedOrder.TotalWithServiceCharge.Should()
                    .Be(actualOrder.TotalWithServiceCharge);

                expectedOrderAfterAdjustment.TotalWithServiceCharge.Should()
                    .Be(actualOrderAfterAdjustment.TotalWithServiceCharge);
            }
        }
    }
}