using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<ExtraValues> ExtraValues { get; set; }
        public DbSet<Pic> Pics { get; set; }
        public DbSet<PossibleExtras> PossibleExtras { get; set; }
        public DbSet<Special> Specials { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureTables();
        }
    }
}
