using System;

namespace Labs_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.in another method

            void DoSomething()
            {
                Console.WriteLine("hey i am doign csomtithinwrbgiuo");
            }

            DoSomething();

            DoSomethingElse();

            var d = new Dog();
            d.Bark();
            Console.WriteLine(Dog.NumLegs);
        }

        //2. in the same class using static keyword which attached method to the class
        static void DoSomethingElse()
        {
                Console.WriteLine("doign somthing else");
        }
    }
    //3. in another class either as static or instance method
    class Dog
    {
        //instance method 
        //static method
        public void Bark()
        {
            Console.WriteLine("dog is now barking lowdly");
        }

        //static field
        public static int NumLegs = 4;
    }
}
