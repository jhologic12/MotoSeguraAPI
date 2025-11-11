using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using MotoSeguraAPI;

namespace MotoSeguraAPI.Tests.Utils
{
    public abstract class ApiIntegrationTestBase : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly HttpClient Client;

        protected ApiIntegrationTestBase(WebApplicationFactory<Program> factory)
        {
            Client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }
    }
}