using Core.Models;
using NLog;
using NUnit.Allure.Attributes;
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

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public LoginPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public LoginPage(IWebDriver? driver) : base(driver, false)
        {
        }

        [AllureStep(name:"Navigate to Login page")]
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

        [AllureStep]
        public void InputUserName(string userName)
        {
            ChromeDriver.FindElement(UserNameInputBy).SendKeys(userName);
        }

        [AllureStep]
        public void InputPassword(string password)
        { 
            ChromeDriver.FindElement(PasswordInputBy).SendKeys(password);
        }

        [AllureStep]
        public void ClickLoginButton()
        {
            ChromeDriver.FindElement(LoginButtonBy).Click();
        }

        [AllureStep]
        public void Login(User user)
        {
            InputUserName(user.UserName);
            InputPassword(user.Password);
            ClickLoginButton();
        }

        [AllureStep]
        public InventoryPage SuccessfulLogin(User user)
        {
            Login(user);
            _logger.Info(message: "Navigate to InventoryPage");
            return new InventoryPage(ChromeDriver);
        }

        [AllureStep]
        public LoginPage IncorrectLogin(User user)
        {
            Login(user);
            _logger.Info(message: "Navigate to LoginPage");
            return this;
        }

        [AllureStep]
        public bool CheckErrorMessage()
        {
           return ChromeDriver.FindElement(ErrorMessageBy).Displayed;
        }
    }
}
