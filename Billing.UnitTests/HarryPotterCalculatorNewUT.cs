using Billing.Entity;
using Billing.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Billing.UnitTests
{
    [TestClass]
    public class HarryPotterCalculatorNewUT
    {
        [TestMethod]
        public void TestMethod1()
        {



            var books = new List<Books>
            {
                new Books { BookId = 1, Name = "Book 1", Qty = 1 },
                new Books { BookId = 2, Name = "Book 2", Qty = 1 },
                new Books { BookId = 3, Name = "Book 3", Qty = 1 },
                new Books { BookId = 4, Name = "Book 4", Qty = 1 },
                new Books { BookId = 5, Name = "Book 5", Qty = 1 }
            };

            var discountCalculator = new DiscountCalculator();
            var costCalculator = new HarryPotterCostCalculator(discountCalculator);
            var outputWriter = new FileOutputWriter();
            var calculator = new HarryPotterCalculatorNew(costCalculator, outputWriter);

            calculator.CalculateCost(books, "output.txt", "Test User", "Test Address");

            Assert.AreEqual(275, File.OpenRead("output.txt").Length);

            string str = string.Empty;
        }


    }
}
