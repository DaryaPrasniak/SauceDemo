using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Saucedemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.Tests
{
    internal class BaseTest
    {
        protected WebDriver ChromeDriver { get; set; }
        public LoginPage LoginPage { get; set; }
        public InventoryPage InventoryPage { get; set; }
        public ItemDetailedInfoPage ItemDetailedInfoPage { get; set; }
        public CartPage CartPage { get; set; }
        public CheckoutYourInfoPage CheckoutYourInfoPage { get; set; }
        public CheckoutOverviewPage CheckoutOverviewPage { get; set; }
        public CheckoutCompletePage CheckoutCompletePage { get; set; }

        [SetUp]
        public void SetUp()
        {
            string browser = TestContext.Parameters.Get("Browser");

            switch (browser)
            {
                case "headless":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--headless");
                    break;
                default:
                    ChromeDriver = new ChromeDriver();
                    break;
            }

            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ChromeDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            LoginPage = new LoginPage(ChromeDriver);
            InventoryPage = new InventoryPage(ChromeDriver);
            ItemDetailedInfoPage = new ItemDetailedInfoPage(ChromeDriver);
            CartPage = new CartPage(ChromeDriver);
            CheckoutYourInfoPage = new CheckoutYourInfoPage(ChromeDriver);
            CheckoutOverviewPage = new CheckoutOverviewPage(ChromeDriver);
            CheckoutCompletePage = new CheckoutCompletePage(ChromeDriver);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}
