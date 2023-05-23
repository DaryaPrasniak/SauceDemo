using Core;
using Core.Models;
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

        protected User GetUser()
        {
            return new User()
            {
                UserName = "standard_user",
                Password = "secret_sauce",
                FirstName = "John",
                LastName = "Smith",
                ZipCode = "123456"
            };
        }

        protected User GetInvalidUser()
        {
            return new User()
            {
                UserName = "standard_gguser",
                Password = "secret_sauce",
                FirstName = "John",
                LastName = "Smith",
                ZipCode = "123456"
            };
        }
    }
}
