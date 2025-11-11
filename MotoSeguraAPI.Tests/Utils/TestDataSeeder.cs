using MotoSeguraAPI.Data;
using MotoSeguraAPI.Models;
using System;
using System.Collections.Generic;

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

            var trayectos = new List<Trayecto>
            {
                new Trayecto
                {
                    Id = Guid.NewGuid(),
                    FechaInicio = DateTime.Now.AddMinutes(-20),
                    FechaFin = DateTime.Now,
                    ModoConduccion = "Normal",
                    DistanciaMetros = 1500,
                    TiempoSegundos = 1200,
                    VelocidadPromedio = 45,
                    AceleracionPromedio = 1.5,
                    FrenadasFuertes = 1,
                    GirosBruscos = 0,
                    ExcesoVelocidad = 0,
                    UserId = userId
                }
            };

            context.Users.Add(user);
            context.Trayectos.AddRange(trayectos);
            context.SaveChanges();
        }
    }
}