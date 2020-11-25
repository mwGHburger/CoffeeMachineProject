namespace CoffeeMachine
{
    public class EmailNotifier
    {
        private IOutput _output;

        public EmailNotifier(IOutput output)
        {
            _output = output;
        }

        public void NotifyMissingDrink(IDrinkType drinkType)
        {
            _output.Write($"Notifying company... you have run out of {drinkType.Name}");
        }
    }
}