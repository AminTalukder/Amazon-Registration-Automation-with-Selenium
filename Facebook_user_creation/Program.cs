using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Facebook_User_Creation
{
    internal class Program
    {
        IWebDriver driver = new ChromeDriver();
        static void Main(string[] args)
        {
        }
        [SetUp]
        public void initialize()
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/");
        }
        [Test]
        public void ExecuteTest()
        {
            driver.Manage().Window.Maximize();

            IWebElement createuser = driver.FindElement(By.Id("u_0_0_qa"));
            createuser.Click();
            IWebElement firstName = driver.FindElement(By.Id("u_0_8_Go"));
            firstName.SendKeys("John");
            IWebElement lastName = driver.FindElement(By.Id("u_0_a_fG"));
            lastName.SendKeys("Snow");
            IWebElement Day = driver.FindElement(By.Id("day"));
            var selectElementDay = new SelectElement(Day);
            selectElementDay.SelectByValue("12");

            IWebElement Month = driver.FindElement(By.Id("month"));
            var selectElementMonth = new SelectElement(Month);
            selectElementMonth.SelectByValue("10");

            IWebElement year = driver.FindElement(By.Id("year"));
            var selectElementYear = new SelectElement(year);
            selectElementYear.SelectByValue("2005");

            IWebElement genderSelect = driver.FindElement(By.XPath("//input[@id='sex' and @value='2']"));
            genderSelect.Click();

            IWebElement eMail = driver.FindElement(By.Id("u_0_h_PT"));
            eMail.SendKeys("JohnSnowmsmjsamfiqfweiw@gmail.com");
            IWebElement Password = driver.FindElement(By.Id("password_step_input"));
            Password.SendKeys("NewFacsfscebookAccfsgedge123");

            IWebElement signup = driver.FindElement(By.Id("u_0_n_NJ"));
            signup.Click();

            IWebElement errorMessage=driver.FindElement(By.XPath("//*[@id=\"scrollview\"]/div/div/div[2]/div/div/div[1]/div/div/div[1]/div/div/div/div/div/div/div/div[2]/div/div/div[2]/div/div/div/div/div[1]/div/span/span"));
            Assert.That(errorMessage.Text.Contains("Make sure this is you"));

        }

        [TearDown]
        public void TestClose()
        {
            driver.Quit();
        }


    }
}
