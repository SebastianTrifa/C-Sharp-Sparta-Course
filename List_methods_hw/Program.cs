using System;

namespace List_methods_hw
{
    class Program
    {
        static void Main(string[] args)
        {
            var Argos = new Animal(2);
            Console.WriteLine(Argos.Aging(Argos));
            fiveparam(1234, 3563, 234, 2421, 134);
            fiveparam(b: 3563, d: 2421, a: 1234, e: 134, c: 234);
        }
        static void fiveparam(int a, int b, int c, int d, int e)
        {
            Console.WriteLine($"first {a}, then {b}, then {c}, then {d}, and finally {e}");
        }
    }
    class Animal
    {
        public int Age { get; set; }
        public Animal(int age)
        {
            this.Age = age;
        }
        public int Aging(Animal Dog)
        {
            Dog.Age++;
            return Dog.Age;
        }
    }
}
