using System.Collections.Generic;

namespace CoffeeMachine.Tests
{
    public static class TestHelper
    {
        // params
        public static List<IDrinkStorage> SetupDrinkStorageList(IDrinkStorage teaStorage, IDrinkStorage coffeeStorage, IDrinkStorage chocolateStorage)
        {
            return new List<IDrinkStorage>()
            {
                teaStorage,
                coffeeStorage,
                chocolateStorage
            };
        }

        public static IDrinkType SetupTea()
        {
            return new Tea();
        }

        public static IDrinkType SetupCoffee()
        {
            return new Coffee();
        }

        public static IDrinkType SetupChocolate()
        {
            return new Chocolate();
        }
    }
}