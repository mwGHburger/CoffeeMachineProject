namespace CoffeeMachine
{
    public interface INotifier
    {
        void NotifyMissingDrink(IDrinkType drinkType);
    }
}