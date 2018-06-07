using ClientLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary
{
    public class ClientService
    {
        private HttpClient _httpClient;

        public object JsonCovert { get; private set; }

        public ClientService()
        {
            _httpClient = new HttpClient();
        }


        public async Task<Basket> GetBasket(int customerId)
        {
            if (customerId == 0)
                throw new ArgumentException("a customerId must be specified");

            var httpMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:44340/api/baskets/")
            };


            using (var httpResponse = await _httpClient.SendAsync(httpMessage))
            {
                if (!httpResponse.IsSuccessStatusCode)
                    return null;

                var responseString = await httpResponse.Content.ReadAsStringAsync();

                return Newtonsoft.Json.JsonConvert.DeserializeObject<Basket>(responseString);
            }
        }

        /// <summary>
        /// Adds a product to a Basket.
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        public Task AddProduct(Product product)
        {
            var httpMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://localhost:44340/api/baskets/"),
                Content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json")
            };

            return Task.CompletedTask;
        }

        public Task RemoveProduct(int productId)
        {
            var httpMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"https://localhost:44340/api/baskets/")
            };

            return Task.CompletedTask;
        }

        public Task ClearBasket()
        {
            return Task.CompletedTask;
        }

        public async Task<Product> GetProduct(int productId)
        {
            if (productId == 0)
                throw new ArgumentException("a productID must be specified");

            var httpMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:44340/api/products/{productId}")
            };


            using (var httpResponse = await _httpClient.SendAsync(httpMessage))
            {
                if (!httpResponse.IsSuccessStatusCode)
                    return null;

                var responseString = await httpResponse.Content.ReadAsStringAsync();

                return Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(responseString);
            }
        }

    }
}
