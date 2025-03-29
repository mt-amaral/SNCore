using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Admin.Domain.Account;
using Admin.Domain.Entities;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Identity
{
    public class Authenticate : IAuthenticate
    {
        private readonly IConfiguration _configuration;
        private readonly DbSet<User> _dbSet;

        public Authenticate(ApplicationDbContext context, IConfiguration configuration)
        {
            _dbSet = context.Set<User>();
            _configuration = configuration;

        }

        public async Task<bool> AuthenticateAsync(string name, string password)
        {
            var user = await _dbSet.FirstOrDefaultAsync(x => x.Name == name.ToLower());
            if (user == null) return false;

            byte[] computedHash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                user.PasswordSalt,                
                user.Iterations,                  
                HashAlgorithmName.SHA512,         
                64                                
            );

            return CryptographicOperations.FixedTimeEquals(computedHash, user.PasswordHash);
        }
        
        public async Task<bool> ValidatePasswordAsync(User user, string password)
        {
            byte[] computedHash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                user.PasswordSalt,
                user.Iterations,
                HashAlgorithmName.SHA512,
                64
            );
    
            return CryptographicOperations.FixedTimeEquals(computedHash, user.PasswordHash);
        }

        public async Task<string> GenerateTokenAsync(Guid id, string name)
        {
            // 1. Configuração das Claims
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("name", name.ToLower()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            // 2. Geração da chave segura com PBKDF2
            byte[] secretKey = await DeriveKeyAsync(
                _configuration["jwt:SecurityKey"] ?? throw new InvalidOperationException("Chave JWT não configurada"),
                Encoding.UTF8.GetBytes(_configuration["jwt:Salt"] ?? "default-salt-replace-me")
            );

            // 3. Configuração do Token
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(secretKey),
                SecurityAlgorithms.HmacSha256Signature // Algoritmo mais forte
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["jwt:Issuer"],
                audience: _configuration["jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(4), // Tempo de vida mais seguro (4h em vez de 7 dias)
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        private async Task<byte[]> DeriveKeyAsync(string masterKey, byte[] salt)
        {
            const int iterations = 100_000;
            const int keySize = 32; // 256 bits para HMAC-SHA256

            return await Task.Run(() => 
                Rfc2898DeriveBytes.Pbkdf2(
                    Encoding.UTF8.GetBytes(masterKey),
                    salt,
                    iterations,
                    HashAlgorithmName.SHA256,
                    keySize
                )
            );
        }
        

        public async Task<User?> GetUserByName(string name)
        {
            return await _dbSet.Where(x => x.Name.ToLower() == name.ToLower()).AsNoTracking().FirstOrDefaultAsync();
        }

        
        public async Task<bool> UserExists(string name)
        {
            var user = await _dbSet.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
            if (user is null)
                return false;
            
            return true;
        }
    }
}