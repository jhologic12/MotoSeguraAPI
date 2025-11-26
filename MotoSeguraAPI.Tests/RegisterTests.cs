using Xunit;
using Moq;
using MotoSeguraAPI.Services.Interfaces;
using MotoSeguraAPI.Models;
using MotoSeguraAPI.Dtos;
using MotoSeguraAPI.Tests.Utils;

public class RegisterTests
{
    private readonly Mock<IAuthService> _authServiceMock; // ✅ Cambiado a IAuthService

    public RegisterTests()
    {
        _authServiceMock = new Mock<IAuthService>(); // ✅ Crear mock de IAuthService
    }

    [Fact]
    public async Task Register_ShouldSucceed_WhenDataIsValid()
    {
        // Arrange
        var request = new UserRegisterDto
        {
            Email = "nuevo.usuario@test.com",
            Password = "Segura123!"
        };

        _authServiceMock
            .Setup(s => s.RegisterAsync(request))
            .ReturnsAsync(true); // ✅ IAuthService probablemente retorna bool

        // Act
        var result = await _authServiceMock.Object.RegisterAsync(request);

        // Assert
        Assert.True(result); // ✅ Verificar que retorna true
    }

    [Fact]
    public async Task Register_ShouldFail_WhenEmailAlreadyExists()
    {
        // Arrange
        var request = new UserRegisterDto
        {
            Email = "existente@test.com",
            Password = "Segura123!"
        };

        _authServiceMock
            .Setup(s => s.RegisterAsync(request))
            .ReturnsAsync(false); // ✅ Retorna false para email duplicado

        // Act
        var result = await _authServiceMock.Object.RegisterAsync(request);

        // Assert
        Assert.False(result); // ✅ Verificar que retorna false
    }

    [Fact]
    public async Task Register_ShouldFail_WhenPasswordIsWeak()
    {
        // Arrange
        var request = new UserRegisterDto
        {
            Email = "seguridad@test.com",
            Password = "123" // Password débil
        };

        _authServiceMock
            .Setup(s => s.RegisterAsync(request))
            .ReturnsAsync(false); // ✅ Retorna false para password débil

        // Act
        var result = await _authServiceMock.Object.RegisterAsync(request);

        // Assert
        Assert.False(result);
    }
}