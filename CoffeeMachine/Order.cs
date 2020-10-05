namespace CoffeeMachine
{
    public class Order
    {
        public Order(string drinkType, int sugarQuantity, string message="")
        {
            DrinkType = drinkType;
            SugarQuantity = sugarQuantity;
            Message = message;
        }

        public string DrinkType { get; private set; }
        public int SugarQuantity { get; private set; }
        
        public string Message { get; private set; }
    }
}