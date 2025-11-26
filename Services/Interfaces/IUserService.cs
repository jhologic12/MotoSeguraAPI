using System.Security.Claims;
using MotoSeguraAPI.Models;
using MotoSeguraAPI.Dtos;

namespace MotoSeguraAPI.Services.Interfaces
{
    public interface IUserService
    {
        User? FindById(Guid id);
        Task<User?> FindByEmailAsync(string email);
        bool Exists(Guid id);
        UserProfileDto? GetProfile(ClaimsPrincipal user);

    }
}