﻿using AplicatieInterviu.Data;
using AplicatieInterviu.Models;
using AplicatieInterviu.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace AplicatieInterviu.Repo.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAllAsync() => await _context.Roles.ToListAsync();

        public async Task<Role?> GetByIdAsync(int id) => await _context.Roles.FindAsync(id);

        public async Task AddAsync(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}
