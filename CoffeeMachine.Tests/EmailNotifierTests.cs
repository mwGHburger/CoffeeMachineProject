using Moq;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class EmailNotifierTests
    {
        [Fact]
        public void NotifyMissingDrink_ShouldOutputMessageToConsole()
        {
            var mockConsoleOutput = new Mock<IOutput>();
            var tea = TestHelper.SetupTea();
            var emailNotifier = new EmailNotifier(mockConsoleOutput.Object);

            emailNotifier.NotifyMissingDrink(tea);

            mockConsoleOutput.Verify(x => x.Write("Notifying company... you have run out of tea"), Times.Exactly(1));
        }
    }
}