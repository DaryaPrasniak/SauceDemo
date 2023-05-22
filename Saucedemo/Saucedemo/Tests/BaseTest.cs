using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Saucedemo.Tests
{
    internal class BaseTest
    {
        public static readonly string BaseUrl = "https://www.saucedemo.com/";

        [ThreadStatic] protected static IWebDriver? ChromeDriver;
        protected WaitService? WaitService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
            ChromeDriver = new Browser().Driver;
            WaitService = new WaitService(ChromeDriver);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver?.Quit();
        }
    }
}
