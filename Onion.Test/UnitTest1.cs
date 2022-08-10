using NUnit.Framework;
using Onion.Infrastructure;
using Onion.Service.Users;

namespace Onion.Test
{
    public class Tests
    {
        private IUsersService _userService;
        [SetUp]
        public void Setup()
        {
            var serviceProvider = Startup.ServiceProvider;
            //if (serviceProvider != null)
            //{
            //    _userService = serviceProvider.GetService();
            //}
        }

        [Test]
        public void UserServiceAdd_Test()
        {
            var user = new UserDTO
            {
                FirstName = "Mohammed",
                MiddleName = "Tanbir",
                LastName = "Hossain"
            };
            var actualResult = _userService.AddAsync(user);
            var expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
