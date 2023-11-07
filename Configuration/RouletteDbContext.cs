using Microsoft.EntityFrameworkCore;
using Roulette.DataTransferObjects;
using Roulette.Models;
using System;
using System.Threading.Tasks;

namespace Roulette.Configuration
{
    /// <summary>
    /// Handles all database interactions
    /// </summary>
    public class RouletteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Spin> Spins { get; set; }

        public RouletteDbContext(DbContextOptions<RouletteDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=Roulette.db");
            }
        }



    }
}
