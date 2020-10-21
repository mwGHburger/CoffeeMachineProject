namespace CoffeeMachine
{
    public class Order : IOrder
    {
        public Order(DrinkType drinkType, int sugarQuantity, string message="")
        {
            DrinkType = drinkType;
            SugarQuantity = sugarQuantity;
        }

        public DrinkType DrinkType { get; private set; }
        public int SugarQuantity { get; private set; }
    }
}