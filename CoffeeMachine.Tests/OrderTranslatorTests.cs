using Moq;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class OrderTranslatorTests
    {
        [Fact]
        public void TranslateOrder_ShouldReturnInstructionObject()
        {
            var sugarQuantity = 2;
            var drinkType = new Mock<IDrinkType>();
            Order order = new Order(drinkType.Object,sugarQuantity);
            var orderTranslator = new OrderTranslator();

            drinkType.Setup(x => x.Name).Returns("tea");

            var result = orderTranslator.TranslateOrder(order);
            Assert.IsType<Instruction>(result);
        }

        [Theory]
        [InlineData("T:1:0", "tea", 0.4, "T", 1)]
        [InlineData("H::", "chocolate", 0.5,"H", 0)]
        [InlineData("C:2:0", "coffee", 0.6, "C", 2)]
        [InlineData("O::", "orange juice", 0.6, "O", 0)]
        //Open-Close principle
        public void TranslateOrder_ShouldReturnCorrectString_FromOrderObject(string expected, string drinkName, double drinkCost,string character, int sugarQuantity)
        {
            var drinkType = new Mock<IDrinkType>();
            Order order = new Order(drinkType.Object,sugarQuantity);
            var orderTranslator = new OrderTranslator();

            drinkType.Setup(x => x.Name).Returns(drinkName);
            drinkType.Setup(x => x.Cost).Returns(drinkCost);
            drinkType.Setup(x => x.Character).Returns(character);

            var actualResult = orderTranslator.TranslateOrder(order);
            Assert.Equal(expected, actualResult.InstructionMessage);
        }

        [Theory]
        [InlineData("Ch::", "coffee", 0.6, "C", 0, true)]
        [InlineData("Hh:1:0", "chocolate", 0.5,"H", 1, true)]
        [InlineData("Th:2:0", "tea", 0.4,"T", 2, true)]
        public void TranslateOrder_ShouldReturnCorrectString_FromExtraHotOrderObject(string expected, string drinkName, double drinkCost,string character, int sugarQuantity, bool isExtraHot)
        {
            var drinkType = new Mock<IDrinkType>();
            Order order = new Order(drinkType.Object,sugarQuantity, isExtraHot);
            
            
            var orderTranslator = new OrderTranslator();

            drinkType.Setup(x => x.Name).Returns(drinkName);
            drinkType.Setup(x => x.Cost).Returns(drinkCost);
            drinkType.Setup(x => x.Character).Returns(character);
            
            
            var actualResult = orderTranslator.TranslateOrder(order);
            Assert.Equal(expected, actualResult.InstructionMessage);
        }
    }
}