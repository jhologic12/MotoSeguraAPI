using Xunit;
using Moq;
using MotoSeguraAPI.Dtos;
using MotoSeguraAPI.Services.Interfaces;
using MotoSeguraAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MotoSeguraAPI.Tests.Utils
{
    public class RegisterEndpointTests
    {
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly AuthController _controller;

        public RegisterEndpointTests()
        {
            _authServiceMock = new Mock<IAuthService>();
            _controller = new AuthController(_authServiceMock.Object);
        }

        [Fact]
        public async Task Register_User_Success()
        {
            // Arrange
            var dto = new UserRegisterDto
            {
                Email = "test@example.com",
                Password = "SecurePassword123"
                // ❌ ELIMINADO PhoneNumber
            };

            _authServiceMock
                .Setup(s => s.RegisterAsync(dto))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.Register(dto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Usuario registrado correctamente.", okResult.Value);
        }

        // ... otros tests sin PhoneNumber ...
    }
}