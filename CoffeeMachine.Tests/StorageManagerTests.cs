using System.Collections.Generic;
using Moq;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class StorageManagerTests
    {
        Mock<INotifier> mockEmailNotifier = new Mock<INotifier>();
        IDrinkType tea = TestHelper.SetupTea();
        IDrinkType chocolate = TestHelper.SetupChocolate();
        IDrinkType coffee = TestHelper.SetupCoffee();

        // TODO: Add boundary tests

        [Fact]
        public void ReduceDrinkQuantity_ShouldReduceQuantityForSpecificDrinkType()
        {
            var teaStorage = new Storage(5, tea);
            var coffeeStorage = new Storage(0, coffee);
            var chocolateStorage = new Storage(0, chocolate);

            var drinks = TestHelper.SetupDrinkStorageList(teaStorage, coffeeStorage, chocolateStorage);

            var drinkQuantityChecker = new DrinkQuantityChecker();
            var storageManager = new StorageManager(drinks, drinkQuantityChecker, mockEmailNotifier.Object);

            storageManager.ReduceDrinkQuantity(tea);

            Assert.Equal(4, teaStorage.Quantity);
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_IfQuantityForGivenDrinkTypeIs0()
        {
            var teaStorage = new Storage(0, tea);
            var coffeeStorage = new Storage(0, coffee);
            var chocolateStorage = new Storage(0, chocolate);

            var drinks = TestHelper.SetupDrinkStorageList(teaStorage, coffeeStorage, chocolateStorage);

            var drinkQuantityChecker = new DrinkQuantityChecker();
            var storageManager = new StorageManager(drinks, drinkQuantityChecker, mockEmailNotifier.Object);

            var actual = storageManager.IsEmpty(tea);

            Assert.True(actual);
            mockEmailNotifier.Verify(x => x.NotifyMissingDrink(tea), Times.Exactly(1));
        }

        [Fact]
        public void IsEmpty_ShouldReturnFalse_IfQuantityForGivenDrinkTypeAbove0()
        {
            var teaStorage = new Storage(1, tea);
            var coffeeStorage = new Storage(0, coffee);
            var chocolateStorage = new Storage(0, chocolate);

            var drinks = TestHelper.SetupDrinkStorageList(teaStorage, coffeeStorage, chocolateStorage);

            var drinkQuantityChecker = new DrinkQuantityChecker();
            var storageManager = new StorageManager(drinks, drinkQuantityChecker, mockEmailNotifier.Object);

            Assert.False(storageManager.IsEmpty(tea));
        }
    }
}