using System.Collections.Generic;
namespace CoffeeMachine
{
    public class DrinkDictionaryGenerator
    {
        public Dictionary<DrinkType,int> Generate(List<IOrder> orders)
        {
            var dictionary = new Dictionary<DrinkType, int>();
            foreach(Order order in orders)
            {
                if(dictionary.ContainsKey(order.DrinkType))
                {
                    // TODO: Think about this next time
                }
            }
        }
    }
}