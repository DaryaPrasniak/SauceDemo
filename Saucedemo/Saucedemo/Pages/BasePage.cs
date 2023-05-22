using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Saucedemo.Pages
{
    internal abstract class BasePage
    {
        protected const int WAIT_FOR_PAGE_LOADING_TIME = 60;
        [ThreadStatic] protected static IWebDriver ChromeDriver;

        public BasePage()
        {
        }

        protected abstract void OpenPage();
        public abstract bool IsPageOpened();

        public BasePage(IWebDriver? driver, bool openPageByUrl)
        {
            ChromeDriver = driver;

            if (openPageByUrl)
            {
                OpenPage();
            }

            WaitForOpen();
        }

        protected void WaitForOpen()
        {
            var secondsCount = 0;
            var isPageOpenedIndicator = IsPageOpened();

            while (!isPageOpenedIndicator && secondsCount < WAIT_FOR_PAGE_LOADING_TIME)
            {
                Thread.Sleep(1000);
                secondsCount++;
                isPageOpenedIndicator = IsPageOpened();
            }

            if (!isPageOpenedIndicator)
            {
                throw new AssertionException("Page was not opened.");
            }
        }
    }
}
