using System;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Onion.Repository;
using Onion.Repository.Users;
using Onion.Service.Users;

namespace Onion.Test
{
    [SetUpFixture]
    public class Startup
    {
        internal static IServiceProvider ServiceProvider { get; set; }
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            ServiceProvider = ContainerBuilder();
        }
        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {

        }
        public IServiceProvider ContainerBuilder()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IUsersService, UsersService>(); ;
            services.AddDbContext<OnionCrudDBContext>();
            return services.BuildServiceProvider();
        }
    }
}
