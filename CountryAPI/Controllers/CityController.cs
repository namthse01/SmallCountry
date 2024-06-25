using CountryAPI.IService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CountryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Route("GetAllCity")]
        public async Task<IActionResult> GetAllCity()
        {
            try
            {
                return Ok(await _cityService.GetAllCity());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCityByName")]
        public async Task<IActionResult> GetCityByName(string name)
        {
            try
            {
                return Ok(await _cityService.GetCityByName(name));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("UpdateCity/{id}")]
        public async Task<IActionResult> UpdateCity(
            [Required(ErrorMessage ="City id must required")] 
            Guid id,
            [MinLength(3, ErrorMessage = "City name must be at least 3 character long.")] 
            string? name,
            [Required(ErrorMessage ="Population must required")]
            [Range(1, int.MaxValue, ErrorMessage ="Population must greater than 0.")]
            int population
           )
        {
            try
            {
                await _cityService.UpdateCity(id, name, population);
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateCity")]
        public async Task<IActionResult> CreateCity(
            [Required(ErrorMessage ="City must have name")]
            [MinLength(3,ErrorMessage ="City name must be at least 3 character long.")]
            string name,
            [Required(ErrorMessage ="City must have population")]
            [Range(1, int.MaxValue, ErrorMessage ="Population must greater than 0.")]
            int population
            )
        {
            try
            {
                await _cityService.CreateCity(name, population);
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
