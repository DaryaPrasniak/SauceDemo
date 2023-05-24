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
        [AllureTms(name:"TMS-13")]
        [AllureTag(tags:"Smoke")]
        [AllureLink(url: "https://app.qase.io/project/SHARELANE")]      
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

        [Test, Category("Negative")]
        [Description("Detailed test description")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("FailedSuite")]
        [AllureSubSuite("GUI")]
        [AllureIssue(name: "TMS-42")]
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
