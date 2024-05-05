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
    internal class MyDiamonds : SearchMidLogin
    {
        private IWebElement clearMyListBtn => driver.FindElement(By.CssSelector("#bootsTrapper > ng-sidebar-container > div > div > main > user-cart > section > div > div:nth-child(2) > div.table-toolbar.hidden-xs.hidden-sm > div > div > button"));
        private IWebElement clearMyListBtn2 => driver.FindElement(By.CssSelector("#bootsTrapper > ng-sidebar-container > div > div > main > user-cart > section > div > div:nth-child(2) > div.table-toolbar.hidden-xs.hidden-sm > div > div > button:nth-child(2)"));
        private IWebElement addDiamondsBtn => driver.FindElement(By.XPath("//*[@id=\"bootsTrapper\"]/ng-sidebar-container/div/div/main/user-cart/div[2]/div/div/div/div[1]/button"));
        private IWebElement findDiamondsBtn => driver.FindElement(By.CssSelector(".find-btn"));
        private IWebElement diamondNum2 => driver.FindElement(By.XPath("/html/body/mid-app-root/ng-sidebar-container/div/div/main/ng-component/section/div/div[2]/search-results-table/div/div/div/table/tbody[3]/tr/td[2]/a/i"));
        private IWebElement countOfDiamondsInCartText => driver.FindElement(By.CssSelector("#bootsTrapper > ng-sidebar-container > div > div > main > user-cart > div.container > div > div > div > div.search-heading > p"));

        [Test]
        public void AddDiamondsToCartTest()
        {
            LoginTest("itay080297@gmail.com", "itayH123!");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".nav-item:nth-child(1) .item-text")));
            searchBtn.Click();
            IWebElement myDiamondsBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".two-liner-menu-item > .hidden-xs > span")));
            myDiamondsBtn.Click();

            Thread.Sleep(1000);
            string expectedText = "2";
            string actualText = countOfDiamondsInCartText.Text;
            string[] splitText = actualText.Split(' ');
            actualText = splitText[0];
            if (actualText == "0")
            {
                clearMyListBtn.Click();
            }
            else
            {
                clearMyListBtn2.Click();
            }
            addDiamondsBtn.Click();
            findDiamondsBtn.Click();
            IWebElement diamondNum1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/mid-app-root/ng-sidebar-container/div/div/main/ng-component/section/div/div[2]/search-results-table/div/div/div/table/tbody[2]/tr/td[2]/a/i")));
            diamondNum1.Click();
            diamondNum2.Click();
            myDiamondsBtn.Click();
            Thread.Sleep(1000);

            actualText = driver.FindElement(By.CssSelector("#bootsTrapper > ng-sidebar-container > div > div > main > user-cart > div.container > div > div > div > div.search-heading > p")).Text;
            Array.Clear(splitText, 0, splitText.Length);
            splitText = actualText.Split(' ');
            actualText = splitText[0];
            Assert.That(actualText, Is.EqualTo(expectedText), $"Text assertion failed! Expected: '{expectedText}', Actual: '{actualText}'");
            Console.WriteLine($"My Diamonds Test:\nThe test passed successfully! Expected: '{expectedText}', Actual: '{actualText}'");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
