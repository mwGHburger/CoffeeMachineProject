using Xunit;

namespace CoffeeMachine.Tests
{
    public class StorageTests
    {
        [Fact]
        public void ReduceQuantity_ShouldDecreaseQuantityBy1()
        {
            var storage = new Storage(10, new Tea());

            storage.ReduceQuantity();

            Assert.Equal(9, storage.Quantity);
        }
    }
}