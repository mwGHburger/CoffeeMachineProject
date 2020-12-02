using System.Collections.Generic;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class E2ETest
    {
        [Theory]
        [InlineData(0.4, 10, true, "Th:1:0")]
        [InlineData(0.3, 10, true, "M:Not enough, missing 0.1 euro")]
        public void TheProgramShould_ReturnCorrectStringAsInstruction_BasedOnInputOrder(double paymentValue, int drinkQuantity, bool isExtraHot, string expectedResult)
        {
            var tea = new Tea();
            var order = new Order(tea,1, isExtraHot:isExtraHot);
            var payment = new Payment(paymentValue);
            var paymentAssessor = new PaymentAssessor();
            var teaStorage = new Storage(drinkQuantity, tea);
            var drinkStorageList = new List<IDrinkStorage>(){teaStorage};
            var output = new ConsoleOutput();
            var drinkQuantityChecker = new DrinkQuantityChecker();
            var emailNotifier = new EmailNotifier(output);
            var storageManager = new StorageManager(drinkStorageList, drinkQuantityChecker, emailNotifier);
            var orderTranslator = new OrderTranslator();
            var drinkMakerProtocol = new DrinkMakerProtocol(paymentAssessor, orderTranslator, storageManager);

            var actualResult = drinkMakerProtocol.HandleOrder(order, payment).InstructionMessage;
            Assert.Equal(expectedResult , actualResult);
        }
    }
}