namespace CoffeeMachine
{
    public class Instruction
    {
        public Instruction(string drinkTypeCharacter, string sugarQuantity, string stickOrder)
        {
            InstructionMessage = FormatInstructionMessage(drinkTypeCharacter, sugarQuantity, stickOrder);
        }

        private static string FormatInstructionMessage(string drinkTypeCharacter, string sugarQuantity, string stickOrder)
        {
            return $"{drinkTypeCharacter}:{sugarQuantity}:{stickOrder}";
        }

        public string InstructionMessage { get; private set; }
    }
}