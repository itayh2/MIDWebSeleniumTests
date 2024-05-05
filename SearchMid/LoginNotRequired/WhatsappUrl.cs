using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.SearchMid.LoginNotRequired
{
    internal class WhatsappUrl : SearchMidLogin
    {
        private IWebElement whatsappBtn => driver.FindElement(By.CssSelector(".ng-tns-c20-0 > .icon-whatsapp"));
        [Test]
        public void WhatsappUrlTest()
        {
            whatsappBtn.Click();
            string expectedUrl = "https://api.whatsapp.com/send/?phone=19176884459&text&type=phone_number&app_absent=0";
            string? newWindowHandle = WaitForNewWindowHandle(10);
            driver.SwitchTo().Window(newWindowHandle);
            Assert.That(driver.Url, Is.EqualTo(expectedUrl), $"Text assertion failed! Expected: '{expectedUrl}', Actual: '{driver.Url}'");
            Console.WriteLine($"Whatsapp Test passed succeeded:\nExpected: '{expectedUrl}', Actual: '{driver.Url}'");
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
