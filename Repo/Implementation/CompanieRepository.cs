using AplicatieInterviu.Data;
using AplicatieInterviu.Models;
using AplicatieInterviu.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace AplicatieInterviu.Repo.Implementation
{
    public class CompanieRepository : ICompanieRepository
    {
        private readonly AppDbContext _context;

        public CompanieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Companie>> GetAllAsync() => await _context.Companii.ToListAsync();

        public async Task<Companie?> GetByIdAsync(int id) => await _context.Companii.FindAsync(id);

        public async Task<Companie> AddAsync(Companie companie)
        {
            _context.Companii.Add(companie);
            await _context.SaveChangesAsync();
            return companie;
        }


        public async Task UpdateAsync(Companie companie)
        {
            _context.Companii.Update(companie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var companie = await _context.Companii.FindAsync(id);
            if (companie != null)
            {
                _context.Companii.Remove(companie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Companie> GetByNameAsync(string name)
        {
            return await _context.Companii.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
