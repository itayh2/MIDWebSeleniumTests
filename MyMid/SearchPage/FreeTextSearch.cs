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
    internal class FreeTextSearch : Login
    {
        [Test]
        public void FreeTextSearchTest()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchNameTextBox = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("body > app-root > mat-sidenav-container > mat-sidenav-content > div > div > main > search > div:nth-child(3) > div > search-filters > div:nth-child(3) > section > div:nth-child(2) > textarea")));
            searchNameTextBox.SendKeys("ih-0001 ih-0003 ih-0007");
            Thread.Sleep(1000);
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange")));
            searchBtn.Click();
            Thread.Sleep(1000);
            IWebElement countOfDiamondsText = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".result-number")));
            string expectedText = "4";
            string actualText = countOfDiamondsText.Text.Split('\n')[0].Split('\r')[0];
            Assert.That(actualText, Is.EqualTo(expectedText), $"Text assertion failed! Expected: '{expectedText}', Actual: '{actualText}'");
            Console.Write($"Free Text Search:\n The test passed successfully! Expected: '{expectedText}', Actual: '{actualText}'");

        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
