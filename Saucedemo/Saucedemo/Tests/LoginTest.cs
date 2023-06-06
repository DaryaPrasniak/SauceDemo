using Allure.Commons;
using Core.Models;
using NUnit.Allure.Attributes;
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
    internal class LoginTest: BaseTest
    {
        [Test (Description = "Successful login")]
        [Description("Detailed test description")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue(name:"TMS-46")]
        [AllureTms(name:"TMS-43")]
        [AllureTag(tags:"Smoke")]
        [AllureLink(url: "https://app.qase.io/public/report/db59e4c48b2469ccdaffa44f1ee7d77ad3527e8a")]      
        public void Test1()
        {
            UserBuilder builder = new UserBuilder();

            User user = builder
                .SetUserName("standard_user")
                .SetPassword("secret_sauce")
                .Build();

            LoginPage loginPage = new LoginPage(ChromeDriver, true);         

            var inventoryPage = loginPage.SuccessfulLogin(user);  

            Assert.IsTrue(inventoryPage.CheckInventoryItemsOnThePage());  
        }

        [Test (Description = "Incorrect login"), Category("Negative")]
        [Description("Detailed test description")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("FailedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue(name: "TMS-42")]
        [AllureTms(name: "TMS-45")]
        [AllureTag(tags: "Regression")]
        [AllureLink(url: "https://app.qase.io/public/report/db59e4c48b2469ccdaffa44f1ee7d77ad3527e8a")]
        public void Test2()
        {
            UserBuilder builder = new UserBuilder();

            User invalidUser = builder
                .SetUserName("standard_gguser")
                .SetPassword("secret_sauce")
                .Build();

            LoginPage loginPage = new LoginPage(ChromeDriver, true);
            loginPage.IncorrectLogin(invalidUser);

            Assert.IsFalse(loginPage.CheckErrorMessage());
        }
    }
}
