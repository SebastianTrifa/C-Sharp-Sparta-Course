using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Homework_104_WPFNorthwindEntityProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Customer> customers = new List<Customer>();
        static List<Employee> employees = new List<Employee>();
        static List<Product> products = new List<Product>();
        static List<Supplier> suppliers = new List<Supplier>();
        static List<Order> orders = new List<Order>();
        static List<Order_Detail> order_Details = new List<Order_Detail>();
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }
        void Initialize()
        {
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                ListBoxCustomers.DisplayMemberPath = "CompanyName";
                ListBoxCustomers.ItemsSource = customers;
                employees = db.Employees.ToList();
                ListBoxEmployees.DisplayMemberPath = "LastName";
                ListBoxEmployees.ItemsSource = employees;
                products = db.Products.ToList();
                ListBoxProducts.DisplayMemberPath = "ProductName";
                ListBoxProducts.ItemsSource = products;
                suppliers = db.Suppliers.ToList();
                ListBoxSuppliers.DisplayMemberPath = "CompanyName";
                ListBoxSuppliers.ItemsSource = suppliers;
                ListBoxCustomers.Visibility = Visibility.Collapsed;
                ListBoxEmployees.Visibility = Visibility.Collapsed;
                ListBoxProducts.Visibility = Visibility.Collapsed;
                ListBoxSuppliers.Visibility = Visibility.Collapsed;
                foreach (Customer c in customers)
                {

                }
            }
        }

        private void CustomersClick(object sender, RoutedEventArgs e)
        {
            ListBoxEmployees.Visibility = Visibility.Collapsed;
            ListBoxProducts.Visibility = Visibility.Collapsed;
            ListBoxSuppliers.Visibility = Visibility.Collapsed;
            ListBoxCustomers.Visibility = Visibility.Visible;
            ListBoxOrderDetails.Visibility = Visibility.Collapsed;
            ListBoxOrders.Visibility = Visibility.Collapsed;
        }

        private void ProductsClick(object sender, RoutedEventArgs e)
        {
            ListBoxCustomers.Visibility = Visibility.Collapsed;
            ListBoxEmployees.Visibility = Visibility.Collapsed;
            ListBoxSuppliers.Visibility = Visibility.Collapsed;
            ListBoxProducts.Visibility = Visibility.Visible;
            ListBoxOrderDetails.Visibility = Visibility.Collapsed;
            ListBoxOrders.Visibility = Visibility.Collapsed;
        }

        private void EmployeesClick(object sender, RoutedEventArgs e)
        {
            ListBoxCustomers.Visibility = Visibility.Collapsed;
            ListBoxProducts.Visibility = Visibility.Collapsed;
            ListBoxSuppliers.Visibility = Visibility.Collapsed;
            ListBoxOrderDetails.Visibility = Visibility.Collapsed;
            ListBoxOrders.Visibility = Visibility.Collapsed;
            ListBoxEmployees.Visibility = Visibility.Visible;
        }

        private void SuppliersClick(object sender, RoutedEventArgs e)
        {
            ListBoxCustomers.Visibility = Visibility.Collapsed;
            ListBoxEmployees.Visibility = Visibility.Collapsed;
            ListBoxProducts.Visibility = Visibility.Collapsed;
            ListBoxSuppliers.Visibility = Visibility.Visible;
            ListBoxOrderDetails.Visibility = Visibility.Collapsed;
            ListBoxOrders.Visibility = Visibility.Collapsed;
        }

        private void CustomersSelected(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new NorthwindEntities())
            {
                ListBoxCustomers.Visibility = Visibility.Collapsed;
                ListBoxOrders.Visibility = Visibility.Visible;
                Customer customer = (Customer)ListBoxCustomers.SelectedItem;
                orders = db.Orders.Where(o=>o.CustomerID==customer.CustomerID).ToList();
                ListBoxOrders.DisplayMemberPath = "OrderID";
                ListBoxCustomers.Visibility = Visibility.Collapsed;
                ListBoxOrders.ItemsSource = orders;
            }
        }

        private void OrderDetailsSelected(object sender, SelectionChangedEventArgs e)
        { 
            using (var db = new NorthwindEntities())
            {
                ListBoxOrderDetails.Visibility = Visibility.Visible;
                ListBoxOrders.Visibility = Visibility.Collapsed;
                Order order = (Order)ListBoxOrders.SelectedItem;
                order_Details = db.Order_Details.Where(o => o.OrderID == order.OrderID).ToList();
                List<Product> product_order = new List<Product>();
                foreach (Order_Detail o in order_Details)
                {
                    product_order.Add(db.Products.Where(p => p.ProductID == o.ProductID).ToList().First());
                }
                ListBoxOrders.Visibility = Visibility.Collapsed;
                ListBoxOrderDetails.DisplayMemberPath = "ProductName";
                ListBoxOrderDetails.ItemsSource = product_order;
            }
        }
    }
}
