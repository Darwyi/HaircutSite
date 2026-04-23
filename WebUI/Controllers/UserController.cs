using HaircutSite.Application.Interfaces.Services;
using HaircutSite.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HaircutSite.WEBUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _userService.GetUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserUpById(Guid id)
        {
            if (_userService.GetUserById(id) is null) return BadRequest("User is not found");

            return Ok(await _userService.GetUserById(id));
        }
        [Authorize]
        [HttpGet("{id}/appointments")]
        public async Task<IActionResult> GetUserAppointments(Guid id)
        {
            try
            {
                if (_userService.GetUserAppointments(id) is null) return BadRequest("User is not found");

                return Ok(await _userService.GetUserAppointments(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> RegisterUser(UserViewModel userVM)
        //{
        //    try
        //    {
        //        var newUser = userVM.ToUser();

        //        await _userService.RegisterUser(newUser);
        //        return Ok(newUser);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] UserViewModel userVM)
        //{
        //    try
        //    {
        //        var user = userVM.ToUser();
        //        var token = _userService.Login(user).Result;
        //        if (token is null) return BadRequest("Invalid credentials");
        //        return Ok(token);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [Authorize]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, User user)
        {
            try
            {
                var userId = await _userService.GetUserById(id);
                if (userId is null) return BadRequest("User is not found");

                var newUser = _userService.UpdateUser(id, user);

                await newUser;

                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("user/{name}")]
        public async Task<User> GetUserByName(string name)
        {
            try
            {
                var trackedUser = await _userService.GetUserByName(name);
                if (trackedUser is null) throw new Exception("User not found");
                return trackedUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
