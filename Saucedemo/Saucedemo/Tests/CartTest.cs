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
            string userName = "standard_user";
            string password = "secret_sauce";

            var cartPage = new LoginPage(ChromeDriver, true)
               .SuccessfulLogin(userName, password)
               .ClickAddToCartButtonForBackpack()
               .ClickShoppingCartLink();

            var itemsAmount = cartPage.CheckItemInTheCart();

            Assert.AreEqual(itemsAmount, 1);           
        }
    }
}
