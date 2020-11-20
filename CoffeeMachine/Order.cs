namespace CoffeeMachine
{
    public class Order : IOrder
    {
        public Order(IDrinkType drinkType, int sugarQuantity, bool isExtraHot = false)
        {
            DrinkType = drinkType;
            SugarQuantity = sugarQuantity;
            IsExtraHot = isExtraHot;
        }

        public IDrinkType DrinkType { get; }
        public int SugarQuantity { get; }

        public bool IsExtraHot { get;}
    }
}