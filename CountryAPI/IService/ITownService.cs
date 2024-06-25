using CountryAPI.DTO;
using CountryAPI.Models;

namespace CountryAPI.IService
{
    public interface ITownService
    {
        Task<List<Town>> GetAllTown();
        Task<List<Town>> GetTownByName(string name);
        Town GetTownByID(Guid id);
        Task<List<Town>> GetTownByDistrictId(Guid id);
        Task UpdateTown(Guid id, string name, int population);
        Task CreateTown(string name, int population);
        Task CreateTownFromCommune(CreateTownFromCommunesDTO townDTO);
        Task GroupCommuneToTown(GroupCommunesToTownDTO townDTO);
    }
}
