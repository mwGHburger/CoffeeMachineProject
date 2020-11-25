using System.Collections.Generic;
using Xunit;

namespace CoffeeMachine.Tests
{
    public class ReportTests
    {
        Dictionary<string, int> orders = new Dictionary<string, int>();
        
        [Fact]
        public void GenerateReport_ShouldReturnReportString()
        {
            var revenue = 10;
            
            orders.Add("Tea", 5);
            orders.Add("Chocolate", 5);
            orders.Add("Coffee", 6);
            var report = new Report(revenue, orders);

            var expected =
            "Report\n" +
            "Tea: 5 units\n" +
            "Chocolate: 5 units\n" +
            "Coffee: 6 units\n" +
            "Total Revenue: $10\n"; 

            var actual = report.GenerateReport();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GenerateReport_ShouldReturnReportString_2()
        {
            var revenue = 2;
            orders.Add("Tea", 5);
            var report = new Report(revenue, orders);

            var expected =
            "Report\n" +
            "Tea: 5 units\n" +
            "Total Revenue: $2\n"; 

            var actual = report.GenerateReport();

            Assert.Equal(expected, actual);
        }
    }
}