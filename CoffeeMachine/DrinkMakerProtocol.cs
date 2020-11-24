using System;

namespace CoffeeMachine
{
    //TO-DO: add git ignore file next time.
    public class DrinkMakerProtocol
    {
        private IPaymentAssessor _paymentAssessor;
        private IOrderTranslator _orderTranslator;
        private IStorageManager _storageManager;

        public DrinkMakerProtocol(IPaymentAssessor paymentAssessor, IOrderTranslator orderTranslator, IStorageManager storageManager)
        {
            _paymentAssessor = paymentAssessor;
            _orderTranslator = orderTranslator;
            _storageManager = storageManager;
        }

        public Instruction HandleOrder(Order order, Payment payment)
        {
            if (_storageManager.IsEmpty(order.DrinkType))
            {
                return _orderTranslator.ProduceMessage(StandardMessages.IsEmptyMessage(order.DrinkType));
            }
            if (_paymentAssessor.IsPaymentNotEnough(order, payment))
            {
                return _orderTranslator.ProduceMessage(
                    StandardMessages.InsufficientPaymentMessage(order.DrinkType.Cost - payment.Amount)
                );
            }
            
            _storageManager.ReduceDrinkQuantity(order.DrinkType);
            return _orderTranslator.TranslateOrder(order);
        }
    }
}