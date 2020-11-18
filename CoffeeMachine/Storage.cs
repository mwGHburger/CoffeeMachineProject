namespace CoffeeMachine
{
    public class Storage : IDrinkStorage
    {
        public int Quantity { get; private set; }
        public IDrinkType DrinkType { get;}

        public Storage(int quantity, IDrinkType drinkType)
        {
            Quantity = quantity;
            DrinkType = drinkType;
        }

        public void ReduceQuantity()
        {
            Quantity--;
        }
    }
}