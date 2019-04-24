using System;

namespace Labs_classprop
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Parent();
            p.SetHidden("hello private data");
            p.Age = 23;
            p.Heigth = 1500;
            Console.WriteLine(p.Heigth);
        }
    }
    class Parent
    {
        private string _hidden;
        private double heigth;
        public int Age { get; set; }
        //expanded form
        public double Heigth
        {
            get
            {
                return heigth;
            }
            set
            {
                if(value > 0)
                    heigth = value;
            }
        }
        public void SetHidden(string SetData) //private field
        {
            _hidden = SetData;
        }
        public string GetHidden()
        {
            return _hidden;
        }
    }
}
