using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBasketManager
{
    class ConsumeBasketSync
    {
        public void GetAllBaskets()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content_Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("https://localhost:44340/api/baskets");
                Console.WriteLine(Environment.NewLine + result);
            }
        }

        public void GetCustBasket(int customerId)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content_Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("https://localhost:44340/api/baskets/" + customerId);
                Console.WriteLine(Environment.NewLine + result);
            }
        }

        public void ClearBasketsForCust(int customerId)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content_Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.UploadString("https://localhost:44340/api/baskets" + customerId, "Delete", "");
                Console.WriteLine(Environment.NewLine + result);
            }
        }


    }
}
