using System.Collections.Generic;

namespace CoffeeMachine
{
    public static class ClassInstantiatorFactory
    {

        public static readonly IDrinkType Tea = CreateTea();

        public static CoffeeMachine CreateDrinkMakerProtocol()
        {
            return new CoffeeMachine(CreatePaymentAssessor(), CreateOrderTranslator(), CreateStorageManager(), CreateOutput(), CreateEmailNotifier());
        }
        
        private static IPaymentAssessor CreatePaymentAssessor()
        {
            return new PaymentAssessor();
        }
        
        private static IOrderTranslator CreateOrderTranslator()
        {
            return new DrinkMakerProtocol();
        }
        
        private static IStorageManager CreateStorageManager()
        {
            return new StorageManager(CreateDrinkStorages(), CreateDrinkQuantityChecker());
        }

        private static List<IDrinkStorage> CreateDrinkStorages()
        {
           var teaStorage = new Storage(0, Tea);
           return new List<IDrinkStorage>() {teaStorage};
        }

        private static IDrinkQuantityChecker CreateDrinkQuantityChecker()
        {
            return new DrinkQuantityChecker();
        }
        
        private static INotifier CreateEmailNotifier()
        {
            return new EmailNotifier();
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