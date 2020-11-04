using System;
using System.Collections.Generic;
namespace CoffeeMachine
{
    public class DrinkDictionaryGenerator
    {
        public DrinkDictionaryGenerator()
        {
            Revenue = 0;
        }

        public double Revenue { get; private set; }

        public Dictionary<string,int> Generate(List<IOrder> orders)
        {
            var dictionary = new Dictionary<string, int>();
            foreach(IOrder order in orders)
            {
                if(dictionary.ContainsKey(order.DrinkType.Name))
                {
                    dictionary[order.DrinkType.Name] += 1;
                }
                else
                {
                    dictionary.Add(order.DrinkType.Name, 1);
                }
            }

            if (dictionary.Count==0)
            {
                throw new Exception("Currently No Orders!");
            }
            return dictionary;
            
        }

        public double CalculateRevenue(List<IOrder> orders)
        {
            foreach (IOrder order in orders)
            {
                Revenue += order.DrinkType.Cost;
            }
            return Revenue;
        }
        //TO-Do: Add Output reporting modules and Clean up tests!
    }
}