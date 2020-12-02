using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var drinkMakerProtocol = ClassInstantiatorFactory.CreateDrinkMakerProtocol();
            var order = new Order(ClassInstantiatorFactory.Tea, 1, true);
            var payment = new Payment(0.4);
            var instruction = drinkMakerProtocol.HandleOrder(order, payment);
            Console.WriteLine(instruction.InstructionMessage);
        }
    }
}
