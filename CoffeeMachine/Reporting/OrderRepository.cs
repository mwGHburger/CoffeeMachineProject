using System.Collections.Generic;

namespace CoffeeMachine
{
    public class OrderRepository
    {
        public List<IOrder> Orders { get;} = new List<IOrder>();

        public void AddOrder(IOrder order)
        {
            Orders.Add(order);
        }
    }
}