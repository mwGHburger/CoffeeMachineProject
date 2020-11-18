using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkDictionaryGeneratorTests
    {
        [Fact]
        public void ShouldGenerateDictionaryDrinkTypeAndQuantitySold()
        {
            var mockOrder1 = new Mock<IOrder>();
            var mockOrder2 = new Mock<IOrder>();
            var mockOrder3 = new Mock<IOrder>();
            var orders = new List<IOrder>{
                mockOrder1.Object,
                mockOrder2.Object,
                mockOrder3.Object
            };
            
            mockOrder1.Setup(x => x.DrinkType).Returns(new Coffee());
            mockOrder2.Setup(x => x.DrinkType).Returns(new Coffee());
            mockOrder3.Setup(x => x.DrinkType).Returns(new Tea());

            var drinkDictionaryGenerator = new DrinkDictionaryGenerator();

            var actual = drinkDictionaryGenerator.Generate(orders);

            Assert.Equal(2, actual["coffee"]);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenOrderListIsEmpty()
        {
            var orders = new List<IOrder>();

            var drinkDictionaryGenerator = new DrinkDictionaryGenerator();

            var ex = Assert.Throws<Exception>(() => drinkDictionaryGenerator.Generate(orders));
            Assert.Equal("Currently No Orders!", ex.Message);
        }
        
        [Fact]
        public void ShouldCalculateTotalMoneyForListOfOrders()
        {
            Mock<IOrder> mockOrder1 = new Mock<IOrder>();
            Mock<IOrder> mockOrder2 = new Mock<IOrder>();
            Mock<IOrder> mockOrder3 = new Mock<IOrder>();
            var orders = new List<IOrder>{
                mockOrder1.Object,
                mockOrder2.Object,
                mockOrder3.Object
            };
            var expected = 1.6;

            mockOrder1.Setup(x => x.DrinkType).Returns(new Coffee());
            mockOrder2.Setup(x => x.DrinkType).Returns(new Coffee());
            mockOrder3.Setup(x => x.DrinkType).Returns(new Tea());

            var drinkDictionaryGenerator = new DrinkDictionaryGenerator();

            var actual = drinkDictionaryGenerator.CalculateRevenue(orders);

            Assert.Equal(expected, actual);
        }
    }
}