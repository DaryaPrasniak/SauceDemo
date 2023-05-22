using NUnit.Framework;
using NUnit.Framework.Internal;
using Saucedemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.Tests
{
    internal class InventoryTest: BaseTest
    {
        [Test]
        public void Test1()
        {
            var user = GetUser();

            var itemDetailedInfoPage = new LoginPage(ChromeDriver, true)
                .SuccessfulLogin(user)
                .ClickFirstInventoryItemLink();

            Assert.IsTrue(itemDetailedInfoPage.CheckBackToProductsButton());
        }

        [Test]
        public void Test2()
        {
            var user = GetUser();

            var itemDetailedInfoPage = new LoginPage(ChromeDriver, true)
               .SuccessfulLogin(user)
               .ClickSecondInventoryItemLink();

            Assert.IsTrue(itemDetailedInfoPage.CheckBackToProductsButton());
        }

        [Test]
        public void Test3()
        {
            var user = GetUser();

            var itemDetailedInfoPage = new LoginPage(ChromeDriver, true)
               .SuccessfulLogin(user)
               .ClickThirdInventoryItemLink();

            Assert.IsTrue(itemDetailedInfoPage.CheckBackToProductsButton());
        }
    }
}
