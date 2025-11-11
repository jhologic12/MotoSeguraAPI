using Microsoft.EntityFrameworkCore;
using MotoSeguraAPI.Data;
using MotoSeguraAPI.Models;
using MotoSeguraAPI.Services.Interfaces;
using MotoSeguraAPI.Services;
using MotoSeguraApi.Dtos;

namespace MotoSeguraAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwt;

        public AuthService(ApplicationDbContext context, JwtService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public async Task<bool> RegisterAsync(UserRegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return false;

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string?> LoginAsync(UserLoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            return _jwt.GenerateToken(user);
        }
    }
}