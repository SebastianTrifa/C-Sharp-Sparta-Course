using System;

namespace Labs_events
{
    class Program
    {
        delegate void Mydelegate();
        static event Mydelegate myEvent;
        static void Main(string[] args)
        {
            MyMethod01();
            MyMethod02();
            MyMethod03();
            myEvent += MyMethod01;
            myEvent();
        }
        static void MyMethod01()
        {
            Console.WriteLine("write smth01");
        }
        static void MyMethod02()
        {
            Console.WriteLine("write smth02");
        }
        static void MyMethod03()
        {
            Console.WriteLine("write smth03");
        }
    }
}
