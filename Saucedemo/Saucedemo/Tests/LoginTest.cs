using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saucedemo.Tests
{
    internal class LoginTest: BaseTest
    {
        [Test]
        public void Test1()
        {
            string userName = "standard_user";
            string password = "secret_sauce";

            LoginPage.InputUserName(userName);
            LoginPage.InputPassword(password);
            LoginPage.ClickLoginButton();

            Assert.IsTrue(InventoryPage.CheckInventoryItemsOnThePage());  
        }
    }
}
