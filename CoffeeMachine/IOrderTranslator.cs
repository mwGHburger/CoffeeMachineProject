namespace CoffeeMachine
{
    public interface IOrderTranslator
    {
         Instruction TranslateOrder(Order order);
         Instruction ProduceMessage(string message);
    }
}