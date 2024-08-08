using Billing.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.Interface
{
    public interface IBookCostCalculator
    {
        decimal CalculateTotalCost(List<Books> books);
    }
}
