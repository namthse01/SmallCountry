using CountryAPI.Models;

namespace CountryAPI.IRepository
{
    public interface IDistrictRepository
    {
        Task<List<District>> GetAllDistricts();
        Task<List<District>> GetDistrictByName(string name);
        Task<District> GetDistrictById(Guid id);
        Task UpdateDisctrict(District district);
        Task CreateDistrict(District district);
    }
}
