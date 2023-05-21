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
            string userName = "standard_user";
            string password = "secret_sauce";

            LoginPage loginPage = new LoginPage(ChromeDriver);
            LoginPage
            .SuccessfulLogin(userName, password);             

            Assert.IsTrue(InventoryPage.CheckInventoryItemsOnThePage());  
        }

        [Test, Category("Negative")]
        public void Test2()
        {
            string userName = "standard_user";
            string password = "secret_sauce123";

            LoginPage loginPage = new LoginPage(ChromeDriver);
            LoginPage
            .IncorrectLogin(userName, password);

            Assert.IsTrue(LoginPage.CheckErrorMessage());
        }
    }
}
