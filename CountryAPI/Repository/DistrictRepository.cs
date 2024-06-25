using CountryAPI.IRepository;
using CountryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryAPI.Repository
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly CountryApiContext _context;

        public DistrictRepository(CountryApiContext context)
        {
            _context = context;
        }

        public async Task<List<District>> GetAllDistricts()
        {
            return await _context.Districts.ToListAsync();
        }

        public async Task<List<District>> GetDistrictByName(string name)
        {
            return await _context.Districts.Where(x => x.DistrictName.Contains(name)).ToListAsync();
        }

        public async Task<District> GetDistrictById(Guid id)
        {
            return await _context.Districts.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateDisctrict(District district)
        {
           _context.Update(district); 
           await _context.SaveChangesAsync();
        }

        public async Task CreateDistrict(District district)
        {
            await _context.AddAsync(district);
            await _context.SaveChangesAsync();
        }
    }
}
