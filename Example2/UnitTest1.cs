using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using NUnit.Framework;
using NSelene;
using static NSelene.Selene;

namespace Example2
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArguments("--lang=ru-ru");
            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, new TimeSpan(0, 4, 0));
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://www.google.ru/";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("[name = 'q']")));
            driver.FindElement(By.CssSelector("[name = 'q']")).SendKeys("Selenium");
            //driver.FindElement(By.CssSelector("[class = 'FPdoLc lJ9FBc'] [name = 'btnK']")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[5]/center/input[1]")));
            driver.FindElement(By.XPath("//div[5]/center/input[1]")).Click();
            Thread.Sleep(3000);
        }

        [Test]
        public void Test2()
        {
            driver.Url = "https://www.google.ru/";
            S("[name = 'q']", driver).Should(Be.Visible).SetValue("Selenium");
            S("//div[5]/center/input[1]", driver).Should(Be.Visible).Click();
            Thread.Sleep(3000);
            
        }

        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
