using System.Collections.Generic;

namespace CoffeeMachine
{
    public static class ClassInstantiatorFactory
    {

        public static readonly IDrinkType Tea = CreateTea();

        public static DrinkMakerProtocol CreateDrinkMakerProtocol()
        {
            return new DrinkMakerProtocol(CreatePaymentAssessor(), CreateOrderTranslator(), CreateStorageManager());
        }
        
        private static IPaymentAssessor CreatePaymentAssessor()
        {
            return new PaymentAssessor();
        }
        
        private static IOrderTranslator CreateOrderTranslator()
        {
            return new OrderTranslator();
        }
        
        private static IStorageManager CreateStorageManager()
        {
            return new StorageManager(CreateDrinkStorages(), CreateDrinkQuantityChecker(), CreateEmailNotifier());
        }

        private static List<IDrinkStorage> CreateDrinkStorages()
        {
           var teaStorage = new Storage(10, Tea);
           return new List<IDrinkStorage>() {teaStorage};
        }

        private static IDrinkQuantityChecker CreateDrinkQuantityChecker()
        {
            return new DrinkQuantityChecker();
        }
        
        private static INotifier CreateEmailNotifier()
        {
            return new EmailNotifier(CreateOutput());
        }

        private static IOutput CreateOutput()
        {
            return new ConsoleOutput();
        }

        private static IDrinkType CreateTea()
        {
            return new Tea();
        }
    }
}