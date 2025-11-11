using Moq;
using Microsoft.Extensions.Logging;
using AutoMapper;
using MotoSeguraAPI.Data;
using MotoSeguraAPI.Services.Interfaces;

namespace MotoSeguraAPI.Tests.Utils
{
    public static class TestMocks
    {
        public static Mock<ApplicationDbContext> DbContextMock() => new Mock<ApplicationDbContext>();

        public static Mock<IMapper> MapperMock() => new Mock<IMapper>();

        public static Mock<ILogger<T>> LoggerMock<T>() where T : class => new Mock<ILogger<T>>();

        public static Mock<IUserService> UserServiceMock() => new Mock<IUserService>();

        public static Mock<IAuthService> AuthServiceMock() => new Mock<IAuthService>();

        public static Mock<ITrayectoService> TrayectoServiceMock() => new Mock<ITrayectoService>();

        // Puedes agregar más servicios aquí según crezcan tus controladores
    }
}