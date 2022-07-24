namespace Domains.Models
{
    public class Food : Product
    {
        public Food(string name, bool isImported, decimal price, int quantity)
            : base(name, isImported, price, quantity)
        {
        }
    }
}
