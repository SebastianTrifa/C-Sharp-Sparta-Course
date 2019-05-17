using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace Labs_nunit_sqltestbase
{
    public class Program
    {

        static void Main(string[] args){ }
    }
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public Customer(string CustomerID, string CompanyName, string Address, string City, string Region, 
            string PostalCode, string Country)
        {
            this.CustomerID = CustomerID;
            this.CompanyName = CompanyName;
            this.Address = Address;
            this.City = City;
            this.Region = Region;
            this.PostalCode = PostalCode;
            this.Country = Country;
        }
        static public List<Customer> Query(string query)
        {
        List<Customer> customers = new List<Customer>();
        using (var connection = new SqlConnection(@"Data Source=localhost;
                    Initial Catalog=Northwind;Persist Security Info=True;User ID=SA;Password=Passw0rd2018"))
            {
                //string Script = File.ReadAllText("C:\\c-\\sql.sql");
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    //store result of user query in customers
                    SqlDataReader sqlreader = command.ExecuteReader();
                    while (sqlreader.Read())
                    {
                        string CustomerID = sqlreader["CustomerID"].ToString();
                        string CompanyName = sqlreader["CompanyName"].ToString();
                        string City = sqlreader["City"].ToString();
                        string Address = sqlreader["Address"].ToString();
                        string Region = sqlreader["Region"].ToString();
                        string PostalCode = sqlreader["PostalCode"].ToString();
                        string Country = sqlreader["Country"].ToString();
                        var customer = new Customer(CustomerID, CompanyName, Address, City, Region, PostalCode, Country);
                        customers.Add(customer);
                    }
                }
                /*string Baseline = "SELECT CustomerId, CompanyName, Address, City, Region, PostalCode, Country " +
                    "FROM Customers WHERE City IN('London', 'Paris'); ";
                using (var command = new SqlCommand(Baseline, connection))
                {
                    //store result of correct query in expected
                }*/
            }
            return customers;
        }
    }
}
