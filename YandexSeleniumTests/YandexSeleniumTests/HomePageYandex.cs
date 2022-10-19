using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;

namespace YandexSeleniumTests
{
    public class HomePageYandex : BasePage
    {
        public static readonly By _LoginButton1 = By.CssSelector(".user__login-link");
        public static readonly By _LoginButton2 = By.ClassName("Button2");
        public HomePageYandex(IWebDriver driver) : base(driver)
        {
        }

        public void ClickLoginButton()
        {
            Driver.WaitForElement(_LoginButton1, TimeSpan.FromMinutes(2)).Click();
        }

        public LoginPageYandex GoToLoginPage()
        {
            Driver.WaitForElement(_LoginButton2, TimeSpan.FromMinutes(2)).Click();
            return new LoginPageYandex(Driver);
        }
        public void TakeScreenshot(IWebDriver driver, string saveLocation)
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(saveLocation, ScreenshotImageFormat.Png);
        }
    }
}
