namespace CoffeeMachine
{
    public class OrderTranslator : IOrderTranslator
    {
        public Instruction TranslateOrder(Order order)
        {
            var drinkTypeCharacter = GetDrinkTypeCharacter(order);
            var sugarQuantity = GetSugarQuantity(order);
            var stickOrder = GetStickOrder(order);
            var isExtraHot = GetIsExtraHotInfo(order);
            return new Instruction(drinkTypeCharacter, sugarQuantity, stickOrder, isExtraHot);
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
        
        private string GetIsExtraHotInfo(Order order)
        {
            return order.IsExtraHot ? "h" : "";
        }
    }
}