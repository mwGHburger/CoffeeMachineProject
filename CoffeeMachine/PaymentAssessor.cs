namespace CoffeeMachine
{
    public class PaymentAssessor : IPaymentAssessor
    {
        public bool AssessPayment(Order order, Payment payment)
        {
            var drinkCost = order.DrinkType.Cost;
            var isPaymentEnough = payment.Amount >= drinkCost;
            return (isPaymentEnough);
        }
    }
}