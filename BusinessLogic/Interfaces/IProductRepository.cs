using Domains.Enums;
using Domains.Models;

namespace BusinessLogic.Interfaces
{
    public interface IProductRepository
    {
        Product GetProduct(string name, decimal price, int quantity, GoodsType goodsType, bool isImported);
    }
}
