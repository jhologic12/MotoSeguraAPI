using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using MotoSeguraAPI.Dtos;
using MotoSeguraAPI.Data;
using MotoSeguraAPI.Models;
using MotoSeguraAPI.Services.Interfaces;

namespace MotoSeguraAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User? FindById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public bool Exists(Guid id)
        {
            return _context.Users.Any(u => u.Id == id);
        }


        public UserProfileDto? GetProfile(ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdClaim, out var userId))
                return null;

            var entity = FindById(userId);
            if (entity == null)
                return null;

            return new UserProfileDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email
            };
        }

    }
}