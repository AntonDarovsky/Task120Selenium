using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace YandexSeleniumTests
{
    public class LoginPageYandex : BasePage
    {
        public static readonly By _loginField = By.Id("passp-field-login");

        public static readonly By _signInButton1 = By.CssSelector(".passp-sign-in-button");

        public static readonly By _passwordField = By.Id("passp-field-passwd");

        public static readonly By _passwordButton = By.CssSelector(".passp-sign-in-button");

        public static readonly By _mailSettingsButton = By.XPath("//*[contains(@class,'mail - SettingsButton')]");

        public static readonly By _userButton = By.CssSelector(".user-account__name");

        public static readonly By _logOutButton = By.XPath("//*[contains(@class, 'legouser__menu-item_action_exit')]");

        public LoginPageYandex(IWebDriver driver) : base(driver)
        {
        }
        
        public void Login(string login)
        {
            Driver.WaitForElement(_loginField, TimeSpan.FromMinutes(2)).SendKeys(login);
            
            Driver.WaitForElement(_signInButton1, TimeSpan.FromMinutes(2)).Click();

            Thread.Sleep(1000);
        }

        public void Password(string password)
        {
            
            Driver.WaitForElement(_passwordField, TimeSpan.FromMinutes(2)).SendKeys(password);

            Driver.WaitForElement(_passwordButton, TimeSpan.FromMinutes(2)).Click();
        }

        public void LogOut()
        {
            Driver.WaitForElement(_userButton, TimeSpan.FromMinutes(3)).Click();

            Driver.WaitForElement(_logOutButton, TimeSpan.FromMinutes(2)).Click();
        }
        
    }
}
