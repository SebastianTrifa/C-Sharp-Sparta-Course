using NUnit.Framework;
using Labs_hw_01;
using Labs_hw_Polymorphism;
using Labs_hw_Stopwatch;
using Labs_hw_Classes;

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

        [TestCase(10, 5)]
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
    }
}