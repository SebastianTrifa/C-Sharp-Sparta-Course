using NUnit.Framework;
using Labs_hw_01;

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
    }
}