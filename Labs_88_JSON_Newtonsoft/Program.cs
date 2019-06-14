using System;
using Newtonsoft.Json;

namespace Labs_88_JSON_Newtonsoft
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new MyClass()
            {
                MyClassID = 1,
                MyClassName = "Bob",
                DateofBirth = new DateTime(2000, 10, 01)
            };
            var jsonObject = JsonConvert.SerializeObject(instance);
            var instance02 = JsonConvert.DeserializeObject<MyClass>(jsonObject);
            Console.WriteLine($"{instance02.MyClassID},{instance02.MyClassName},{instance02.DateofBirth}");
        }
    }
    class MyClass
    {
        public int MyClassID { get; set; }
        public string MyClassName { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}
