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

        public bool IsEmpty(IDrinkType drinkType)
        {
            var drinkStorage = FindDrinkStorage(drinkType);
            return _drinkQuantityChecker.IsEmpty(drinkStorage);
        }

        private IDrinkStorage FindDrinkStorage(IDrinkType drinkType)
        {
            return _drinks.Find(x => x.DrinkType.Equals(drinkType));
        }
    }
}