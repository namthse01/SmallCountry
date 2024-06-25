using CountryAPI.IRepository;
using CountryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryAPI.Repository
{
    public class CommnuneRepository : ICommuneRepository
    {
        private readonly CountryApiContext _context;
        public CommnuneRepository(CountryApiContext context)
        {
            _context = context;
        }

        public async Task<List<Commune>> GetAllCommunes()
        {
            return await _context.Communes.ToListAsync();
        }

        public async Task<List<Commune>> GetCommnueByName(string name)
        {
            return await _context.Communes.Where(x => x.CommuneName.Contains(name)).ToListAsync();
        }

        public async Task<Commune> GetCommnueById(Guid id)
        {
            return await _context.Communes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Commune>> GetCommuneByTownID(Guid id)
        {
            return await _context.Communes.Where(x=> x.TownId == id).ToListAsync();
        }

        public async Task<List<Commune>> GetListCommuneByID(List<Guid> listId)
        {
            return await _context.Communes.Where(x => listId.Contains(x.Id) && x.TownId == null).ToListAsync();
        }

        public async Task UpdateCommnune(Commune commune)
        {
           _context.Entry(commune).Property(x=> x.CommuneName).IsModified = commune.CommuneName != null;
            _context.Entry(commune).Property(x=>x.Population).IsModified = commune.Population >0;
           await _context.SaveChangesAsync();
        }

        public async Task UpdateCommunesList(List<Commune> communes)
        {
            _context.Communes.UpdateRange(communes);
            await _context.SaveChangesAsync();
        }

        public async Task CreateCommnue(Commune commune)
        {
            await _context.AddAsync(commune);
            await _context.SaveChangesAsync();
        }
    }
}
