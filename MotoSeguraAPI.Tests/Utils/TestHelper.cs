using System.Security.Claims;
using MotoSeguraAPI.Dtos;

namespace MotoSeguraAPI.Tests.Utils
{
    public static class TestHelper
    {
        public static ClaimsPrincipal FakeUserPrincipal(Guid userId) =>
            new(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            }));

        public static UserProfileDto FakeUserProfile(Guid? id = null) =>
            new()
            {
                Id = id ?? Guid.NewGuid(),
                Name = "Jhon Ospino",
                Email = "jaofdev1@yopmail.com"
            };

        public static TrayectoDto FakeTrayectoDto() =>
            new()
            {
                FechaInicio = DateTime.UtcNow,
                FechaFin = DateTime.UtcNow.AddMinutes(15),
                ModoConduccion = "Normal",
                DistanciaRecorridaKm = 1.2,
                VelocidadPromedioKmH = 35.5,
                VelocidadMaximaKmH = 60.0
            };

        // ✅ ELIMINAR FakeTrayecto que usa tipos complejos
    }
}