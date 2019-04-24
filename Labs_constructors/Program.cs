using System;

namespace Labs_constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Parent("Fred", 32);
        }

        class Parent
        {
            public string Name { get; set; } //Property
            public int Age; //Field
            //create a constructor : same name as class
            public Parent(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }

        //class Child : Parent { }
    }
}
