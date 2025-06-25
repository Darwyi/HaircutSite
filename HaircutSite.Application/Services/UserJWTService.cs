using HaircutSite.Application.Interfaces.Auth;
using HaircutSite.Application.Interfaces.Services;
using HaircutSite.Domain.Interfaces;
using HaircutSite.Domain.Models;
using Nest;

namespace HaircutSite.Application.Services
{
    public class UserJWTService : IUserJWTService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHashRepository _passwordHasher;
        private readonly IJwtRepository _jwtProvider;
        private readonly IUserRepository _userRepository;

        public UserJWTService(
            IUserService userService, IPasswordHashRepository passwordHash,
            IJwtRepository jwtRepository, IUserRepository userRepository)
        {
            _userService = userService;
            _jwtProvider = jwtRepository;
            _passwordHasher = passwordHash;
            _userRepository = userRepository;
        }

        public async Task RegisterUser(string name, string password)
        {
            var users = _userService.GetUsers();
            if (users.Result.Find(n => n.Name == name) != null)
                throw new Exception("user already exists!");

            var hashedPassword = _passwordHasher.Generate(password);
            var newUser = User.Create(name, hashedPassword);
            //    new User {
            //    Id = Guid.NewGuid(),
            //    Name = user.Name, 
            //    Password = hashedPassword,
            //    UpdatedAt = DateTime.UtcNow
            //};

            await _userRepository.RegisterUser(newUser);
        }

        public async Task<string> Login(string name, string password)
        {
            var userByName = await _userRepository.GetUserByName(name);

            var result = _passwordHasher.Verify(password, userByName.Password);

            if (!result) throw new Exception("Failed to login");

            var token = _jwtProvider.GenerateToken(userByName);

            return token;
        }
    }
}
