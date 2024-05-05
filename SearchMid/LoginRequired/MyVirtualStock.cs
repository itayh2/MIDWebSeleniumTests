using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.SearchMid.LoginRequired
{
    internal class MyVirtualStock : SearchMidLogin
    {
        [Test]
        public void SetOffTheNetVirtualStone()
        {
            LoginTest("itay080297@gmail.com", "itayH123!");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".nav-item:nth-child(1) .item-text")));
            searchBtn.Click();
            IWebElement myVirtualStockBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-primary")));
            myVirtualStockBtn.Click();
            Thread.Sleep(500);
            IWebElement setOffTheNetBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-tns-c38-1:nth-child(4) .circle")));
            setOffTheNetBtn.Click();
            IWebElement choosePeriod = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-group:nth-child(1) > .btn-primary")));
            choosePeriod.Click();
            IWebElement okBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".modal-footer > .btn-orange")));
            okBtn.Click();
            Thread.Sleep(2000);
            IWebElement newBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".new-search-btn")));
            newBtn.Click();
            IWebElement arrow = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn > .caret")));
            arrow.Click();
            IWebElement offTheNetOnlyBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dropdown-menu:nth-child(3) a")));
            offTheNetOnlyBtn.Click();
            Thread.Sleep(2000);
            string actualText = driver.FindElement(By.CssSelector(".text-light-grey")).Text.Split(' ')[1];

            string expectedTest = "1";
            Assert.That(actualText, Is.EqualTo(expectedTest), "Set Off The Net Virtual Stone Test - Failed\n");
            Console.WriteLine($"Set Off The Net Virtual Stone Test - Success, Actual: {actualText}, Expected: {expectedTest}\n");
        }

        [Test]
        public void SetOnTheNetVirtualStone()
        {
            LoginTest("itay080297@gmail.com", "itayH123!");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".nav-item:nth-child(1) .item-text")));
            searchBtn.Click();
            IWebElement myVirtualStockBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-primary")));
            myVirtualStockBtn.Click();
            IWebElement setOnTheNetBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-tns-c38-1:nth-child(4) .circle")));
            setOnTheNetBtn.Click();
            Thread.Sleep(1000);
            IWebElement newBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".new-search-btn")));
            newBtn.Click();
            IWebElement arrow = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn > .caret")));
            arrow.Click();
            IWebElement offTheNetOnlyBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dropdown-menu:nth-child(3) a")));
            offTheNetOnlyBtn.Click();
            Thread.Sleep(2000);
            string actualText = driver.FindElement(By.CssSelector(".hidden-xs .saved-search-item")).Text.Split('\n')[0].Split('\r')[0];

            string expectedTest = "Sorry, we do not have any in stock!";
            Assert.That(actualText, Is.EqualTo(expectedTest), "Set On The Net Virtual Stone Test - Failed\n");
            Console.WriteLine($"Set On The Net Virtual Stone Test - Success, Actual: {actualText}, Expected: {expectedTest}");
        }
        [TearDown]

        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
