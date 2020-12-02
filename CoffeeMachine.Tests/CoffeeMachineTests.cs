using Moq;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkMakerProtocolTests
    {
        Mock<IStorageManager> storageManager = new Mock<IStorageManager>();
        Mock<IPaymentAssessor> paymentAssessor = new Mock<IPaymentAssessor>();
        Mock<IOrderTranslator> orderTranslator = new Mock<IOrderTranslator>();

        [Fact]
        public void HandleOrderShould_ReturnCorrectMessage_WhenStorageIsEmpty()
        {
            var order = new Order(TestHelper.SetupTea(), 1);
            var payment = new Payment(1);
            var drinkMakerProtocol = new CoffeeMachine(paymentAssessor.Object, orderTranslator.Object, storageManager.Object);

            storageManager.Setup(x => x.IsEmpty(It.IsAny<IDrinkType>())).Returns(true);
            orderTranslator.Setup(x => x.ProduceMessage("tea is empty")).Returns(new Instruction("tea is empty"));
                
            var actualResult = drinkMakerProtocol.HandleOrder(order, payment);
        
            Assert.Equal("M:tea is empty", actualResult.InstructionMessage);
        }

        
        [Fact]
        public void HandleOrderShould_ReturnCorrectOrderString_WhenSufficientPaymentAmount_AndDrinkTypeIsNotEmpty()
        {
            var order = new Order(TestHelper.SetupTea(),1);
            var payment = new Payment(1);
            var drinkMakerProtocol = new CoffeeMachine(paymentAssessor.Object, orderTranslator.Object, storageManager.Object);

            storageManager.Setup(x => x.IsEmpty(order.DrinkType)).Returns(false);
            paymentAssessor.Setup(x => x.IsPaymentNotEnough(order, payment)).Returns(false);
            orderTranslator.Setup(x => x.TranslateOrder(order)).Returns(new Instruction("T","1","0",""));

            var actualResult = drinkMakerProtocol.HandleOrder(order, payment);

            storageManager.Verify(x=> x.ReduceDrinkQuantity(order.DrinkType), Times.Exactly(1));

            Assert.Equal("T:1:0", actualResult.InstructionMessage);
        }
        
        [Fact]
        public void HandleOrderShould_ReturnCorrectOrderString_WhenInSufficientPaymentAmount_AndDrinkTypeIsNotEmpty()
        {
            var order = new Order(TestHelper.SetupTea(),1);
            var payment = new Payment(0.3);
            var drinkMakerProtocol = new CoffeeMachine(paymentAssessor.Object, orderTranslator.Object, storageManager.Object);
            var expectedChange = 0.1;

            storageManager.Setup(x => x.IsEmpty(It.IsAny<IDrinkType>())).Returns(false);
            paymentAssessor.Setup(x => x.IsPaymentNotEnough(order, payment)).Returns(true);
            orderTranslator.Setup(x => x.ProduceMessage($"Not enough, missing {expectedChange} euro")).Returns(new Instruction($"Not enough, missing {expectedChange} euro"));

            var actualResult = drinkMakerProtocol.HandleOrder(order, payment);
        
            Assert.Equal($"M:Not enough, missing {expectedChange} euro", actualResult.InstructionMessage);
        }
        
        //TODO: Refactor tests/ add repositories to organize files/ make it work
    }
}
