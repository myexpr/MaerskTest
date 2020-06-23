using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessRule
{
    class Program
    {
        public static void Main(string[] args)
        {
            OrderItem orderItem = new OrderItem();
            orderItem.product = new Product { ID = 1, Name = "Physical Item", Price = 10 };
            orderItem.Qty = 1;

            Order order = new Order(new List<OrderItem> { orderItem });

            order.Process();

            //*******************************
            //orderItem.product = new Book { ID = 1, Name = "Book", Price = 10 };
            //orderItem.Qty = 1;

            //order.Process();

            //**********************************
        }
    }
}
