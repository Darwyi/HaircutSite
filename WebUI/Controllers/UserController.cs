using HaircutSite.Application.Interfaces;
using HaircutSite.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModel;

namespace HaircutSite.WEBUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;

        public UserController(IUserService user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _user.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserUpById(Guid id)
        {
            if (_user.GetUserById(id) is null) return BadRequest("User is not found");

            return Ok(await _user.GetUserById(id));
        }

        [HttpGet("{id}/appointments")]
        public async Task<IActionResult> GetUserAppointments(Guid id)
        {
            if (_user.GetUserAppointments(id) is null) return BadRequest("User is not found");

            return Ok(await _user.GetUserAppointments(id));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserViewModel userVM)
        {
            var newUser = userVM.ToUser();

            await _user.RegisterUser(newUser);
            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, User user)
        {
            var userId = await _user.GetUserById(id);
            if (userId is null) return BadRequest("User is not found");

            var newUser = _user.UpdateUser(id, user);

            await newUser;

            return Ok(newUser);
        }
    }
}
