
using Admin.Domain.Account;

namespace Admin.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
}
