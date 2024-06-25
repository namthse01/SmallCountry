using CountryAPI.Models;

namespace CountryAPI.IService
{
    public interface ICommnuneService
    {
        Task<List<Commune>> GetAllCommune();
        Task<List<Commune>> GetCommnueByName(string name);
        Task<Commune> GetCommnueById(Guid id);
        Task<List<Commune>> GetCommuneByTownID(Guid id);
        Task CreateCommune(string name, int population);
        Task UpdateCommnune(Guid id, string name, int population);
    }
}
