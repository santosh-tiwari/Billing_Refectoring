using Billing.Entity;
using Billing.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Billing.Implementation
{
    public class FileOutputWriter : IOutputWriter
    {
        public void WriteOutput(string path, string name, string address, decimal totalCost, List<Books> books)
        {
            using (var fs = File.OpenWrite(path))
            {
                var header = Encoding.ASCII.GetBytes($"Date: {DateTime.Now.ToShortDateString()}\r\nName: {name}\r\nAddress: {address}\r\n\r\n");
                fs.Write(header, 0, header.Length);

                var detailsHeader = "Description\t\t\t\t\tQuantity\tPrice\r\n";
                fs.Write(Encoding.ASCII.GetBytes(detailsHeader), 0, Encoding.ASCII.GetBytes(detailsHeader).Length);

                foreach (var book in books)
                {
                    var discount = new DiscountCalculator().CalculateDiscount(book.Qty);
                    var bookLine = string.Format("{0} Harry Potter books\t\t{1}\t\t\t{2}\r\n", book.Name, book.Qty, book.Price * book.Qty * (1 - discount));
                    fs.Write(Encoding.ASCII.GetBytes(bookLine), 0, Encoding.ASCII.GetBytes(bookLine).Length);
                }

                var totalLine = string.Format("Total: {0}\r\n", totalCost);
                fs.Write(Encoding.ASCII.GetBytes(totalLine), 0, Encoding.ASCII.GetBytes(totalLine).Length);
            }
        }
    }
}
