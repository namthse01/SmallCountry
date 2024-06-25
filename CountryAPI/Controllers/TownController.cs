using CountryAPI.DTO;
using CountryAPI.IService;
using CountryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CountryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TownController : ControllerBase
    {
        private readonly ITownService _townService;

        public TownController(ITownService townService)
        {
            _townService = townService;
        }

        [HttpGet]
        [Route("GetAllTown")]
        public async Task<IActionResult> GetAllTown()
        {
            try
            {
                return Ok(await _townService.GetAllTown());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAllTownByName")]
        public async Task<IActionResult> GetTownByName(string name)
        {
            try
            {
                return Ok(await _townService.GetTownByName(name));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch]
        [Route("UpdateTown/{id}")]
        public async Task<IActionResult> UpdateTown(
            [Required(ErrorMessage ="Town id must required")]
            Guid id,
            [MinLength(3, ErrorMessage = "Town name must be at least 3 character long.")]
            string? name,
            [Required(ErrorMessage ="Population must required")]
            [Range(1, int.MaxValue, ErrorMessage ="Population must greater than 0.")]
            int population
           )
        {
            try
            {
                await _townService.UpdateTown(id, name, population);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("CreateTown")]
        public async Task<IActionResult> CreateTown(
            [Required(ErrorMessage ="Town must have name")]
            [MinLength(3, ErrorMessage = "Town name must be at least 3 character long.")]
            string name,
            [Required(ErrorMessage ="Population must required")]
            [Range(1, int.MaxValue, ErrorMessage ="Population must greater than 0.")]
            int population
           )
        {
            try
            {
                await _townService.CreateTown(name, population);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("CreateTownFromCommune")]
        public async Task<IActionResult> CreateTownFromCommune([FromBody]CreateTownFromCommunesDTO townDTO)
        {
            try
            {
                await _townService.CreateTownFromCommune(townDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("GroupCommunesToTown")]
        public async Task<IActionResult> GroupCommuneToTown([FromBody]GroupCommunesToTownDTO townDTO)
        {
            try
            {
                await _townService.GroupCommuneToTown(townDTO);
                return Ok();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
