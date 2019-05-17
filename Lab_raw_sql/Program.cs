using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Lab_raw_sql
{ 
    class Program
    {
        static List<Customer> customers = new List<Customer>();

        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(@"Data Source=localhost;
                    Initial Catalog=Northwind;Persist Security Info=True;User ID=SA;Password=Passw0rd2018"))
            {
                connection.Open();
                Console.WriteLine(connection.State);
                string SQLSelect = "Select * from Customers";
                using (var command = new SqlCommand(SQLSelect, connection))
                {
                    SqlDataReader sqlreader = command.ExecuteReader();
                    while(sqlreader.Read())
                    {
                        string CustomerID = sqlreader["CustomerID"].ToString();
                        string CompanyName = sqlreader["CompanyName"].ToString();
                        string ContactName = sqlreader["ContactName"].ToString();
                        var customer = new Customer(CustomerID, CompanyName, ContactName);
                        customers.Add(customer);
                    }
                    foreach(Customer c in customers)
                    {
                        Console.WriteLine($"{c.CustomerID},{c.CompanyName},{c.ContactName}");
                    }
                }
                Customer newcustomer = new Customer("SDFBD", "ACME Co", "James Frasier");
                string SQLInsert = $"Insert into customers (CustomerID, CompanyName, ContactName) VALUES (\"{newcustomer.CustomerID}\",\"{newcustomer.CompanyName}\",\"{newcustomer.ContactName}\")";
                using (var command = new SqlCommand(SQLInsert, connection))
                {
                    command.ExecuteNonQuery();
                }
                string SQLDelete = $"Delete from Customers where CustomerID={newcustomer.CustomerID}";
                using (var command = new SqlCommand(SQLDelete, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    internal class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public Customer(string CustomerID, string CompanyName, string ContactName)
        {
            this.CustomerID = CustomerID;
            this.CompanyName = CompanyName;
            this.ContactName = ContactName;
        }
    }
}
