namespace CoffeeMachine
{
    public interface IDrinkStorage
    {
         int Quantity { get; }
         IDrinkType DrinkType {get; }
         void ReduceQuantity();
    }
}