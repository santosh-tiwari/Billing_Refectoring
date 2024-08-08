﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Implementation
{
    internal class EqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            for (int i = 1; i <= 5; ++i)
            {
                if (x[i] != y[i]) return false;
            }
            return true;
        }

        public int GetHashCode(int[] obj)
        {
            return obj.Sum(x => x.GetHashCode());
        }
    }
}
