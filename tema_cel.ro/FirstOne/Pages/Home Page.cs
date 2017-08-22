using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstOne
{

    class Home_Page
    {
        private IWebDriver driver;

        [FindsBy(How=How.Id, Using = "logo_head")]
        private IWebElement logoField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "head title")]
        private IWebElement titleField { get; set; }


        [FindsBy(How = How.CssSelector, Using = ".categ_name")]
        private IList<IWebElement>  softwareField{ get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='MenuLeft']/div[1]/div[8]/div[1]")]
        private IWebElement CategoryField{ get; set; }
        
       
        [FindsBy(How = How.XPath, Using = ".//*[@id='MenuLeft']/div[1]/div[8]/div[2]")]
        private IWebElement boxField { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='MenuLeft']/div[1]/div[8]/div[2]/div/div/div[3]/a/span")]
        private IWebElement antivirusField { get; set; }

        public static void HoverAndClick(IWebDriver driver, IWebElement elementToHover,IWebElement elementToMove, IWebElement elementToClick)
        {
            Actions action = new Actions(driver);
            action.Click(elementToHover).MoveToElement(elementToMove).Click(elementToClick).Build().Perform();
        }
        public void SelectCategory(int x)
        {
            softwareField[x-1].Click();
        }
        
        public void ClickSubcategory()
        {
            for (int i = 0; i <= softwareField.Count; i++)
            {

                if (softwareField[i].Text == "Software")
                {
                    //antivirusField[56].Click();
                    break;
                }
            }
        }

        public string GetTitle()
        {
            return titleField.Text;
        }
        public void FirstSteps()
        {
            
            StringAssert.Contains(driver.Title,"CEL");
            Assert.AreEqual(true, logoField.Displayed);
           // SelectCategory(8);
            //ClickSubcategory();
            //Thread.Sleep(5000);
            //antivirusField.Click();
            // HoverAndClick(driver,CategoryField, boxField,antivirusField);
            CategoryField.Click();
            boxField.Click();
            antivirusField.Click();
        }
        public Home_Page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        
    }
}
