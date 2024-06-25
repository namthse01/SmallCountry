using CountryAPI.IService;
using CountryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CountryAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CommuneController : ControllerBase
    {
        private readonly ICommnuneService _communeService;

        public CommuneController(ICommnuneService communeService)
        {
            _communeService = communeService;
        }

        [HttpGet]
        [Route("GetAllCommune")]
        public async Task<IActionResult> GetAllCommune()
        {
            try
            {
                return Ok(await _communeService.GetAllCommune());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCommuneByName")]
        public async Task<IActionResult> GetCommuneByName(string name)
        {
            try
            {
                return Ok(await _communeService.GetCommnueByName(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("UpdateCommune/{id}")]
        public async Task<IActionResult> UpdateCommune(
            [Required(ErrorMessage ="Commune id must required")]
            Guid id,
            [MinLength(3, ErrorMessage = "Commune name must be at least 3 character long.")]
            string? name,
            [Required(ErrorMessage ="Population must required")]
            [Range(1, int.MaxValue, ErrorMessage ="Population must greater than 0.")]
            int population
           )
        {
            try
            {
                await _communeService.UpdateCommnune(id, name,population);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateCommune")]
        public async Task<IActionResult> CreateCommune(
             [Required(ErrorMessage ="Commune must have name.")]
             [MinLength(3, ErrorMessage = "Commune name must be at least 3 character long.")]
             string name,
             [Required(ErrorMessage ="Population must required")]
             [Range(1, int.MaxValue, ErrorMessage ="Population must greater than 0.")]
             int population
            )
        {
            try
            {
                await _communeService.CreateCommune(name,population);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
