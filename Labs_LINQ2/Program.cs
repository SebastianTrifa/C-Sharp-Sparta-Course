using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Labs_LINQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                var customers = from customer in db.Customers
                                where (customer.City=="Berlin" || customer.City=="London")
                                select customer;
                foreach(var customer in customers)
                {
                    Console.WriteLine($"{customer.CustomerID,-15} {customer.CustomerID,-15} from {customer.City}");
                }
                var onecustomer = db.Customers.Find("ALFKI");
                var allcustomers = from c in db.Customers orderby c.City select c;
                foreach (var customer in allcustomers)
                {
                    Console.WriteLine($"{customer.CustomerID,-15} {customer.CustomerID,-15} from {customer.City}");
                }
                var CustomOutputObject = from c in db.Customers orderby c.Country descending, c.City descending select c;
                foreach (var customer in CustomOutputObject)
                {
                    Console.WriteLine($"{customer.CustomerID,-15} {customer.CustomerID,-15} from {customer.Country}{customer.City}");
                }
                var CustomOutputObject2 = from c in db.Customers orderby c.Country descending, c.City descending
                                          select new {ID=c.CustomerID, Name=c.ContactName, Location= c.City+" in "+ c.Country};
                foreach( var c in CustomOutputObject2)
                {
                    Console.WriteLine($"{c.ID,-10} {c.Name,-25} from {c.Location}");
                }
                var customOutputObject3 = (from c in db.Customers
                                          orderby c.Country, c.City
                                          select new CustomObject()
                                          {
                                              ID = c.CustomerID,
                                              Name = c.ContactName,
                                              Location = c.City + " in " + c.Country
                                          }).ToList();
                customOutputObject3.ForEach(c => Console.WriteLine($"{c.ID,-10} {c.Name,-25} from {c.Location}"));
                var CountCustomersByCity = from customer in db.Customers
                                           group customer by customer.City into cities
                                           orderby cities.Key
                                           select new
                                           {
                                               City = cities.Key,
                                               Count = cities.Count()
                                           };
                foreach(var item in CountCustomersByCity)
                    Console.WriteLine($"{item.City, -20} {item.Count}");
            }
        }
    class CustomObject
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
    }
}
