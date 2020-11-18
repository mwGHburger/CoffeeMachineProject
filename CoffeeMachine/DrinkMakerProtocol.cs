using System;

namespace CoffeeMachine
{
    //TO-DO: add git ignore file next time.
    public class DrinkMakerProtocol
    {
        private IPaymentAssessor _paymentAssessor;
        private IOrderTranslator _orderTranslator;

        public DrinkMakerProtocol(IPaymentAssessor paymentAssessor, IOrderTranslator orderTranslator)
        {
            _paymentAssessor = paymentAssessor;
            _orderTranslator = orderTranslator;
        }

        public Instruction HandleOrder(Order order, Payment payment)
        {   
            if (_paymentAssessor.AssessPayment(order, payment))
            {
                return _orderTranslator.TranslateOrder(order);
            }
            return _orderTranslator.ProduceMessage(
                StandardMessages.InsufficientPaymentMessage(order.DrinkType.Cost - payment.Amount)
            );
        }
    }
}