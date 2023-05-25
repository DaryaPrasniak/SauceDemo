using Allure.Commons;
using NUnit.Allure.Attributes;
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
        [Test(Description = "Successful checkout")]
        [Description("Detailed test description")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue(name: "TMS-46")]
        [AllureTms(name: "TMS-44")]
        [AllureTag(tags: "Smoke")]
        [AllureLink(url: "https://app.qase.io/public/report/f482b13c702ded708b1bbe22b472f42d6e5220cc")]
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

        [Test(Description = "Incorrect checkout")]
        [Description("Detailed test description")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("User")]
        [AllureSuite("FailedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue(name: "TMS-48")]
        [AllureTms(name: "TMS-45")]
        [AllureTag(tags: "Smoke")]
        [AllureLink(url: "https://app.qase.io/public/report/f482b13c702ded708b1bbe22b472f42d6e5220cc")]
        public void Test2()
        {
            var user = GetUser();

            var checkoutYourInfoPage = new LoginPage(ChromeDriver, true)
               .SuccessfulLogin(user)
               .ClickAddToCartButtonForBackpack()
               .ClickShoppingCartLink()
               .ClickCheckoutButton()
               .IncorrectInputUserInfo(user);

            Assert.IsFalse(checkoutYourInfoPage.CheckCartErrorMessage());
        }
    }
}
