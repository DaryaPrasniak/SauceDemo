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
            string userName = "standard_user";
            string password = "secret_sauce";

            var itemDetailedInfoPage = new LoginPage(ChromeDriver, true)
                .SuccessfulLogin(userName, password)
                .ClickFirstInventoryItemLink();

            Assert.IsTrue(itemDetailedInfoPage.CheckBackToProductsButton());
        }

        [Test]
        public void Test2()
        {
            string userName = "standard_user";
            string password = "secret_sauce";

            var itemDetailedInfoPage = new LoginPage(ChromeDriver, true)
               .SuccessfulLogin(userName, password)
               .ClickSecondInventoryItemLink();

            Assert.IsTrue(itemDetailedInfoPage.CheckBackToProductsButton());
        }

        [Test]
        public void Test3()
        {
            string userName = "standard_user";
            string password = "secret_sauce";

            var itemDetailedInfoPage = new LoginPage(ChromeDriver, true)
               .SuccessfulLogin(userName, password)
               .ClickThirdInventoryItemLink();

            Assert.IsTrue(itemDetailedInfoPage.CheckBackToProductsButton());
        }
    }
}
