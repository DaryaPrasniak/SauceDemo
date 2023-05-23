using Core.Models;
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
        [Test, Category("Positive")]
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
        public void Test2()
        {
            UserBuilder builder = new UserBuilder();

            User invalidUser = builder
                .SetUserName("standard_gguser")
                .SetPassword("secret_sauce")
                .Build();

            LoginPage loginPage = new LoginPage(ChromeDriver, true);
            loginPage.IncorrectLogin(invalidUser);

            Assert.IsTrue(loginPage.CheckErrorMessage());
        }
    }
}
