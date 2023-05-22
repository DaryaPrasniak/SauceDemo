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
            var user = GetUser();

            LoginPage loginPage = new LoginPage(ChromeDriver, true);         

            var inventoryPage = loginPage.SuccessfulLogin(user);  

            Assert.IsTrue(inventoryPage.CheckInventoryItemsOnThePage());  
        }

        [Test, Category("Negative")]
        public void Test2()
        {
            var invalidUser = GetInvalidUser();

            LoginPage loginPage = new LoginPage(ChromeDriver, true);
            loginPage.IncorrectLogin(invalidUser);

            Assert.IsTrue(loginPage.CheckErrorMessage());
        }
    }
}
