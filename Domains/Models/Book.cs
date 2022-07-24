namespace Domains.Models
{
    public class Book : Product
    {
        public Book(string name, bool isImported, decimal price, int quantity)
            : base(name, isImported, price, quantity)
        {
        }
    }
}
