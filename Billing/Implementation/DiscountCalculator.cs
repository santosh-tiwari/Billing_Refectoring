using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.Implementation
{
    public class DiscountCalculator
    {
        public decimal CalculateDiscount(int differentBooksCount)
        {
            decimal discount = 0;

            switch (differentBooksCount)
            {
                case 2:
                    discount = 0.05m;
                    break;
                case 3:
                    discount = 0.10m;
                    break;
                case 4:
                    discount = 0.20m;
                    break;
                case 5:
                    discount = 0.25m;
                    break;
            }

            return discount;
        }
    }
}
