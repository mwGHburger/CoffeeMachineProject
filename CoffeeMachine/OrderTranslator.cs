namespace CoffeeMachine
{
    public class OrderTranslator : IOrderTranslator
    {
        public Instruction TranslateOrder(Order order)
        {
            var drinkTypeCharacter = GetDrinkTypeCharacter(order);
            var sugarQuantity = GetSugarQuantity(order);
            var stickOrder = GetStickOrder(order);
            return new Instruction(drinkTypeCharacter, sugarQuantity, stickOrder);
        }
        public Instruction ProduceMessage(string message)
        {
            return new Instruction(message);
        }

        private string GetStickOrder(Order order)
        {
            return (order.SugarQuantity > 0) ? "0" : "";
        }
        
        private string GetSugarQuantity(Order order)
        {
            return (order.SugarQuantity > 0) ? $"{order.SugarQuantity}" : "";
        }

        private string GetDrinkTypeCharacter(Order order)
        {
            return order.DrinkType.Character;
        }
    }
}