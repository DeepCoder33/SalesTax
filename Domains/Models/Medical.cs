namespace Domains.Models
{
    public class Medical : Product
    {
        public Medical(string name, bool isImported, decimal price, int quantity)
            : base(name, isImported, price, quantity)
        {
        }
    }
}
