using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Framework;

namespace Lab_94_selenium
{
    class Selenium_Tests
    {
        /*static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.bbc.co.uk";
            Thread.Sleep(2000);
            driver.Close();
            driver.Quit();
        }*/
    }

    class Tests
    {
        IWebDriver driver;
        IWebElement element;

        [SetUp]
        public void Initialise()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test_BBC()
        {
            driver.Url = "https://bbc.co.uk";
            Console.WriteLine(driver.PageSource);
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("https://xkcd.com");
        }

        [Test]
        public void Selenium_test_student_portal()
        {
            driver.Url = "http://34.244.111.198";
            element = driver.FindElement(By.Name("email"));
            element.SendKeys("admin@spartaglobal.com");
            element = driver.FindElement(By.Name("password"));
            element.SendKeys("Password1");
            element = driver.FindElement(By.LinkText("Users"));
            element = driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-md.btn-block"));
            element.Click();
        }

        [TearDown]
        public void ClearUp()
        {
            Thread.Sleep(3000);
            driver.Close();
            driver.Quit();
        }
    }
}
