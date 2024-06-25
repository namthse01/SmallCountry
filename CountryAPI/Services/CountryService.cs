using CountryAPI.DTO;
using CountryAPI.IService;
using CountryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CountryAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly ITownService _townService;
        private readonly IDistrictService _districtService;
        private readonly ICommnuneService _commnuneService;
        private readonly ICityService _cityService;
        
        public CountryService(ICommnuneService commnuneService, IDistrictService districtService, ITownService townService, ICityService cityService)
        {
            _townService = townService;
            _districtService = districtService;
            _commnuneService = commnuneService;
            _cityService = cityService;
        }
        public async Task<Dictionary<string, List<Object>>> GetAllCountryData()
        {
            List<Town> listTowns = await _townService.GetAllTown();
            List<City> listCities = await _cityService.GetAllCity();
            List<Commune> listCommunes = await _commnuneService.GetAllCommune();
            List<District> listDistricts = await _districtService.GetAllDistricts();

            Dictionary<string, List<object>> result = new Dictionary<string, List<object>>
            {
                { "Towns", listTowns.Select(t => new { t.TownName, t.Population }).Cast<object>().ToList() },
                { "Cities", listCities.Select(c => new { c.CityName, c.Population }).Cast<object>().ToList() },
                { "Communes", listCommunes.Select(cm => new { cm.CommuneName, cm.Population }).Cast<object>().ToList() },
                { "Districts", listDistricts.Select(d => new { d.DistrictName, d.Population }).Cast<object>().ToList() }
            };
            return result;
        }

        public async Task<Dictionary<string, List<Object>>> GetDataFromCountryByName(string name)
        {
            List<Town> listTowns = await _townService.GetTownByName(name);
            List<City> listCities = await _cityService.GetCityByName(name);
            List<Commune> listCommunes = await _commnuneService.GetCommnueByName(name);
            List<District> listDistricts = await _districtService.GetDistrictByName(name);

            Dictionary<string, List<object>> result = new Dictionary<string, List<Object>>();

            if(listTowns != null && listTowns.Any())
            {
                result.Add("Towns", listTowns.Select(t => new {t.TownName, t.Population}).Cast<object>().ToList());
            }
            if(listCities != null && listCities.Any())
            {
                result.Add("Cities", listCities.Select(c=> new {c.CityName, c.Population}).Cast<object>().ToList());
            }
            if (listCommunes != null && listCommunes.Any())
            {
                result.Add("Communes", listCommunes.Select(cm=> new {cm.CommuneName, cm.Population}).Cast<object>().ToList());
            }
            if(listDistricts != null && listDistricts.Any())
            {
                result.Add("Districts", listDistricts.Select(d=> new {d.DistrictName, d.Population}).Cast<object>().ToList());
            }

            return result;
        }

        public async Task<List<TownAndCommuneSearchDTO>> GetDataTownAndCommune(string name)
        {
            List<Town> listTowns = await _townService.GetTownByName(name);
            List<TownAndCommuneSearchDTO> result = new List<TownAndCommuneSearchDTO>();
            foreach(Town town in listTowns)
            {
                List<Commune> listCommunes = await _commnuneService.GetCommuneByTownID(town.Id);
                List<string> communeNames = listCommunes.Select(c => c.CommuneName).ToList();
                TownAndCommuneSearchDTO dto = new TownAndCommuneSearchDTO
                {
                    TownName = town.TownName,
                    CommuneName = communeNames
                };
                result.Add(dto);
            }

            return result;
        }

        public async Task<List<DistrictAndTownSearchDTO>> GetDataDistrictAndTown(string name)
        {
            List<District> listDistricts = await _districtService.GetDistrictByName(name);
            List<DistrictAndTownSearchDTO> result = new List<DistrictAndTownSearchDTO>();
            foreach(District d in listDistricts)
            {
                List<Town> listTowns = await _townService.GetTownByDistrictId(d.Id);
                List<string> townNames = listTowns.Select(c=> c.TownName).ToList();
                DistrictAndTownSearchDTO dto = new DistrictAndTownSearchDTO
                {
                    DistrictName = d.DistrictName,
                    TownName = townNames
                };
                result.Add(dto);
            }
            return result; 
        }
    }
}
