namespace CoffeeMachine
{
    public static class StandardMessages
    {
        public static string InsufficientPaymentMessage(double paymentDifference)
        {
            return $"Not enough, missing {paymentDifference:N1} euro";
        }

        public static string IsEmptyMessage(IDrinkType drinkType)
        {
            return $"{drinkType.Name} is empty";
        }

        public static string Welcome ()
        {
            return "Welcome";
        }
    }
}