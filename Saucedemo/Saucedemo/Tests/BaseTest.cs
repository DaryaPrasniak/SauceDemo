using Allure.Commons;
using Core;
using Core.Models;
using NLog;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;

namespace Saucedemo.Tests
{
    [AllureNUnit]
    internal class BaseTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public static readonly string BaseUrl = "https://www.saucedemo.com/";

        [ThreadStatic] protected static IWebDriver? ChromeDriver;
        protected WaitService? WaitService;
        private AllureLifecycle _allure;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _allure = AllureLifecycle.Instance;
        }

        [SetUp]
        public void Setup()
        {
            _logger.Trace(message: "Message level Trace");
            _logger.Debug(message: "Message level Debug");
            _logger.Info(message: "Message level Information");
            _logger.Warn(message: "Message level Warning");
            _logger.Error(message: "Message level Error");
            _logger.Fatal(message: "Message level Fatal");

            ChromeDriver = new Browser().Driver;
            WaitService = new WaitService(ChromeDriver);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)ChromeDriver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                _allure.AddAttachment(name: "Screenshot", type: "image/png", screenshotBytes);
            }
            ChromeDriver?.Quit();
        }
    }
}
