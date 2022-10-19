using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Threading;
using YandexSeleniumTests;
using Assert = NUnit.Framework.Assert;

namespace YandexTests
{
    [TestFixture]
    public class YandexLoginTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Open()
        {
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), GetChromeOptions().ToCapabilities(), TimeSpan.FromSeconds(60));
        }
        private ChromeOptions GetChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            var selenoidOptions = new Dictionary<string, object> { { "sessionTimeout", "2m" } };
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddArgument("--disable-extensions");
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
            chromeOptions.AddAdditionalOption("selenoid:options", selenoidOptions);
            return chromeOptions;
        }

        [TearDown]
        public void Close()
        {
            driver.Close();
        }
        [Test]
        public void LoginYandexTest()
        {
            driver.Url = "https://www.yandex.com/";

            driver.Manage().Window.Maximize();

            HomePageYandex homeYandex = new HomePageYandex(driver);

            homeYandex.ClickLoginButton();

            homeYandex.TakeScreenshot(driver, "../Test.png");

            LoginPageYandex loginPageYandex = homeYandex.GoToLoginPage();

            loginPageYandex.Login("antonantonov972");

            loginPageYandex.Password("Antongekaleo97");

            loginPageYandex.LogOut();
   
            var element = driver.WaitForElement(By.CssSelector(".Button2-Text"), TimeSpan.FromMinutes(2));

            Assert.IsTrue(element.Displayed, "Wrong page!");

        }
    }
}
