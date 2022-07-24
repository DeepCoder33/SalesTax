using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using BusinessLogic.Repositories;
using Domains.Enums;
using Domains.Models;

namespace SalesTaxApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            IProductRepository productRepository = new ProductRepository();
            var cartItems = new List<Product>();
            var count = 0;

            while (true)
            {
                Console.WriteLine("----------------- Shopping Cart -------------");
                Console.WriteLine("Add Items to Cart");
                Console.WriteLine("");
                Console.WriteLine($"Item {++count}");
                Console.WriteLine("");

                Console.WriteLine("Name : ");
                var name = Console.ReadLine();

                Console.WriteLine("Price : ");
                if (!decimal.TryParse(Console.ReadLine(), out var price)) throw new Exception("Invalid price");

                Console.WriteLine("Quantity : ");
                if (!int.TryParse(Console.ReadLine(), out var quantity)) throw new Exception("Invalid quantity");

                Console.WriteLine("Is imported : (Y/N) [any other key except y/Y is considered as N]");
                var isImported = Console.ReadLine()?.ToLower() == "y" ? true : false;

                Console.WriteLine("Type of Item (select one of below)\n1. Book\n2. Food\n3. Medical\n4. Other");

                if (!Enum.TryParse(Console.ReadLine(), out GoodsType goodsType)) throw new Exception("Invalid type");

                Console.WriteLine("Do you want to add more items? (Y/N) [any other key except y/Y is considered as N]");
                var input = Console.ReadLine()?.ToLower();

                var product = productRepository.GetProduct(name, Convert.ToDecimal(price), Convert.ToInt32(quantity),
                    goodsType, isImported);
                cartItems.Add(product);

                if (input == "y")
                    continue;
                break;
            }

            Console.WriteLine("\n");
            Console.WriteLine("Your Billing details are below");
            Console.WriteLine("------- Date : " + DateTime.Now.ToString("dd/MM/yyyy") + " -------");
            Console.WriteLine("");
            Console.WriteLine("Item Name (Quantity)    Price   Is Imported    Tax");
            Console.WriteLine("");

            foreach (var item in cartItems)
                Console.WriteLine(item.Name + " (" + item.Quantity + ")" + "                    "
                                  + item.Price + "    "
                                  + item.IsImported + "   "
                                  + item.CalculateTax());

            Console.WriteLine("\n");

            Console.WriteLine($"----------------- Total Items : {cartItems.Count()} -----------------\n");
           
            Console.WriteLine(
                "Sales Tax : " + cartItems.Sum(item => item.CalculateTax()));
            Console.WriteLine("Total Price : " + cartItems.Sum(item => item.Price));
            Console.ReadLine();
        }
    }
}