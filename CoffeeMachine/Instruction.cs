namespace CoffeeMachine
{
    public class Instruction
    {
        public Instruction(string drinkTypeCharacter, string sugarQuantity, string stickOrder)
        {
            InstructionMessage = FormatInstructionMessage(drinkTypeCharacter, sugarQuantity, stickOrder);
        }

        public Instruction(string customerMessage)
        {
            InstructionMessage = $"M:{customerMessage}";
        }

        private string FormatInstructionMessage(string drinkTypeCharacter, string sugarQuantity, string stickOrder)
        {
            return $"{drinkTypeCharacter}:{sugarQuantity}:{stickOrder}";
        }

        // public override string ToString()
        // {
        //     return $"{drinkTypeCharacter}:{sugarQuantity}:{stickOrder}";
        // }
        //To-Do: keep properties instead of one InstructionMessage.
        //To-Do: add To-string method later.

        public string InstructionMessage { get; private set; }
    }
}