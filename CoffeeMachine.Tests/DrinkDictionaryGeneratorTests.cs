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
            Mock<IOrder> mockOrder1 = new Mock<IOrder>();
            Mock<IOrder> mockOrder2 = new Mock<IOrder>();
            Mock<IOrder> mockOrder3 = new Mock<IOrder>();
            var orders = new List<IOrder>{
                mockOrder1.Object,
                mockOrder2.Object,
                mockOrder3.Object
            };
            
            mockOrder1.Setup(x => x.DrinkType).Returns(new DrinkType("coffee", 0.6));
            mockOrder2.Setup(x => x.DrinkType).Returns(new DrinkType("coffee", 0.6));
            mockOrder3.Setup(x => x.DrinkType).Returns(new DrinkType("tea", 0.5));

            var drinkDictionaryGenerator = new DrinkDictionaryGenerator();

            var actual = drinkDictionaryGenerator.Generate(orders);

            Assert.Equal(2, actual["coffee"]);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenOrderListIsEmpty()
        {
            // Mock<IOrder> mockOrder1 = new Mock<IOrder>();
            // Mock<IOrder> mockOrder2 = new Mock<IOrder>();
            // Mock<IOrder> mockOrder3 = new Mock<IOrder>();
            var orders = new List<IOrder>();
            
            // mockOrder1.Setup(x => x.DrinkType).Returns(new DrinkType("coffee", 0.6));
            // mockOrder2.Setup(x => x.DrinkType).Returns(new DrinkType("coffee", 0.6));
            // mockOrder3.Setup(x => x.DrinkType).Returns(new DrinkType("tea", 0.5));

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
            
            mockOrder1.Setup(x => x.DrinkType).Returns(new DrinkType("coffee", 0.6));
            mockOrder2.Setup(x => x.DrinkType).Returns(new DrinkType("coffee", 0.6));
            mockOrder3.Setup(x => x.DrinkType).Returns(new DrinkType("tea", 0.5));

            var drinkDictionaryGenerator = new DrinkDictionaryGenerator();

            var actual = drinkDictionaryGenerator.CalculateRevenue(orders);

            Assert.Equal(1.7, actual);
        }
    }
}