
using Admin.Domain.Entities;

namespace Admin.Domain.Interfaces;

public interface IUserRepository
{
    Task Create(User entity);
}
