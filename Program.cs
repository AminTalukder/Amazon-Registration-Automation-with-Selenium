                                       //Amazon Registration Testing
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Automation
{
    internal class Program
    {
        IWebDriver driver = new ChromeDriver();
        static void Main(string[] args)
        {
        }
        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com/");
        }
        [Test]
        public void ExecuteTest()
        {
            driver.Manage().Window.Maximize();
            IWebElement SignIn = driver.FindElement(By.Id("nav-link-accountList"));
            SignIn.Click();
            IWebElement Email = driver.FindElement(By.Id("ap_email"));
            Email.SendKeys("2019360014@ewubd.edu");
            IWebElement Continue = driver.FindElement(By.Id("continue"));
            Continue.Click();
            IWebElement ErrorMessage = driver.FindElement(By.ClassName("a-alert-heading"));
            string ActualText=ErrorMessage.Text;
            string ExpectedText = "There was a problem";

            Assert.That(Equals(ActualText,ExpectedText));
        }
        [TearDown]
        public void QuitTest()
        {
            driver.Quit();
        }
    }
}

