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
    internal class Search : SearchMidLogin
    {
        private IWebElement findDiamondsBtn => driver.FindElement(By.CssSelector(".find-btn"));

        [Test]
        public void SearchTest()
        {
            LoginTest("itay080297@gmail.com", "itayH123!");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".nav-item:nth-child(1) .item-text")));
            searchBtn.Click();

            findDiamondsBtn.Click();
            string expectedText = "7840";
            IWebElement countOfDiamondsSearchResults = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#bootsTrapper > ng-sidebar-container > div > div > main > ng-component > div.container > div > div.col-sm-2 > p")));
            string actualText = countOfDiamondsSearchResults.Text.Split(' ')[1];
            Assert.That(actualText, Is.EqualTo(expectedText), $"Text assertion failed! Expected: '{expectedText}', Actual: '{actualText}'");
            Console.Write($"Search Test:\n The test passed successfully! Expected: '{expectedText}', Actual: '{actualText}'");
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
