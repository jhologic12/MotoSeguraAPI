using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MotoSeguraAPI;
using MotoSeguraAPI.Data;
using MotoSeguraAPI.Services.Interfaces;
using Moq;
using MotoSeguraAPI.Dtos;
using MotoSeguraAPI.Models;
using System.Security.Claims;

namespace MotoSeguraAPI.Tests.Utils
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, configBuilder) =>
            {
                var testConfig = new Dictionary<string, string?>
                {
                    { "Jwt:Key", "supersecretkeywith32characters!!" },
                    { "Jwt:Issuer", "MotoSeguraAPI" },
                    { "Jwt:Audience", "MotoSeguraClient" },
                    { "ConnectionStrings:DefaultConnection", "InMemoryDb" },
                    { "Logging:LogLevel:Default", "Warning" }
                };

                configBuilder.AddInMemoryCollection(testConfig);
            });

            builder.ConfigureServices(services =>
            {
                // 🔧 ELIMINAR COMPLETAMENTE el proveedor PostgreSQL
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                if (dbContextDescriptor != null)
                    services.Remove(dbContextDescriptor);

                // 🔧 También eliminar ApplicationDbContext si está registrado
                var dbContextServiceDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(ApplicationDbContext));
                if (dbContextServiceDescriptor != null)
                    services.Remove(dbContextServiceDescriptor);

                // ✅ Registrar SOLO el proveedor InMemory
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("TestDb_" + Guid.NewGuid()));

                // 🔧 Mock de IUserService
                var userServiceMock = new Mock<IUserService>();
                userServiceMock.Setup(s => s.FindById(It.IsAny<Guid>()))
                    .Returns((Guid id) => 
                    {
                        var userType = typeof(User);
                        var user = Activator.CreateInstance(userType);
                        userType.GetProperty("Id")?.SetValue(user, id);
                        userType.GetProperty("Email")?.SetValue(user, "test@example.com");
                        userType.GetProperty("Name")?.SetValue(user, "Test User");
                        return user as User;
                    });

                userServiceMock.Setup(s => s.GetProfile(It.IsAny<ClaimsPrincipal>()))
                    .Returns(new UserProfileDto { Id = Guid.NewGuid(), Email = "test@example.com", Name = "Test User" });

                // Reemplazar servicio real por mock
                var userServiceDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(IUserService));
                if (userServiceDescriptor != null)
                {
                    services.Remove(userServiceDescriptor);
                    services.AddScoped<IUserService>(_ => userServiceMock.Object);
                }

                // ✅ NO usar EnsureCreated() aquí - puede causar conflictos
                using var scope = services.BuildServiceProvider().CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                
                // Solo seeding básico
                if (!db.Users.Any())
                {
                    db.Users.Add(new User 
                    { 
                        Id = Guid.NewGuid(), 
                        Name = "Test User", 
                        Email = "test@example.com",
                        PasswordHash = "hashed"
                    });
                    db.SaveChanges();
                }
            });
        }
    }
}