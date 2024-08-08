using Billing.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.Interface
{
    public interface IOutputWriter
    {
        void WriteOutput(string path, string name, string address, decimal totalCost, List<Books> books);
    }
}
