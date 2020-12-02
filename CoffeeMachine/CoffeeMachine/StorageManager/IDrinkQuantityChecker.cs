namespace CoffeeMachine
{
    public interface IDrinkQuantityChecker
    {
        bool IsEmpty(IDrinkStorage drinkStorage);
    }
}