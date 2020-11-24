namespace CoffeeMachine
{
    public interface IPaymentAssessor
    {
        bool IsPaymentNotEnough(Order order, Payment payment);
    }
}