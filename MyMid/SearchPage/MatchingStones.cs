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
    internal class MatchingStones : Login
    {
        [Test]
        public void MatchingStonesAllResults()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement matchingStonesBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".search-option > .ng-tns-c51-6:nth-child(2)")));
            matchingStonesBtn.Click();
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange")));
            searchBtn.Click();
            Thread.Sleep(1000);
            IWebElement countOfDiamondsText = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".result-number")));
            string expectedText = "278";
            string actualText = countOfDiamondsText.Text.Split('\n')[0].Split('\r')[0];
            Assert.That(actualText, Is.EqualTo(expectedText), $"Text assertion failed! Expected: '{expectedText}', Actual: '{actualText}'");
            Console.Write($"Matching Stones All:\nThe test passed successfully! Expected: '{expectedText}', Actual: '{actualText}'");
        }
        [Test]
        public void MatchingStonesPerfectResults()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement matchingStonesBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".search-option > .ng-tns-c51-6:nth-child(2)")));
            matchingStonesBtn.Click();
            IWebElement matchingStonesPerfectBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".matching-filter .btn-circle-wrap:nth-child(5) > .btn")));
            matchingStonesPerfectBtn.Click();
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange")));
            searchBtn.Click();
            Thread.Sleep(1000);
            IWebElement countOfDiamondsText = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".result-number")));
            string expectedText = "198";
            string actualText = countOfDiamondsText.Text.Split('\n')[0].Split('\r')[0];
            Assert.That(actualText, Is.EqualTo(expectedText), $"Text assertion failed! Expected: '{expectedText}', Actual: '{actualText}'");
            Console.Write($"Matching Stones Perfect:\nThe test passed successfully! Expected: '{expectedText}', Actual: '{actualText}'");
        }
        [Test]
        public void MatchingStonesSeparableResults()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement matchingStonesBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".search-option > .ng-tns-c51-6:nth-child(2)")));
            matchingStonesBtn.Click();
            IWebElement matchingStonesSeparableBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".matching-filter .btn-circle-wrap:nth-child(1) > .btn")));
            matchingStonesSeparableBtn.Click();
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange")));
            searchBtn.Click();
            Thread.Sleep(1000);
            IWebElement countOfDiamondsText = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".result-number")));
            string expectedText = "80";
            string actualText = countOfDiamondsText.Text.Split('\n')[0].Split('\r')[0];
            Assert.That(actualText, Is.EqualTo(expectedText), $"Text assertion failed! Expected: '{expectedText}', Actual: '{actualText}'");
            Console.Write($"Matching Stones Separable:\nThe test passed successfully! Expected: '{expectedText}', Actual: '{actualText}'");
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
