using System;

namespace Labs_oop
{
    public class animal_count
    {
        string count;
        public animal_count(string count)
        {
            int n = 5;
            string animal = "lion(s)";
            this.count = $"{n} {animal}";
        }
        public string return_count()
        {
            return count;
        }
    }
    //define abstract class
    public abstract class Genus
    {
        public abstract void choose(int n);
    }
    //define override subclass
    public class Choice: Genus
    {
        int n;
        public Choice(int n)
        {
            this.n = n;
        }
        public override void choose(int n)
        {
            var a= new string[] {"mammal","reptile","bird","fish"};
            Console.WriteLine($"{a[n]}");
        }
    }
    public class Number: Choice
    {
        private static int n;
        public Number(): base (n)
        {
        }
        public override void choose(int n)
        {
            Console.WriteLine($" {n}");
        }
    }   
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2;
            var animal1 = new animal_count("tiger");
            var animal2 = new Choice(n);
            var animal3 = new Number();
            Console.WriteLine(animal1.return_count());
            animal2.choose(n);
            animal3.choose(n);
        }
    }
}
