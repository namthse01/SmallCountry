using CountryAPI.Models;

namespace CountryAPI.IRepository
{
    public interface ICommuneRepository
    {
        Task<List<Commune>> GetAllCommunes();
        Task<List<Commune>> GetCommnueByName(string name);
        Task<Commune> GetCommnueById(Guid id);
        Task<List<Commune>> GetCommuneByTownID(Guid id);
        Task<List<Commune>> GetListCommuneByID(List<Guid> listId);
        Task UpdateCommnune(Commune commune);
        Task UpdateCommunesList(List<Commune> communes);
        Task CreateCommnue(Commune commune);
    }
}
