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
    internal class GuestPermissions : SearchMidLogin
    {
        [Test]
        public void GuestPermissionsTest()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement findDiamondsBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".find-btn")));
            Thread.Sleep(1000);
            findDiamondsBtn.Click();
            IWebElement seePriceBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("SEE PRICE")));
            Assert.That(seePriceBtn.Text, Is.EqualTo("SEE PRICE"));
            Console.Write($"Guest Permissions Test passed successfully\n");

            Thread.Sleep(1000);
            seePriceBtn.Click();
            Thread.Sleep(1000);
            seePriceBtn.Click();

            string? newWindowHandle = WaitForNewWindowHandle(10);
            driver.SwitchTo().Window(newWindowHandle);
            Thread.Sleep(2000);

            Assert.That(driver.Url.Contains("https://mid-preprod.us.auth0.com/login?"), "New window does not contain the desired URL");
            Console.WriteLine("New window contains the desired URL");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
