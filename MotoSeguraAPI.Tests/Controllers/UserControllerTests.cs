using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MotoSeguraAPI.Controllers;
using MotoSeguraAPI.Tests.Utils;
using MotoSeguraApi.Dtos;

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

            var mockUserService = TestMocks.UserServiceMock();
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
    }
}