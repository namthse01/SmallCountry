using CountryAPI.DTO;
using CountryAPI.IRepository;
using CountryAPI.IService;
using CountryAPI.Models;
using CountryAPI.Repository;

namespace CountryAPI.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly ITownRepository _townRepository;

        public DistrictService(IDistrictRepository districtRepository, ITownRepository townRepository)
        {
            _districtRepository = districtRepository;
            _townRepository = townRepository;
        }

        public async Task<List<District>> GetAllDistricts()
        {
            return await _districtRepository.GetAllDistricts();
        }

        public async Task<List<District>> GetDistrictByName(string name)
        {
            return await _districtRepository.GetDistrictByName(name);
        }

        public async Task<District> GetDistrictById(Guid id)
        {
            return await _districtRepository.GetDistrictById(id);
        }

        public async Task UpdateDisctrict(Guid id, string name, int population)
        {
            District district = await _districtRepository.GetDistrictById(id);
            if (district != null)
            {
                district.DistrictName = name;
                district.Population = population;
                await _districtRepository.UpdateDisctrict(district);
            }
        }

        public async Task CreateDistrict(string name, int population)
        {
            District district = new District
            {
                DistrictName = name,
                Id = Guid.NewGuid(),
                Population = population
            };
            await _districtRepository.CreateDistrict(district);
        }

        public async Task CreateDistrictFromTown(CreateDistrictFromTownsDTO districtDTO)
        {
            int? population=0;
            if (districtDTO.TownIds.Count < 3)
            {
                throw new InvalidOperationException("At least 3 town to create new District");
            }
            List<Town> townList = await _townRepository.GetListTownById(districtDTO.TownIds);
            if (townList.Any(x => x.DistrictId != null))
            {
                throw new InvalidOperationException("Town must not belong to any District");
            }

            //create new District

            District newDistrict = new District
            {
                DistrictName = districtDTO.DistrictName,
                Id = Guid.NewGuid(),
                Towns = townList
            };
            foreach (Town town in townList)
            {
                town.DistrictId = newDistrict.Id;
                population = population + town.Population;
            }
            newDistrict.Population = population;
            await _districtRepository.CreateDistrict(newDistrict);
            await _townRepository.UpdateListTown(townList);
        }

        public async Task GroupTownsToDistrict(GroupTownsToDistrictDTO districtDTO)
        {
            int? population = 0;
            if(districtDTO.TownIds.Count <= 0)
            {
                throw new InvalidOperationException("At least 1 town to group into District");
            }
            District groupDistrict = await _districtRepository.GetDistrictById(districtDTO.DistrictId);
            if(groupDistrict == null)
            {
                throw new InvalidOperationException("District Not exist!");
            }
            else
            {
                List<Town> listTowns = await _townRepository.GetListTownById(districtDTO.TownIds);
                if (listTowns.Count <=0)
                {
                    throw new InvalidOperationException("At least 1 town to group into District");
                }
                else
                {
                    foreach (Town town in listTowns)
                    {
                        town.DistrictId = groupDistrict.Id;
                        population = population + town.Population;
                    }
                }
                groupDistrict.Population = groupDistrict.Population + population;
                groupDistrict.Towns = listTowns;
                await _districtRepository.UpdateDisctrict(groupDistrict);
                await _townRepository.UpdateListTown(listTowns);
            }
        }
    }
}
