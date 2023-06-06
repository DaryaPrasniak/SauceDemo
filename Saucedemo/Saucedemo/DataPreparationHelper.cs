using Core.Models;

namespace Saucedemo
{
    public static class DataPreparationHelper
    {
        public static User GetUser()
        {
            return new User()
            {
                UserName = "standard_user",
                Password = "secret_sauce",
                FirstName = "John",
                LastName = "Smith",
                ZipCode = "123456"
            };
        }

        public static User GetInvalidUser()
        {
            var user = GetUser();
            user.UserName = "standard_gguser";

            return user;
        }
    }
}
