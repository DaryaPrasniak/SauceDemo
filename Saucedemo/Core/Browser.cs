using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Browser
    {
        private IWebDriver? _webDriver;

        public Browser()
        {
            Driver = new DriverFactory().GetChromeDriver();

            Driver?.Manage().Window.Maximize();
            Driver?.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public IWebDriver? Driver { get; set; }
    }
}
