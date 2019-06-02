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

namespace Homework_105_ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Customer> customers = new List<Customer>();
        static List<Product> products = new List<Product>();
        static List<Supplier> suppliers = new List<Supplier>();
        static List<Employee> employees = new List<Employee>();
        static List<Order_Detail> order_details = new List<Order_Detail>();
        static List<Order> orders = new List<Order>();
        static Customer customer;
        static Product product;
        static Supplier supplier;
        static Employee employee;
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            ContactName.IsReadOnly = true;
            Company.IsReadOnly = true;
            City.IsReadOnly = true;
        }

        private void ListCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox01.ItemsSource = null;
            ListBox02.ItemsSource = null;
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                ListBox01.DisplayMemberPath = "CompanyName";
                ListBox01.ItemsSource = customers;
            }
        }

        private void ListEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox01.ItemsSource = null;
            using (var db = new NorthwindEntities())
            {
                employees = db.Employees.ToList();
                ListBox01.DisplayMemberPath = "LastName";
                ListBox01.ItemsSource = employees;
            }
        }

        private void ListProductsButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox01.ItemsSource = null;
            using (var db = new NorthwindEntities())
            {
                products = db.Products.ToList();
                ListBox01.DisplayMemberPath = "ProductName";
                ListBox01.ItemsSource = products;
            }
        }

        private void ListSuppliersButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox01.ItemsSource = null;
            using (var db = new NorthwindEntities())
            {
                suppliers = db.Suppliers.ToList();
                ListBox01.DisplayMemberPath = "CompanyName";
                ListBox01.ItemsSource = suppliers;
            }
        }

        private void ListBox01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox04.Items.Clear();
            using (var db = new NorthwindEntities())
            {
                ListBox02.ItemsSource = null;
                ListBox03.ItemsSource = null;
                if (ListBox01.SelectedItem != null)
                {
                    customer = (Customer)ListBox01.SelectedItem;
                    ContactName.Text = customer.ContactName;
                    Company.Text = customer.CompanyName;
                    City.Text = customer.City;
                    ID.Text = customer.CustomerID;
                    orders = db.Orders.Where(o => o.CustomerID == customer.CustomerID).ToList();
                    ListBox02.DisplayMemberPath = "OrderID";
                    ListBox02.ItemsSource = orders;
                }
            }
        }

        private void ListBox03_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox03.SelectedItem != null)
            {
                MessageBox.Show("message");
                ListBox04.ItemsSource = null;
                using (var db = new NorthwindEntities())
                {
                    Product product = (Product)ListBox03.SelectedItem;
                    ListBox04.Items.Add(product.ProductID);
                    ListBox04.Items.Add(product.ProductName);
                    ListBox04.Items.Add(product.CategoryID);
                    ListBox04.Items.Add(product.UnitPrice);
                }
            }
        }

        private void ListBox02_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox04.Items.Clear();
            if (ListBox02.SelectedItem != null)
            {
                using (var db = new NorthwindEntities())
                {
                    Order order = (Order)ListBox02.SelectedItem;
                    order_details = db.Order_Details.Where(o => o.OrderID == order.OrderID).ToList();
                    List<Product> product_order = new List<Product>();
                    foreach (Order_Detail o in order_details)
                    {
                        product_order.Add(db.Products.Where(p => p.ProductID == o.ProductID).ToList().First());
                    }
                    ListBox03.DisplayMemberPath = "ProductName";
                    ListBox03.ItemsSource = product_order;
                }
            }
        }

        private void ListBox04_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Add.Content.ToString() == "Add")
            {
                ContactName.IsReadOnly = false;
                Company.IsReadOnly = false;
                City.IsReadOnly = false;
                Add.Content = "Save Changes";
                Delete.IsEnabled = false;
                Edit.IsEnabled = false;
            }
            else
            {
                using (var db = new NorthwindEntities())
                {
                    Add.Content = "Add";
                    Delete.IsEnabled = true;
                    Edit.IsEnabled = true;
                    Customer added = new Customer();
                    added.CustomerID = ID.Text;
                    added.ContactName = ContactName.Text;
                    added.CompanyName = Company.Text;
                    added.City = City.Text;
                    db.Customers.Add(added);
                    db.SaveChanges();
                    ListBox01.ItemsSource = null;
                    ListBox02.ItemsSource = null;
                    ListBox03.ItemsSource = null;
                    ListBox04.ItemsSource = null;
                    customers = db.Customers.ToList();
                    ListBox01.ItemsSource = customers;
                    ContactName.IsReadOnly = true;
                    Company.IsReadOnly = true;
                    City.IsReadOnly = true;
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Edit.Content.ToString() == "Edit")
            {
                ContactName.IsReadOnly = false;
                Company.IsReadOnly = false;
                City.IsReadOnly = false;
                Edit.Content = "Save Changes";
                Delete.IsEnabled = false;
                Add.IsEnabled = false;
            }
            else
            {
                using (var db = new NorthwindEntities())
                {
                    Edit.Content = "Edit";
                    Delete.IsEnabled = true;
                    Add.IsEnabled = true;
                    if (ListBox01.SelectedItem != null)
                    {
                        customer = (Customer)ListBox01.SelectedItem;
                        Customer CustomerToEdit = db.Customers.Where(o => o.CustomerID == customer.CustomerID).First();
                        CustomerToEdit.ContactName = ContactName.Text;
                        CustomerToEdit.CompanyName = Company.Text;
                        CustomerToEdit.City = City.Text;
                        CustomerToEdit.CustomerID = ID.Text;
                        db.SaveChanges();
                    }
                    ListBox04.ItemsSource = null;
                    ListBox01.ItemsSource = null;
                    ListBox02.ItemsSource = null;
                    ListBox03.ItemsSource = null;
                    customers = db.Customers.ToList();
                    ListBox01.ItemsSource = customers;
                    ContactName.IsReadOnly = true;
                    Company.IsReadOnly = true;
                    City.IsReadOnly = true;
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Delete.Content.ToString() == "Delete")
            {
                ContactName.IsReadOnly = false;
                Company.IsReadOnly = false;
                City.IsReadOnly = false;
                Delete.Content = "Save Changes";
                Edit.IsEnabled = false;
                Add.IsEnabled = false;
            }
            else
            {
                using (var db = new NorthwindEntities())
                {
                    Delete.Content = "Delete";
                    Edit.IsEnabled = true;
                    Add.IsEnabled = true;
                    if (ListBox01.SelectedItem != null)
                    {
                        customer = (Customer)ListBox01.SelectedItem;
                        Customer CustomerToDelete = db.Customers.Where(o => o.CustomerID == customer.CustomerID).First();
                        db.Customers.Remove(CustomerToDelete);
                        db.SaveChanges();
                    }
                    ListBox01.ItemsSource = null;
                    ListBox02.ItemsSource = null;
                    ListBox03.ItemsSource = null;
                    ListBox04.ItemsSource = null;
                    customers = db.Customers.ToList();
                    ListBox01.ItemsSource = customers;
                    ContactName.IsReadOnly = true;
                    Company.IsReadOnly = true;
                    City.IsReadOnly = true;
                }
            }
        }
    }
}

