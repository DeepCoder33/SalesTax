using System;
using BusinessLogic.Interfaces;
using Domains.Enums;
using Domains.Models;

namespace BusinessLogic.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProduct(string name, decimal price, int quantity, GoodsType goodsType, bool isImported)
        {
            switch (goodsType)
            {
                case GoodsType.Book:
                    return new Book(name, isImported, price, quantity);

                case GoodsType.Food:
                    return new Food(name, isImported, price, quantity);

                case GoodsType.Medical:
                    return new Medical(name, isImported, price, quantity);

                case GoodsType.Other:
                    return new Others(name, isImported, price, quantity);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}