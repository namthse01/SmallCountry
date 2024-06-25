using CountryAPI.DTO;

namespace CountryAPI.IService
{
    public interface ICountryService
    {
        Task<Dictionary<string, List<Object>>> GetAllCountryData();
        Task<Dictionary<string, List<Object>>> GetDataFromCountryByName(string name);
        Task<List<TownAndCommuneSearchDTO>> GetDataTownAndCommune(string name);
        Task<List<DistrictAndTownSearchDTO>> GetDataDistrictAndTown(string name);
    }
}
