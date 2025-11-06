using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using MotoSeguraAPI.Controllers;
using MotoSeguraAPI.DTOs;
using MotoSeguraAPI.Models;
using MotoSeguraAPI.Data;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Text.Json;
namespace MotoSeguraAPI.Tests.Controllers
{
    public class HelmetControllerTests
    {
        [Fact]
        public async Task ValidateHelmet_ValidRequest_ReturnsOk()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MotoSeguraTestDB")
                .Options;

            var context = new ApplicationDbContext(options);

            var validatorMock = new Mock<IValidator<HelmetValidationRequest>>();
            validatorMock.Setup(v => v.ValidateAsync(It.IsAny<HelmetValidationRequest>(), default))
                .ReturnsAsync(new ValidationResult());

            var controller = new HelmetController(context, validatorMock.Object);

            var request = new HelmetValidationRequest
            {
                Name = "Jhon",
                HelmetType = "Integral"
            };

            // Act
            var result = await controller.ValidateHelmet(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<HelmetValidationResponse>(okResult.Value);
            Assert.Equal("Jhon", response.Name);
            Assert.Equal("Integral", response.HelmetType);
            Assert.True(response.HelmetValidated);
        }





        // caso datos incorrectos

        [Fact]
        public async Task ValidateHelmet_InvalidHelmetType_ReturnsBadRequest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("MotoSeguraTestDB_Invalid")
                .Options;

            var context = new ApplicationDbContext(options);

            var validationFailures = new List<ValidationFailure>
    {
        new ValidationFailure("HelmetType", "El tipo de casco no es válido.")
    };

            var validatorMock = new Mock<IValidator<HelmetValidationRequest>>();
            validatorMock.Setup(v => v.ValidateAsync(It.IsAny<HelmetValidationRequest>(), default))
                .ReturnsAsync(new ValidationResult(validationFailures));

            var controller = new HelmetController(context, validatorMock.Object);

            var request = new HelmetValidationRequest
            {
                Name = "Jhon",
                HelmetType = "CascoDeCartón"
            };

            // Act
            var result = await controller.ValidateHelmet(request);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);

            var json = JsonSerializer.Serialize(badRequest.Value);
            var root = JsonDocument.Parse(json).RootElement;

            Assert.Equal("Validación fallida", root.GetProperty("Mensaje").GetString());

            var errores = root.GetProperty("Errores").EnumerateArray();
            var found = errores.Any(e =>
                e.GetProperty("Campo").GetString() == "HelmetType" &&
                e.GetProperty("Error").GetString() == "El tipo de casco no es válido.");

            Assert.True(found);
        }


    }
}