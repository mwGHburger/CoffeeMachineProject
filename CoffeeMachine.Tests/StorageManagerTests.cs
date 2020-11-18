using System.Collections.Generic;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class StorageManagerTests
    {
        [Fact]
        public void ReduceDrinkQuantity_ShouldReduceQuantityForSpecificDrinkType()
        {
            var tea = new Tea();
            var coffee = new Coffee();
            var chocolate = new Chocolate();
            var teaStorage = new Storage(5, tea);
            var drinks = new List<IDrinkStorage>()
            {
                teaStorage
            };

            var drinkQuantityChecker = new DrinkQuantityChecker();
            var storageManager = new StorageManager(drinks, drinkQuantityChecker);

            storageManager.ReduceDrinkQuantity(tea);

            Assert.Equal(4, teaStorage.Quantity);
        }
    }
}