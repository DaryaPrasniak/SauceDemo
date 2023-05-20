using OpenQA.Selenium;
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

        public CartPage(WebDriver driver) : base(driver) { }

        public int CheckItemInTheCart()
        {
          return ChromeDriver.FindElements(ItemInTheCartBy).Count();
        }

        public void ClickCheckoutButton()
        {
            ChromeDriver.FindElement(CheckoutButtonBy).Click();
        }
    }
}
