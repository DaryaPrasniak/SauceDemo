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
    internal class CheckoutOverviewPage: BasePage
    {
        By FinishButtonBy = By.Id("finish");

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public CheckoutOverviewPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckoutOverviewPage(IWebDriver? driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            ChromeDriver.Navigate().GoToUrl(BaseTest.BaseUrl + "checkout-step-two.html");
        }

        public override bool IsPageOpened()
        {
            try
            {
                return ChromeDriver.FindElement(FinishButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public CheckoutCompletePage ClickFinishButton()
        { 
            ChromeDriver.FindElement(FinishButtonBy).Click();
            _logger.Info(message: "Navigate to CheckoutCompletePage");
            return new CheckoutCompletePage(ChromeDriver);
        }
    }
}
