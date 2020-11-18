using Xunit;

namespace CoffeeMachine.Tests
{
    public class DrinkQuantityCheckerTests
    {
        [Fact]
        public void isEmpty_ShouldReturnTrueWhenDrinkQuantityIs0()
        {
            var drinkQuantityChecker = new DrinkQuantityChecker();
            var teaStorage = new Storage(0, new Tea());

            var actual = drinkQuantityChecker.IsEmpty(teaStorage);

            Assert.True(actual);
        }

        [Fact]
        public void isEmpty_ShouldReturnFalseWhenDrinkQuantityIsAbove0()
        {
            var drinkQuantityChecker = new DrinkQuantityChecker();
            var teaStorage = new Storage(1, new Tea());

            var actual = drinkQuantityChecker.IsEmpty(teaStorage);

            Assert.False(actual);
        }
    }
}