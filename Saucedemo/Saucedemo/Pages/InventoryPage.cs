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
    internal class InventoryPage: BasePage
    {
        By InventoryContainerBy = By.Id("inventory_container");
        By FirstInventoryItemLinkBy = By.LinkText("Sauce Labs Backpack");
        By SecondInventoryItemLinkBy = By.LinkText("Sauce Labs Bike Light");
        By ThirdInventoryItemLinkBy = By.LinkText("Sauce Labs Bolt T-Shirt");
        By AddToCartButtonForBackpackBy = By.Id("add-to-cart-sauce-labs-backpack");
        By ShoppingCartLink = By.ClassName("shopping_cart_link");

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public InventoryPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public InventoryPage(IWebDriver? driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            ChromeDriver.Navigate().GoToUrl(BaseTest.BaseUrl + "inventory.html");
        }

        public override bool IsPageOpened()
        {
            try
            {
                return ChromeDriver.FindElement(InventoryContainerBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckInventoryItemsOnThePage()
        {
          return ChromeDriver.FindElement(InventoryContainerBy).Displayed;
        }

        public ItemDetailedInfoPage ClickFirstInventoryItemLink()
        {
            ChromeDriver.FindElement(FirstInventoryItemLinkBy).Click();
            _logger.Info(message: "Navigate to ItemDetailedInfoPage");
            return new ItemDetailedInfoPage(ChromeDriver);
        }

        public ItemDetailedInfoPage ClickSecondInventoryItemLink()
        {
            ChromeDriver.FindElement(SecondInventoryItemLinkBy).Click();
            _logger.Info(message: "Navigate to ItemDetailedInfoPage");
            return new ItemDetailedInfoPage(ChromeDriver);
        }

        public ItemDetailedInfoPage ClickThirdInventoryItemLink()
        {
            ChromeDriver.FindElement(ThirdInventoryItemLinkBy).Click();
            _logger.Info(message: "Navigate to ItemDetailedInfoPage");
            return new ItemDetailedInfoPage(ChromeDriver);
        }

        public InventoryPage ClickAddToCartButtonForBackpack()
        { 
            ChromeDriver.FindElement(AddToCartButtonForBackpackBy).Click();
            _logger.Info(message: "Navigate to InventoryPage");
            return this;
        }

        public CartPage ClickShoppingCartLink()
        {
            ChromeDriver.FindElement(ShoppingCartLink).Click();
            _logger.Info(message: "Navigate to CartPage");
            return new CartPage(ChromeDriver);
        }
    }
}
