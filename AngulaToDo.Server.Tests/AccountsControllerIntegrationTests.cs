using AngulaToDo.Server.Controllers;
using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using AngulaToDo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Moq;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using AngulaToDo.Server.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Net;

namespace AngulaToDo.Server.Tests
{
    public class AccountsControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient Client;

        public AccountsControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            Client = factory.CreateClient();
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
    }
}