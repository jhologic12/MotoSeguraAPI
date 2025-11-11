using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MotoSeguraAPI.Controllers;
using MotoSeguraAPI.Data;
using MotoSeguraAPI.Models;
using MotoSeguraAPI.Services.Interfaces;
using MotoSeguraApi.Dtos;
using AutoMapper;

namespace MotoSeguraAPI.Tests.Controllers
{
    public class TrayectoControllerTests
    {
        [Fact]
        public void RegistrarTrayecto_ValidUser_ReturnsCreated()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var trayectoDto = new TrayectoDto { FechaInicio = DateTime.Now, ModoConduccion = "Normal" };

            var mockContext = new Mock<ApplicationDbContext>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<TrayectoController>>();
            var mockUserService = new Mock<IUserService>();

            mockUserService.Setup(s => s.FindById(userId)).Returns(new User { Id = userId, Email = "test@example.com" });
            mockMapper.Setup(m => m.Map<Trayecto>(trayectoDto)).Returns(new Trayecto { FechaInicio = trayectoDto.FechaInicio, ModoConduccion = trayectoDto.ModoConduccion });

            var controller = new TrayectoController(mockContext.Object, mockMapper.Object, mockLogger.Object, mockUserService.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                    }))
                }
            };

            // Act
            var result = controller.RegistrarTrayecto(trayectoDto);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdResult.StatusCode);
        }
    }
}