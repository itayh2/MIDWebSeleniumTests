using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.MyMid.DashboardPage
{
    internal class CreateMidApi : Login
    {
        [Test]
        public void JsonApiTest()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement dashboardBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a:nth-child(2) .mdc-list-item__content")));
            dashboardBtn.Click();
            Thread.Sleep(2000);
            IWebElement apiBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".inline-block:nth-child(6) > .dashboard-tab-text-wrap")));
            apiBtn.Click();
            IWebElement addMidApi = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange:nth-child(1)")));
            addMidApi.Click();
            IWebElement addMember = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("member-input")));
            addMember.SendKeys("itay080297@gmail.com");
            IWebElement chooseMember = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".completer-list-item:nth-child(3)")));
            chooseMember.Click();
            IWebElement roundIcon = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-round")));
            roundIcon.Click();
            IWebElement nextBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".pull-right > .btn")));
            nextBtn.Click();
            IWebElement addAllFields = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".col-sm-4:nth-child(2) > .btn")));
            addAllFields.Click();
            IWebElement saveApi = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange:nth-child(2)")));
            saveApi.Click();
            string expectedText = "Your API has been successfully created!";
            string actualText = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".title"))).Text;
            Assert.That(actualText, Is.EqualTo(expectedText), "The Json Mid api was not created successfully");
            driver.FindElement(By.CssSelector(".orange-btn")).Click();
            Console.WriteLine("The Json Mid api was created successfully");
        }

        [Test]
        public void XmlApiTest()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement dashboardBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a:nth-child(2) .mdc-list-item__content")));
            dashboardBtn.Click();
            Thread.Sleep(1000);
            IWebElement apiBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".inline-block:nth-child(6) > .dashboard-tab-text-wrap")));
            apiBtn.Click();
            IWebElement addMidApi = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange:nth-child(1)")));
            addMidApi.Click();
            Thread.Sleep(1000);
            IWebElement xmlFormat = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".col-sm-12 > .api-format > label:nth-child(4)")));
            xmlFormat.Click();
            IWebElement addMember = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("member-input")));
            addMember.SendKeys("itay080297@gmail.com");
            IWebElement chooseMember = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".completer-list-item:nth-child(3)")));
            chooseMember.Click();
            IWebElement roundIcon = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-round")));
            roundIcon.Click();
            IWebElement nextBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".pull-right > .btn")));
            nextBtn.Click();
            IWebElement addAllFields = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".col-sm-4:nth-child(2) > .btn")));
            addAllFields.Click();
            IWebElement saveApi = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange:nth-child(2)")));
            saveApi.Click();
            string expectedText = "Your API has been successfully created!";
            string actualText = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".title"))).Text;
            Assert.That(actualText, Is.EqualTo(expectedText), "The Xml Mid api was not created successfully");
            driver.FindElement(By.CssSelector(".orange-btn")).Click();
            Console.WriteLine("The Xml Mid api was created successfully");
        }
        [Test]
        public void CsvApiTest()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement dashboardBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a:nth-child(2) .mdc-list-item__content")));
            dashboardBtn.Click();
            Thread.Sleep(1000);
            IWebElement apiBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".inline-block:nth-child(6) > .dashboard-tab-text-wrap")));
            apiBtn.Click();
            IWebElement addMidApi = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange:nth-child(1)")));
            addMidApi.Click();
            Thread.Sleep(1000);
            IWebElement csvFormat = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".api-format > label:nth-child(6)")));
            csvFormat.Click();
            IWebElement addMember = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("member-input")));
            addMember.SendKeys("itay080297@gmail.com");
            IWebElement chooseMember = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".completer-list-item:nth-child(3)")));
            chooseMember.Click();
            IWebElement roundIcon = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-round")));
            roundIcon.Click();
            IWebElement nextBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".pull-right > .btn")));
            nextBtn.Click();
            IWebElement addAllFields = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".col-sm-4:nth-child(2) > .btn")));
            addAllFields.Click();
            IWebElement saveApi = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange:nth-child(2)")));
            saveApi.Click();
            string expectedText = "Your API has been successfully created!";
            string actualText = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".title"))).Text;
            Assert.That(actualText, Is.EqualTo(expectedText), "The Csv Mid api was not created successfully");
            driver.FindElement(By.CssSelector(".orange-btn")).Click();
            Console.WriteLine("The Csv Mid api was created successfully");
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
