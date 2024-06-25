using CountryAPI.DTO;
using CountryAPI.Models;

namespace CountryAPI.IService
{
    public interface IDistrictService
    {
        Task<List<District>> GetAllDistricts();
        Task<List<District>> GetDistrictByName(string name);
        Task<District> GetDistrictById(Guid id);
        Task UpdateDisctrict(Guid id, string name, int population);
        Task CreateDistrict(string name, int population);
        Task CreateDistrictFromTown(CreateDistrictFromTownsDTO districtDTO);
        Task GroupTownsToDistrict(GroupTownsToDistrictDTO districtDTO);
    }
}
