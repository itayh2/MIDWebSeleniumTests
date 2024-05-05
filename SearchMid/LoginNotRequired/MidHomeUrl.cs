using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.SearchMid.LoginNotRequired
{
    internal class MidHomeUrl : SearchMidLogin
    {
        [Test]
        public void OpenMidHomeUrlTest()
        {
            WaitForVisibleAndPerformAction(By.CssSelector(".icon-home"), (homeBtn) =>
            {
                homeBtn.Click();
            });
            string expectedUrl = "https://www.middiamonds.com/";
            string? newWindowHandle = WaitForNewWindowHandle(10);
            driver.SwitchTo().Window(newWindowHandle);
            Assert.That(driver.Url, Is.EqualTo(expectedUrl), $"Text assertion failed! Expected: '{expectedUrl}', Actual: '{driver.Url}'");
            Console.WriteLine($"Navigate To Home URL Test passed successfully:\nExpected: '{expectedUrl}', Actual: '{driver.Url}'");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
