using System;

namespace CoffeeMachine
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string input)
        {
            Console.WriteLine(input);
        }
    }
}