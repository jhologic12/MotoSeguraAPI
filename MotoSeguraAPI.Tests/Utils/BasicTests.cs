using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MotoSeguraAPI.Controllers;
using MotoSeguraAPI.Dtos;
using MotoSeguraAPI.Services.Interfaces;

namespace MotoSeguraAPI.Tests
{
    public class BasicTests
    {
        [Fact]
        public void UserController_GetProfile_ValidUser_ReturnsOk()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var profileDto = new UserProfileDto
            {
                Id = userId,
                Name = "Test User",
                Email = "test@example.com"
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
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Simple_Test_Should_Pass()
        {
            Assert.True(1 + 1 == 2);
        }
    }
}