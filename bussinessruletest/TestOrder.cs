using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using BussinessRule;
using System.Collections.Generic;

namespace BussinessRuleTest
{
    [TestClass]
    public class TestOrder
    {
        [TestClass]
        public class OrderTests
        {
            string file = Path.Combine(Environment.CurrentDirectory, "Logs.txt");
            public OrderTests()
            {
                File.WriteAllText(file, "");
            }

            [TestMethod]
            public void Test_Physical()
            {
                OrderItem orderItem = new OrderItem();
                orderItem.product = new Product { ID = 1, Name = "Physical Item", Price = 10 };
                orderItem.Qty = 1;

                Order order = new Order(new List<OrderItem> { orderItem });

                order.Process();

                string[] lines = File.ReadAllLines(file);

                Assert.AreEqual(lines.Length, 2);


            }

            [TestMethod]
            public void Test_Book()
            {
                OrderItem orderItem = new OrderItem();
                orderItem.product = new Book { ID = 1, Name = "Book", Price = 10 };
                orderItem.Qty = 1;

                Order order = new Order(new List<OrderItem> { orderItem });

                order.Process();

                string[] lines = File.ReadAllLines(file);

                Assert.AreEqual(lines.Length, 2);


            }

            [TestMethod]
            public void Test_Membership_Active()
            {
                OrderItem orderItem = new OrderItem();
                orderItem.product = new Membership(true) { ID = 1, Name = "Active Membership", Price = 10 };
                orderItem.Qty = 1;

                Order order = new Order(new List<OrderItem> { orderItem });

                order.Process();

                string[] lines = File.ReadAllLines(file);

                Assert.AreEqual(lines.Length, 2);


            }

            [TestMethod]
            public void Test_Membership_Upgrade()
            {
                OrderItem orderItem = new OrderItem();
                orderItem.product = new Membership(false) { ID = 1, Name = "Active Membership", Price = 10 };
                orderItem.Qty = 1;

                Order order = new Order(new List<OrderItem> { orderItem });

                order.Process();

                string[] lines = File.ReadAllLines(file);

                Assert.AreEqual(lines.Length, 2);


            }

            [TestMethod]
            public void Test_Video()
            {
                OrderItem orderItem = new OrderItem();
                orderItem.product = new Video { ID = 1, Name = "Other videos", Price = 10 };
                orderItem.Qty = 1;

                Order order = new Order(new List<OrderItem> { orderItem });

                order.Process();

                string[] lines = File.ReadAllLines(file);

                Assert.AreEqual(lines.Length, 1);


            }

            [TestMethod]
            public void Test_Video_LearningToSki()
            {
                OrderItem orderItem = new OrderItem();
                orderItem.product = new Video { ID = 1, Name = "Learning to Ski,", Price = 10 };
                orderItem.Qty = 1;

                Order order = new Order(new List<OrderItem> { orderItem });

                order.Process();

                string[] lines = File.ReadAllLines(file);

                Assert.AreEqual(lines.Length, 1);


            }
        }
    }
}
