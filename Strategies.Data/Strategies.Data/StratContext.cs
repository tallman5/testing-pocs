using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Strategies.Data
{
    public class StratContext : DbContext, IRocketRepo
    {
        public StratContext() { }

        public StratContext(DbContextOptions<StratContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Database
            var assembly = Assembly.GetExecutingAssembly();
            using var resourceStream = assembly.GetManifestResourceStream("Strategies.Data.Responses.get-all-rockets.json");
            using var reader = new StreamReader(resourceStream, Encoding.UTF8);
            string rocketJson = reader.ReadToEnd();
            var allRockets = JsonSerializer.Deserialize<List<Rocket>>(
                rocketJson, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            foreach(var rocket in allRockets)
                modelBuilder.Entity<Rocket>().HasData(rocket);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // In Memory
                optionsBuilder.UseInMemoryDatabase("strat-in-mem-db");

                // With SQL Server
                //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=strat-loc;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public virtual DbSet<Rocket> Rockets { get; set; }

        public async Task<List<Rocket>> GetRocketsAsync()
        {
            Database.EnsureCreated();

            var returnValue = await Rockets
                .AsNoTracking()
                .ToListAsync();
            return returnValue;
        }
    }
}
