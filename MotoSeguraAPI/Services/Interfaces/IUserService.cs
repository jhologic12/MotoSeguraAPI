using System.Security.Claims;
using MotoSeguraApi.Dtos;
using MotoSeguraAPI.Models;

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