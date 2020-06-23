using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessRule
{
    public class Order
    {
        public List<OrderItem> orderItems { get; set; }

        public decimal TotAmt { get; set; }

        Payment payment = new Payment();

        public Order()
        {
            orderItems = new List<OrderItem>();
        }

        public Order(List<OrderItem> orderItems)
        {

            orderItems = new List<OrderItem>();
            this.orderItems = orderItems;
        }

        public void Process()
        {
            this.TotAmt = orderItems.Sum(x => (x.product.Price * x.Qty) - x.discount);
            Logger.Log("Generate a packing slip for shipping.");
            bool isSuccesfulPayment = payment.Pay(this);

            if (isSuccesfulPayment)
            {
                foreach (var orderItem in orderItems)
                {
                    orderItem.product.ExecuteOrder();
                }
                Logger.Log("Generate a commission payment to the agent.");
            }
        }
    }
}
