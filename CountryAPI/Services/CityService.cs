using CountryAPI.IRepository;
using CountryAPI.IService;
using CountryAPI.Models;

namespace CountryAPI.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<City>> GetAllCity()
        {
            return await _cityRepository.GetAllCity();
        }

        public async Task<List<City>> GetCityByName(string name)
        {
            return await _cityRepository.GetCityByName(name);
        }

        public async Task<City> GetCityById(Guid id)
        {
            return await _cityRepository.GetCityById(id);
        }

        public async Task UpdateCity(Guid id, string name, int Population)
        {
            City newCity = await _cityRepository.GetCityById(id);
            if (newCity != null)
            {
                if(Population >0)
                {
                    newCity.Population = Population;
                    newCity.CityName = name;
                    await _cityRepository.UpdateCity(newCity);
                }
            }
        }

        public async Task CreateCity(string name, int Population)
        {
            City newCity = new City
            {
                CityName = name,
                Population = Population,
                Id = Guid.NewGuid()
            };
            await _cityRepository.CreateCity(newCity);
        }
    }
}
