using HaircutSite.Domain.Models;
using HaircutSite.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace HaircutSite.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignUpsController : ControllerBase
    {
        private readonly ApplicationContext _dbContext;

        public SignUpsController(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public List<SignUps> GetAllSignUps()
        { 
            return _dbContext.Set<SignUps>().ToList();
        }

        [HttpGet("signups/{id}")]
        public async Task<ActionResult<SignUps>> GetSignupById(long id) 
        {
            var signup = await _dbContext.SignUps.FindAsync(id);
            if (signup is null)
            {
                return BadRequest("Signup not found");
            }
            return Ok(signup);
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<SignUps>> SignUp(HaircutStyles hcs, Guid user)
        {
            var getuser = await _dbContext.Users.FindAsync(user);
            if (getuser == null)
            {
                return BadRequest("User not found");
            }

            var haircutstyles = await _dbContext.HairCutStyles.FindAsync(hcs.Id);
            if (haircutstyles == null)
            {
                return BadRequest("Haircut style not found");
            }

            var signup = new SignUps
            {
                User = getuser,
                haircutStyle = haircutstyles,
                Date = DateTime.UtcNow
            };

            _dbContext.Add(signup);
            await _dbContext.SaveChangesAsync();
            return Ok(signup);
        }

        [HttpPut("SignUp/{id}")]
        public async Task<ActionResult<SignUps>> UpdateSignUp(long id, SignUps signup)
        {
            var existingSignup = await _dbContext.SignUps.FindAsync(id);
            if (existingSignup is null)
            {
                return BadRequest("Signup not found");
            }
            existingSignup.User = signup.User;
            existingSignup.Date = signup.Date;
            await _dbContext.SaveChangesAsync();
            return Ok(existingSignup);
        }
    }
}
