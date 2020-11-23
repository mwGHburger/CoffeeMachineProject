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

        [Fact]
        public void IsEmpty_ShouldReturnTrue_IfQuantityForGivenDrinkTypeIs0()
        {
            var tea = new Tea();
            var teaStorage = new Storage(0, tea);
            var drinks = new List<IDrinkStorage>()
            {
                teaStorage
            };

            var drinkQuantityChecker = new DrinkQuantityChecker();
            var storageManager = new StorageManager(drinks, drinkQuantityChecker);

            Assert.True(storageManager.IsEmpty(tea));
        }

        [Fact]
        public void IsEmpty_ShouldReturnFalse_IfQuantityForGivenDrinkTypeAbove0()
        {
            var tea = new Tea();
            var teaStorage = new Storage(1, tea);
            var drinks = new List<IDrinkStorage>()
            {
                teaStorage
            };

            var drinkQuantityChecker = new DrinkQuantityChecker();
            var storageManager = new StorageManager(drinks, drinkQuantityChecker);

            Assert.False(storageManager.IsEmpty(tea));
        }
    }
}