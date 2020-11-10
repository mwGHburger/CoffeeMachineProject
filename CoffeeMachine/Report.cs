using System.Collections.Generic;
namespace CoffeeMachine
{
    public class Report
    {
        private int _revenue;
        private Dictionary<string, int> _orders;

        public Report(int revenue, Dictionary<string, int> orders)
        {
            _revenue = revenue;
            _orders = orders;
        }
        public string GenerateReport()
        {
            var header = "Report\n";
            var body = "";
            foreach(KeyValuePair<string, int> order in _orders)
            {
                body += $"{order.Key}: {order.Value} units\n";
            }
            var revenue = $"Total Revenue: ${_revenue}\n";
            return header + body + revenue;
        }
        //TODO: Clean up tests!, Console Output, Report class design, fifth iteration, instruction class design
    }
}