using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkQuantityCheckerTests
    {
        DrinkQuantityChecker drinkQuantityChecker = new DrinkQuantityChecker();
        
        [Fact]
        public void isEmpty_ShouldReturnTrueWhenDrinkQuantityIs0()
        {
            var teaStorage = new Storage(0, TestHelper.SetupTea());

            var actual = drinkQuantityChecker.IsEmpty(teaStorage);

            Assert.True(actual);
        }

        [Fact]
        public void isEmpty_ShouldReturnFalseWhenDrinkQuantityIsAbove0()
        {
            var teaStorage = new Storage(1, TestHelper.SetupTea());

            var actual = drinkQuantityChecker.IsEmpty(teaStorage);

            Assert.False(actual);
        }
    }
}