using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.SearchMid.LoginNotRequired
{
    internal class FreeTextSearch : SearchMidLogin
    {
        [Test]
        public void FreeTextSearchTest()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement freeTextBox = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".completer-dropdown-small")));
            freeTextBox.SendKeys("ih-0001 ih-0003 ih-0007");
            Thread.Sleep(1000);
            freeTextBox.SendKeys(Keys.Enter);
            IWebElement countOfDiamondsInCartText = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".text-light-grey")));
            string expectedText = "3";
            string actualText = countOfDiamondsInCartText.Text.Split(' ')[1];
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
