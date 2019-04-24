using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using labs_test_01;

namespace lab_test_01_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            var a = new Animal();
            a.Age = 10;
            int expected = 11;
            // act 
            int actual = a.Grow();

            // assert
            Assert.AreEqual(expected, actual);

        }
    }
}
