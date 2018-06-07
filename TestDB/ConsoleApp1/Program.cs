using ClientLibrary;
using ClientLibrary.Models;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var shopService = new ClientService();

            Basket myBasket = shopService.GetBasket(1).Result;

           Console.WriteLine($"{myBasket.BasketId} {myBasket.Status} {myBasket.CreatedDate}");

            //Product myProduct = shopService.GetProduct(1).Result;

            //Console.WriteLine($"{myProduct.ProductId} {myProduct.Name} {myProduct.Description} {myProduct.Price}");

            Console.ReadKey();
           
        }
    }
}
