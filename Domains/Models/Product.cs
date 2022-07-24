using System;

namespace Domains.Models
{
    public abstract class Product
    {
        public string Name { get; set; }

        public bool IsImported { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int Type { get; }

        protected Product(string name, bool isImported, decimal price, int quantity)
        {
            Name = name;
            IsImported = isImported;
            Price = price;
            Quantity = quantity;
        }

        public virtual decimal CalculateTax()
        {
            decimal tax = 0;

            if (IsImported == true)
            {
                tax = Convert.ToDecimal(Convert.ToDouble(Price * Quantity) * 0.05);
            }

            return Math.Round(tax, 2);
        }
    }
}
