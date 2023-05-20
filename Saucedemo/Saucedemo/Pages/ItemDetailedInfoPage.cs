using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.Pages
{
    internal class ItemDetailedInfoPage: BasePage
    {
        By BackToProductsButtonBy = By.Id("back-to-products");

        public ItemDetailedInfoPage(WebDriver driver) : base(driver) { }

        public bool CheckBackToProductsButton()
        {
            return ChromeDriver.FindElement(BackToProductsButtonBy).Displayed;
        }
    }
}
