namespace CoffeeMachine
{
    public class EmailNotifier : INotifier
    {

        public string NotifyMissingDrink(IDrinkType drinkType)
        {
            return $"Notifying company... you have run out of {drinkType.Name}";
        }
    }
}