using System;
using System.Xml.Linq;

namespace Labs_92_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            var xml = new XElement("test", 100);
            Console.WriteLine(xml);

            var xml2 = new XElement("testElement", new XElement("subElement",200));
            Console.WriteLine(xml2);

            var xml3 = new XElement("testElement", new XElement("subElement", 200),
                new XElement("subElement", 200),
                new XElement("subElement", 200),
                new XElement("subElement", 200),
                new XElement("subElement", 200),
                new XElement("subElement", 200),
                new XElement("subElement", 200)
                );
            Console.WriteLine(xml3);

            var xml4 = new XElement("testElement", 
                new XElement("subElement", new XAttribute("width", 200), new XElement("another element", 100)),
                new XElement("subElement", new XAttribute("width", 200), 300),
                new XElement("subElement", new XAttribute("width", 200), 300),
                new XElement("subElement", new XAttribute("width", 200), 300)
                );
            Console.WriteLine(xml4);
        }
    }
}
