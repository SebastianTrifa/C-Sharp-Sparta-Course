using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_Entity2
{
    class Program
    {
        static List<Customer> customerList;
        static Customer customer;
        static Customer newCustomer;
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                newCustomer = new Customer()
                {
                    CustomerID = "PHLAF",
                    ContactName = "Bob",
                    CompanyName = "SpartaGlobal",
                    City = "London"
                };
                db.Customers.Add(newCustomer);
            }
            using (var db = new NorthwindEntities())
            {
                customerList = (from c in db.Customers
                                select c).ToList<Customer>();
                foreach (Customer c in db.Customers)
                {
                    customer = db.Customers.Where(cust => cust.CustomerID == "PHLAF").FirstOrDefault();
                    Console.WriteLine($"ID : {c.CustomerID}, Name : {c.ContactName}, City : {c.City}");
                }
            }
            using (var db = new NorthwindEntities())
            {
                customer = db.Customers.Where(cust => cust.CustomerID == "PHLAF").FirstOrDefault();
                if(customer!=null)
                {
                    Console.WriteLine($"{customer.CustomerID}");
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }
    }
}
