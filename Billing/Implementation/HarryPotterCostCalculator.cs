using Billing.Entity;
using Billing.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.Implementation
{
    public class HarryPotterCostCalculator : IBookCostCalculator
    {
        private readonly DiscountCalculator _discountCalculator;

        public HarryPotterCostCalculator(DiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

        public decimal CalculateTotalCost(List<Books> books)
        {
            var groupedBooks = books.GroupBy(b => b.BookId).Select(g => g.First()).ToList();
            int differentBooksCount = groupedBooks.Count;

            decimal discount = _discountCalculator.CalculateDiscount(differentBooksCount);

            decimal totalCost = 0;
            foreach (var book in books)
            {
                totalCost += book.Qty * book.Price * (1 - discount);
            }

            return totalCost;
        }
    }
}
