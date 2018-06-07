using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBasketManager
{
    class ConsumeBasketAsync
    {
        public void AddItemToBasket(int basketId)
        {
            using (var client = new WebClient())
            {
                Basket basket = new Basket();
                basket.BasketId = 2;
                basket.CustomerId = 1;
                basket.ProductId = 12;
                basket.ProductName = "iPhone 8 Plus";
                basket.Status = "Pending";
                basket.ProductQty = 1;
                basket.Date = DateTime.UtcNow.AddDays(-5);
                client.Headers.Add("Content_Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.UploadString("https://localhost:44340/api/baskets/" + basketId, "PUT", JsonConvert.SerializeObject(basket));
                Console.WriteLine(result);

            }
        }
    }
}
