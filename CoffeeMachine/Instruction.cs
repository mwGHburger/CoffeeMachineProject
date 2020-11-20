namespace CoffeeMachine
{
    public class Instruction
    {
        // TODO: Explanation on how to structure this class
        // instruction.InstructionMessage
        // OR
        // instruction.ToString()
        public Instruction(string drinkTypeCharacter, string sugarQuantity, string stickOrder, string isExtraHot)
        {
            InstructionMessage = FormatInstructionMessage(drinkTypeCharacter, sugarQuantity, stickOrder, isExtraHot);
        }

        public Instruction(string customerMessage)
        {
            InstructionMessage = $"M:{customerMessage}";
        }

        private static string FormatInstructionMessage(string drinkTypeCharacter, string sugarQuantity, string stickOrder, string isExtraHot)
        {
            return $"{drinkTypeCharacter}{isExtraHot}:{sugarQuantity}:{stickOrder}";
        }

        public string InstructionMessage { get; private set; }
        
    }
}