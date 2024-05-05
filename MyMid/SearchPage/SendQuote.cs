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
    internal class SendQuote : Login
    {
        [Test]
        public void SendQuoteTest()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchForMemberBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("body > app-root > mat-sidenav-container > mat-sidenav-content > div > div > main > search > div:nth-child(3) > div > search-filters > div.col-sm-2.search-section-wrap.ng-tns-c51-6.ng-star-inserted > section > div:nth-child(1) > div > button")));
            searchForMemberBtn.Click();
            IWebElement selectMember = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("body > app-root > mat-sidenav-container > mat-sidenav-content > div > div > main > search > div:nth-child(3) > div > search-filters > search-member-modal > div > div > div > div > div > div > div:nth-child(4) > section > div > table > tbody > tr:nth-child(1) > td:nth-child(3) > div")));
            selectMember.Click();
            IWebElement startQuoteBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("body > app-root > mat-sidenav-container > mat-sidenav-content > div > div > main > search > div:nth-child(3) > div > search-filters > search-member-modal > div > div > div > div > div > div > div.link-add-member-group > div.flex-container.ng-star-inserted > i")));
            startQuoteBtn.Click();
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/search/div[2]/div/div[1]/button[4]")));
            searchBtn.Click();
            Thread.Sleep(2000);
            IWebElement addDiamonds1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/search/div[4]/stone-table/div/div/section/div[2]/div/div/table/tbody[1]/tr/td[2]")));
            addDiamonds1.Click();
            IWebElement addDiamonds2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/search/div[4]/stone-table/div/div/section/div[2]/div/div/table/tbody[2]/tr/td[2]")));
            addDiamonds2.Click();
            IWebElement addToQuotes = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange:nth-child(3)")));
            addToQuotes.Click();
            IWebElement moveToQuote = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-my-diamonds")));
            moveToQuote.Click();
            Thread.Sleep(2000);
            IWebElement quoteId = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/member-details/div[2]/quote/div[1]/div/div/div[1]/div/h1/span")));
            string expectedText = quoteId.Text;
            IWebElement saveAndContinue = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("btn-orange")));
            saveAndContinue.Click();
            Thread.Sleep(1000);
            IWebElement sendQuote = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-white-mail")));
            sendQuote.Click();
            Thread.Sleep(1000);
            IWebElement iconQuoteBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-quotes")));
            iconQuoteBtn.Click();
            Thread.Sleep(1000);
            IWebElement quoteNumText = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".matching:nth-child(1) .text-orange")));
            string quoteText = quoteNumText.Text;
            Assert.That(expectedText, Is.EqualTo(quoteText), $"Send Quote Failed! Expected: '{expectedText}', Actual: '{quoteText}'");
            Console.WriteLine($"Send Quote Test passed successfully:\n Expected: '{expectedText}', Actual: '{quoteText}'");
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
