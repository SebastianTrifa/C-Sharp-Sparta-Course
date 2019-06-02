using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_LINQ_Join
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                var CustOrders = from cust in db.Customers
                                 join order in db.Orders
                                 on cust.CustomerID equals order.CustomerID
                                 orderby order.OrderDate descending
                                 select new
                                 {
                                     ID = cust.CustomerID,
                                     Name = cust.ContactName,
                                     order.OrderID,
                                     order.OrderDate
                                 };
                foreach (var c in CustOrders)
                    Console.WriteLine();

                var categ = from category in db.Categories
                            select category.CategoryID;
                var prod = from producto in db.Products
                           select new
                           {
                               Id = producto.CategoryID,
                               Name = producto.ProductName
                           };
                foreach (var c in categ)
                {
                    Console.WriteLine();
                    foreach(var p in prod)
                    {
                        if(p.Id==c)
                            Console.WriteLine(p.Name);
                    }
                }
            }
        }
    }
}
