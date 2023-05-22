using OpenQA.Selenium;
using Saucedemo.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.Pages
{
    internal class LoginPage: BasePage
    {
        By UserNameInputBy = By.Name("user-name");
        By PasswordInputBy = By.Name("password");
        By LoginButtonBy = By.Name("login-button");
        By ErrorMessageBy = By.ClassName("error-message-container");

        public LoginPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public LoginPage(IWebDriver? driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            ChromeDriver.Navigate().GoToUrl(BaseTest.BaseUrl);
        }
        
        public override bool IsPageOpened()
        {
            try
            {
                return ChromeDriver.FindElement(LoginButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void InputUserName(string userName)
        {
            ChromeDriver.FindElement(UserNameInputBy).SendKeys(userName);
        }

        public void InputPassword(string password)
        { 
            ChromeDriver.FindElement(PasswordInputBy).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            ChromeDriver.FindElement(LoginButtonBy).Click();
        }

        public void Login(string userName, string password)
        {
            InputUserName(userName);
            InputPassword(password);
            ClickLoginButton();
        }

        public InventoryPage SuccessfulLogin(string userName, string password)
        {
            Login(userName, password);
            return new InventoryPage(ChromeDriver);
        }

        public LoginPage IncorrectLogin(string userName, string password)
        {
            Login(userName, password);
            return this;
        }

        public bool CheckErrorMessage()
        {
           return ChromeDriver.FindElement(ErrorMessageBy).Displayed;
        }
    }
}
