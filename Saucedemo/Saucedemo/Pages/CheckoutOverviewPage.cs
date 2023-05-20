using OpenQA.Selenium;
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

        public CheckoutOverviewPage(WebDriver driver) : base(driver) { }

        public void ClickFinishButton()
        { 
            ChromeDriver.FindElement(FinishButtonBy).Click();
        }
    }
}
