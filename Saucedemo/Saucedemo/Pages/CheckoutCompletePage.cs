using OpenQA.Selenium;
using Saucedemo.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.Pages
{
    internal class CheckoutCompletePage: BasePage
    {
        By SuccessfulCompleteMessageBy = By.ClassName("complete-header");

        public CheckoutCompletePage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckoutCompletePage(IWebDriver? driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            ChromeDriver.Navigate().GoToUrl(BaseTest.BaseUrl + "checkout-complete.html");
        }

        public override bool IsPageOpened()
        {
            try
            {
                return ChromeDriver.FindElement(SuccessfulCompleteMessageBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string CheckCompleteMessage()
        {
            return ChromeDriver.FindElement(SuccessfulCompleteMessageBy).Text;
        }
    }
}
