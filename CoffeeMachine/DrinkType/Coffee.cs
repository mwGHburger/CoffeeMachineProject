namespace CoffeeMachine
{
    public class Coffee : IDrinkType
    {
        public string Name { get; } = "coffee";
        public double Cost { get; } = 0.6;
        
        public string Character { get; } = "C";
    }
    
}