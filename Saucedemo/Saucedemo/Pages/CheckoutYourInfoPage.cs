﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.Pages
{
    internal class CheckoutYourInfoPage : BasePage
    {
        By FirstNameInputBy = By.Id("first-name");
        By LastNameInputBy = By.Id("last-name");
        By ZipPostalCodeInputBy = By.Id("postal-code");
        By ContinueButtonBy = By.Id("continue");

        public CheckoutYourInfoPage(WebDriver driver) : base(driver) { }

        public void SetFirstName(string firstName)
        {
            ChromeDriver.FindElement(FirstNameInputBy).SendKeys(firstName);
        }

        public void SetLastName(string lastName)
        {
            ChromeDriver.FindElement(LastNameInputBy).SendKeys(lastName);
        }

        public void SetZipOrPostalCode(string zipCode)
        {
            ChromeDriver.FindElement(ZipPostalCodeInputBy).SendKeys(zipCode);
        }

        public void ClickContinueButton()
        {
            ChromeDriver.FindElement(ContinueButtonBy).Click();
        }

        public void InputUserInfo(string firstName, string lastName, string zipCode)
        { 
            SetFirstName(firstName);
            SetLastName(lastName); 
            SetZipOrPostalCode(zipCode);
        }
    }
}
