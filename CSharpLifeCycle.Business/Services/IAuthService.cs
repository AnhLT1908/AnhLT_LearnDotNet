using CSharpLifeCycle.DTOs;
using CSharpLifeCycle.Models;

namespace CSharpLifeCycle.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(string username, string password, string? fullName);
        Task<AuthResponse?> LoginAsync(string username, string password);
        Task<User?> GetByUsernameAsync(string username);
    }
}