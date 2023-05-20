using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.Tests
{
    internal class CheckoutTest: BaseTest
    {
        [Test]
        public void Test1()
        {
            string userName = "standard_user";
            string password = "secret_sauce";
            string firstName = "John";
            string lastName = "Smith";
            string zipCode = "123456";
            var expectedCompleteMessage = "Thank you for your order!";

            LoginPage.Login(userName, password);
            InventoryPage.ClickAddToCartButtonForBackpack();
            InventoryPage.ClickShoppingCartLink();
            CartPage.ClickCheckoutButton();
            CheckoutYourInfoPage.InputUserInfo(firstName, lastName, zipCode);
            CheckoutYourInfoPage.ClickContinueButton();
            CheckoutOverviewPage.ClickFinishButton();

            Assert.That(CheckoutCompletePage.CheckCompleteMessage, Is.EqualTo(expectedCompleteMessage));
        }
    }
}
