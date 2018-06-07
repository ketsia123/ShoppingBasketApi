using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class Customer
    {
        public Customer()
        {
            List<Customer> li = new List<Customer>();

        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public ICollection<Basket> Basket { get; set; }
        public object ProductId { get; internal set; }
      
     
    }

    internal class Set<T>
    {
        public static implicit operator Set<T>(HashSet<T> v)
        {
            throw new NotImplementedException();
        }

       
    }
}

