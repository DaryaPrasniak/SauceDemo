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
    internal class ItemDetailedInfoPage: BasePage
    {
        By BackToProductsButtonBy = By.Id("back-to-products");

        public ItemDetailedInfoPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public ItemDetailedInfoPage(IWebDriver? driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            ChromeDriver.Navigate().GoToUrl(BaseTest.BaseUrl + "inventory-item.html?id=4");
        }

        public override bool IsPageOpened()
        {
            try
            {
                return ChromeDriver.FindElement(BackToProductsButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckBackToProductsButton()
        {
            return ChromeDriver.FindElement(BackToProductsButtonBy).Displayed;
        }
    }
}
