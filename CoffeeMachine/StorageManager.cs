using System.Collections.Generic;

namespace CoffeeMachine
{
    public class StorageManager
    {
        private List<IDrinkStorage> _drinks;
        private IDrinkQuantityChecker _drinkQuantityChecker;

        public StorageManager(List<IDrinkStorage> drinks, IDrinkQuantityChecker drinkQuantityChecker)
        {
            _drinks = drinks;
            _drinkQuantityChecker = drinkQuantityChecker;
        }

        public void ReduceDrinkQuantity(IDrinkType drinkType)
        {
            var drink = FindDrinkStorage(drinkType);
            drink.ReduceQuantity();
        }

        // TODO: Add email notifier
        // TODO: Check if there is enough quantity

        private IDrinkStorage FindDrinkStorage(IDrinkType drinkType)
        {
            return _drinks.Find(x => x.DrinkType.Equals(drinkType));
        }
    }
}