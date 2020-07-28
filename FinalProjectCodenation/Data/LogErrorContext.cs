using FinalProjectCodenation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.Data
{
    public class LogErrorContext : DbContext

    {

        public LogErrorContext(DbContextOptions<LogErrorContext> options) : base(options) { }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Default");
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(p => p.Sector)
            .WithMany(b => b.Users);

            modelBuilder.Entity<Log>()
            .HasOne(p => p.User)
            .WithMany(b => b.Logs);

        }

    }
}
