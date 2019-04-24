using System;

namespace Labs_classes_hw
{
    class Program
    {
        static void Main(string[] args)
        {
            var I = new Parent(64);
            var II = new Child(39);
            var III = new Grandchild(16);
            Console.WriteLine(I.Grow(I));
            Console.WriteLine(II.Grow(II));
            Console.WriteLine(III.Grow(III));
        }
    }
    class Parent
    {
        int Age { get; set; }
        public Parent(int age)
        {
            this.Age = age;
        }
        public int Grow(Parent I)
        {
            I.Age++;
            return I.Age;
        }
    }
    class Child : Parent 
    {
        int Age { get; set; }
        public Child(int Age): base (Age)
        {
            this.Age = Age;
        }        
    }
    class Grandchild : Child
    {
        int Age { get; set; }
        public Grandchild(int Age) : base(Age)
        {
            this.Age = Age;
        }
    }
}
