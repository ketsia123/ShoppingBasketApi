using System;
using System.Collections.Generic;


namespace TestDB.Models
{
    public partial class Product
    {
        public Product()
        {
            Basket = new HashSet<Basket>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public ICollection<Basket> Basket { get; set; }
       
    }
}

