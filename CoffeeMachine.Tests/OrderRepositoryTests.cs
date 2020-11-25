using Moq;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToAddOrderToOrderList()
        {
            var repository = new OrderRepository();
            Mock<IOrder> mockOrder = new Mock<IOrder>();
            
            Assert.Empty(repository.Orders);
            repository.AddOrder(mockOrder.Object);
            Assert.NotEmpty(repository.Orders);
        }
    }
}