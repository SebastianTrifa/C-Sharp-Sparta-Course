using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Labs_93_Entity_XML;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Labs_93_Entity_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            using (var db = new Northwind())
            {
                products = db.Products.ToList();
                products.ForEach(c => Console.WriteLine(c.ProductName));
                Product product = products.FirstOrDefault();
                Console.WriteLine(product.ProductName);
                Product product2 = products.Last();
                Console.WriteLine(product2.ProductName);
                var xmlProduct = new XElement("Product",
                    new XElement("Name", product.ProductName),
                    new XElement("Price", product.UnitPrice));
                Console.WriteLine(xmlProduct);

                xmlProduct.Save("xmlOneProduct");
                var xmlProductSave = new XDocument(XElement.Parse(xmlProduct.ToString()));
                xmlProductSave.Save("xmlOneProduct2");

                var xmlProducts = new XElement("Products",
                    from p in products
                    select new XElement("Product",
                    new XElement("ID", p.ProductID),
                    new XElement("Name", p.ProductName),
                    new XElement("Price", p.UnitPrice)
                    //new XElement("Price", p.Category.CategoryName)
                    ));
                Console.WriteLine(xmlProducts);
                products = db.Products.ToList();
                var xmlProductsOutput = new XElement(
                    "Products",
                    from product3 in products
                    select new XElement("Product",
                        new XElement("ProductID", product3.ProductID),
                        new XElement("ProductName", product3.ProductName),
                        new XElement("CategoryID", product3.CategoryID)));
                xmlProductsOutput.Save("xmlProductsOutput.xml");

                var productsDeserialized = new Products();
                using (var reader = new StreamReader("xmlProductsOutput.xml"))
                {
                    var serializer = new XmlSerializer(typeof(Products));
                    productsDeserialized = (Products)serializer.Deserialize(reader);
                }

                productsDeserialized.ProductList.ForEach(p => { Console.WriteLine($"{p.ProductID,-10}{p.ProductName,-25},{p.CategoryID}"); });
            }
        }
    }

    [XmlRoot("Products")]
    public class Products
    {
        [XmlElement("Product")]
        public List<Product> ProductList { get; set; }
    }
}
