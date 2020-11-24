using Moq;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkMakerProtocolTests
    {
        [Fact]
        public void HandleOrderShould_ReturnCorrectMessage_WhenStorageIsEmpty()
        {
            var tea = new Tea();
            // TODO: Continue
            var storageManager = new Mock<IStorageManager>();
            var paymentAssessor = new PaymentAssessor();
            var orderTranslator = new OrderTranslator();
            var order = new Order(tea,1);
            var payment = new Payment(1);
            var drinkMakerProtocol = new DrinkMakerProtocol(paymentAssessor, orderTranslator, storageManager.Object);

            storageManager.Setup(x => x.IsEmpty(It.IsAny<IDrinkType>())).Returns(true);
                
            var actualResult = drinkMakerProtocol.HandleOrder(order, payment);
        
            Assert.Equal("M:tea is empty", actualResult.InstructionMessage);
        }

        
        [Fact]
        public void HandleOrderShould_ReturnCorrectOrderString_WhenSufficientPaymentAmount_AndDrinkTypeIsNotEmpty()
        {
            var tea = new Tea();
            var storageManager = new Mock<IStorageManager>();
            var paymentAssessor = new PaymentAssessor();
            var orderTranslator = new OrderTranslator();
            var order = new Order(tea,1);
            var payment = new Payment(1);
            var drinkMakerProtocol = new DrinkMakerProtocol(paymentAssessor, orderTranslator, storageManager.Object);
            storageManager.Setup(x => x.IsEmpty(order.DrinkType)).Returns(false);
            var actualResult = drinkMakerProtocol.HandleOrder(order, payment);
            storageManager.Verify(x=> x.ReduceDrinkQuantity(order.DrinkType), Times.Exactly(1));
            Assert.Equal("T:1:0", actualResult.InstructionMessage);
        }
        
        
        
        [Fact]
        public void HandleOrderShould_ReturnCorrectOrderString_WhenInSufficientPaymentAmount_AndDrinkTypeIsNotEmpty()
        {
            var tea = new Tea();
            var storageManager = new Mock<IStorageManager>();
            var paymentAssessor = new PaymentAssessor();
            var orderTranslator = new OrderTranslator();
            var order = new Order(tea,1);
            var payment = new Payment(0.3);
            var drinkMakerProtocol = new DrinkMakerProtocol(paymentAssessor, orderTranslator, storageManager.Object);
            var expectedChange = 0.1;
            storageManager.Setup(x => x.IsEmpty(It.IsAny<IDrinkType>())).Returns(false);
            var actualResult = drinkMakerProtocol.HandleOrder(order, payment);
        
            Assert.Equal($"M:Not enough, missing {expectedChange} euro", actualResult.InstructionMessage);
        }
        
        //TODO: Refactor tests/ add repositories to organize files/ make it work
    }
}
