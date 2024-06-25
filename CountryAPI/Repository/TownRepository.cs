using CountryAPI.DTO;
using CountryAPI.IRepository;
using CountryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryAPI.Repository
{
    public class TownRepository : ITownRepository
    {
        private readonly CountryApiContext _context;

        public TownRepository(CountryApiContext context)
        {
            this._context = context;
        }

        public async Task<List<Town>> GetAllTown()
        {
            return await _context.Towns.ToListAsync();
        }

        public async Task<List<Town>> GetTownByName(string name)
        {
            return await _context.Towns.Where(x => x.TownName.Contains(name)).ToListAsync();
        }

        public async Task<Town> GetTownById(Guid id)
        {
            return await _context.Towns.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Town>> GetTownByDistrictId(Guid id)
        {
            return await _context.Towns.Where(x => x.DistrictId == id).ToListAsync();
        }

        public async Task<List<Town>> GetListTownById(List<Guid> listId)
        {
            return await _context.Towns.Where(x => listId.Contains(x.Id)).ToListAsync();
        }

        public async Task UpdateTown(Town town)
        {
            _context.Entry(town).Property(x => x.TownName).IsModified = town.TownName != null;
            _context.Entry(town).Property(x => x.Population).IsModified = town.Population > 0;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateListTown(List<Town> list)
        {
            _context.UpdateRange(list);
            await _context.SaveChangesAsync();
        }

        public async Task CreateTown(Town town)
        {
            await _context.Towns.AddAsync(town);
            await _context.SaveChangesAsync();
        }
    }
}
