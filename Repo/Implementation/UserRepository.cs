using AplicatieInterviu.Data;
using AplicatieInterviu.Models;
using AplicatieInterviu.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace AplicatieInterviu.Repo.Implementation
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync() => await _context.Users.ToListAsync();

        public async Task<User?> GetByIdAsync(int id) => await _context.Users.FindAsync(id);

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> GetByCompanyNameAndEmailAsync(string companyName, string email)
        {
            var test = await (
                from user in _context.Users
                join companie in _context.Companii
                    on user.CompanyId equals companie.Id
                where user.Email == email && companie.Name == companyName
                select user
            ).FirstOrDefaultAsync();
            return test;
        }
        public async Task<List<User>> GetUsersByCompanyIdAsync(int companyId)
        {
            return await _context.Users
                .Where(u => u.CompanyId == companyId)
                .ToListAsync();
        }

    }
}
