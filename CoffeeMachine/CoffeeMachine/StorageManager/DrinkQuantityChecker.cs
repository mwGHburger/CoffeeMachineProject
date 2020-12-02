namespace CoffeeMachine
{
    public class DrinkQuantityChecker : IDrinkQuantityChecker
    {
        public bool IsEmpty(IDrinkStorage drinkStorage)
        {
            return drinkStorage.Quantity.Equals(0);
        }
    }
}