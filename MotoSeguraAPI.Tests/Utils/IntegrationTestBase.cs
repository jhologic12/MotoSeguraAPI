using Microsoft.EntityFrameworkCore;
using MotoSeguraAPI.Data;

namespace MotoSeguraAPI.Tests.Utils
{
    public abstract class IntegrationTestBase : IDisposable
    {
        protected readonly ApplicationDbContext Context;

        protected IntegrationTestBase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Aisla cada test
                .Options;

            Context = new ApplicationDbContext(options);

            // Seed de datos simulados
            TestDataSeeder.Seed(Context);
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}