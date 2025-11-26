using MotoSeguraAPI.Data;
using MotoSeguraAPI.Models;
using System;
using System.Collections.Generic;
using MotoSeguraAPI.Dtos; 

namespace MotoSeguraAPI.Tests.Utils
{
    public static class TestDataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                Name = "Jhon Ospino",
                Email = "jaofdev1@yopmail.com",
                PasswordHash = "hashed-password"
            };

            // ✅ SOLO crear usuario - evitar problemas con propiedades complejas
            context.Users.Add(user);
            context.SaveChanges();
        }

        /// <summary>
        /// Semilla básica solo con usuario (sin trayectos)
        /// </summary>
        public static User SeedBasicUser(ApplicationDbContext context)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Test User",
                Email = "test@example.com",
                PasswordHash = "hashed-password"
            };

            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }
    }
}