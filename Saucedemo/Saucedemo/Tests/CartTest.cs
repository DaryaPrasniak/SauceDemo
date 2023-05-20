using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.Tests
{
    internal class CartTest: BaseTest
    {
        [Test]
        public void Test1()
        {
            string userName = "standard_user";
            string password = "secret_sauce";

            LoginPage.Login(userName, password);
            InventoryPage.ClickAddToCartButtonForBackpack();
            InventoryPage.ClickShoppingCartLink();

            var itemsAmount = CartPage.CheckItemInTheCart();

            Assert.AreEqual(itemsAmount, 1);           
        }
    }
}
