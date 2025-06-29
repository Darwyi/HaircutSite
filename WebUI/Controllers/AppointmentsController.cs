using HaircutSite.Application.Interfaces.Services;
using HaircutSite.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModel;

namespace HaircutSite.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [Authorize]
        [HttpGet("/appointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                return Ok(await _appointmentService.GetAllAppointments());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            try
            {
                return Ok(await _appointmentService.GetAppointmentById(id));
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Authorize]
        [HttpGet("/appointments/{time}")]
        public async Task<IActionResult> GetAppointmentByDate(DateTime time)
        {
            try
            {
                if (_appointmentService.GetAppointmentByDate(time) is null) return BadRequest("Appointment not found");

                return Ok(await _appointmentService.GetAppointmentByDate(time));
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpGet("/getAppointmentByTime")]
        public async Task<IActionResult> GetAppointmentByTime(DateTime time)
        {
            try
            {
                if (_appointmentService.GetAppointmentByTime(time) is null) return BadRequest("Appointment not found");
                return Ok(await _appointmentService.GetAppointmentByTime(time));
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPost("/appointments{appointmentVM}")]
        public async Task<IActionResult> CreateAppointment([FromForm] AppointmentViewModel appointmentVM)
        {
            try
            {
                await _appointmentService.CreateAppointment(appointmentVM.ToAppointment());
                return Ok("Appointment created");
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPut("appointments")]
        public async Task<IActionResult> UpdateAppointment([FromForm]Appointment appointment)
        {
            try
            {
                await _appointmentService.UpdateAppointment(appointment);
                return Ok("Appointment updated");
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpDelete(" /appointments/{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            try
            {
                await  _appointmentService.DeleteAppointment(id);
                return Ok("Appointment deleted");
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
