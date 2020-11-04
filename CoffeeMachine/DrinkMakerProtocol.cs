using System;

namespace CoffeeMachine
{
    //TO-DO: add git ignore file next time.
    public static class DrinkMakerProtocol
    {
        
        public static Instruction AssessPayment(Order order, Payment payment)
        {
            var drinkCost = order.DrinkType.Cost;
            var isPaymentEnough = payment.Amount >= drinkCost;
            
            return (isPaymentEnough) ? TranslateOrder(order) : ProduceMessage($"Not enough, missing {drinkCost - payment.Amount} euro");
        }
        public static Instruction TranslateOrder(Order order)
        {
            var drinkTypeCharacter = GetDrinkTypeCharacter(order);
            var sugarQuantity = GetSugarQuantity(order);
            var stickOrder = GetStickOrder(order);
            
            return new Instruction(drinkTypeCharacter, sugarQuantity, stickOrder);
        }

        private static string GetStickOrder(Order order)
        {
            return (order.SugarQuantity > 0) ? "0" : "";
        }
        
        private static string GetSugarQuantity(Order order)
        {
            return (order.SugarQuantity > 0) ? $"{order.SugarQuantity}" : "";
        }

        private static string GetDrinkTypeCharacter(Order order)
        {
            switch (order.DrinkType.Name)
            {
                case "tea":
                    return "T";
                case "coffee":
                    return "C";
                case "chocolate":
                    return "H";
            }

            throw new Exception();
        }

        private static Instruction ProduceMessage(string message)
        {
            return new Instruction(message);
        }
    }
}