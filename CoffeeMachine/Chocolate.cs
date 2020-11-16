namespace CoffeeMachine
{
    public class Chocolate:IDrinkType
    {
        public string Name { get; } = "chocolate";
        public double Cost { get; } = 0.5;
        
        public string Character { get; } = "H";
    }
}