namespace CoffeeMachine
{
    public class Order : IOrder
    {
        public Order(IDrinkType drinkType, int sugarQuantity, string message="")
        {
            DrinkType = drinkType;
            SugarQuantity = sugarQuantity;
        }

        public IDrinkType DrinkType { get; private set; }
        public int SugarQuantity { get; private set; }
    }
}