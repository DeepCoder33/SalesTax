using System;

namespace Domains.Models
{
    public class Others : Product
    {
        public Others(string name, bool isImported, decimal price, int quantity)
            : base(name, isImported, price, quantity)
        {
        }

        public override decimal CalculateTax()
        {
            decimal importedTax = 0;

            if (IsImported == true)
            {
                importedTax = Convert.ToDecimal(Convert.ToDouble(Price * Quantity) * 0.05);
            }

            var salesTax = Convert.ToDecimal(Convert.ToDouble(Price * Quantity) * 0.1);

            return Math.Round(importedTax + salesTax, 2);
        }
    }
}
