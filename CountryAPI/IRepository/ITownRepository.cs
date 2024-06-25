
using CountryAPI.DTO;
using CountryAPI.Models;

namespace CountryAPI.IRepository
{
    public interface ITownRepository
    {
        Task<List<Town>> GetAllTown();
        Task<List<Town>> GetTownByName(string name);
        Task<Town> GetTownById(Guid id);
        Task<List<Town>> GetTownByDistrictId(Guid id);
        Task<List<Town>> GetListTownById(List<Guid> listId);
        Task UpdateTown(Town town);
        Task UpdateListTown(List<Town> list);
        Task CreateTown(Town town);
    }
}
