using CSharpFunctionalExtensions;
using HaircutSite.Domain.Models;
using HaircutSite.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace HaircutSite.WEBUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _dbContext;

        public UserController(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return _dbContext.Set<User>().ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserUpById(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user is null)
            {
                return BadRequest("User not found");
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUserUp(Guid id, string Name, string password)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user is null)
            {
                return BadRequest("User is not found");
            }
            user.Name = Name;
            user.Password = password;
            user.UpdatedAt = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser(
            User user)
        {
            _dbContext.Users.Add(user);

            var entries = _dbContext.ChangeTracker.Entries();

            await _dbContext.SaveChangesAsync();
            return Ok(User);
        }
    }
}
