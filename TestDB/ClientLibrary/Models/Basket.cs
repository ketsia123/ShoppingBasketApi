using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ClientLibrary.Models
{
    public class Basket
    {
        public int BasketId { get; set; }

        public int CustomerId { get; set; }

        public List<Product> Products { get; set; }

        public BasketStatus Status { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
