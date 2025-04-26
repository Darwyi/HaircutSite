using HaircutSite.Application.Interfaces;
using HaircutSite.Domain.Interfaces;
using HaircutSite.Domain.Models;

namespace HaircutSite.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> GetUsers()
    {
        return await _userRepository.GetUsers();
    }

    public async Task<User> GetUserById(Guid id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task RegisterUser(User user)
    {
        var users = await _userRepository.GetUsers();
        if (users.Any(u => u.Name == user.Name))
        {
            throw new InvalidOperationException("A user with the same name already exists.");
        }
        await _userRepository.RegisterUser(user);
    }

    public async Task UpdateUser(Guid id, User user)
    {
        await _userRepository.UpdateUser(id, user);
    }

    public async Task<List<Appointment>?> GetUserAppointments(Guid id)
    {
        return await _userRepository.GetUserAppointments(id);
    }
}