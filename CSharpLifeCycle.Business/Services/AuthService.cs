using CSharpLifeCycle.Data;
using CSharpLifeCycle.DTOs;
using CSharpLifeCycle.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CSharpLifeCycle.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public async Task<User?> RegisterAsync(string username, string password, string? fullName)
        {
            if (await _db.Users.AnyAsync(u => u.Username == username)) return null;

            var user = new User
            {
                Username = username,
                Password = password,
                FullName = fullName,
                Role = "User"
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<AuthResponse?> LoginAsync(string username, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            if (user == null) return null;

            var jwtSection = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var expires = DateTime.UtcNow.AddMinutes(int.Parse(jwtSection["ExpiresInMinutes"]!));

            var token = new JwtSecurityToken(
                issuer: jwtSection["Issuer"],
                audience: jwtSection["Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthResponse
            {
                Token = jwt,
                Username = user.Username,
                Role = user.Role,
                ExpiresAt = expires
            };
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}