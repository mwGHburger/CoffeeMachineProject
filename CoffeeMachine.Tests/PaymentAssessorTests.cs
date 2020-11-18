using Moq;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class PaymentAssessorTests
    {
        [Fact]
        public void AssessPaymentShould_ReturnTrue_WhenSufficientPaymentAmount()
        {
            var mockDrinkType = new Mock<IDrinkType>();
            var order = new Order(mockDrinkType.Object,1);
            var payment = new Payment(1);
            var paymentAssessor = new PaymentAssessor();

            var actualResult = paymentAssessor.AssessPayment(order, payment);
        
            Assert.True(actualResult);
        }
    }
}