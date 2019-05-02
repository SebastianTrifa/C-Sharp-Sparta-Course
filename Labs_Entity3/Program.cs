using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_Entity3
{
        class Program
        {
            static List<Order> orderList;
            static List<Product> productList;
            static List<Order_Detail> detail;
            static Customer customer;
            static Product product;
            static Order data;
            static Customer newCustomer;
            static void Main(string[] args)
            {
                using (var db = new NorthwindEntities())
                {
                    orderList = (from dat in db.Orders where dat.CustomerID == dat.Customer.CustomerID select dat).ToList();
                    foreach(Order dat in orderList)
                    {
                        Console.WriteLine($"{dat.Customer.ContactName}, {dat.OrderDate}");
                        detail = (from det in db.Order_Details where det.OrderID == dat.OrderID select det).ToList();
                    }
                    foreach (Order_Detail det in detail)
                    {
                        productList = (from prod in db.Products where prod.ProductID == det.ProductID select prod).ToList();
                        productList.ForEach(p => Console.WriteLine(p.ProductName));
                    }
                orderList = (from c in db.Customers
                                 join data in db.Orders on c.CustomerID equals data.CustomerID
                                 select data).ToList<Order>();
                }
                using (var db = new NorthwindEntities())
                {
                    
                }
                using (var db = new NorthwindEntities())
                {
                    
                }
            }
        }
}
