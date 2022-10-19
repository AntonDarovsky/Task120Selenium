using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace YandexSeleniumTests
{
    public static class WebDriverWaiter
    {
        public static IWebElement WaitForElement(this IWebDriver driver, By by, TimeSpan timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, timeoutInSeconds);
            var element = wait.Until(drv => drv.FindElement(by));
            return element;
        }

    }
}