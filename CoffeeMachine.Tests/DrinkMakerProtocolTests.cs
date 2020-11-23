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
            // var storageManager = new StorageManager();
            var paymentAssessor = new PaymentAssessor();
            var orderTranslator = new OrderTranslator();
            var order = new Order(tea,1);
            var payment = new Payment(1);
            var drinkMakerProtocol = new DrinkMakerProtocol(paymentAssessor, orderTranslator);

            var actualResult = drinkMakerProtocol.HandleOrder(order, payment);
        
            Assert.Equal("M: tea is empty", actualResult.InstructionMessage);
        }

        
        [Fact]
        public void HandleOrderShould_ReturnCorrectOrderString_WhenSufficientPaymentAmount()
        {
            var tea = new Tea();
            var paymentAssessor = new PaymentAssessor();
            var orderTranslator = new OrderTranslator();
            var order = new Order(tea,1);
            var payment = new Payment(1);
            var drinkMakerProtocol = new DrinkMakerProtocol(paymentAssessor, orderTranslator);

            var actualResult = drinkMakerProtocol.HandleOrder(order, payment);
        
            Assert.Equal("T:1:0", actualResult.InstructionMessage);
        }
        
        [Fact]
        public void HandleOrderShould_ReturnCorrectOrderString_WhenInSufficientPaymentAmount()
        {
            var tea = new Tea();
            var paymentAssessor = new PaymentAssessor();
            var orderTranslator = new OrderTranslator();
            var order = new Order(tea,1);
            var payment = new Payment(0.3);
            var drinkMakerProtocol = new DrinkMakerProtocol(paymentAssessor, orderTranslator);
            var expectedChange = 0.1;

            var actualResult = drinkMakerProtocol.HandleOrder(order, payment);
        
            Assert.Equal($"M:Not enough, missing {expectedChange} euro", actualResult.InstructionMessage);
        }
    }
}
