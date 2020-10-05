using System;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkMakerProtocolTests
    {
        [Theory]
        [InlineData("T:1:0", "tea", 1)]
        [InlineData("H::", "chocolate", 0)]
        [InlineData("C:2:0", "coffee", 2)]
        public void TranslateOrder_ShouldReturnCorrectString_FromOrderObject(string expected, string drinkType, int sugarQuantity)
        {
            Order order = new Order(drinkType,sugarQuantity);
            var actualResult = DrinkMakerProtocol.TranslateOrder(order);
            Assert.Equal(expected, actualResult);
        }
        
        [Fact]
        public void TranslateOrderMessage_ShouldReturnCorrectString_FromOrderObject()
        {
            Order order = new Order("coffee",1,"Message-content");
            var actualResult = DrinkMakerProtocol.TranslateOrderMessage(order);
            Assert.Equal("M:Message-content", actualResult);
        }

    }
}
