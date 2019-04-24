using System;

namespace Labs_object
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Animal("int",23,355);
        }
    }
    class Animal
    {
        public string Type { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public Animal(string type, int age, double weight)
        {
            this.Type = type;
            this.Age = age;
            this.Weight = weight;
        }
    }
}
