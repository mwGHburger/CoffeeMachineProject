namespace CoffeeMachine
{
    public class Tea : IDrinkType
    {
        public string Name { get; } = "tea";
        public double Cost { get; } = 0.4;

        public string Character { get; } = "T";
    }
}