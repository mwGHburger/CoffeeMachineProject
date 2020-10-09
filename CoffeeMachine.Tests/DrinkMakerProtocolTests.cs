using System;
using Xunit;

namespace CoffeeMachine.Tests
{
    // TODO: Is it okay to go back and change initial tests when we add new features?
    public class DrinkMakerProtocolTests
    {
        [Theory]
        [InlineData("T:1:0", "tea", 0.4, 1)]
        [InlineData("H::", "chocolate", 0.5, 0)]
        [InlineData("C:2:0", "coffee", 0.6, 2)]
        public void TranslateOrder_ShouldReturnCorrectString_FromOrderObject(string expected, string drinkName, double drinkCost, int sugarQuantity)
        {
            var drinkType = new DrinkType(drinkName, drinkCost);
            Order order = new Order(drinkType,sugarQuantity);
            var actualResult = DrinkMakerProtocol.TranslateOrder(order);
            Assert.Equal(expected, actualResult);
        }

        [Fact]
        public void AssessPaymentShould_ReturnCorrectOrderString_WhenSufficientPaymentAmount()
        {
            // Order order = new Order(drinkType: "tea", sugarQuantity: 1);
            var tea = new DrinkType("tea", 0.4);
            var order = new Order(tea,1);
            var payment = new Payment(1);
            var actualResult = DrinkMakerProtocol.AssessPayment(order, payment);

            Assert.Equal("T:1:0", actualResult);
        }

        [Fact]
        public void AssessPaymentShould_ReturnCorrectOrderString_WhenInSufficientPaymentAmount()
        {
            var tea = new DrinkType("tea", 0.4);
            var order = new Order(tea,1);
            var payment = new Payment(0.15);
            var expectedChange = 0.25;

            var actualResult = DrinkMakerProtocol.AssessPayment(order, payment);

            Assert.Equal($"M:Not enough, missing {expectedChange} euro", actualResult);
        }
    }
}
