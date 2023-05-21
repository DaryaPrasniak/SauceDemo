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
        [Test, Category("Positive")]
        public void Test1()
        {
            string userName = "standard_user";
            string password = "secret_sauce";
            string firstName = "John";
            string lastName = "Smith";
            string zipCode = "123456";
            var expectedCompleteMessage = "Thank you for your order!";

            LoginPage
               .SuccessfulLogin(userName, password)
               .ClickAddToCartButtonForBackpack()
               .ClickShoppingCartLink()
               .ClickCheckoutButton()
               .CorrectInputUserInfo(firstName, lastName, zipCode)
               .ClickFinishButton();           

            Assert.That(CheckoutCompletePage.CheckCompleteMessage, Is.EqualTo(expectedCompleteMessage));
        }

        [Test, Category("Negative")]
        public void Test2()
        {
            string userName = "standard_user";
            string password = "secret_sauce";
            string firstName = "John";
            string lastName = "Smith";

            LoginPage
               .SuccessfulLogin(userName, password)
               .ClickAddToCartButtonForBackpack()
               .ClickShoppingCartLink()
               .ClickCheckoutButton()
               .IncorrectInputUserInfo(firstName, lastName);

            Assert.IsTrue(CheckoutYourInfoPage.CheckCartErrorMessage());
        }
    }
}
