using Admin.Domain.Entities;
using Admin.Shared.Request.User;
using Admin.Shared.Response.User;
using AutoMapper;

namespace Admin.Application.Mappings;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<NewUserRequest, User>();
        CreateMap<User, UserResponse>();

    }
}


