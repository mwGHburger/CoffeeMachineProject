using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Repository
    {
        public List<IOrder> Orders { get;} = new List<IOrder>();

        public void AddOrder(IOrder order)
        {
            Orders.Add(order);
        }
    }
}