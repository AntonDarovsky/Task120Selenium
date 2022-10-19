using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace YandexSeleniumTests
{
    public class BasePage
    {
        public IWebDriver Driver { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
