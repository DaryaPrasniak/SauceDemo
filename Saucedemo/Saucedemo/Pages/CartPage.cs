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
    internal class CartPage: BasePage
    {
        By ItemInTheCartBy = By.ClassName("cart_item");
        By CheckoutButtonBy = By.Id("checkout");

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public CartPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CartPage(IWebDriver? driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            ChromeDriver.Navigate().GoToUrl(BaseTest.BaseUrl + "cart.html");
        }

        public override bool IsPageOpened()
        {
            try
            {
                return ChromeDriver.FindElement(CheckoutButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int CheckItemInTheCart()
        {
          return ChromeDriver.FindElements(ItemInTheCartBy).Count();
        }

        public CheckoutYourInfoPage ClickCheckoutButton()
        {
            ChromeDriver.FindElement(CheckoutButtonBy).Click();
            _logger.Info(message: "Navigate to CheckoutYourInfoPage");
            return new CheckoutYourInfoPage(ChromeDriver);
        }
    }
}
