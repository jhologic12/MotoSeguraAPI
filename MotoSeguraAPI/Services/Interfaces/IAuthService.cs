using MotoSeguraApi.Dtos;
using MotoSeguraAPI.DTOs;

namespace MotoSeguraAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(UserRegisterDto dto);
        Task<string?> LoginAsync(UserLoginDto dto);
    }
}