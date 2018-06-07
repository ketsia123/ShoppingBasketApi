using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class Basket
    {
        public int BasketId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
        public int? ProductQty { get; set; }
        public string ProductName { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }

        public List<Product> Products { get; set; }
    }
}
