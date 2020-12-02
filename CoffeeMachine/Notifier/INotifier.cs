namespace CoffeeMachine
{
    public interface INotifier
    {
        string NotifyMissingDrink(IDrinkType drinkType);
    }
}