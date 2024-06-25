using CountryAPI.IRepository;
using CountryAPI.IService;
using CountryAPI.Models;

namespace CountryAPI.Services
{
    public class CommuneService : ICommnuneService
    {
        private readonly ICommuneRepository _communeRepository;

        public CommuneService(ICommuneRepository communeRepository)
        {
            _communeRepository = communeRepository;
        }

        public async Task<List<Commune>> GetAllCommune()
        {
            return await _communeRepository.GetAllCommunes();
        }

        public async Task<List<Commune>> GetCommnueByName(string name)
        {
            return await _communeRepository.GetCommnueByName(name);
        }

        public async Task<Commune> GetCommnueById(Guid id)
        {
            return await _communeRepository.GetCommnueById(id);
        }

        public async Task<List<Commune>> GetCommuneByTownID(Guid id)
        {
            return await _communeRepository.GetCommuneByTownID(id);
        }

        public async Task UpdateCommnune(Guid id, string name, int population)
        {
            Commune communeUpdate = await _communeRepository.GetCommnueById(id);
            if (communeUpdate != null)
            {
                communeUpdate.CommuneName = name;
                communeUpdate.Population = population;
                await _communeRepository.UpdateCommnune(communeUpdate);
            }
        }

        public async Task CreateCommune(string name, int population)
        {
            Commune commune = new Commune
            {
                CommuneName = name,
                Population = population,
                Id = Guid.NewGuid(),
            };
            await _communeRepository.CreateCommnue(commune);
        }
    }
}
