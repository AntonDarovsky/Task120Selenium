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

        public TestContext TestContext { get; set; }

        [SetUp]
        public void Open()
        {
            driver = new RemoteWebDriver(new Uri("https://oauth-antondarovski97-bf9e3:19b6c1c4-5127-4d25-b46e-d1f8419358ca@ondemand.eu-central-1.saucelabs.com:443/wd/hub"), GetChromeOptions().ToCapabilities(), TimeSpan.FromSeconds(60));
        }
        private ChromeOptions GetChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.PlatformName = "Windows 10";
            chromeOptions.BrowserVersion = "latest";
            chromeOptions.AddAdditionalOption("username", "oauth-antondarovski97-bf9e3");
            chromeOptions.AddAdditionalOption("accessKey", "*****58ca");
            var sauceOptions = new Dictionary<string, object>();
            sauceOptions.Add("build", "selenium-build-5PEA4");
            sauceOptions.Add("name", "<Anton>");
            chromeOptions.AddAdditionalOption("sauce:options", sauceOptions);
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

            //loginPageYandex.LogOut();
   
           // var element = driver.WaitForElement(By.CssSelector(".Button2-Text"), TimeSpan.FromMinutes(2));

           // Assert.IsTrue(element.Displayed, "Wrong page!");

        }
    }
}
