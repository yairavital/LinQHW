using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQHW
{
    public class Order 
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public Customer customer;
        public Order(string productName, int price, Customer customer1)
            {ProductName = productName;
            Price = price;
            customer = customer1;
            }
    }
}
