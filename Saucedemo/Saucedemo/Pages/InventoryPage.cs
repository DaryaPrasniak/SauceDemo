using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.Pages
{
    internal class InventoryPage: BasePage
    {
        By InventoryContainerBy = By.ClassName("inventory_list");
        By FirstInventoryItemLinkBy = By.LinkText("Sauce Labs Backpack");
        By SecondInventoryItemLinkBy = By.LinkText("Sauce Labs Bike Light");
        By ThirdInventoryItemLinkBy = By.LinkText("Sauce Labs Bolt T-Shirt");
        By AddToCartButtonForBackpackBy = By.Id("add-to-cart-sauce-labs-backpack");
        By ShoppingCartLink = By.ClassName("shopping_cart_link");
        public InventoryPage(WebDriver driver) : base(driver) { }

        public bool CheckInventoryItemsOnThePage()
        {
          return ChromeDriver.FindElement(InventoryContainerBy).Displayed;
        }

        public void ClickFirstInventoryItemLink()
        {
            ChromeDriver.FindElement(FirstInventoryItemLinkBy).Click();
        }

        public void ClickSecondInventoryItemLink()
        {
            ChromeDriver.FindElement(SecondInventoryItemLinkBy).Click();
        }

        public void ClickThirdInventoryItemLink()
        {
            ChromeDriver.FindElement(ThirdInventoryItemLinkBy).Click();
        }

        public void ClickAddToCartButtonForBackpack()
        { 
            ChromeDriver.FindElement(AddToCartButtonForBackpackBy).Click(); 
        }

        public void ClickShoppingCartLink()
        {
            ChromeDriver.FindElement(ShoppingCartLink).Click();
        }
    }
}
