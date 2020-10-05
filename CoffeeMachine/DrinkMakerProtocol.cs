using System;

namespace CoffeeMachine
{
    //TO-DO: add git ignore file next time.
    public static class DrinkMakerProtocol
    {
        public static string TranslateOrder(Order order)
        {
            
            var drinkTypeCharacter = GetDrinkTypeCharacter(order);
            var sugarQuantity = GetSugarQuantity(order);
            var stickOrder = GetStickOrder(order);
            
            return $"{drinkTypeCharacter}:{sugarQuantity}:{stickOrder}";
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
            switch (order.DrinkType)
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

        public static string TranslateOrderMessage(Order order)
        {
            return $"M:{order.Message}";
        }
    }
}