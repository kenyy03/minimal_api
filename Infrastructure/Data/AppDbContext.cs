using Domain.Entities;
using Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public DbSet<Ability> Abilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AbilityMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
