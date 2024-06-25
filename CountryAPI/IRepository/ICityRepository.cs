using CountryAPI.Models;

namespace CountryAPI.IRepository
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCity();
        Task<List<City>> GetCityByName(string name);
        Task<City> GetCityById(Guid id);
        Task UpdateCity(City city);
        Task CreateCity(City city);
    }
}
