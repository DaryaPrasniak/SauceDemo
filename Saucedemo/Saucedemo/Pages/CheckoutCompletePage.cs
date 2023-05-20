using OpenQA.Selenium;
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

        public CheckoutCompletePage(WebDriver driver) : base(driver) { }

        public string CheckCompleteMessage()
        {
            return ChromeDriver.FindElement(SuccessfulCompleteMessageBy).Text;
        }
    }
}
