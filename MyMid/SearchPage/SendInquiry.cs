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
    internal class SendInquiry : Login
    {
        [Test]
        public void SendInquiryTest()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange")));
            searchBtn.Click();
            Thread.Sleep(3000);
            IWebElement selectStone = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#col-2 > .ng-tns-c59-8:nth-child(2)")));
            selectStone.Click();
            IWebElement sendInquiryBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".search-actions:nth-child(1) > .btn:nth-child(2)")));
            sendInquiryBtn.Click();
            IWebElement messageTextBox = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".xs-pl-20")));
            messageTextBox.SendKeys("Hi, is a testing!");
            IWebElement sendBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("orange-btn")));
            sendBtn.Click();
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
