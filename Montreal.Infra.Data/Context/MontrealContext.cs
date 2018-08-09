using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Montreal.Domain.Models;
using Montreal.Infra.Data.Mappings;
using System.IO;

namespace Montreal.Infra.Data.Context
{
    public class MontrealContext : DbContext
    {
        public MontrealContext()
        {

        }
        public MontrealContext(DbContextOptions<MontrealContext> options) :base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ImageMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }
    }
}
