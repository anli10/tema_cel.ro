using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using FirstOne.Pages;
namespace FirstOne
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
           
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.cel.ro/");

            Home_Page page1 = new Home_Page(driver);
            page1.FirstSteps();

            ResultsPage page2 = new ResultsPage(driver);
            page2.Second();


        }
    }
}
