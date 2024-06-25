using CountryAPI.IRepository;
using CountryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryAPI.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly CountryApiContext _context;

        public CityRepository(CountryApiContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllCity()
        {
            return await _context.Cities.ToListAsync();
        }
        public async Task<List<City>> GetCityByName(string name)
        {
            return await _context.Cities.Where(x=> x.CityName.Contains(name)).ToListAsync();
        }

        public async Task<City> GetCityById(Guid id)
        {
            return await _context.Cities.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateCity(City city)
        {
            if (!string.IsNullOrEmpty(city.CityName) && city.Population>0)
            {
                _context.Cities.Entry(city).Property(x => x.CityName).IsModified = city.CityName != null && city.CityName.Length > 0 && city.CityName != "string";
                _context.Cities.Entry(city).Property(x => x.Population).IsModified = city.Population > 0;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateCity(City city)
        {
            await _context.AddAsync(city);
            await _context.SaveChangesAsync();
        }
    }
}
