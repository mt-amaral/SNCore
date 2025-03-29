using System.Security.Cryptography;
using System.Text;
using Admin.Application.Interfaces;
using Admin.Domain.Account;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Request.User;
using Admin.Shared.Response;
using Admin.Shared.Response.User;
using AutoMapper;


namespace Admin.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticate _authenticate;
    private readonly IMapper _mapper;
    public UserService(IMapper mapper, IUserRepository userRepository, IAuthenticate authenticate)
    {
        _authenticate = authenticate;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Response<LoginToken?>> Login(LoginRequest login)
    {
        var exist = await _authenticate.UserExists(login.Name);
        if (exist is false)
            return new Response<LoginToken?>(null, 409, "Usuario ou senha invalido");
        
        var result = await _authenticate.AuthenticateAsync(login.Name, login.Password);
        if (result is false)
            return new Response<LoginToken?>(null, 409, "Usuario ou senha invalido");
        
        var user = await _authenticate.GetUserByName(login.Name);
        if (user is null)
            return new Response<LoginToken?>(null, 409, "Usuario ou senha invalido");

        var token = await _authenticate.GenerateTokenAsync(user.UniqueId, user.Name);
        LoginToken response = new()
        {
            Id = user.UniqueId,
            Token = token,
        };
        return new Response<LoginToken?>(response, 200, "");
    }


    public async Task<Response<UserResponse?>> Create(NewUserRequest user)
    {
        var exist = await _authenticate.UserExists(user.Name);
        if (exist!)
            return new Response<UserResponse?>(null, 409, "Nome de Usuario Já existente");
        try
        {
            var entity = await CalculateHash(user);
            await _userRepository.Create(entity);
            return new Response<UserResponse?>(_mapper.Map<UserResponse>(entity), 201, "Usuario criado com sucesso");
        }
        catch (Exception ex)
        {
            throw new Exception("Erro na criação de usuario");
        }
    }



    private Task<User> CalculateHash(NewUserRequest userRequest)
    {
        const int iterations = 210_000; // Ajuste conforme hardware
        byte[] salt = RandomNumberGenerator.GetBytes(32); // Salt de 32 bytes
    
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(userRequest.Password),
            salt,
            iterations,
            HashAlgorithmName.SHA512,
            64 // Tamanho do hash (512 bits)
        );

        var entity = _mapper.Map<User>(userRequest);
        entity.ChangePassword(hash, salt, iterations);
        return Task.FromResult(entity);
    }
}