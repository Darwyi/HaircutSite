using HaircutSite.Application.Interfaces;
using HaircutSite.Domain.Models;
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

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            return Ok(await _appointmentService.GetAllAppointments());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {//TODO: сделать try
            if (_appointmentService.GetAppointmentById(id) is null) return BadRequest("Appointment not found");

            return Ok(_appointmentService.GetAppointmentById(id));
        }

        [HttpGet("/{time}")]
        public async Task<IActionResult> GetAppointmentByDate(DateTime time)
        {
            if (_appointmentService.GetAppointmentByDate(time) is null) return BadRequest("Appointment not found");

            return Ok(await _appointmentService.GetAppointmentByDate(time));
        }

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

        [HttpPost("CreateAppointment")]
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

        [HttpPut("SignUp/{id}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, Appointment appointment)
        {
            await _appointmentService.UpdateAppointment(id, appointment);
            return Ok("Appointment updated");
        }
    }
}
