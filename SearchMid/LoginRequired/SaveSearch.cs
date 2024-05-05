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
    internal class SaveSearch : SearchMidLogin
    {
        private IWebElement iconRoundBtn => driver.FindElement(By.CssSelector(".icon-round"));
        private IWebElement weightRangeBtn => driver.FindElement(By.CssSelector("div:nth-child(1) > .btn-white:nth-child(1)"));
        private IWebElement savedSearchTextBox => driver.FindElement(By.Name("save-search"));
        private IWebElement saveSearchBtn => driver.FindElement(By.CssSelector(".save-search-btn"));
        private IWebElement dontCareBtn => driver.FindElement(By.CssSelector(".gray-btn"));
        private IWebElement closeBtn => driver.FindElement(By.CssSelector(".orange-btn"));

        [Test]
        public void SaveSearchTest()
        {
            LoginTest("itay080297@gmail.com", "itayH123!");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".nav-item:nth-child(1) .item-text")));
            searchBtn.Click();

            iconRoundBtn.Click();
            weightRangeBtn.Click();
            savedSearchTextBox.SendKeys("Save Number 1");
            saveSearchBtn.Click();
            IWebElement popUpMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".title")));
            string actualText = popUpMessage.Text;
            string[] expectedText = { "Your Search has been successfully saved!", "Search with this name already exists!" };
            if (actualText == "Your Search has been successfully saved!")
            {
                Assert.That(actualText, Is.EqualTo(expectedText[0]), $"Text assertion failed! Expected: '{expectedText[0]}', Actual: '{actualText}'");
                Console.Write($"Save Search Test:\nThe test passed successfully! Expected: '{expectedText[0]}', Actual: '{actualText}'");
            }
            else if (actualText == "Search with this name already exists!")
            {
                string[] splitText = actualText.Split(' ');
                string[] trimmedArray = splitText.Skip(1).Take(splitText.Length - 2).ToArray();
                string result = string.Join(" ", trimmedArray);
                dontCareBtn.Click();
                Assert.That(result, Is.EqualTo(expectedText[1]), $"Text assertion failed! Expected: '{expectedText[1]}', Actual: '{result}'");
                Console.Write($"Save Search Test:\nThe test passed successfully! Expected: '{expectedText[1]}', Actual: '{result}'");

                Thread.Sleep(5000);
            }
            closeBtn.Click();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
