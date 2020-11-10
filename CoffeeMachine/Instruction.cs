namespace CoffeeMachine
{
    public class Instruction
    {
        // TODO: Explanation on how to structure this class
        // instruction.InstructionMessage
        // OR
        // instruction.ToString()
        public Instruction(string drinkTypeCharacter, string sugarQuantity, string stickOrder)
        {
            InstructionMessage = FormatInstructionMessage(drinkTypeCharacter, sugarQuantity, stickOrder);
        }

        public Instruction(string customerMessage)
        {
            InstructionMessage = $"M:{customerMessage}";
        }

        private static string FormatInstructionMessage(string drinkTypeCharacter, string sugarQuantity, string stickOrder)
        {
            return $"{drinkTypeCharacter}:{sugarQuantity}:{stickOrder}";
        }

        public string InstructionMessage { get; private set; }
        
    }
}