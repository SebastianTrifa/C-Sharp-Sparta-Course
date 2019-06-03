using NUnit.Framework;
using System;
using Labs_hw_01;
using Labs_hw_Polymorphism;
using Labs_hw_Stopwatch;
using Labs_hw_Classes;
using Labs_nunit_sqltestbase;
using Labs_rabbits;
using System.IO;
using Homework_106_Classes;
using Hw_109_linq_aggregate;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, 6)]
        public void Collectionstest(int a, int b, int c, int d, int e, int expected)
        {
            var actual = Collections.Collect(a, b, c, d, e);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, 10, 6, 15)]
        public void Lab_hw_Classes(int initialAge, int initialheight, int finalAge, int finalHeight)
        {
            //arrange'
            var expected = finalAge;
            var instance = new Dog();
            instance.Height = initialheight;
            var actual = instance.Grow(initialAge, out int resultheight);
            Assert.AreEqual(expected, actual);//height
            actual = resultheight;
            expected = finalHeight;
            Assert.AreEqual(expected, actual);//age
        }

        [TestCase(true, "I am Child")]
        [TestCase(false, "I am Parent")]
        public void Lab_hw_polymorphism(bool child, string expected)
        {
            Child kid = new Child();
            Parent parent = new Parent();
            if (child)
                Assert.AreEqual(expected, kid.OutputText());
            else
                Assert.AreEqual(expected, parent.OutputText());
        }

        //[TestCase(10, 5)]
        //[TestCase(10, 10)]
        //[TestCase(10, 20)]
        public void Lab_hw_Stopwatch(int expected, int limit)
        {
            //n=8 3 seconds
            //n=9 12 seconds
            //n=10 36 seconds
            int power = 0, time = 0;
            while (time < limit * 1000)
            {
                power++;
                time = CountNumber.CountNow(power, limit);
            }
            var actual = power;
            Assert.AreEqual(expected, actual);
        }
        [TestCase(10000)]
        public void Labs_rabbits(int population)
        {
            Assert.AreEqual(14, Rabbit.Growth(population));
        }
        [TestCase("C:\\\\c-\\sql.sql", "SELECT CustomerId, CompanyName, Address, City, Region, PostalCode, Country " +
                    "FROM Customers WHERE City IN('London', 'Paris');")]
        public void Labs_sqltesting(string path, string elem)
        {
            string Path = File.ReadAllText(path);
            var actual = Customer.Query(Path);
            var expected = Customer.Query(elem);
            Assert.AreEqual(actual.Count, expected.Count);
            for (int i= 0; i<=actual.Count-1;i++)
            {
                Assert.AreEqual(actual[i], expected[i]);
            }
        }

        [TestCase("hello",3,-1)]
        public void Homework_106(string input, int index, int expected)
        {
            int actual =  ASCII.value(input, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6}, 21)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9}, 45)]
        [TestCase(new int[] { 1, 2, 3, 4}, 10)]
        public void Hw_109_LINQ_Aggregate(int[] array, int expected)
        {
            var actual = LinqAggregate.LinqAggregateSum(array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new string[] {"a", "b", "c" }, new string[] { "b", "c", "d" }, new string[] { "a", "b", "c", "d" })]
        [TestCase(new string[] {"1", "2", "4", "5" }, new string[] { "b", "c", "d" }, new string[] {"1", "2", "4", "5", "b", "c", "d"})]
        [TestCase(new string[] {"1", "2", "three", "4" }, new string[] { "1", "2", "3" }, new string[] { "1", "2", "three", "4", "3"})]
        public void Hw_109_LINQ_Union(string[] array1, string[] array2, string[] array_exp)
        {
            var actual = LinqAggregate.LinqUnion(array1, array2);
            Assert.AreEqual(array_exp, actual);
        }

        [TestCase(new string[] { "a", "b", "c" }, new string[] { "b", "c", "d" }, new string[] { "b", "c" })]
        [TestCase(new string[] { "1", "2", "4", "5" }, new string[] { "b", "c", "d" }, new string[] { })]
        [TestCase(new string[] { "1", "2", "three", "4" }, new string[] { "1", "2", "3" }, new string[] { "1", "2" })]
        public void Hw_109_LINQ_Intersect(string[] array1, string[] array2, string[] array_exp)
        {
            var actual = LinqAggregate.LinqIntersect(array1, array2);
            Assert.AreEqual(array_exp, actual);
        }
    }
}