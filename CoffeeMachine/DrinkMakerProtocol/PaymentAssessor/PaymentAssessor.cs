namespace CoffeeMachine
{
    public class PaymentAssessor : IPaymentAssessor
    {
        public bool IsPaymentNotEnough(Order order, Payment payment)
        {
            var drinkCost = order.DrinkType.Cost;
            var isPaymentNotEnough = payment.Amount < drinkCost;
            return (isPaymentNotEnough);
        }
    }
}