using Admin.Domain.Account;
using Admin.Shared.Response.Account;
using AutoMapper;

namespace Admin.Application.Mappings;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UsersResponse>();
    }

}