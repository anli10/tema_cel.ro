using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstOne.Pages
{
    class ResultsPage
    {

        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = ".breadCrumb>span>span>a>b")]
        private IList<IWebElement> path{ get; set; }

        [FindsBy(How=How.CssSelector,Using = ".productListing-data-b.product_link.product_name>span")]
        private IList<IWebElement> description { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".productListingWrapper")]
        private IList<IWebElement> product { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='bodycode']/div[3]/div[1]/div[1]/div[4]/div[1]/form/button")]
        private IWebElement addCart { get; set; }

        [FindsBy(How = How.Id, Using = "btngocart")]
        private IWebElement cart { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"mesaj_casuta\"]/div/div[1]/div/a")]
        private IWebElement popUp { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='produse_cos']/table/tbody/tr[2]/td[3]/input[1]")]
        private IWebElement amount { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='produse_cos']/table/tbody/tr[2]/td[4]/strong")]
        private IWebElement unitPrice { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id=' .//*[@id='body_cos_produse']/tr[2]/td[2]/table/tbody/tr[4]/td[2]/b")]
        private IWebElement totalPrice { get; set; }
    
        private string ReturnPath()
        {
            string pathString=null;
            for(int i = 0; i < path.Count; i++)
            {
                pathString = pathString + path[i].Text;
                if(i!=path.Count-1)
                    pathString=pathString+"::";
            }
            return pathString;
        }
        private void ClickProduct()
        {
            for(int i = 0; i < description.Count; i++)
            {
                
                 if(description[i].Text.Contains("Kaspersky Anti-Virus 2017 1PC 1An+3luni gratuite"))
                    product[i].Click();
            }
        }
        public void Second()
        {
            StringAssert.Contains(driver.Title, "Antivirus");
            Assert.AreEqual("CEL.ro::Software::Antivirus",ReturnPath());
            ClickProduct();
            StringAssert.Contains(driver.Title, "Kaspersky Anti-Virus 2017 1PC 1An+3luni gratuite");
            popUp.Click();
            Thread.Sleep(3000);
            addCart.Click();
            Thread.Sleep(3000);

            cart.Click();
            StringAssert.Contains(driver.Title, "Continut cos");
            amount.Clear();
            amount.SendKeys("3");
            Thread.Sleep(3000);
            Assert.AreEqual(300, int.Parse(unitPrice.Text)*3);

        }
        public ResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ResultsPage()
        {
        }
    }
}
