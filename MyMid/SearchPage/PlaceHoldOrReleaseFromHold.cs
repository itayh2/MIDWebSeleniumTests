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
    internal class PlaceHoldOrReleaseFromHold : Login
    {
        [Test]
        public void PlaceHoldOrReleaseFromHoldTest()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange")));
            searchBtn.Click();
            Thread.Sleep(2000);
            IWebElement selectStone = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/search/div[4]/stone-table/div/div/section/div[2]/div/div/table/tbody[1]/tr/td[2]")));
            Thread.Sleep(2000);
            selectStone.Click();
            Thread.Sleep(1000);
            IWebElement placeOrReleaseHoldBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".search-actions > .btn:nth-child(6)")));
            if (placeOrReleaseHoldBtn.Text == "Place Hold")
            {
                placeOrReleaseHoldBtn.Click();
                IWebElement forMember = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("member-input")));
                forMember.SendKeys("itay080297@gmail.com");
                IWebElement chooseMember = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".completer-list-item:nth-child(3)")));
                chooseMember.Click();
                IWebElement choosePeriod = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-group:nth-child(3) > .btn")));
                choosePeriod.Click();
                IWebElement okBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange:nth-child(2)")));
                okBtn.Click();
                Thread.Sleep(2000);
                IWebElement holdSymbole = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/search/div[4]/stone-table/div/div/section/div[2]/div/div/table/tbody[1]/tr/td[3]/div/button[3]")));
                string isActive = holdSymbole.GetAttribute("class");
                Assert.IsTrue(isActive.Contains("active"), "Place Hold - The action was not done successfully");
                Console.WriteLine("Set Off The Net - The test passed successfully");
            }
            else
            {
                placeOrReleaseHoldBtn.Click();
                Thread.Sleep(2000);
                IWebElement holdSymbole = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/search/div[4]/stone-table/div/div/section/div[2]/div/div/table/tbody[1]/tr/td[3]/div/button[3]")));
                string isActive = holdSymbole.GetAttribute("class");
                Assert.IsTrue(!isActive.Contains("active"), "Release From Hold - The action was not done successfully");
                Console.WriteLine("Release From Hold - The test passed successfully");
            }
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
