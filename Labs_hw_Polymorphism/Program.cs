using System;

namespace Labs_hw_Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child();
            Console.WriteLine(child.OutputText());
        }
    }

    public class Parent{
        virtual public string OutputText()
        {
            return "I am Parent";
        }
    }

    public class Child : Parent
    {
        public override string OutputText()
        {
            return "I am Child";
        }
    }
}
