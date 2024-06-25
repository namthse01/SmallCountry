using CountryAPI.DTO;
using CountryAPI.IRepository;
using CountryAPI.IService;
using CountryAPI.Models;

namespace CountryAPI.Services
{
    public class TownService : ITownService
    {
        private readonly ITownRepository _townRepository;
        private readonly ICommuneRepository _communeRepository;

        public TownService(ITownRepository townRepository, ICommuneRepository communeRepository)
        {
            _townRepository = townRepository;
            _communeRepository = communeRepository;
        }

        public async Task<List<Town>> GetAllTown()
        {
            return await _townRepository.GetAllTown();
        }

        public async Task<List<Town>> GetTownByName(string name)
        {
            return await _townRepository.GetTownByName(name);
        }

        public Town GetTownByID(Guid id)
        {
            return _townRepository.GetTownById(id).Result;
        }

        public async Task<List<Town>> GetTownByDistrictId(Guid id)
        {
            return await _townRepository.GetTownByDistrictId(id);
        }

        public async Task UpdateTown(Guid id, string name, int population)
        {
            Town townUpdate = await _townRepository.GetTownById(id);
            if (townUpdate != null)
            {
                townUpdate.TownName = name;
                townUpdate.Population = population;
                await _townRepository.UpdateTown(townUpdate);
            }
        }

        public async Task CreateTown(string name, int population)
        {
            Town newTown = new Town
            {
                TownName = name,
                Population = population,
                Id = Guid.NewGuid(),
            };
            await _townRepository.CreateTown(newTown);
        }

        public async Task CreateTownFromCommune(CreateTownFromCommunesDTO townDTO)
        {
            int? population = 0;

            if (townDTO.CommuneIds.Count < 3)
            {
                throw new InvalidOperationException("At least 3 communes is requied to create Town");
            }
            List<Commune> listCommunes = await _communeRepository.GetListCommuneByID(townDTO.CommuneIds);
            if (listCommunes.Any(x => x.TownId != null))
            {
                throw new InvalidOperationException("Commnues must not belong to any Town");
            }
            //Create new town
            Town newTown = new Town
            {
                Id = Guid.NewGuid(),
                Communes = listCommunes,
                TownName = townDTO.TownName
            };
            foreach (Commune commune in listCommunes)
            {
                commune.TownId = newTown.Id;
                population = population + commune.Population;
            }
            newTown.Population = population;  

            await _townRepository.CreateTown(newTown);

            //Add Commune to Town:
            await _communeRepository.UpdateCommunesList(listCommunes);
        }

        public async Task GroupCommuneToTown(GroupCommunesToTownDTO townDTO)
        {
            int? population = 0;
            if(townDTO.CommuneIds.Count <= 0)
            {
                throw new InvalidOperationException("At least 1 communes is requied to create Town");
            }
            Town groupTown = await _townRepository.GetTownById(townDTO.TownId);
            if(groupTown == null)
            {
                throw new InvalidOperationException("Town Not exist!");
            }
            else
            {
                List<Commune> listCommunes = await _communeRepository.GetListCommuneByID(townDTO.CommuneIds);
                if(listCommunes.Count <= 0)
                {
                   throw new InvalidOperationException("At least 1 communes is requied to create Town");
                }
                else
                {
                    foreach (Commune commune in listCommunes)
                    {
                        commune.TownId = groupTown.Id;
                        population = population + commune.Population;
                    }
                    groupTown.Population = groupTown.Population + population;
                    groupTown.Communes = listCommunes;
                    await _townRepository.UpdateTown(groupTown);
                    await _communeRepository.UpdateCommunesList(listCommunes);
                }
            }
        }
    }
}
