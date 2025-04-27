
using Admin.Domain.Account;
using Admin.Shared.Request.Account;
using Admin.Shared.Response;

namespace Admin.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User?>> GetAll();
    
}
