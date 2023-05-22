using NUnit.Framework;
using Saucedemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.Tests
{
    internal class CheckoutTest: BaseTest
    {
        [Test, Category("Positive")]
        public void Test1()
        {
            var user = GetUser();

            var expectedCompleteMessage = "Thank you for your order!";

            var checkoutCompletePage = new LoginPage(ChromeDriver, true)
               .SuccessfulLogin(user)
               .ClickAddToCartButtonForBackpack()
               .ClickShoppingCartLink()
               .ClickCheckoutButton()
               .CorrectInputUserInfo(user)
               .ClickFinishButton();           

            Assert.That(checkoutCompletePage.CheckCompleteMessage, Is.EqualTo(expectedCompleteMessage));
        }

        [Test, Category("Negative")]
        public void Test2()
        {
            var user = GetUser();

            var checkoutYourInfoPage = new LoginPage(ChromeDriver, true)
               .SuccessfulLogin(user)
               .ClickAddToCartButtonForBackpack()
               .ClickShoppingCartLink()
               .ClickCheckoutButton()
               .IncorrectInputUserInfo(user);

            Assert.IsTrue(checkoutYourInfoPage.CheckCartErrorMessage());
        }
    }
}
