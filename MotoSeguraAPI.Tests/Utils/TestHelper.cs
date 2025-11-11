using System.Security.Claims;
using MotoSeguraAPI.Models;
using MotoSeguraApi.Dtos;

namespace MotoSeguraAPI.Tests.Utils
{
    public static class TestHelper
    {
        public static ClaimsPrincipal FakeUserPrincipal(Guid userId)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            }));
        }

        public static User FakeUser(Guid? id = null)
        {
            return new User
            {
                Id = id ?? Guid.NewGuid(),
                Name = "Jhon Ospino",
                Email = "jaofdev1@yopmail.com",
                PasswordHash = "hashed-password"
            };
        }

        public static UserProfileDto FakeUserProfile(Guid? id = null)
        {
            return new UserProfileDto
            {
                Id = id ?? Guid.NewGuid(),
                Name = "Jhon Ospino",
                Email = "jaofdev1@yopmail.com"
            };
        }

        public static TrayectoDto FakeTrayectoDto()
        {
            return new TrayectoDto
            {
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now.AddMinutes(15),
                ModoConduccion = "Normal",
                DistanciaMetros = 1200,
                TiempoSegundos = 900,
                VelocidadPromedio = 35.5,
                AceleracionPromedio = 1.2,
                FrenadasFuertes = 2,
                GirosBruscos = 1,
                ExcesoVelocidad = 0
            };
        }

        public static Trayecto FakeTrayecto(Guid? userId = null)
        {
            return new Trayecto
            {
                Id = Guid.NewGuid(),
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now.AddMinutes(15),
                ModoConduccion = "Normal",
                DistanciaMetros = 1200,
                TiempoSegundos = 900,
                VelocidadPromedio = 35.5,
                AceleracionPromedio = 1.2,
                FrenadasFuertes = 2,
                GirosBruscos = 1,
                ExcesoVelocidad = 0,
                UserId = userId ?? Guid.NewGuid()
            };
        }
    }
}