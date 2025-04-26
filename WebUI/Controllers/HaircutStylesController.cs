using HaircutSite.Application.Interfaces;
using HaircutSite.Application.Services;
using HaircutSite.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using WebUI.ViewModel;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HaircutStylesController : ControllerBase
    {
        private readonly IHaircutStyleService _haircutStyleService;
        public HaircutStylesController(IHaircutStyleService haircutStyleService)
        {
            _haircutStyleService = haircutStyleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHaircutStyles()
        {
            return Ok(await _haircutStyleService.GetHaircutStyles());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHaircutById(Guid Id)
        {
            var haircut = await _haircutStyleService.GetHaircutStyleById(Id);
            if (haircut is null)
            {
                return BadRequest("Haircut not found");
            }

            return Ok(haircut);
        }

        [HttpPost("/CreateNewHaircut")]
        public async Task<IActionResult> CreateHaircut(HaircutStylesViewModel haircutStylesVM)
        {
            try
            {
                var newHaircut = haircutStylesVM.ToStyle();
                await _haircutStyleService.CreateHaircutStyle(newHaircut);
                return Ok(newHaircut);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStyle(Guid id, HaircutStyles haircutStyles)
        {
            var haircut = await _haircutStyleService.GetHaircutStyleById(id);
            if (haircut is null)
            {
                return BadRequest("Haircut not found");
            }

            var newHaircutStyle = _haircutStyleService.UpdateHaircutStyle(id, haircutStyles);
            return Ok(newHaircutStyle);
        }
    }
}
