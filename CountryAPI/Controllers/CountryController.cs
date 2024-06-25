using CountryAPI.DTO;
using CountryAPI.IService;
using CountryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        [Route("GetAllDataFromCountry")]
        public async Task<IActionResult> GetAllCountryData()
        {
            try
            {
                return Ok(await _countryService.GetAllCountryData());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetDataFromCountryByName")]
        public async Task<IActionResult> GetDataFromCountryByName(string name)
        {
            try
            {
                return Ok(await _countryService.GetDataFromCountryByName(name));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetDataTownAndCommnues")]
        public async Task<IActionResult> GetDataTownAndCommune(string name)
        {
            try
            {
                return Ok(await _countryService.GetDataTownAndCommune(name));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetDataDistrictAndTown")]
        public async Task<IActionResult> GetDataDistrictAndTown(string name)
        {
            try
            {
                return Ok(await _countryService.GetDataDistrictAndTown(name));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
