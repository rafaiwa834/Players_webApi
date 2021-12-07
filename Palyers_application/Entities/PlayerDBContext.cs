using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilkarze.Entities
{
    public class PlayerDBContext: DbContext
    {
        private string _connectionString = @"Server=RafalPC\WINCCPLUSMIG2014;Database=FootbalerDB;Trusted_Connection=True;";
        
        public DbSet<Player> Players { get; set; }
        public DbSet<Club> Clubs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .Property(r=>r.Name)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Club>()
                .Property(r => r.Name)
                .HasMaxLength(50)
                .IsRequired();
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
