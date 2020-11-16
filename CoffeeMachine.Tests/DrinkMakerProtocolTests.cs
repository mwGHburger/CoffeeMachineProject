using Moq;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkMakerProtocolTests
    {
        
        [Fact]
        public void TranslateOrder_ShouldReturnInstructionObject()
        {
            var sugarQuantity = 2;
            var drinkType = new Mock<IDrinkType>();
            //set up
            Order order = new Order(drinkType.Object,sugarQuantity);
            drinkType.Setup(x => x.Name).Returns("tea");
            var result = DrinkMakerProtocol.TranslateOrder(order);
            Assert.IsType<Instruction>(result);
        }
        
        [Theory]
        [InlineData("T:1:0", "tea", 0.4, "T", 1)]
        [InlineData("H::", "chocolate", 0.5,"H", 0)]
        [InlineData("C:2:0", "coffee", 0.6, "C", 2)]
        //Open-Close principle
        public void TranslateOrder_ShouldReturnCorrectString_FromOrderObject(string expected, string drinkName, double drinkCost,string character, int sugarQuantity)
        {
            var drinkType = new Mock<IDrinkType>();
            Order order = new Order(drinkType.Object,sugarQuantity);
            //set up
            drinkType.Setup(x => x.Name).Returns(drinkName);
            drinkType.Setup(x => x.Cost).Returns(drinkCost);
            drinkType.Setup(x => x.Character).Returns(character);
            var actualResult = DrinkMakerProtocol.TranslateOrder(order);
            Assert.Equal(expected, actualResult.InstructionMessage);
        }

        // [Fact]
        // public void AssessPaymentShould_ReturnCorrectOrderString_WhenSufficientPaymentAmount()
        // {
        //     // Order order = new Order(drinkType: "tea", sugarQuantity: 1);
        //     var tea = new DrinkType("tea", 0.4);
        //     var order = new Order(tea,1);
        //     var payment = new Payment(1);
        //     var actualResult = DrinkMakerProtocol.AssessPayment(order, payment);
        //
        //     Assert.Equal("T:1:0", actualResult.InstructionMessage);
        // }
        //
        // [Fact]
        // public void AssessPaymentShould_ReturnCorrectOrderString_WhenInSufficientPaymentAmount()
        // {
        //     var tea = new DrinkType("tea", 0.4);
        //     var order = new Order(tea,1);
        //     var payment = new Payment(0.15);
        //     var expectedChange = 0.25;
        //
        //     var actualResult = DrinkMakerProtocol.AssessPayment(order, payment);
        //
        //     Assert.Equal($"M:Not enough, missing {expectedChange} euro", actualResult.InstructionMessage);
        // }
    }
}
