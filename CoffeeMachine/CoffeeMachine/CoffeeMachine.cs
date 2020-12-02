using System;

namespace CoffeeMachine
{
    //TO-DO: add git ignore file next time.
    public class CoffeeMachine
    {
        private IPaymentAssessor _paymentAssessor;
        private IOrderTranslator _drinkMakerProtocol;
        private IStorageManager _storageManager;
        private IOutput _output;
        private INotifier _notifier;

        public CoffeeMachine(IPaymentAssessor paymentAssessor, IOrderTranslator drinkMakerProtocol, IStorageManager storageManager, IOutput output, INotifier notifier)
        {
            _paymentAssessor = paymentAssessor;
            _drinkMakerProtocol = drinkMakerProtocol;
            _storageManager = storageManager;
            _output = output;
            _notifier = notifier;
        }

        public void HandleOrder(Order order, Payment payment)
        {
            var message = ValidateOrder(order, payment);

            if(message.Length.Equals(0))
            {
                _storageManager.ReduceDrinkQuantity(order.DrinkType);
                _output.Write(_drinkMakerProtocol.TranslateOrder(order).InstructionMessage);
            }
            else
            {
                _output.Write(_drinkMakerProtocol.ProduceMessage(message).InstructionMessage);
            }
            
        }

        private string ValidateOrder(Order order, Payment payment)
        {
            if (_storageManager.IsEmpty(order.DrinkType))
            {
                _output.Write(_notifier.NotifyMissingDrink(order.DrinkType));
                return StandardMessages.IsEmptyMessage(order.DrinkType);
            }
            if (_paymentAssessor.IsPaymentNotEnough(order, payment))
            {
                return StandardMessages.InsufficientPaymentMessage(order.DrinkType.Cost - payment.Amount);
            }
            return "";
        }
    }
}