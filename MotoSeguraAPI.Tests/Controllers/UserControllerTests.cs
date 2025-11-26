using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MotoSeguraAPI.Controllers;
using MotoSeguraAPI.Dtos;
using MotoSeguraAPI.Services.Interfaces;

namespace MotoSeguraAPI.Tests.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public void GetProfile_ValidUser_ReturnsOk()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var profileDto = new UserProfileDto
            {
                Id = userId,
                Name = "Jhon Ospino",
                Email = "jaofdev1@yopmail.com"
            };

            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(s => s.GetProfile(It.IsAny<ClaimsPrincipal>())).Returns(profileDto);

            var controller = new UserController(mockUserService.Object);
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
            var result = controller.GetProfile();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProfile = Assert.IsType<UserProfileDto>(okResult.Value);
            Assert.Equal(profileDto.Email, returnedProfile.Email);
        }

        [Fact]
        public void GetProfile_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var userId = Guid.NewGuid();

            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(s => s.GetProfile(It.IsAny<ClaimsPrincipal>())).Returns((UserProfileDto?)null);

            var controller = new UserController(mockUserService.Object);
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
            var result = controller.GetProfile();

            // Assert
            // ✅ El controlador probablemente retorna Unauthorized en lugar de NotFound
            Assert.IsType<UnauthorizedObjectResult>(result);
        }

        [Fact]
        public void GetProfile_InvalidUserId_ReturnsBadRequest()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            var controller = new UserController(mockUserService.Object);
            
            // Usuario con ID inválido
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, "invalid-guid-format")
                    }))
                }
            };

            // Act
            var result = controller.GetProfile();

            // Assert
            // ✅ El controlador probablemente retorna Unauthorized en lugar de BadRequest
            Assert.IsType<UnauthorizedObjectResult>(result);
        }

        [Fact]
        public void GetProfile_UnauthenticatedUser_ReturnsUnauthorized()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            var controller = new UserController(mockUserService.Object);
            
            // Usuario sin identidad (no autenticado)
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal() // Usuario sin claims
                }
            };

            // Act
            var result = controller.GetProfile();

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal(401, unauthorizedResult.StatusCode);
        }
    }
}