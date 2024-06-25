using CountryAPI.DTO;
using CountryAPI.IService;
using CountryAPI.Models;
using CountryAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CountryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            this._districtService = districtService;
        }

        [HttpGet]
        [Route("GetAllDistrict")]
        public async Task<IActionResult> GetAllDistrict()
        {
            try
            {
                return Ok( await _districtService.GetAllDistricts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllDistrictByName")]
        public async Task<IActionResult> GetAllDistrictByName(string name)
        {
            try
            {
                return Ok(await _districtService.GetDistrictByName(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetDistrictById")]
        public async Task<IActionResult> GetDistrictById(Guid id)
        {
            try
            {
                return Ok(await _districtService.GetDistrictById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("UpdateDistrict/{id}")]
        public async Task<IActionResult> UpdateDistrict(
            [Required(ErrorMessage ="District id must required")]
            Guid id,
            [MinLength(3, ErrorMessage = "District name must be at least 3 character long.")]
            string? name,
            [Required(ErrorMessage ="Population must required")]
            [Range(1, int.MaxValue, ErrorMessage ="Population must greater than 0.")]
            int population
           )
        {
            try
            {
                await _districtService.UpdateDisctrict(id, name,population);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateDistrict")]
        public async Task<IActionResult> CreateDistrict(
            [Required(ErrorMessage ="District must have name.")]
            [MinLength(3, ErrorMessage = "District name must be at least 3 character long.")]
            string name,
            [Required(ErrorMessage ="Population must required")]
            [Range(1, int.MaxValue, ErrorMessage ="Population must greater than 0.")] int population
            )
        {
            try
            {
                await _districtService.CreateDistrict(name,population);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateDistricFromTown")]
        public async Task<IActionResult> CreateDistrictFromTown([FromBody] CreateDistrictFromTownsDTO districtDTO)
        {
            try
            {
                await _districtService.CreateDistrictFromTown(districtDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("GroupTownsToDistrict")]
        public async Task<IActionResult> GroupTownsToDistrict([FromBody]GroupTownsToDistrictDTO districtDTO)
        {
            try
            {
                await _districtService.GroupTownsToDistrict(districtDTO);
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
