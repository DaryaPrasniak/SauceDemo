using OpenQA.Selenium;
using Saucedemo.Tests;
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
        By CartErrorMessageBy = By.ClassName("error-button");

        public CheckoutYourInfoPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckoutYourInfoPage(IWebDriver? driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            ChromeDriver.Navigate().GoToUrl(BaseTest.BaseUrl + "checkout-step-one.html");
        }

        public override bool IsPageOpened()
        {
            try
            {
                return ChromeDriver.FindElement(ContinueButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

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
            ClickContinueButton();
        }

        public CheckoutOverviewPage CorrectInputUserInfo(string firstName, string lastName, string zipCode)
        { 
            InputUserInfo(firstName, lastName, zipCode);
            return new CheckoutOverviewPage(ChromeDriver);
        }

        public CheckoutYourInfoPage IncorrectInputUserInfo(string firstName, string lastName)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            ClickContinueButton();
            return this;
        }

        public bool CheckCartErrorMessage()
        {
           return ChromeDriver.FindElement(CartErrorMessageBy).Displayed;
        }
    }
}
