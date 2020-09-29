using System;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkMakerProtocolTests
    {
        [Theory]
        [InlineData("T:1:0", "tea", 1)]
        // TODO: IMPLEMENT LOGIC FOR TRANSLATEORDER METHOD
        [InlineData("C:2:0", "coffee", 2)]
        public void ShouldReturnCorrectString_FromOrderObject(string expected, string drinkType, int sugarQuantity)
        {
            Order order = new Order(drinkType,sugarQuantity);
            var actualResult = DrinkMakerProtocol.TranslateOrder(order);
            Assert.Equal(expected, actualResult);
        }

    }
}
