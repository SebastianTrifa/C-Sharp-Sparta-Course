using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_Entity
{
    class Program
    {
        public static Customer customertoUpdate;
        public static Customer findone;
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                findone = (from cust in db.Customers where cust.CustomerID == "PHLAF" select cust).FirstOrDefault();
                var customers = db.Customers.ToList();

                foreach(var customer in customers)
                {
                    Console.WriteLine(customer.CustomerID);
                }
                customertoUpdate = db.Customers.Where(cust=>cust.CustomerID=="PHLAF").FirstOrDefault();
            }
        }
    }
}
