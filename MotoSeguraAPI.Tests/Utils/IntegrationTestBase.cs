using Microsoft.EntityFrameworkCore;
using MotoSeguraAPI.Data;
using MotoSeguraAPI.Models;
using MotoSeguraAPI.Dtos;

namespace MotoSeguraAPI.Tests.Utils
{
    public abstract class IntegrationTestBase : IDisposable
    {
        protected readonly ApplicationDbContext Context;

        protected IntegrationTestBase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            Context = new ApplicationDbContext(options);
            Context.Database.EnsureCreated();
            TestDataSeeder.Seed(Context);
        }

        protected void CleanDatabase()
        {
            if (Context.Trayectos != null)
                Context.Trayectos.RemoveRange(Context.Trayectos);
            Context.Users.RemoveRange(Context.Users);
            Context.SaveChanges();
        }

        protected User CreateTestUser(string email = "test@example.com", string name = "Test User")
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                PasswordHash = "hashed_password_test"
            };

            Context.Users.Add(user);
            Context.SaveChanges();
            return user;
        }

        // ✅ ELIMINAR CreateTestTrayecto - causa muchos problemas

        public void Dispose()
        {
            CleanDatabase();
            Context?.Dispose();
        }
    }
}