using NUnit.Framework;
using NUnit.Framework.Internal;
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

            LoginPage.Login(userName, password);
            InventoryPage.ClickFirstInventoryItemLink();

            Assert.IsTrue(ItemDetailedInfoPage.CheckBackToProductsButton());
        }

        [Test]
        public void Test2()
        {
            string userName = "standard_user";
            string password = "secret_sauce";

            LoginPage.Login(userName, password);
            InventoryPage.ClickSecondInventoryItemLink();

            Assert.IsTrue(ItemDetailedInfoPage.CheckBackToProductsButton());
        }

        [Test]
        public void Test3()
        {
            string userName = "standard_user";
            string password = "secret_sauce";

            LoginPage.Login(userName, password);
            InventoryPage.ClickThirdInventoryItemLink();

            Assert.IsTrue(ItemDetailedInfoPage.CheckBackToProductsButton());
        }
    }
}
