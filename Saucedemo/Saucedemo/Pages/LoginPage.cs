﻿using OpenQA.Selenium;
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

        public LoginPage(WebDriver driver) : base(driver) { }

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
    }
}
