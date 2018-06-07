using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBasketManager
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
    }
}
