namespace CoffeeMachine
{
    public interface IStorageManager
    {
        void ReduceDrinkQuantity(IDrinkType drinkType);

        bool IsEmpty(IDrinkType drinkType);
    }
}