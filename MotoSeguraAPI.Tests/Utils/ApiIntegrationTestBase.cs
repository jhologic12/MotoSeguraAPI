using Microsoft.AspNetCore.Mvc.Testing;   
using Microsoft.AspNetCore.Hosting;       
using Xunit;
using MotoSeguraAPI;                      
using MotoSeguraAPI.Dtos; 
using System.Net.Http.Json; // ✅ Agregar este using para JsonContent

namespace MotoSeguraAPI.Tests.Utils
{
    public abstract class ApiIntegrationTestBase : IClassFixture<CustomWebApplicationFactory>
    {
        protected readonly HttpClient Client;
        protected readonly CustomWebApplicationFactory Factory;

        protected ApiIntegrationTestBase(CustomWebApplicationFactory factory)
        {
            Factory = factory;
            Client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false,
                BaseAddress = new Uri("https://localhost")
            });
        }

        /// <summary>
        /// Helper method para crear requests HTTP con headers comunes
        /// </summary>
        protected HttpRequestMessage CreateRequest(HttpMethod method, string url, object? content = null)
        {
            var request = new HttpRequestMessage(method, url);
            
            if (content != null)
            {
                request.Content = JsonContent.Create(content);
            }
            
            return request;
        }

        /// <summary>
        /// Helper method para crear requests autenticados con JWT
        /// </summary>
        protected HttpRequestMessage CreateAuthenticatedRequest(HttpMethod method, string url, string token, object? content = null)
        {
            var request = CreateRequest(method, url, content);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return request;
        }

        /// <summary>
        /// Helper method para deserializar respuestas JSON
        /// </summary>
        protected async Task<T?> DeserializeResponse<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(content, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        /// <summary>
        /// Helper method para verificar respuestas exitosas
        /// </summary>
        protected void AssertSuccessfulResponse(HttpResponseMessage response) // ✅ Quitado async
        {
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", 
                response.Content.Headers.ContentType?.ToString());
        }

        /// <summary>
        /// Helper method para verificar respuestas de error
        /// </summary>
        protected async Task AssertErrorResponse(HttpResponseMessage response, System.Net.HttpStatusCode expectedStatusCode)
        {
            Assert.Equal(expectedStatusCode, response.StatusCode);
            var errorContent = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrEmpty(errorContent));
        }
    }
}