using Billing.Entity;

using Billing.Interface;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    public class HarryPotterCalculatorNew
    {
        private readonly IBookCostCalculator _costCalculator;
        private readonly IOutputWriter _outputWriter;

        public HarryPotterCalculatorNew(IBookCostCalculator costCalculator, IOutputWriter outputWriter)
        {
            _costCalculator = costCalculator;
            _outputWriter = outputWriter;
        }

        public void CalculateCost(List<Books> books, string path, string name, string address)
        {
            decimal totalCost = _costCalculator.CalculateTotalCost(books);
            _outputWriter.WriteOutput(path, name, address, totalCost, books);
        }
    }
}
