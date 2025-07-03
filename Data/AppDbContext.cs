using AplicatieInterviu.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AplicatieInterviu.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Companie> Companii { get; set; }

    }
}
