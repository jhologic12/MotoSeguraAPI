using MotoSeguraAPI.Dtos;


namespace MotoSeguraAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(UserRegisterDto dto);
        Task<string?> LoginAsync(UserLoginDto dto);
    }
}