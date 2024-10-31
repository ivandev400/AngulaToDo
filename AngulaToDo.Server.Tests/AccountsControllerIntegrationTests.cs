using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.EntityFrameworkCore;
using AngulaToDo.Server.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using System.Net;

namespace AngulaToDo.Server.Tests
{
    public class AccountsControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient Client;

        public AccountsControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            Client = CreateAndReturnFactory(factory);
        }

        [Fact]
        public async System.Threading.Tasks.Task Register_Returns_Created_When_Successful()
        {
            var userForRegistration = new UserForRegistrationDto
            {
                UserName = "testUser",
                Email = "test.user@gmail.com",
                Password = "SomePass1234!",
                ConfirmPassword = "SomePass1234!"
            };

            var response = await Client.PostAsJsonAsync("/api/accounts/register", userForRegistration);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        private HttpClient CreateAndReturnFactory(WebApplicationFactory<Program> factory)
        {
            return factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType == typeof(DbContextOptions<ToDoContext>));
                        if (descriptor != null)
                        {
                            services.Remove(descriptor);
                        }

                        services.AddDbContext<ToDoContext>(options =>
                        {
                            options.UseInMemoryDatabase("InMemoryDbForTesting");
                        });

                        services.AddIdentity<User, IdentityRole>()
                            .AddEntityFrameworkStores<ToDoContext>()
                            .AddDefaultTokenProviders();
                    });
                })
                .CreateClient();
        }
    }
}