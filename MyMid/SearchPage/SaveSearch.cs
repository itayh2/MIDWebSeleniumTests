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
    internal class SaveSearch : Login
    {
        private IWebElement dontCareBtn => driver.FindElement(By.CssSelector(".gray-btn"));
        private IWebElement closeBtn => driver.FindElement(By.CssSelector(".orange-btn"));

        [Test]
        public void SaveSearchTest()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement roundIcon = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-round")));
            roundIcon.Click();
            IWebElement searhNameTextBox = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("save-search")));
            searhNameTextBox.SendKeys("round");
            IWebElement saveSearch = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-new-save")));
            saveSearch.Click();
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
