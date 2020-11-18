namespace CoffeeMachine
{
    public interface IPaymentAssessor
    {
        bool AssessPayment(Order order, Payment payment);
    }
}