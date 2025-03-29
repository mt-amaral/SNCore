
using Admin.Domain.Entities;

namespace Admin.Domain.Account

{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string name, string password);
        Task<bool> ValidatePasswordAsync(User user, string password);
        Task<bool> UserExists(string name);
        Task<string> GenerateTokenAsync(Guid id, string name);
        Task<User?> GetUserByName(string name);
    }
}