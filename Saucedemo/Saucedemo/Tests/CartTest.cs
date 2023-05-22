using NUnit.Framework;
using Saucedemo.Pages;
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
            var user = GetUser();

            var cartPage = new LoginPage(ChromeDriver, true)
               .SuccessfulLogin(user)
               .ClickAddToCartButtonForBackpack()
               .ClickShoppingCartLink();

            var itemsAmount = cartPage.CheckItemInTheCart();

            Assert.AreEqual(itemsAmount, 1);           
        }
    }
}
