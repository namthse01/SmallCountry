using CountryAPI.Models;

namespace CountryAPI.IService
{
    public interface ICityService
    {
        Task<List<City>> GetAllCity();
        Task<List<City>> GetCityByName(string name);
        Task<City> GetCityById(Guid id);
        Task UpdateCity(Guid id, string name, int Population);
        Task CreateCity(string name, int Population);
    }
}
