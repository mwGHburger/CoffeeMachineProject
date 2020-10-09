namespace CoffeeMachine
{
    public class DrinkType
    {
        public string Name {get; private set;}
        public double Cost {get; private set;}
        public DrinkType(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}