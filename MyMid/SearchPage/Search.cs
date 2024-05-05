using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.MyMid.SearchPage
{
    internal class Search : Login
    {
        [Test]
        public void SearchMidDiamondsTest()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange")));
            searchBtn.Click();

            IWebElement notificationMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".result-number")));
            string actualText = notificationMessage.Text;
            string expectedText = "8549";
            string[] parts = actualText.Split('\r');
            string numberStr = parts[0];
            if (numberStr != expectedText)
            {
                Assert.Fail($"Text assertion failed! Expected: '{expectedText}', Actual: '{numberStr}'");
            }
            else
            {
                Console.WriteLine($"Mid Diamonds Search Test:\nThe test passed successfully! Expected: '{expectedText}', Actual: '{numberStr}'");
            }
        }
        [Test]
        public void SearchEcoDiamondsTest()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement ecoDiamBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-search-mode-lab")));
            ecoDiamBtn.Click();
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange")));
            searchBtn.Click();

            IWebElement notificationMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".result-number")));
            string actualText = notificationMessage.Text;
            string expectedText = "613";
            string[] parts = actualText.Split('\r');
            string numberStr = parts[0];
            if (numberStr != expectedText)
            {
                Assert.Fail($"Text assertion failed! Expected: '{expectedText}', Actual: '{numberStr}'");
            }
            else
            {
                Console.WriteLine($"Eco Diamonds Search Test:\nThe test passed successfully! Expected: '{expectedText}', Actual: '{numberStr}'");
            }
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
