using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class StorageManager : IStorageManager
    {
        private List<IDrinkStorage> _drinks;
        private IDrinkQuantityChecker _drinkQuantityChecker;

        // DrinkReporsitory.cs <- List of drinks
        // DrinkService <- fetch, save --- solely DB actions - CRUD 
        // Make Database external
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
            if(_drinkQuantityChecker.IsEmpty(drinkStorage))
            {
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