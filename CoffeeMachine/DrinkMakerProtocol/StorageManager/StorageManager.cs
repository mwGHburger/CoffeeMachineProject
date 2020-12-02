using System.Collections.Generic;

namespace CoffeeMachine
{
    public class StorageManager : IStorageManager
    {
        private List<IDrinkStorage> _drinks;
        private IDrinkQuantityChecker _drinkQuantityChecker;
        private INotifier _notifier;

        // DrinkReporsitory.cs <- List of drinks
        // DrinkService <- fetch, save --- solely DB actions - CRUD 
        // Make Database external
        public StorageManager(List<IDrinkStorage> drinks, IDrinkQuantityChecker drinkQuantityChecker, INotifier notifier)
        {
            _drinks = drinks;
            _drinkQuantityChecker = drinkQuantityChecker;
            _notifier = notifier;
        }

        public void ReduceDrinkQuantity(IDrinkType drinkType)
        {
            var drink = FindDrinkStorage(drinkType);
            drink.ReduceQuantity();
        }

        public bool IsEmpty(IDrinkType drinkType)
        {
            var drinkStorage = FindDrinkStorage(drinkType);
            if(_drinkQuantityChecker.IsEmpty(drinkStorage))
            {
                _notifier.NotifyMissingDrink(drinkType);
                return true;
            }
            return false;
        }

        private IDrinkStorage FindDrinkStorage(IDrinkType drinkType)
        {
            return _drinks.Find(x => x.DrinkType.Equals(drinkType));
        }
    }
}