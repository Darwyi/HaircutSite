using HaircutSite.Application.Interfaces.Auth;
using HaircutSite.Application.Interfaces.Services;
using HaircutSite.Domain.Interfaces;
using HaircutSite.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace HaircutSite.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashRepository _passwordHasher;
    private readonly IJwtRepository _jwtProvider;

    public UserService(IUserRepository userRepository, IPasswordHashRepository passwordHasher, IJwtRepository jwtProvider)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
        _jwtProvider = jwtProvider;
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        if (users == null)
            throw new Exception("Users not found");

        return users;
    }

    public async Task<User> GetUserById(Guid id)
    {
        var user = await _userRepository.GetUserById(id);

        if (user == null)
            throw new Exception("User not found");

        return user;
    }

    public async Task RegisterUser(User user)
    {
        var users = GetUsers();
        if (users.Result.Find(n => n.Name == user.Name) != null)
                throw new Exception("user already exists!");

        var hashedPassword = _passwordHasher.Generate(user.Password);
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Name = user.Name,
            Password = hashedPassword,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _userRepository.RegisterUser(newUser);
    }

    public async Task<string> Login(User user)
    {
        var userByName = await _userRepository.GetUserByName(user.Name);

        var result = _passwordHasher.Verify(user.Password, userByName.Password);

        if (!result) throw new Exception("Failed to login");

        var token = _jwtProvider.GenerateToken(userByName);

        return token;
    }

    public async Task UpdateUser(Guid id, User user)
    {
        var trackedEntity = await GetUserById(id);

        await _userRepository.UpdateUser(id, user);
    }

    public async Task<List<Appointment>?> GetUserAppointments(Guid id)
    {
        var appointments = await _userRepository.GetUserAppointments(id);
        if (appointments == null)
            throw new Exception("User appointments not found");

        return appointments;
    }
    public async Task<User> GetUserByName(string name)
    {
        var user = await _userRepository.GetUserByName(name);
        if (user == null)
            throw new Exception("User not found");

        return user;
    }
}